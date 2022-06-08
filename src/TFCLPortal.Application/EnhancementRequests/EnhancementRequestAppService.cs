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
using TFCLPortal.EnhancementRequests.Dto;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.EnhancementRequests
{
    public class EnhancementRequestAppService : TFCLPortalAppServiceBase, IEnhancementRequestAppService
    {
        private readonly IRepository<EnhancementRequest, Int32> _EnhancementRequestRepository;
        private readonly IRepository<PaymentFrequency> _paymentFrequencyRepository;
        private readonly IRepository<LoanPurpose> _loanPurposeRepository;
        private readonly IRepository<CreditBureauCheck> _CreditBureauCheckRepository;
        private readonly IRepository<ClientStatus> _clientStatusRepository;
        private readonly IRepository<LoanTenureRequired> _loanTenurerepository;
        private readonly IRepository<LoanPurposeClassification> _LoanPurposeClassificationRepository;
        private readonly IRepository<Applicationz> _applicationsRepository;
        private readonly IRepository<ReasonOfDecline> _reasonOfDeclineRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private string EnhancementRequest = "Business Plan";
        public EnhancementRequestAppService(IRepository<EnhancementRequest, Int32> EnhancementRequestRepository,
            IRepository<PaymentFrequency> paymentFrequencyRepository,
            IRepository<LoanPurpose> loanPurposeRepository,
            IRepository<LoanTenureRequired> loanTenurerepository,
            IRepository<ClientStatus> clientStatusRepository,
            IRepository<CreditBureauCheck> creditBureauCheckRepository,
            IRepository<Applicationz> applicationsRepository,
            IRepository<ReasonOfDecline> reasonOfDeclineRepository,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<LoanPurposeClassification> LoanPurposeClassificationRepository,
            IApplicationAppService applicationAppService)
        {
            _EnhancementRequestRepository = EnhancementRequestRepository;
            _paymentFrequencyRepository = paymentFrequencyRepository;
            _loanPurposeRepository = loanPurposeRepository;
            _loanTenurerepository = loanTenurerepository;
            _applicationAppService = applicationAppService;
            _clientStatusRepository = clientStatusRepository;
            _reasonOfDeclineRepository = reasonOfDeclineRepository;
            _applicationsRepository = applicationsRepository;
            _CreditBureauCheckRepository = creditBureauCheckRepository;
            _LoanPurposeClassificationRepository = LoanPurposeClassificationRepository;
            _apiCallLogAppService = apiCallLogAppService;
        }

        public async Task<string> CreateEnhancementRequest(CreateEnhancementRequestDto input)
        {
            string ResponseString = "";
            try
            {

                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateEnhancementRequest";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var bp = _EnhancementRequestRepository.GetAllList(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (bp != null)
                {
                    await _EnhancementRequestRepository.DeleteAsync(bp);
                    var EnhancementRequests = ObjectMapper.Map<EnhancementRequest>(input);
                    _EnhancementRequestRepository.Insert(EnhancementRequests);
                }
                else
                {
                    var EnhancementRequests = ObjectMapper.Map<EnhancementRequest>(input);
                    _EnhancementRequestRepository.Insert(EnhancementRequests);
                }
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", EnhancementRequest));

            }
        }

        public async Task<EnhancementRequestListDto> GetEnhancementRequestById(int Id)
        {
            try
            {
                var EnhancementRequests = await _EnhancementRequestRepository.GetAsync(Id);

                return ObjectMapper.Map<EnhancementRequestListDto>(EnhancementRequests);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", EnhancementRequest));
            }
        }

        //public async Task<string> MigrateEnhancementRequest(int ApplicationId)
        //{
        //    string ResponseString = "";
        //    try
        //    {
        //        var EnhancementReq = _EnhancementRequestRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
        //        if (EnhancementReq != null)
        //        {
        //            //ObjectMapper.Map(input, EnhancementRequests);

        //            if (EnhancementReq.RequestState == 1)//Approved?
        //            {
        //                ResponseString=await _applicationAppService.MigrateEnhancementApplication(EnhancementReq.ApplicationId);

        //                return ResponseString = "Success";
        //            }
        //            else
        //            {
        //                return ResponseString = "Record Not found or is not approved yet.";
        //            }

        //        }
        //        else
        //        {
        //            throw new UserFriendlyException(L("UpdateMethodError{0}", EnhancementRequest));

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException(L("UpdateMethodError{0}", EnhancementRequest));
        //    }
        //}

        //public async Task<string> UpdateEnhancementRequest(UpdateEnhancementRequestDto input)
        //{
        //    string ResponseString = "";
        //    try
        //    {
        //        var EnhancementRequests = _EnhancementRequestRepository.Get(input.Id);
        //        if (EnhancementRequests != null && EnhancementRequests.Id > 0)
        //        {
        //            ObjectMapper.Map(input, EnhancementRequests);
        //            await _EnhancementRequestRepository.UpdateAsync(EnhancementRequests);
        //            CurrentUnitOfWork.SaveChanges();
        //            return ResponseString = "Records Updated Successfully";
        //        }
        //        else
        //        {
        //            throw new UserFriendlyException(L("UpdateMethodError{0}", EnhancementRequest));

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException(L("UpdateMethodError{0}", EnhancementRequest));
        //    }
        //}

        public async Task<EnhancementRequestListDto> GetEnhancementRequestByApplicationId(int ApplicationId)
        {
            try
            {
                var EnhancementRequests = _EnhancementRequestRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                //var Applicationz = _applicationsRepository.GetAllList();
                var EnhancementRequestz = ObjectMapper.Map<EnhancementRequestListDto>(EnhancementRequests);

                if (EnhancementRequestz != null)
                {
                    if (EnhancementRequestz.ApplicationId != 0)
                    {
                        var App = _applicationsRepository.Get(EnhancementRequestz.ApplicationId);
                        EnhancementRequestz.ClientId = App.ClientID;
                        EnhancementRequestz.ClientName = App.ClientName;
                        EnhancementRequestz.ClientBusiness = App.SchoolName;
                        EnhancementRequestz.OldApplicationId = App.PrevApplicationId;
                    }
                }
                return EnhancementRequestz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", EnhancementRequest));
            }
        }
        public async Task<List<EnhancementRequestListDto>> GetAllEnhancementRequests()
        {
            try
            {
                var EnhancementRequests = _EnhancementRequestRepository.GetAllList();
                //var Applicationz = _applicationsRepository.GetAllList();
                var EnhancementRequestz = ObjectMapper.Map<List<EnhancementRequestListDto>>(EnhancementRequests);

                if (EnhancementRequestz != null)
                {
                    foreach (var req in EnhancementRequestz)
                    {
                        if (req.ApplicationId != 0)
                        {
                            var App = _applicationsRepository.Get(req.ApplicationId);
                            req.ClientId = App.ClientID;
                            req.ClientName = App.ClientName;
                            req.ClientBusiness = App.SchoolName;
                        }
                    }
                }
                return EnhancementRequestz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", EnhancementRequest));
            }
        }

        public string SetEnhancementRequestState(int ApplicationId, int state)
        {
            string ResponseString = "";

            try
            {
                var EnhancementRequests = _EnhancementRequestRepository.GetAllList(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (EnhancementRequests != null)
                {
                    EnhancementRequests.RequestState = state;
                    _EnhancementRequestRepository.UpdateAsync(EnhancementRequests);
                }
                return "Success";

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", EnhancementRequest));
            }

        }

        public List<EnhancementRequestListDto> GetAllEnhancementRequestsBySdeId(int SDEID)
        {
            try
            {
                var EnhancementRequests = _EnhancementRequestRepository.GetAllList(x => x.UserId == SDEID).ToList();
                //var Applicationz = _applicationsRepository.GetAllList();
                var EnhancementRequestz = ObjectMapper.Map<List<EnhancementRequestListDto>>(EnhancementRequests);

                foreach(var req in EnhancementRequestz)
                {
                    if (req.ApplicationId != 0)
                    {
                        var App = _applicationsRepository.Get(req.ApplicationId);
                        req.ClientId = App.ClientID;
                        req.ClientName = App.ClientName;
                        req.ClientBusiness = App.SchoolName;
                    }
                }
                   
                return EnhancementRequestz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", EnhancementRequest));
            }
        }


        //public bool CheckEnhancementRequestByApplicationId(int ApplicationId)
        //{
        //    try
        //    {
        //        var EnhancementRequests = _EnhancementRequestRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
        //        if (EnhancementRequests != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException(L("GetMethodError{0}", EnhancementRequest));
        //    }

        //}
    }
}
