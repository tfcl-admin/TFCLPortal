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
using TFCLPortal.CustomerAccounts;
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.Schedules;
using TFCLPortal.ScheduleInstallmentTemps;
using TFCLPortal.InstallmentPayments;
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.Schedules.Dto;
using TFCLPortal.Transactions;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.Applications.Dto;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.LateDaysAuthorizations.Dto;
using TFCLPortal.Branches.Dto;
using TFCLPortal.Branches;

namespace TFCLPortal.LateDaysAuthorizations
{
    public class LateDaysAuthorizationAppService : TFCLPortalAppServiceBase, ILateDaysAuthorizationAppService
    {
        #region Properties
        private readonly IRepository<LateDaysAuthorization, int> _LateDaysAuthorizationRepository;
        private readonly IRepository<ApplicantReputation> _applicantReputations;
        private readonly IRepository<UtilityBillPayment> _utilityBillPayment;
        private readonly IRepository<ReferenceCheck> _referenceCheckRepository;
        private readonly IRepository<CompanyBankAccount> _companyBankAccountRepository;
        private readonly IRepository<NatureOfPayment> _natureOfPaymentRepository;
        private readonly IRepository<ScheduleInstallment, int> _scheduleInstallmentRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ICustomerAccountAppService _customerAccountAppAppService;
        private readonly IInstallmentPaymentAppService _installmentPaymentAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IScheduleAppService _scheduleAppService;

        #endregion
        #region Constructor 
        public LateDaysAuthorizationAppService(IRepository<ScheduleInstallment, int> scheduleInstallmentRepository, IRepository<LateDaysAuthorization> LateDaysAuthorizationRepository,
            IRepository<ApplicantReputation> applicantReputations,
            ICustomerAccountAppService customerAccountAppAppService,
            IInstallmentPaymentAppService installmentPaymentAppService,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IScheduleAppService scheduleAppService,
            IFinalWorkflowAppService finalWorkflowAppService,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IApplicationAppService applicationAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _scheduleAppService = scheduleAppService;
            _finalWorkflowAppService = finalWorkflowAppService;
            _installmentPaymentAppService = installmentPaymentAppService;
            _LateDaysAuthorizationRepository = LateDaysAuthorizationRepository;
            _applicantReputations = applicantReputations;
            _customerAccountAppAppService = customerAccountAppAppService;
            _utilityBillPayment = utilityBillPayment;
            _scheduleInstallmentRepository = scheduleInstallmentRepository;
            _applicationAppService = applicationAppService;
            _referenceCheckRepository = referenceCheckRepository;
            _companyBankAccountRepository = companyBankAccountRepository;
            _natureOfPaymentRepository = natureOfPaymentRepository;
        }
        #endregion
        #region Methods
        public int CreateLateDaysAuthorization(CreateLateDaysAuthorization createLateDaysAuthorization)
        {
            try
            {
                var lateDaysAuthorization = ObjectMapper.Map<LateDaysAuthorization>(createLateDaysAuthorization);
                return _LateDaysAuthorizationRepository.InsertAndGetId(lateDaysAuthorization);

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        //public async Task<AuthorizeInstallmentPaymentListDto> GetAuthorizeInstallmentPaymentById(int Id)
        //{
        //    try
        //    {
        //        var AuthorizeInstallmentPayment = await _AuthorizeInstallmentPaymentRepository.GetAsync(Id);


        //        return ObjectMapper.Map<AuthorizeInstallmentPaymentListDto>(AuthorizeInstallmentPayment);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public List<LateDaysAuthorizationListDto> GetLateDaysUnAuthorizedList()
        {
            try
            {
                var unAuthList = _LateDaysAuthorizationRepository.GetAllIncluding(x => x.isAuthorized == null );

                return ObjectMapper.Map<List<LateDaysAuthorizationListDto>>(unAuthList);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "LateDays"));
            }
        }

        public async Task<string> EditLateDaysAuthorization(EditLateDaysAuthorization editLateDaysAuthorization)
        {
            string ResponseString = "";
            try
            {


                var AuthorizeLateDays = _LateDaysAuthorizationRepository.Get(editLateDaysAuthorization.Id);
                if (AuthorizeLateDays != null && AuthorizeLateDays.Id > 0)
                {
                    ObjectMapper.Map(editLateDaysAuthorization, AuthorizeLateDays);
                    await _LateDaysAuthorizationRepository.UpdateAsync(AuthorizeLateDays);

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


        //public async Task<List<LateDaysAuthorizationListDto>> GetAuthorizeInstallmentPaymentByApplicationId(int ApplicationId)
        //{
        //    try
        //    {
        //        var LateDaysAuthorization = _LateDaysAuthorizationRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId && x.isAuthorized == null).ToList();
        //        var payments = ObjectMapper.Map<List<LateDaysAuthorizationListDto>>(LateDaysAuthorization);

        //        if (payments != null && payments.Count > 0)
        //        {
        //            foreach (var child in payments)
        //            {

        //                if (child.NatureOfPayment != 0)
        //                {
        //                    var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
        //                    child.NatureOfPaymentName = NatureOfPayment.Name;
        //                }
        //                if (child.FK_CompanyBankId != 0)
        //                {
        //                    var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
        //                    child.CompanyBankName = CompanyBank.Name;
        //                }

        //            }
        //        }

        //        return payments;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentByApplicationId(int ApplicationId)
        //{
        //    try
        //    {
        //        var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
        //        var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

        //        if (payments != null && payments.Count > 0)
        //        {
        //            foreach (var child in payments)
        //            {

        //                if (child.NatureOfPayment != 0)
        //                {
        //                    var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
        //                    child.NatureOfPaymentName = NatureOfPayment.Name;
        //                }
        //                if (child.FK_CompanyBankId != 0)
        //                {
        //                    var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
        //                    child.CompanyBankName = CompanyBank.Name;
        //                }

        //            }
        //        }

        //        return payments;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPayments()
        //{
        //    try
        //    {
        //        var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList();
        //        var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

        //        var applications = _applicationAppService.GetApplicationList("", 0);

        //        if (payments != null && payments.Count > 0)
        //        {
        //            foreach (var child in payments)
        //            {

        //                if (child.NatureOfPayment != 0)
        //                {
        //                    var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
        //                    child.NatureOfPaymentName = NatureOfPayment.Name;
        //                }
        //                if (child.FK_CompanyBankId != 0)
        //                {
        //                    var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
        //                    child.CompanyBankName = CompanyBank.Name;
        //                }

        //                var app = applications.Where(x => x.Id == child.ApplicationId).FirstOrDefault();
        //                if (app != null)
        //                {
        //                    child.ClientID = app.ClientID;
        //                    child.ClientName = app.ApplicantName;
        //                    child.SchoolName = app.SchoolName;
        //                    child.branchId = app.branchId;
        //                }
        //            }
        //        }

        //        return payments;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentsUnAuthorized()
        //{
        //    try
        //    {
        //        var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList(x => x.isAuthorized == null);
        //        var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

        //        var applications = _applicationAppService.GetApplicationList("", 0);

        //        if (payments != null && payments.Count > 0)
        //        {
        //            foreach (var child in payments)
        //            {

        //                if (child.NatureOfPayment != 0)
        //                {
        //                    var NatureOfPayment = _natureOfPaymentRepository.GetAllList().Where(x => x.Id == child.NatureOfPayment).FirstOrDefault();
        //                    child.NatureOfPaymentName = NatureOfPayment.Name;
        //                }
        //                if (child.FK_CompanyBankId != 0)
        //                {
        //                    var CompanyBank = _companyBankAccountRepository.GetAllList().Where(x => x.Id == child.FK_CompanyBankId).FirstOrDefault();
        //                    child.CompanyBankName = CompanyBank.Name;
        //                }

        //                var app = applications.Where(x => x.Id == child.ApplicationId).FirstOrDefault();
        //                if (app != null)
        //                {
        //                    child.ClientID = app.ClientID;
        //                    child.ClientName = app.ApplicantName;
        //                    child.SchoolName = app.SchoolName;
        //                    child.branchId = app.branchId;
        //                }
        //            }
        //        }

        //        return payments;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        //public bool CheckAuthorizeInstallmentPaymentByApplicationId(int ApplicationId)
        //{
        //    try
        //    {
        //        var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
        //        if (AuthorizeInstallmentPayment != null)
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
        //        throw new UserFriendlyException(L("GetMethodError{0}", "payment"));
        //    }
        //}

        //public bool InstallmentPayment(CreateAuthorizeInstallmentPayment payment)
        //{
        //    try
        //    {
        //        payment.isAuthorized = true;
        //        var paymentCreation = Create(payment);

        //        if (paymentCreation != -1)
        //        {
        //            var paymentData = GetAuthorizeInstallmentPaymentById(paymentCreation).Result;
        //            if (paymentData != null)
        //            {
        //                CreateInstallmentPayment installmentPayment = new CreateInstallmentPayment();

        //                installmentPayment.ApplicationId = paymentData.ApplicationId;
        //                installmentPayment.InstallmentDueDate = paymentData.InstallmentDueDate;
        //                installmentPayment.InstallmentAmount = paymentData.InstallmentAmount;
        //                installmentPayment.NoOfInstallment = paymentData.NoOfInstallment;
        //                installmentPayment.PreviousBalance = paymentData.PreviousBalance;
        //                installmentPayment.DueAmount = paymentData.DueAmount;
        //                installmentPayment.ModeOfPayment = paymentData.ModeOfPayment;
        //                installmentPayment.Amount = paymentData.Amount;
        //                installmentPayment.ExcessShortPayment = paymentData.ExcessShortPayment;
        //                installmentPayment.AmountWords = paymentData.AmountWords;
        //                installmentPayment.LateDays = paymentData.LateDays;
        //                installmentPayment.LateDaysPenalty = paymentData.LateDaysPenalty;
        //                installmentPayment.DepositDate = DateTime.Parse(paymentData.DepositDate.ToString("yyyy-MM-dd hh:mm:ss tt"));
        //                installmentPayment.isLateDaysApplied = paymentData.isLateDaysApplied;

        //                CreateInstallmentPayment(installmentPayment);
        //            }
        //        }
        //        return true;
        //    }
        //    catch //(Exception ex)
        //    {
        //        return false;
        //        //throw new UserFriendlyException(L("GetMethodError{0}", "payment"));
        //    }
        //}

        //public bool CreateInstallmentPayment(CreateInstallmentPayment payment)
        //{
        //    try
        //    {
        //        var schedule = _scheduleAppService.GetScheduleByApplicationId(payment.ApplicationId).Result;
        //        if (schedule != null)
        //        {
        //            if (schedule.installmentList.Where(x => x.InstNumber == payment.NoOfInstallment.ToString()).FirstOrDefault().isPaid != true)
        //            {
        //                var payments = _installmentPaymentAppService.GetAllInstallmentPaymentByApplicationId(payment.ApplicationId).Result;
        //                if (payments == null)
        //                {
        //                    AuthorizeInstallmentPayment(payment.AuthorizationId);

        //                    DeductInstallmentPaymentRevised(payment);
        //                }
        //                else
        //                {
        //                    var lastpayment = payments.Where(x => x.NoOfInstallment == payment.NoOfInstallment).OrderByDescending(x => x.Id).FirstOrDefault();
        //                    if (lastpayment != null)
        //                    {
        //                        if ((DateTime.Now - lastpayment.CreationTime).TotalMinutes >= 10)
        //                        {
        //                            AuthorizeInstallmentPayment(payment.AuthorizationId);

        //                            DeductInstallmentPaymentRevised(payment);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AuthorizeInstallmentPayment(payment.AuthorizationId);

        //                        DeductInstallmentPaymentRevised(payment);
        //                    }
        //                }

        //            }
        //        }

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}



        #endregion
    }
}
