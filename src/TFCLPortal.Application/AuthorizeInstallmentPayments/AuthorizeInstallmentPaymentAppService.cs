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
using TFCLPortal.AuthorizeInstallmentPayments.Dto;
using TFCLPortal.NatureOfPayments;

namespace TFCLPortal.AuthorizeInstallmentPayments
{
    public class AuthorizeInstallmentPaymentAppService : TFCLPortalAppServiceBase, IAuthorizeInstallmentPaymentAppService
    {
        #region Properties
        private readonly IRepository<AuthorizeInstallmentPayment, int> _AuthorizeInstallmentPaymentRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IApplicationAppService _applicationAppService;

        #endregion
        #region Constructor 
        public AuthorizeInstallmentPaymentAppService(IRepository<AuthorizeInstallmentPayment> AuthorizeInstallmentPaymentRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _AuthorizeInstallmentPaymentRepository = AuthorizeInstallmentPaymentRepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _applicationAppService = applicationAppService;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateAuthorizeInstallmentPayment createAuthorizeInstallmentPayment)
        {
            try
            {
                var AuthorizeInstallmentPayment = ObjectMapper.Map<AuthorizeInstallmentPayment>(createAuthorizeInstallmentPayment);
                await _AuthorizeInstallmentPaymentRepository.InsertAsync(AuthorizeInstallmentPayment);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<AuthorizeInstallmentPaymentListDto> GetAuthorizeInstallmentPaymentById(int Id)
        {
            try
            {
                var AuthorizeInstallmentPayment = await _AuthorizeInstallmentPaymentRepository.GetAsync(Id);


                return ObjectMapper.Map<AuthorizeInstallmentPaymentListDto>(AuthorizeInstallmentPayment);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Update(EditAuthorizeInstallmentPayment editAuthorizeInstallmentPayment)
        {
            string ResponseString = "";
            try
            {


                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.Get(editAuthorizeInstallmentPayment.Id);
                if (AuthorizeInstallmentPayment != null && AuthorizeInstallmentPayment.Id > 0)
                {
                    ObjectMapper.Map(editAuthorizeInstallmentPayment, AuthorizeInstallmentPayment);
                    await _AuthorizeInstallmentPaymentRepository.UpdateAsync(AuthorizeInstallmentPayment);

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

        public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAuthorizeInstallmentPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId && x.isAuthorized==true).ToList();
                var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

                if (payments != null && payments.Count > 0)
                {
                    foreach (var child in payments)
                    {

                        if (child.NatureOfPayment != 0)
                        {
                            var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
                            child.NatureOfPaymentName = NatureOfPayment.Name;
                        }
                        if (child.FK_CompanyBankId != 0)
                        {
                            var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
                            child.CompanyBankName = CompanyBank.Name;
                        }

                    }
                }

                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

                if (payments != null && payments.Count > 0)
                {
                    foreach (var child in payments)
                    {

                        if (child.NatureOfPayment != 0)
                        {
                            var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
                            child.NatureOfPaymentName = NatureOfPayment.Name;
                        }
                        if (child.FK_CompanyBankId != 0)
                        {
                            var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
                            child.CompanyBankName = CompanyBank.Name;
                        }

                    }
                }

                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPayments()
        {
            try
            {
                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList();
                var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

                var applications = _applicationAppService.GetApplicationList("",0);

                if (payments != null && payments.Count > 0)
                {
                    foreach (var child in payments)
                    {

                        if (child.NatureOfPayment != 0)
                        {
                            var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
                            child.NatureOfPaymentName = NatureOfPayment.Name;
                        }
                        if (child.FK_CompanyBankId != 0)
                        {
                            var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
                            child.CompanyBankName = CompanyBank.Name;
                        }

                        var app = applications.Where(x => x.Id == child.ApplicationId).SingleOrDefault();
                        if (app != null)
                        {
                            child.ClientID = app.ClientID;
                            child.ClientName = app.ApplicantName;
                            child.SchoolName = app.SchoolName;
                            child.branchId = app.branchId;
                        }
                    }
                }

                return payments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckAuthorizeInstallmentPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (AuthorizeInstallmentPayment != null)
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
