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
using TFCLPortal.PostDisbursementForms.Dto;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;
using TFCLPortal.DynamicDropdowns.LoansPurpose;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.PostDisbursementForms
{
    public class PostDisbursementFormAppService : TFCLPortalAppServiceBase, IPostDisbursementFormAppService
    {
        private readonly IRepository<PostDisbursementForm, Int32> _PostDisbursementFormRepository;
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
        private string PostDisbursementForm = "Business Plan";
        public PostDisbursementFormAppService(IRepository<PostDisbursementForm, Int32> PostDisbursementFormRepository,
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
            _PostDisbursementFormRepository = PostDisbursementFormRepository;
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

        public async Task<string> CreatePostDisbursementForm(CreatePostDisbursementFormDto input)
        {
            string ResponseString = "";
            try
            {

                //var bp = _PostDisbursementFormRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                //if (bp != null)
                //{
                //    var PostDisbursementForms = _PostDisbursementFormRepository.Get(bp.Id);

                //    await _PostDisbursementFormRepository.DeleteAsync(PostDisbursementForms);

                //    var PostDisbursement = ObjectMapper.Map<PostDisbursementForm>(input);
                //    _PostDisbursementFormRepository.Insert(PostDisbursement);
                //}
                //else
                //{
                    var PostDisbursementForms = ObjectMapper.Map<PostDisbursementForm>(input);
                    _PostDisbursementFormRepository.Insert(PostDisbursementForms);
                //}

                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", PostDisbursementForm));

            }
        }

        public async Task<PostDisbursementFormListDto> GetPostDisbursementFormById(int Id)
        {
            try
            {
                var PostDisbursementForms = await _PostDisbursementFormRepository.GetAsync(Id);

                return ObjectMapper.Map<PostDisbursementFormListDto>(PostDisbursementForms);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", PostDisbursementForm));
            }
        }

        public async Task<string> UpdatePostDisbursementForm(UpdatePostDisbursementFormDto input)
        {
            string ResponseString = "";
            try
            {
                var PostDisbursementForms = _PostDisbursementFormRepository.Get(input.Id);
                if (PostDisbursementForms != null && PostDisbursementForms.Id > 0)
                {
                    ObjectMapper.Map(input, PostDisbursementForms);
                    await _PostDisbursementFormRepository.UpdateAsync(PostDisbursementForms);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", PostDisbursementForm));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", PostDisbursementForm));
            }
        }

        public async Task<PostDisbursementFormListDto> GetPostDisbursementFormByApplicationId(int ApplicationId)
        {
            try
            {
                var PostDisbursementForms = _PostDisbursementFormRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);
                var PostDisbursementFormz = ObjectMapper.Map<PostDisbursementFormListDto>(PostDisbursementForms);
             
                return PostDisbursementFormz;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", PostDisbursementForm));
            }
        }

       
        public bool CheckPostDisbursementFormByApplicationId(int ApplicationId)
        {
            try
            {
                var PostDisbursementForms = _PostDisbursementFormRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if(PostDisbursementForms!=null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", PostDisbursementForm));
            }

        }
    }
}
