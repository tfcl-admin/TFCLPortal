using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.HouseholdIncomeExpenseParents;
using TFCLPortal.HouseholdIncomesExpenses.Dto;

namespace TFCLPortal.HouseholdIncomesExpenses
{
    public class HouseholdIncomeAppService : TFCLPortalAppServiceBase, IHouseholdIncomeAppService
    {
        private readonly IRepository<HouseholdIncomeExpenseParent, Int32> _householdIncomeParentRepository;
        private readonly IRepository<HouseholdIncomeExpense, Int32> _householdIncomeRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private string householdIncomeDetails = "Household Income/Expenses";
        private readonly IApplicationAppService _applicationAppService;
        public HouseholdIncomeAppService(IApplicationAppService applicationAppService,IRepository<HouseholdIncomeExpenseParent, Int32> householdIncomeParentRepository, IRepository<HouseholdIncomeExpense, Int32> householdIncomeRepository, IApiCallLogAppService apiCallLogAppService)
        {
            _householdIncomeParentRepository = householdIncomeParentRepository;
            _householdIncomeRepository = householdIncomeRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
        }
        public string CreateHouseholdIncome(CreateHouseholdIncomeParentDto input)
        {

            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateHouseholdIncome";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var isExisthouseholdIncome = _householdIncomeParentRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (isExisthouseholdIncome != null)
                {
                    var householdIncomeParent = ObjectMapper.Map<HouseholdIncomeExpenseParent>(isExisthouseholdIncome);

                    var HouseHoldIncomes = _householdIncomeRepository.GetAllList().Where(x => x.fk_HouseHoldParentID == householdIncomeParent.Id);

                    foreach (var HouseHoldIncome in HouseHoldIncomes)
                    {
                        _householdIncomeRepository.Delete(HouseHoldIncome);
                    }
                    _householdIncomeParentRepository.Delete(isExisthouseholdIncome);
                }

                var householdIncomeDetail = ObjectMapper.Map<HouseholdIncomeExpenseParent>(input);

                var householdIncomeParentResult = _householdIncomeParentRepository.InsertAndGetId(householdIncomeDetail);

                foreach (var HouseHoldIncome in input.CreateHouseholdIncomes)
                {
                    var householdIncome = ObjectMapper.Map<HouseholdIncomeExpense>(HouseHoldIncome);
                    householdIncome.fk_HouseHoldParentID = householdIncomeParentResult;
                    _householdIncomeRepository.Insert(householdIncome);

                }

                _applicationAppService.UpdateApplicationLastScreen("Household Expenses", input.ApplicationId);



                return "Success";

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", householdIncomeDetails));
            }
        }

        public async Task<HouseholdIncomeParentListDto> GetHouseholdIncomeById(int Id)
        {
            try
            {
                var householdIncomeDetail = await _householdIncomeParentRepository.GetAsync(Id);

                return ObjectMapper.Map<HouseholdIncomeParentListDto>(householdIncomeDetail);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", householdIncomeDetails));
            }
        }

        public async Task<string> UpdateHouseholdIncome(UpdateHouseholdIncomeParentDto input)
        {
            string ResponseString = "";
            try
            {
                var householdIncome = _householdIncomeParentRepository.Get(input.Id);
                if (householdIncome != null && householdIncome.Id > 0)
                {
                    ObjectMapper.Map(input, householdIncome);
                    await _householdIncomeParentRepository.UpdateAsync(householdIncome);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", householdIncomeDetails));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", householdIncomeDetails));
            }
        }

        public HouseholdIncomeParentListDto GetHouseholdIncomeByApplicationId(int ApplicationId)
        {
            try
            {
                var householdIncomeParentDetail = _householdIncomeParentRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                if (householdIncomeParentDetail != null)
                {
                    var householdIncomeParent = ObjectMapper.Map<HouseholdIncomeParentListDto>(householdIncomeParentDetail);

                    var HouseHoldIncomes = _householdIncomeRepository.GetAllList(x => x.fk_HouseHoldParentID == householdIncomeParent.Id);
                    if (HouseHoldIncomes != null)
                    {
                        var HouseHoldIncomesResult = ObjectMapper.Map<List<HouseholdIncomeListDto>>(HouseHoldIncomes);

                        householdIncomeParent.CreateHouseholdIncomes = HouseHoldIncomesResult;
                    }
                    return householdIncomeParent;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", householdIncomeDetails));
            }
        }
        public bool CheckHouseholdIncomeByApplicationId(int ApplicationId)
        {
            try
            {
                var householdIncomeParentDetail = _householdIncomeParentRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                if (householdIncomeParentDetail != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", householdIncomeDetails));
            }
        }
    }
}
