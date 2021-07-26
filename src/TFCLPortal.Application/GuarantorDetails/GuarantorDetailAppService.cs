using Abp.Application.Services.Dto;
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
using TFCLPortal.Applications.Dto;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.GuarantorDetails.Dto;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;

namespace TFCLPortal.GuarantorDetails
{
    public class GuarantorDetailAppService : TFCLPortalAppServiceBase, IGuarantorDetailAppService
    {
        #region Properties
        private readonly IRepository<GuarantorDetail, int> _guarantorDetailRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<CoApplicantDetail> _CoApplicantDetailAppService;
        private readonly IRepository<CreditBureauCheck> _creditBureauCheckRepository;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        #endregion
        #region Constructor 
        public GuarantorDetailAppService(IRepository<GuarantorDetail> guarantorDetailRepository,
               IRepository<Applicationz, Int32> applicationRepository,
            IApplicationAppService applicationAppService,
            IRepository<CreditBureauCheck> creditBureauCheckRepository,
            IApiCallLogAppService apiCallLogAppService,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            IRepository<CoApplicantDetail> coApplicantDetailAppService)
        {
            _guarantorDetailRepository = guarantorDetailRepository;
            _applicationRepository = applicationRepository;
            _CoApplicantDetailAppService = coApplicantDetailAppService;
            _applicationAppService = applicationAppService;
            _apiCallLogAppService = apiCallLogAppService;
            _creditBureauCheckRepository = creditBureauCheckRepository;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateGuarantorDetailInput createGuarantorDetailInput, int applicationId)
        {
            string response = "";
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateGuarantorDetail";
                callLog.Input = JsonConvert.SerializeObject(createGuarantorDetailInput);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                if(applicationId==0 && createGuarantorDetailInput.CreategurantorInput.Count>0)
                {
                    applicationId = createGuarantorDetailInput.CreategurantorInput[0].ApplicationId;
                }

                var IsExist = _guarantorDetailRepository.GetAllList().Where(x => x.ApplicationId == applicationId).ToList();
                if (IsExist.Count > 0)
                {
                    foreach (var guarantor in IsExist)
                    {
                        var gurantors = ObjectMapper.Map<GuarantorDetail>(guarantor);
                        await _guarantorDetailRepository.DeleteAsync(gurantors);
                        CurrentUnitOfWork.SaveChanges();
                    }
                    foreach (var gurantor in createGuarantorDetailInput.CreategurantorInput)
                    {
                        var CnicExistAsApplicant = _applicationRepository.GetAllList().Where(x => x.CNICNo.Trim() == gurantor.CNICNumber.Trim() && !x.ScreenStatus.Contains("Decline") && x.ScreenStatus != ApplicationState.Closed).FirstOrDefault();
                        var CnicExistAsGuarantor = _guarantorDetailRepository.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == gurantor.CNICNumber.Trim()).FirstOrDefault();
                        var CnicExistAsCoApplicant = _CoApplicantDetailAppService.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == gurantor.CNICNumber.Trim()).FirstOrDefault();

                        if (CnicExistAsApplicant != null)
                        {
                            gurantor.Comments = "Applicant having Application No : " + CnicExistAsApplicant.ClientID;
                            response += " Guarantor With CNIC '" + gurantor.CNICNumber + "' is present as Applicant having Application No : " + CnicExistAsApplicant.ClientID + " .";
                        }

                        if (CnicExistAsGuarantor != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsGuarantor.ApplicationId);
                            if (getAppNumber != null)
                            {
                                gurantor.Comments = "Guarantor For Application No : " + getAppNumber.ClientID;
                                response += " Guarantor With CNIC '" + gurantor.CNICNumber + "' is present as Guarantor For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        if (CnicExistAsCoApplicant != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsCoApplicant.ApplicationId);
                            if (getAppNumber != null)
                            {
                                gurantor.Comments = "Co-Applicant For Application No : " + getAppNumber.ClientID;
                                response += " Guarantor With CNIC '" + gurantor.CNICNumber + "' is present as Co-Applicant For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        //gurantor.ApplicationId = applicationId;
                        var gurantors = ObjectMapper.Map<GuarantorDetail>(gurantor);
                        await _guarantorDetailRepository.InsertAsync(gurantors);
                    }
                }
                else
                {
                    foreach (EditGuarantorDetailinput gurantor in createGuarantorDetailInput.CreategurantorInput)
                    {
                        var CnicExistAsApplicant = _applicationRepository.GetAllList().Where(x => x.CNICNo.Trim() == gurantor.CNICNumber.Trim() && !x.ScreenStatus.Contains("Decline") && x.ScreenStatus != ApplicationState.Closed).FirstOrDefault();
                        var CnicExistAsGuarantor = _guarantorDetailRepository.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == gurantor.CNICNumber.Trim()).FirstOrDefault();
                        var CnicExistAsCoApplicant = _CoApplicantDetailAppService.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == gurantor.CNICNumber.Trim()).FirstOrDefault();

                        if (CnicExistAsApplicant != null)
                        {
                            gurantor.Comments = "Applicant having Application No : " + CnicExistAsApplicant.ClientID;
                            response += " Guarantor With CNIC '" + gurantor.CNICNumber + "' is present as Applicant having Application No : " + CnicExistAsApplicant.ClientID + " .";
                        }

                        if (CnicExistAsGuarantor != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsGuarantor.ApplicationId);
                            if (getAppNumber != null)
                            {
                                gurantor.Comments = "Guarantor For Application No : " + getAppNumber.ClientID;
                                response += " Guarantor With CNIC '" + gurantor.CNICNumber + "' is present as Guarantor For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        if (CnicExistAsCoApplicant != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsCoApplicant.ApplicationId);
                            if (getAppNumber != null)
                            {
                                gurantor.Comments = "Co-Applicant For Application No : " + getAppNumber.ClientID;
                                response += " Guarantor With CNIC '" + gurantor.CNICNumber + "' is present as Co-Applicant For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        //gurantor.ApplicationId = applicationId;
                        var gurantors = ObjectMapper.Map<GuarantorDetail>(gurantor);
                        await _guarantorDetailRepository.InsertAsync(gurantors);

                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Guarantor Detail", applicationId);



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
                throw new UserFriendlyException(L("CreateMethodError{0}", "Guarantor Detail"));
            }
        }

        public async Task<List<GuarantorDetailListDto>> GetGuarantorDetailById(int Id)
        {
            try
            {

                var gurantor = await _guarantorDetailRepository.GetAllListAsync(x => x.Id == Id);

                return ObjectMapper.Map<List<GuarantorDetailListDto>>(gurantor);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Guarantor Detail"));
            }
        }

        public async Task<string> Update(UpdateGurantorDtoList editGuarantorDetailinput)
        {


            string ResponseString = "";
            //try
            //{

            //    foreach (EditGuarantorDetailinput gurantorDto in editGuarantorDetailinput.gurantorInput)
            //    {
            //        var gurantorobj = _guarantorDetailRepository.Get(gurantorDto.Id);
            //        if (gurantorobj != null && gurantorobj.Id > 0)
            //        {


            //            ObjectMapper.Map(gurantorDto, gurantorobj);

            //            await _guarantorDetailRepository.UpdateAsync(gurantorobj);

            //            CurrentUnitOfWork.SaveChanges();
            //            ResponseString = "Records Updated Successfully";
            //        }
            //        else
            //        {
            //            throw new UserFriendlyException(L("UpdateMethodError{0}", "Guarantor Detail"));

            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw new UserFriendlyException(L("UpdateMethodError{0}", "Guarantor Detail"));
            //}
            return ResponseString;

        }

        public async Task<List<GuarantorDetailListDto>> GetGuarantorDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var forSDE = _guarantorDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                var GuarantorDetailMapped = ObjectMapper.Map<List<GuarantorDetailListDto>>(forSDE);
                if (GuarantorDetailMapped.Count > 0)
                {
                    foreach (var guarantor in GuarantorDetailMapped)
                    {
                        if (guarantor.CreditBureauStatus != 0 && guarantor.CreditBureauStatus != null)
                        {
                            var result = _creditBureauCheckRepository.Get((int)guarantor.CreditBureauStatus);
                            guarantor.CreditBureauStatusName = result.Name;
                        }

                        if (guarantor.DateOfBirth != null)
                        {
                            DateTime SubmittedDate = _applicationAppService.getLastWorkFlowStateDate(ApplicationId, ApplicationState.Submitted);

                            if (SubmittedDate != new DateTime())
                            {
                                guarantor.CalculatedAge = getDuration(Convert.ToDateTime(guarantor.DateOfBirth), SubmittedDate);

                            }
                            else
                            {
                                guarantor.CalculatedAge = "--";
                            }
                        }

                        var deviation = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(ApplicationId);
                        if (deviation != null)
                        {
                            guarantor.AllowedMinAge = deviation.GuarantorMinAge;
                            guarantor.AllowedMaxAge = deviation.GuarantorMaxAge;
                        }

                    }
                }

                return GuarantorDetailMapped;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Guarantor Detail"));
            }
        }

        public bool CheckGuarantorDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var guarantorDetails = _guarantorDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                if (guarantorDetails.Count > 0)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "Guarantor Detail"));
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

        #endregion
    }
}
