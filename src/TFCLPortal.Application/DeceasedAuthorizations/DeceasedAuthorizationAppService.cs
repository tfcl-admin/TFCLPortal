using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CompanyBankAccounts;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;
using TFCLPortal.DeceasedAuthorizations.Dto;
using TFCLPortal.NatureOfPayments;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TFCLPortal.DeceasedAuthorizations
{
    public class DeceasedAuthorizationAppService : TFCLPortalAppServiceBase, IDeceasedAuthorizationAppService
    {
        #region Properties
        private readonly IRepository<DeceasedAuthorization, int> _DeceasedAuthorizationRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IHostingEnvironment _env;


        #endregion
        #region Constructor 
        public DeceasedAuthorizationAppService(IRepository<DeceasedAuthorization> DeceasedAuthorizationRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _DeceasedAuthorizationRepository = DeceasedAuthorizationRepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
            _applicationAppService = applicationAppService;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateDeceasedAuthorization createDeceasedAuthorization)
        {
            try
            {
                var DeceasedAuthorization = ObjectMapper.Map<DeceasedAuthorization>(createDeceasedAuthorization);

                if(createDeceasedAuthorization.file!=null)
                {

                }

                await _DeceasedAuthorizationRepository.InsertAsync(DeceasedAuthorization);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<DeceasedAuthorizationListDto> GetDeceasedAuthorizationById(int Id)
        {
            try
            {
                var DeceasedAuthorization = await _DeceasedAuthorizationRepository.GetAsync(Id);

                if (DeceasedAuthorization != null)
                {
                    var mapped = ObjectMapper.Map<DeceasedAuthorizationListDto>(DeceasedAuthorization);

                    var app = _applicationAppService.GetApplicationById(mapped.ApplicationId);

                    mapped.ClientName = app.ClientName;
                    mapped.CNIC = app.CNICNo;

                    return mapped;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Update(EditDeceasedAuthorization editDeceasedAuthorization)
        {
            string ResponseString = "";
            try
            {


                var DeceasedAuthorization = _DeceasedAuthorizationRepository.Get(editDeceasedAuthorization.Id);
                if (DeceasedAuthorization != null && DeceasedAuthorization.Id > 0)
                {
                    ObjectMapper.Map(editDeceasedAuthorization, DeceasedAuthorization);
                    await _DeceasedAuthorizationRepository.UpdateAsync(DeceasedAuthorization);

                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "payment"));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "payment"));
            }
            return ResponseString;
        }

        public async Task<List<DeceasedAuthorizationListDto>> GetDeceasedAuthorizationByApplicationId(int ApplicationId)
        {
            try
            {
                var DeceasedAuthorization = _DeceasedAuthorizationRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var payments = ObjectMapper.Map<List<DeceasedAuthorizationListDto>>(DeceasedAuthorization);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DeceasedAuthorizationListDto>> GetAllDeceasedAuthorizations()
        {
            try
            {
                var DeceasedAuthorization = _DeceasedAuthorizationRepository.GetAllList();
                var payments = ObjectMapper.Map<List<DeceasedAuthorizationListDto>>(DeceasedAuthorization);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckDeceasedAuthorizationByApplicationId(int ApplicationId)
        {
            try
            {
                var DeceasedAuthorization = _DeceasedAuthorizationRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (DeceasedAuthorization != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "payment"));
            }
        }


        #endregion
    }
}
