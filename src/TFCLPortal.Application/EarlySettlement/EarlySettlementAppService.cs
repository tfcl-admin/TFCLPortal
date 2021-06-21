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
using TFCLPortal.EarlySettlements.Dto;
using TFCLPortal.NatureOfPayments;

namespace TFCLPortal.EarlySettlements
{
    public class EarlySettlementAppService : TFCLPortalAppServiceBase, IEarlySettlementAppService
    {
        #region Properties
        private readonly IRepository<EarlySettlement, int> _EarlySettlementRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IApplicationAppService _applicationAppService;


        #endregion
        #region Constructor 
        public EarlySettlementAppService(IRepository<EarlySettlement> EarlySettlementRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _EarlySettlementRepository = EarlySettlementRepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
            _applicationAppService = applicationAppService;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateEarlySettlement createEarlySettlement)
        {
            try
            {
                var EarlySettlement = ObjectMapper.Map<EarlySettlement>(createEarlySettlement);
                await _EarlySettlementRepository.InsertAsync(EarlySettlement);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<EarlySettlementListDto> GetEarlySettlementById(int Id)
        {
            try
            {
                var EarlySettlement = await _EarlySettlementRepository.GetAsync(Id);

                if (EarlySettlement != null)
                {
                    var mapped = ObjectMapper.Map<EarlySettlementListDto>(EarlySettlement);

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

        public async Task<string> Update(EditEarlySettlement editEarlySettlement)
        {
            string ResponseString = "";
            try
            {


                var EarlySettlement = _EarlySettlementRepository.Get(editEarlySettlement.Id);
                if (EarlySettlement != null && EarlySettlement.Id > 0)
                {
                    ObjectMapper.Map(editEarlySettlement, EarlySettlement);
                    await _EarlySettlementRepository.UpdateAsync(EarlySettlement);

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

        public async Task<List<EarlySettlementListDto>> GetEarlySettlementByApplicationId(int ApplicationId)
        {
            try
            {
                var EarlySettlement = _EarlySettlementRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var payments = ObjectMapper.Map<List<EarlySettlementListDto>>(EarlySettlement);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<EarlySettlementListDto>> GetAllEarlySettlements()
        {
            try
            {
                var EarlySettlement = _EarlySettlementRepository.GetAllList().ToList();
                var payments = ObjectMapper.Map<List<EarlySettlementListDto>>(EarlySettlement);
                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckEarlySettlementByApplicationId(int ApplicationId)
        {
            try
            {
                var EarlySettlement = _EarlySettlementRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (EarlySettlement != null)
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
