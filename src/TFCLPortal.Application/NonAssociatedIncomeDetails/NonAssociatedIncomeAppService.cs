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
using TFCLPortal.DynamicDropdowns.NaSourceOfIncomes;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.NonAssociatedIncomeChilds;
using TFCLPortal.NonAssociatedIncomeDetails.Dto;
using TFCLPortal.NonAssociatedIncomes;

namespace TFCLPortal.NonAssociatedIncomeDetails
{
    public class NonAssociatedIncomeAppService : TFCLPortalAppServiceBase, INonAssociatedIncomeAppService
    {
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<NonAssociatedIncome> _nonAssociatedIncomeRepository;
        private readonly IRepository<NonAssociatedIncomeChild> _nonAssociatedIncomeChildRepository;
        private readonly IRepository<Occupation> _occupationRepository;
        private readonly IRepository<NaSourceOfIncome> _NaSourceOfIncomeRepository;

        public NonAssociatedIncomeAppService(IRepository<NonAssociatedIncome> nonAsociatedIncomeRepository, 
            IApiCallLogAppService apiCallLogAppService,
            IRepository<Occupation> occupationRepository,
            IRepository<NaSourceOfIncome> NaSourceOfIncomeRepository,
            IApplicationAppService applicationAppService,
            IRepository<NonAssociatedIncomeChild> nonAssociatedIncomeChildRepository)
        {
            _nonAssociatedIncomeRepository = nonAsociatedIncomeRepository;
            _nonAssociatedIncomeChildRepository = nonAssociatedIncomeChildRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _occupationRepository = occupationRepository;
            _applicationAppService = applicationAppService;
            _NaSourceOfIncomeRepository = NaSourceOfIncomeRepository;
        }

        public async Task<string> CreateNonAssociatedIncomeDetails(CreateNonAssociatedIncomeDto input)
        {
            string response = "";
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateNonAssociatedIncomeDetails";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _nonAssociatedIncomeRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (IsExist != null)
                {
                    var nonAssociatedIncome = ObjectMapper.Map<NonAssociatedIncome>(IsExist);
                    var IsExistNonAssociatedIncomeChild = _nonAssociatedIncomeChildRepository.GetAllList().Where(x => x.Fk_NonAssociatedIncome == nonAssociatedIncome.Id).ToList();
                   

                    if (IsExistNonAssociatedIncomeChild.Count > 0)
                    {
                        var nonAssociatedIncomeChilds = ObjectMapper.Map<List<NonAssociatedIncomeChild>>(IsExistNonAssociatedIncomeChild);
                        foreach (var nonAssociatedIncomeChild in nonAssociatedIncomeChilds)
                        {
                            await _nonAssociatedIncomeChildRepository.DeleteAsync(nonAssociatedIncomeChild);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                    await _nonAssociatedIncomeRepository.DeleteAsync(nonAssociatedIncome);
                    CurrentUnitOfWork.SaveChanges();


                    var associatedIncomeInput = ObjectMapper.Map<NonAssociatedIncome>(input);
                    var result = await _nonAssociatedIncomeRepository.InsertAsync(associatedIncomeInput);
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var nonAssociatedIncomeChild in input.NonAssociatedIncomeChilds)
                    {

                        nonAssociatedIncomeChild.Fk_NonAssociatedIncome = result.Id;
                        var nonAssociatedIncomeChildDetail = ObjectMapper.Map<NonAssociatedIncomeChild>(nonAssociatedIncomeChild);
                        await _nonAssociatedIncomeChildRepository.InsertAsync(nonAssociatedIncomeChildDetail);

                    }

                }
                else
                {

                    var associatedIncomeInput = ObjectMapper.Map<NonAssociatedIncome>(input);
                    var result = await _nonAssociatedIncomeRepository.InsertAsync(associatedIncomeInput);
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var NonAssociatedIncomeChild in input.NonAssociatedIncomeChilds)
                    {

                        NonAssociatedIncomeChild.Fk_NonAssociatedIncome = result.Id;
                        var NonAssociatedIncomeChildDetail = ObjectMapper.Map<NonAssociatedIncomeChild>(NonAssociatedIncomeChild);
                        await _nonAssociatedIncomeChildRepository.InsertAsync(NonAssociatedIncomeChildDetail);

                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Non-Associated Income", input.ApplicationId);


                if (response != "")
                {
                    return response;
                }
                else
                {
                    return "Success";
                }
            }
            catch (Exception)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Non Associated Income Details"));
            }
        }

        public NonAssociatedIncomeListDto GetNonAssociatedIncomeDetailByApplicationId(int Id)
        {
            try
            {
                var IsExist = _nonAssociatedIncomeRepository.GetAllList(x => x.ApplicationId == Id).SingleOrDefault();
                if (IsExist!=null)
                {
                    var nonAssociatedIncome = ObjectMapper.Map<NonAssociatedIncomeListDto>(IsExist);

                    var IsExistNonAssociatedIncomeChild = _nonAssociatedIncomeChildRepository.GetAllList(x => x.Fk_NonAssociatedIncome == nonAssociatedIncome.Id).ToList();
                    if (IsExistNonAssociatedIncomeChild.Count > 0)
                    {
                        var nonAssociatedIncomeChilds = ObjectMapper.Map<List<NonAssociatedIncomeChildListDto>>(IsExistNonAssociatedIncomeChild);
                       
                        foreach(var nonAssociatedIncomeChild in nonAssociatedIncomeChilds)
                        {
                            if (nonAssociatedIncomeChild.OtherOccupation != null && nonAssociatedIncomeChild.OtherOccupation != 0)
                            {
                                var OtherOccupation = _occupationRepository.Get((int) nonAssociatedIncomeChild.OtherOccupation);
                                nonAssociatedIncomeChild.OtherOccupationName = OtherOccupation.Name;
                            }
                            if (nonAssociatedIncomeChild.SourceOfIncome != null && nonAssociatedIncomeChild.SourceOfIncome != 0)
                            {
                                var SourceOfIncome = _NaSourceOfIncomeRepository.Get((int)nonAssociatedIncomeChild.SourceOfIncome);
                                nonAssociatedIncomeChild.SourceOfIncomeName = SourceOfIncome.Name;
                            }
                        }

                        
                        nonAssociatedIncome.NonAssociatedIncomeChilds = nonAssociatedIncomeChilds;
                    }

                    return nonAssociatedIncome;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Non Associated Income Details"));
            }
        }
        public bool CheckNonAssociatedIncomeDetailByApplicationId(int Id)
        {
            try
            {
                var IsExist = _nonAssociatedIncomeRepository.FirstOrDefault(x => x.ApplicationId == Id);
                if (IsExist != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "Non Associated Income Details"));
            }
        }
    }
}
