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
using TFCLPortal.DeceasedSettlements.Dto;
using TFCLPortal.NatureOfPayments;

namespace TFCLPortal.DeceasedSettlements
{
    public class DeceasedSettlementAppService : TFCLPortalAppServiceBase, IDeceasedSettlementAppService
    {
        #region Properties
        private readonly IRepository<DeceasedSettlement, int> _DeceasedSettlementRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IApplicationAppService _applicationAppService;


        #endregion
        #region Constructor 
        public DeceasedSettlementAppService(IRepository<DeceasedSettlement> DeceasedSettlementRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _DeceasedSettlementRepository = DeceasedSettlementRepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
            _applicationAppService = applicationAppService;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateDeceasedSettlement createDeceasedSettlement)
        {
            try
            {
                var DeceasedSettlement = ObjectMapper.Map<DeceasedSettlement>(createDeceasedSettlement);
                await _DeceasedSettlementRepository.InsertAsync(DeceasedSettlement);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<DeceasedSettlementListDto> GetDeceasedSettlementById(int Id)
        {
            try
            {
                var DeceasedSettlement = await _DeceasedSettlementRepository.GetAsync(Id);

                if (DeceasedSettlement != null)
                {
                    var mapped = ObjectMapper.Map<DeceasedSettlementListDto>(DeceasedSettlement);

                    var app = _applicationAppService.GetApplicationById(mapped.ApplicationId);

                    mapped.ClientID = app.ClientID;
                    mapped.ClientName = app.ClientName;
                    mapped.SchoolName = app.SchoolName;
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

        public async Task<string> Update(EditDeceasedSettlement editDeceasedSettlement)
        {
            string ResponseString = "";
            try
            {


                var DeceasedSettlement = _DeceasedSettlementRepository.Get(editDeceasedSettlement.Id);
                if (DeceasedSettlement != null && DeceasedSettlement.Id > 0)
                {
                    ObjectMapper.Map(editDeceasedSettlement, DeceasedSettlement);
                    await _DeceasedSettlementRepository.UpdateAsync(DeceasedSettlement);

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

        public async Task<List<DeceasedSettlementListDto>> GetDeceasedSettlementByApplicationId(int ApplicationId)
        {
            try
            {
                var DeceasedSettlement = _DeceasedSettlementRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var payments = ObjectMapper.Map<List<DeceasedSettlementListDto>>(DeceasedSettlement);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DeceasedSettlementListDto>> GetAllDeceasedSettlements()
        {
            try
            {
                var DeceasedSettlement = _DeceasedSettlementRepository.GetAllList().ToList();
                var payments = ObjectMapper.Map<List<DeceasedSettlementListDto>>(DeceasedSettlement);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckDeceasedSettlementByApplicationId(int ApplicationId)
        {
            try
            {
                var DeceasedSettlement = _DeceasedSettlementRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (DeceasedSettlement != null)
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
