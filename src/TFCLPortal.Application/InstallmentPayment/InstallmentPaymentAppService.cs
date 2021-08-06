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
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.NatureOfPayments;
using TFCLPortal.Users;

namespace TFCLPortal.InstallmentPayments
{
    public class InstallmentPaymentAppService : TFCLPortalAppServiceBase, IInstallmentPaymentAppService
    {
        #region Properties
        private readonly IRepository<InstallmentPayment, int> _InstallmentPaymentRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IRepository<Applicationz> _applicationRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IUserAppService _userAppService;

        #endregion
        #region Constructor 
        public InstallmentPaymentAppService(IRepository<InstallmentPayment> InstallmentPaymentRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IRepository<Applicationz> applicationRepository,
            IApplicationAppService applicationAppService,
            IUserAppService userAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _userAppService = userAppService;
            _applicationRepository = applicationRepository;
            _InstallmentPaymentRepository = InstallmentPaymentRepository;
            _applicantReputations = applicantReputations;
            _utilityBillPayment = utilityBillPayment;
            _applicationAppService = applicationAppService;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateInstallmentPayment createInstallmentPayment)
        {
            try
            {
                var InstallmentPayment = ObjectMapper.Map<InstallmentPayment>(createInstallmentPayment);
                await _InstallmentPaymentRepository.InsertAsync(InstallmentPayment);

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<InstallmentPaymentListDto> GetInstallmentPaymentById(int Id)
        {
            try
            {
                var InstallmentPayment = await _InstallmentPaymentRepository.GetAsync(Id);


                return ObjectMapper.Map<InstallmentPaymentListDto>(InstallmentPayment);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Update(EditInstallmentPayment editInstallmentPayment)
        {
            string ResponseString = "";
            try
            {


                var InstallmentPayment = _InstallmentPaymentRepository.Get(editInstallmentPayment.Id);
                if (InstallmentPayment != null && InstallmentPayment.Id > 0)
                {
                    ObjectMapper.Map(editInstallmentPayment, InstallmentPayment);
                    await _InstallmentPaymentRepository.UpdateAsync(InstallmentPayment);

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

        public async Task<List<InstallmentPaymentListDto>> GetInstallmentPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var InstallmentPayment = _InstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId && x.isAuthorized==true).ToList();
                var payments = ObjectMapper.Map<List<InstallmentPaymentListDto>>(InstallmentPayment);

                //var apps = _applicationRepository.GetAllList();
                //var users = _userAppService.GetAllUsers();

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

        public async Task<List<InstallmentPaymentListDto>> GetAllInstallmentPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var InstallmentPayment = _InstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var payments = ObjectMapper.Map<List<InstallmentPaymentListDto>>(InstallmentPayment);

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

        public async Task<List<InstallmentPaymentListDto>> GetAllInstallmentPayments()
        {
            try
            {
                var InstallmentPayment = _InstallmentPaymentRepository.GetAllList();
                var payments = ObjectMapper.Map<List<InstallmentPaymentListDto>>(InstallmentPayment);

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

                        var app=_applicationAppService.GetApplicationById(child.ApplicationId);
                        if (app != null)
                        {
                            child.ClientID = app.ClientID;
                            child.ClientName = app.ClientName;
                            child.SchoolName = app.SchoolName;
                            child.branchId = app.FK_branchid;
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

        public bool CheckInstallmentPaymentByApplicationId(int ApplicationId)
        {
            try
            {
                var InstallmentPayment = _InstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (InstallmentPayment != null)
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
