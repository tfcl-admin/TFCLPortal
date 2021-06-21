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
using TFCLPortal.BusinessDetailsTDS.Dto;
using TFCLPortal.DynamicDropdowns.LegalStatuses;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;

namespace TFCLPortal.BusinessDetailsTDS
{
    public class BusinessDetailsTDSAppService : TFCLPortalAppServiceBase, IBusinessDetailsTDSAppService
    {
        private readonly IRepository<BusinessDetailTDS, Int32> _businessDetailRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<OwnershipStatus> _ownershipStatusRepository;
        private readonly IRentAgreementSignatoryAppService _rentAgreementSignatoryAppService;
        private readonly ILegalStatusAppService _legalStatusAppService;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        

        public BusinessDetailsTDSAppService(ILegalStatusAppService legalStatusAppService, IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,IRepository<OwnershipStatus> ownershipStatusRepository, IRentAgreementSignatoryAppService rentAgreementSignatoryAppService,IRepository<BusinessDetailTDS, Int32> businessDetailRepository, IApiCallLogAppService apiCallLogAppService)
        {
            _businessDetailRepository = businessDetailRepository;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
            _legalStatusAppService = legalStatusAppService;
            _rentAgreementSignatoryAppService = rentAgreementSignatoryAppService;
            _ownershipStatusRepository = ownershipStatusRepository;
            _apiCallLogAppService = apiCallLogAppService;
        }

        public bool CheckBusinessDetailTDSByApplicationId(int ApplicationId)
        {
            try
            {
                var getbusinessdetail = _businessDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (getbusinessdetail != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "business Details TDS"));
            }
        }

        public async Task CreateBusinessDetailTDS(CreateParentBusinessDetailTDSDto input)
        {
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateBusinessDetailTDS";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                if (input.businessDetailTds!=null)
                {
                    foreach (var item in input.businessDetailTds)
                    {
                        var businessDetailTds = _businessDetailRepository.GetAllList(x => x.ApplicationId == item.ApplicationId);
                        if(businessDetailTds!=null)
                        {
                            foreach(var bd in businessDetailTds)
                            {
                               await _businessDetailRepository.DeleteAsync(bd);
                            }
                        }
                    }

                    foreach (var item in input.businessDetailTds)
                    {
                        var businessDetail = ObjectMapper.Map<BusinessDetailTDS>(item);
                        var result = await _businessDetailRepository.InsertAsync(businessDetail);
                        CurrentUnitOfWork.SaveChanges();
                    }
                }

              
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "business Details TDS"));
            }

        }

        public async Task<ParentBusinessDetailTDSListDto> GetBusinessDetailTDSByApplicationId(int ApplicationId)
        {
            try
            {
                var getbusinessdetail = await _businessDetailRepository.GetAllListAsync(x => x.ApplicationId == ApplicationId);
               
                var businessDetailTds= ObjectMapper.Map<List<BusinessDetailTDSListDto>>(getbusinessdetail.ToList());

                ParentBusinessDetailTDSListDto returnObj = new ParentBusinessDetailTDSListDto();
                if (businessDetailTds != null && businessDetailTds.Count > 0)
                {
                    foreach (var branch in businessDetailTds)
                    {
                        returnObj.ApplicationId = branch.ApplicationId;
                        if ( branch.BusinessPlaceOwnership != 0)
                        {
                            var SchoolPlaceOwnership = _ownershipStatusRepository.GetAllList().Where(x => x.Id == branch.BusinessPlaceOwnership).FirstOrDefault();
                            branch.OwnershipStatusName = SchoolPlaceOwnership.Name;
                        }
                        if (branch.RentAgreementSignatory != null && branch.RentAgreementSignatory != 0)
                        {
                            var RentAgreementSignatory = _rentAgreementSignatoryAppService.GetAllList().Where(x => x.Id == branch.RentAgreementSignatory).FirstOrDefault();
                            branch.RentAgreementSignatoryName = RentAgreementSignatory.Name;
                        }
                        if (branch.LegalStatus != 0)
                        {
                            var LegalStatus = _legalStatusAppService.GetAllList().Where(x => x.Id == branch.LegalStatus).FirstOrDefault();
                            branch.LegalStatusName = LegalStatus.Name;
                        }


                        //DateTime SubmittedDate = _applicationAppService.getLastWorkFlowStateDate(ApplicationId, ApplicationState.Submitted);

                        //if (SubmittedDate != new DateTime())
                        //{
                        if (branch.EstablishedSince != null)
                        {
                            branch.CalculatedBusinessAge = getDuration(Convert.ToDateTime(branch.EstablishedSince), DateTime.Now);
                        }
                        if (branch.CurrentAddressSince != null)
                        {
                            branch.CalculatedTimeAtCurrentAddress = getDuration(Convert.ToDateTime(branch.CurrentAddressSince), DateTime.Now);
                        }
                        //}
                        //else
                        //{
                        //    branch.CalculatedBusinessAge = "--";
                        //    branch.CalculatedTimeAtCurrentAddress = "--";
                        //}

                        var deviation = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(ApplicationId);
                        if (deviation != null)
                        {
                            branch.AllowedMinBusinessAge = deviation.BusinessAgeYears;
                            branch.AllowedMinTimeAtCurrentAddress = deviation.BusinessAgeAtCurrentPlaceYears;
                        }

                    }
                }



                returnObj.businessDetailTds= businessDetailTds;
                return returnObj;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "business Details TDS"));
            }
        }
        public string getDuration(DateTime dStart, DateTime dEnd)
        {
            DateTime startDate = dStart;
            DateTime endDate = dEnd;
            int days = 0;
            int months = 0;
            int years = 0;
            //calculate days
            if (endDate.Day >= startDate.Day)
            {
                days = endDate.Day - startDate.Day;
            }
            else
            {
                var tempDate = endDate.AddMonths(-1);
                int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
                days = daysInMonth - (startDate.Day - endDate.Day);
                months--;
            }
            //calculate months
            if (endDate.Month >= startDate.Month)
            {
                months += endDate.Month - startDate.Month;
            }
            else
            {
                months += 12 - (startDate.Month - endDate.Month);
                years--;
            }
            //calculate years
            years += endDate.Year - startDate.Year;


            return string.Format("{0} years, {1} months, {2} days", years, months, days);
        }
        public async Task<BusinessDetailTDSListDto> GetBusinessDetailTDSById(int Id)
        {
            try
            {
                var businessDetail = await _businessDetailRepository.GetAsync(Id);
                var result = ObjectMapper.Map<BusinessDetailTDSListDto>(businessDetail);
                return result;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "business Details TDS"));
            }
        }

        public async Task<string> UpdateBusinessDetailTDS(UpdateBusinessDetailTDSDto input)
        {
            string ResponseString = "Records Updated Successfully";
            try
            {
                var businessDetails = _businessDetailRepository.Get(input.Id);
                if (businessDetails != null && businessDetails.Id > 0)
                {
                    ObjectMapper.Map(input, businessDetails);

                    await _businessDetailRepository.UpdateAsync(businessDetails);
                    CurrentUnitOfWork.SaveChanges();
                }
                return ResponseString;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "business Details TDS"));
            }
        }
    }
}
