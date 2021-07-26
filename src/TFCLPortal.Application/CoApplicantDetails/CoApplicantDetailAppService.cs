using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.CoApplicantDetails.Dto;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.CoApplicantDetails
{
    public class CoApplicantDetailAppService : TFCLPortalAppServiceBase, ICoApplicantDetailAppService
    {
        #region Properties
        private readonly IRepository<CoApplicantDetail> _coApplicantDetailRepository;
        public string coApplicants = "CoApplicant Detail";
        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<GuarantorDetail> _guarantorDetailAppService;
        private readonly IRepository<CreditBureauCheck> _creditBureauCheckRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        #endregion
        #region Constructor 
        public CoApplicantDetailAppService(IRepository<CoApplicantDetail> coApplicantDetailRepository,
            IRepository<Applicationz, Int32> applicationRepository,
            IApplicationAppService applicationAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<CreditBureauCheck> creditBureauCheckRepository,
            IRepository<GuarantorDetail> guarantorDetailAppService)
        {
            _coApplicantDetailRepository = coApplicantDetailRepository;
            _applicationRepository = applicationRepository;
            _guarantorDetailAppService = guarantorDetailAppService;
            _applicationAppService = applicationAppService;
            _apiCallLogAppService = apiCallLogAppService;
            _creditBureauCheckRepository = creditBureauCheckRepository;
        }
        #endregion
        #region Method
        public async Task<string> Create(CreateCoApplicantDetailInput createCoApplicantDetailInpt, int applicationId)
        {
            string response = "";
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateCoApplicantDetail";
                callLog.Input = JsonConvert.SerializeObject(createCoApplicantDetailInpt);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                if (applicationId == 0)
                {
                    applicationId = createCoApplicantDetailInpt.Id;
                }

                if (applicationId == 0 && createCoApplicantDetailInpt.createCoApplicantDetailInput.Count > 0)
                {
                    applicationId = createCoApplicantDetailInpt.createCoApplicantDetailInput[0].ApplicationId;
                }


                var IsExist = _coApplicantDetailRepository.GetAllList().Where(x => x.ApplicationId == applicationId).ToList();
                if (IsExist.Count > 0)
                {
                    foreach (var coApplicnt in IsExist)
                    {
                        var coapplicant = ObjectMapper.Map<CoApplicantDetail>(coApplicnt);
                        _coApplicantDetailRepository.Delete(coapplicant);
                        CurrentUnitOfWork.SaveChanges();
                    }
                    foreach (CoApplicantAddDto coapplicant in createCoApplicantDetailInpt.createCoApplicantDetailInput)
                    {
                        var CnicExistAsApplicant = _applicationRepository.GetAllList().Where(x => x.CNICNo.Trim() == coapplicant.CNICNumber.Trim() && !x.ScreenStatus.Contains("Decline") && x.ScreenStatus != ApplicationState.Closed).FirstOrDefault();
                        var CnicExistAsGuarantor = _guarantorDetailAppService.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == coapplicant.CNICNumber.Trim()).FirstOrDefault();
                        var CnicExistAsCoApplicant = _coApplicantDetailRepository.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == coapplicant.CNICNumber.Trim()).FirstOrDefault();

                        if (CnicExistAsApplicant != null)
                        {
                            coapplicant.Comments = "Applicant having Application No : " + CnicExistAsApplicant.ClientID;
                            response += " Co-Applicant With CNIC '" + coapplicant.CNICNumber + "' is present as Applicant having Application No : " + CnicExistAsApplicant.ClientID + " .";
                        }

                        if (CnicExistAsGuarantor != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsGuarantor.ApplicationId);
                            if (getAppNumber != null)
                            {
                                coapplicant.Comments = "Guarantor For Application No : " + getAppNumber.ClientID;
                                response += " Co-Applicant With CNIC '" + coapplicant.CNICNumber + "' is present as Guarantor For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        if (CnicExistAsCoApplicant != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsCoApplicant.ApplicationId);
                            if (getAppNumber != null)
                            {
                                coapplicant.Comments = "Co-Applicant For Application No : " + getAppNumber.ClientID;
                                response += " Co-Applicant With CNIC '" + coapplicant.CNICNumber + "' is present as Co-Applicant For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        //coapplicant.ApplicationId = coapplicant.ApplicationId;
                        var coApplicantDetail = ObjectMapper.Map<CoApplicantDetail>(coapplicant);
                        _coApplicantDetailRepository.Insert(coApplicantDetail);

                    }

                }
                else
                {

                    foreach (CoApplicantAddDto coapplicant in createCoApplicantDetailInpt.createCoApplicantDetailInput)
                    {
                        var CnicExistAsApplicant = _applicationRepository.GetAllList().Where(x => x.CNICNo.Trim() == coapplicant.CNICNumber.Trim() && !x.ScreenStatus.Contains("Decline") && x.ScreenStatus != ApplicationState.Closed).FirstOrDefault();
                        var CnicExistAsGuarantor = _guarantorDetailAppService.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == coapplicant.CNICNumber.Trim()).FirstOrDefault();
                        var CnicExistAsCoApplicant = _coApplicantDetailRepository.GetAllList().Where(x => x.CNICNumber != null && x.CNICNumber.Trim() == coapplicant.CNICNumber.Trim()).FirstOrDefault();

                        if (CnicExistAsApplicant != null)
                        {
                            coapplicant.Comments = "Applicant having Application No : " + CnicExistAsApplicant.ClientID + ". ";
                            response += " Co-Applicant With CNIC '" + coapplicant.CNICNumber + "' is present as Applicant having Application No : " + CnicExistAsApplicant.ClientID + " .";
                        }

                        if (CnicExistAsGuarantor != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsGuarantor.ApplicationId);
                            if (getAppNumber != null)
                            {
                                coapplicant.Comments = "Guarantor For Application No : " + getAppNumber.ClientID + ". ";
                                response += " Co-Applicant With CNIC '" + coapplicant.CNICNumber + "' is present as Guarantor For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        if (CnicExistAsCoApplicant != null)
                        {
                            var getAppNumber = _applicationAppService.GetApplicationById(CnicExistAsCoApplicant.ApplicationId);
                            if (getAppNumber != null)
                            {
                                coapplicant.Comments = "Co-Applicant For Application No : " + getAppNumber.ClientID + ". ";
                                response += " Co-Applicant With CNIC '" + coapplicant.CNICNumber + "' is present as Co-Applicant For Application No : " + getAppNumber.ClientID + " .";
                            }
                        }

                        coapplicant.ApplicationId = applicationId;
                        var coApplicantDetail = ObjectMapper.Map<CoApplicantDetail>(coapplicant);
                        _coApplicantDetailRepository.Insert(coApplicantDetail);
                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("CoApplicant Detail", applicationId);


                if (response != "")
                {
                    return response;
                }
                else
                {
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", coApplicants));
            }
        }

        public async Task<List<CoApplicantDetailListDto>> GetCoApplicantDetailById(int Id)
        {
            try
            {
                var coApplicantDetail = await _coApplicantDetailRepository.GetAllListAsync(x => x.Id == Id);


                return ObjectMapper.Map<List<CoApplicantDetailListDto>>(coApplicantDetail);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", coApplicants));
            }
        }

        public async Task<string> Update(EditCoApplicantDetailInput input)
        {
            string ResponseString = "";
            try
            {
                foreach (UpdateCoApplicantDto coapplicant in input.updatecoapplicant)
                {
                    var coApplicantDetail = _coApplicantDetailRepository.Get(coapplicant.Id);
                    if (coApplicantDetail != null && coApplicantDetail.Id > 0)
                    {
                        ObjectMapper.Map(coapplicant, coApplicantDetail);
                        await _coApplicantDetailRepository.UpdateAsync(coApplicantDetail);
                        CurrentUnitOfWork.SaveChanges();

                    }
                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", coApplicants));
            }
            return ResponseString;
        }

        public async Task<List<CoApplicantDetailListDto>> GetCoApplicantDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var coApplicantDetail = _coApplicantDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                var coApplicantDetailMapped = ObjectMapper.Map<List<CoApplicantDetailListDto>>(coApplicantDetail);
                if (coApplicantDetailMapped.Count > 0)
                {
                    foreach (var coApplicant in coApplicantDetailMapped)
                    {
                        if (coApplicant.CreditBureauStatus != 0 && coApplicant.CreditBureauStatus != null)
                        {
                            var result = _creditBureauCheckRepository.Get((int)coApplicant.CreditBureauStatus);
                            coApplicant.CreditBureauStatusName = result.Name;
                        }
                    }
                }


                return coApplicantDetailMapped;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", coApplicants));
            }
        }

        public bool CheckCoApplicantDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var coApplicantDetail = _coApplicantDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                if (coApplicantDetail.Count > 0)
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
                throw new UserFriendlyException(L("GetMethodError{0}", coApplicants));
            }
        }

        #endregion
    }
}
