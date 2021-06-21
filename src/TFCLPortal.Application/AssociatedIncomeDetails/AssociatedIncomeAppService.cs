using Abp.Domain.Repositories;
using Abp.UI;
using Abp.UI.Inputs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.AssociatedIncomeChilds;
using TFCLPortal.AssociatedIncomeDetails.Dto;
using TFCLPortal.AssociatedIncomeGrandChilds;
using TFCLPortal.AssociatedIncomes;
using TFCLPortal.DynamicDropdowns.OtherAssociatedIncomes;

namespace TFCLPortal.AssociatedIncomeDetails
{
    public class AssociatedIncomeAppService : TFCLPortalAppServiceBase, IAssociatedIncomeAppService
    {
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<AssociatedIncome> _associatedIncomeRepository;
        private readonly IRepository<AssociatedIncomeChild> _associatedIncomeChildRepository;
        private readonly IRepository<AssociatedIncomeGrandChild> _associatedIncomeGrandChildRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<OtherAssociatedIncome> _otherAssociatedIncomeRepository;
        public AssociatedIncomeAppService(IApplicationAppService applicationAppService,IRepository<AssociatedIncome> associatedIncomeRepository, IRepository<OtherAssociatedIncome> otherAssociatedIncomeRepository, IApiCallLogAppService apiCallLogAppService, IRepository<AssociatedIncomeGrandChild> associatedIncomeGrandChildRepository, IRepository<AssociatedIncomeChild> associatedIncomeChildRepository)
        {
            _associatedIncomeRepository = associatedIncomeRepository;
            _associatedIncomeChildRepository = associatedIncomeChildRepository;
            _associatedIncomeGrandChildRepository = associatedIncomeGrandChildRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _otherAssociatedIncomeRepository = otherAssociatedIncomeRepository;
            _applicationAppService = applicationAppService;
        }

        public async Task<string> CreateAssociatedIncomeDetails(CreateAssociatedIncomeDto input)
        {
            string response = "";
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateAssociatedIncomeDetails";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _associatedIncomeRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).SingleOrDefault();
                if (IsExist != null)
                {
                    var associatedIncome = ObjectMapper.Map<AssociatedIncome>(IsExist);
                    var IsExistAssociatedIncomeChild = _associatedIncomeChildRepository.GetAllList(x => x.Fk_AssociatedIncome == associatedIncome.Id);


                    if (IsExistAssociatedIncomeChild != null)
                    {
                        var associatedIncomeChilds = ObjectMapper.Map<List<AssociatedIncomeChild>>(IsExistAssociatedIncomeChild);
                        foreach (var associatedIncomeChild in associatedIncomeChilds)
                        {
                            var IsExistAssociatedIncomeGrandChild = _associatedIncomeGrandChildRepository.GetAllList(x => x.Fk_AssociatedIncomeChild == associatedIncomeChild.Id);
                            if (IsExistAssociatedIncomeGrandChild != null)
                            {
                                var associatedIncomeGrandChilds = ObjectMapper.Map<List<AssociatedIncomeGrandChild>>(IsExistAssociatedIncomeGrandChild);
                                foreach (var associatedIncomeGrandChild in associatedIncomeGrandChilds)
                                {

                                    await _associatedIncomeGrandChildRepository.DeleteAsync(associatedIncomeGrandChild);
                                    CurrentUnitOfWork.SaveChanges();
                                }

                            }
                            await _associatedIncomeChildRepository.DeleteAsync(associatedIncomeChild);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                    await _associatedIncomeRepository.DeleteAsync(associatedIncome);
                    CurrentUnitOfWork.SaveChanges();


                    var associatedIncomeInput = ObjectMapper.Map<AssociatedIncome>(input);

                    var result = await _associatedIncomeRepository.InsertAsync(associatedIncomeInput);
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var AssociatedIncomeChild in input.AssociatedIncomeChilds)
                    {

                        AssociatedIncomeChild.Fk_AssociatedIncome = result.Id;
                        var AssociatedIncomeChildDetail = ObjectMapper.Map<AssociatedIncomeChild>(AssociatedIncomeChild);

                        var resultChild = await _associatedIncomeChildRepository.InsertAsync(AssociatedIncomeChildDetail);
                        CurrentUnitOfWork.SaveChanges();

                        foreach (var associatedIncomeGrandChild in AssociatedIncomeChild.associatedIncomeGrandChilds)
                        {
                            associatedIncomeGrandChild.Fk_AssociatedIncomeChild = resultChild.Id;
                            var AssociatedIncomeGrandChildDetail = ObjectMapper.Map<AssociatedIncomeGrandChild>(associatedIncomeGrandChild);
                            await _associatedIncomeGrandChildRepository.InsertAsync(AssociatedIncomeGrandChildDetail);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                }
                else
                {

                    var associatedIncomeInput = ObjectMapper.Map<AssociatedIncome>(input);

                    var result = await _associatedIncomeRepository.InsertAsync(associatedIncomeInput);
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var AssociatedIncomeChild in input.AssociatedIncomeChilds)
                    {

                        AssociatedIncomeChild.Fk_AssociatedIncome = result.Id;
                        var AssociatedIncomeChildDetail = ObjectMapper.Map<AssociatedIncomeChild>(AssociatedIncomeChild);
                        var resultChild = await _associatedIncomeChildRepository.InsertAsync(AssociatedIncomeChildDetail);
                        CurrentUnitOfWork.SaveChanges();

                        foreach (var associatedIncomeGrandChild in AssociatedIncomeChild.associatedIncomeGrandChilds)
                        {
                            associatedIncomeGrandChild.Fk_AssociatedIncomeChild = resultChild.Id;
                            var AssociatedIncomeGrandChildDetail = ObjectMapper.Map<AssociatedIncomeGrandChild>(associatedIncomeGrandChild);
                            await _associatedIncomeGrandChildRepository.InsertAsync(AssociatedIncomeGrandChildDetail);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Associated Income", input.ApplicationId);


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
                throw new UserFriendlyException(L("CreateMethodError{0}", "Associated Income Details"));
            }
        }

        public AssociatedIncomeListDto GetAssociatedIncomeDetailByApplicationId(int Id)
        {
            try
            {
                var IsExist = _associatedIncomeRepository.FirstOrDefault(x => x.ApplicationId == Id);
                if (IsExist != null)
                {
                    var associatedIncome = ObjectMapper.Map<AssociatedIncomeListDto>(IsExist);

                    var IsExistAssociatedIncomeChild = _associatedIncomeChildRepository.GetAllList(x => x.Fk_AssociatedIncome == associatedIncome.Id).ToList();
                    if (IsExistAssociatedIncomeChild.Count > 0)
                    {
                        var associatedIncomeChilds = ObjectMapper.Map<List<AssociatedIncomeChildListDto>>(IsExistAssociatedIncomeChild);

                        foreach (var associatedIncomeChild in associatedIncomeChilds)
                        {
                            var IsExistAssociatedIncomeGrandChild = _associatedIncomeGrandChildRepository.GetAllList(x => x.Fk_AssociatedIncomeChild == associatedIncomeChild.Id).ToList();
                            if (IsExistAssociatedIncomeGrandChild.Count > 0)
                            {
                                var associatedIncomeGrandChilds = ObjectMapper.Map<List<AssociatedIncomeGrandChildListDto>>(IsExistAssociatedIncomeGrandChild);

                                foreach (var associatedIncomeGrandChild in associatedIncomeGrandChilds)
                                {
                                    if(associatedIncomeGrandChild.OtherAssociatedIncome!=null && associatedIncomeGrandChild.OtherAssociatedIncome != 0)
                                    {
                                        var income = _otherAssociatedIncomeRepository.Get((int)associatedIncomeGrandChild.OtherAssociatedIncome);
                                        associatedIncomeGrandChild.OtherAssociatedIncomeName = income.Name;
                                    }
                                }
                                associatedIncomeChild.associatedIncomeGrandChilds = associatedIncomeGrandChilds;
                            }

                        }

                        associatedIncome.AssociatedIncomeChilds = associatedIncomeChilds;
                    }

                    return associatedIncome;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Associated Income Details"));
            }
        }
        public bool CheckAssociatedIncomeDetailByApplicationId(int Id)
        {
            try
            {
                var IsExist = _associatedIncomeRepository.GetAllList(x => x.ApplicationId == Id).SingleOrDefault();
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
                throw new UserFriendlyException(L("GetMethodError{0}", "Associated Income Details"));
            }
        }
    }
}
