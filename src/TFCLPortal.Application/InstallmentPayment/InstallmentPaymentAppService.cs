using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AllScreensGetByAppID.Dto;
using TFCLPortal.Applications;
using TFCLPortal.ClosingMonths;
using TFCLPortal.CompanyBankAccounts;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;
using TFCLPortal.EarlySettlements;
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.NatureOfPayments;
using TFCLPortal.Schedules;
using TFCLPortal.Schedules.Dto;
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
        private readonly ICustomerAccountAppService _customerAccountAppAppService;
        private readonly IUserAppService _userAppService;
        //private readonly IScheduleAppService _scheduleAppService;
        private readonly IClosingMonthAppService _closingMonthAppService;
        private readonly IEarlySettlementAppService _earlySettlementAppService;

        #endregion
        #region Constructor 
        public InstallmentPaymentAppService(IRepository<InstallmentPayment> InstallmentPaymentRepository,
            IRepository<ApplicantReputation> applicantReputations,
            IRepository<CompanyBankAccount> companyBankAccountRepository,
            IRepository<UtilityBillPayment> utilityBillPayment,
            IRepository<NatureOfPayment> natureOfPaymentRepository,
            IRepository<Applicationz> applicationRepository,
            IApplicationAppService applicationAppService,
            ICustomerAccountAppService customerAccountAppAppService,
            IEarlySettlementAppService earlySettlementAppService,
            IClosingMonthAppService closingMonthAppService,
            //IScheduleAppService scheduleAppService,
            IUserAppService userAppService,
            IRepository<ReferenceCheck> referenceCheckRepository)
        {
            _userAppService = userAppService;
            _customerAccountAppAppService = customerAccountAppAppService;
            _applicationRepository = applicationRepository;
            _InstallmentPaymentRepository = InstallmentPaymentRepository;
            _applicantReputations = applicantReputations;
            //_scheduleAppService = scheduleAppService;
            _closingMonthAppService = closingMonthAppService;
            _utilityBillPayment = utilityBillPayment;
            _earlySettlementAppService = earlySettlementAppService;
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
                var InstallmentPayment = _InstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId && x.isAuthorized==true).OrderBy(x=>x.Id).ToList();
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

        public CurrentInstallmentPaymentDto GetCurrentInstallmentPayment(int ApplicationId,ScheduleListDto schedule)
        {
            try
            {
                CurrentInstallmentPaymentDto rtn = new CurrentInstallmentPaymentDto();

                rtn.ApplicationId = ApplicationId;

                var app = _applicationAppService.GetApplicationById(ApplicationId);
                rtn.ClientId = app.ClientID;
                rtn.ClientName = app.ClientName;

                //var Banks = _companyBankAccountRepository.GetAllList().Select(s => new { Id = s.Id, Selection = string.Format("{0} {1} ({2})", s.Name, s.Branch, s.AccountNumber) }).ToList();
                //ViewBag.BanksList = new SelectList(Banks, "Id", "Selection");

                //var NatureOfPayments = _natureOfPaymentRepository.GetAllList().ToList();
                //ViewBag.NatureOfPaymentsList = new SelectList(NatureOfPayments, "Id", "Name");

                //var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result ?? null;

                ScheduleInstallmenttListDto firstUnpaidInstallment = new ScheduleInstallmenttListDto();

                if (schedule != null)
                {
                    firstUnpaidInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber != "G*").FirstOrDefault();
                }
                else
                {
                    firstUnpaidInstallment = null;
                }

                var Acc = _customerAccountAppAppService.GetCustomerAccountByCNICwithTransactions(app.CNICNo);
                if (Acc != null)
                {
                    rtn.Payment = Acc.Balance;
                }

                if (firstUnpaidInstallment != null)
                {
                    rtn.InstallmentDueDate = firstUnpaidInstallment.InstallmentDueDate;
                    rtn.InstallmentAmount = (firstUnpaidInstallment.installmentAmount == "--" || firstUnpaidInstallment.installmentAmount == "" ? "0" : firstUnpaidInstallment.installmentAmount);
                    rtn.InstallmentNumber = firstUnpaidInstallment.InstNumber;
                    rtn.RemainingInstallments = firstUnpaidInstallment.BalInst;
                }
                else
                {
                    rtn.InstallmentDueDate = "0";
                    rtn.InstallmentAmount = "0";
                    rtn.InstallmentNumber = "0";
                    rtn.RemainingInstallments = schedule.installmentList.Where(x => x.InstNumber != "G*").Count().ToString();
                }

                var paidInstallments = GetInstallmentPaymentByApplicationId(ApplicationId);
                decimal previous;
                if (paidInstallments.Result.Count > 0)
                {
                    var lastPaidInstallment = paidInstallments.Result.LastOrDefault();
                    if (lastPaidInstallment.NoOfInstallment.ToString() != firstUnpaidInstallment.InstNumber)
                    {
                        rtn.PreviousBalance = lastPaidInstallment.ExcessShortPayment;
                        previous = lastPaidInstallment.ExcessShortPayment;
                    }
                    else if (lastPaidInstallment.NoOfInstallment.ToString() == "0")
                    {
                        //Changed due to Asif Iqbal's Previous Balance Issue
                        //var sameInstallmentPaymentsList = paidInstallments.Result.Where(x => x.InstallmentDueDate == DateTime.Parse(lastPaidInstallment.InstallmentDueDate));
                        var sameInstallmentPaymentsList = paidInstallments.Result.Where(x => x.InstallmentDueDate == DateTime.Parse(firstUnpaidInstallment.InstallmentDueDate));
                        decimal sumOfAllPaymentsForOneInstallment = 0;

                        int count = 0;
                        if (sameInstallmentPaymentsList.Count() > 0)
                        {

                            foreach (var payments in sameInstallmentPaymentsList)
                            {
                                if (count > 0)
                                {
                                    sumOfAllPaymentsForOneInstallment += (payments.Amount);
                                }
                                else
                                {
                                    sumOfAllPaymentsForOneInstallment += (payments.Amount + payments.PreviousBalance);
                                }

                                count++;
                            }

                        }
                        else
                        {
                            sumOfAllPaymentsForOneInstallment = lastPaidInstallment.ExcessShortPayment;
                        }
                        rtn.PreviousBalance = sumOfAllPaymentsForOneInstallment;
                        previous = sumOfAllPaymentsForOneInstallment;
                    }
                    else
                    {
                        var sameInstallmentPaymentsList = paidInstallments.Result.Where(x => x.NoOfInstallment == lastPaidInstallment.NoOfInstallment);
                        decimal sumOfAllPaymentsForOneInstallment = 0;

                        int count = 0;
                        foreach (var payments in sameInstallmentPaymentsList)
                        {
                            if (count > 0)
                            {
                                sumOfAllPaymentsForOneInstallment += (payments.Amount);
                            }
                            else
                            {
                                sumOfAllPaymentsForOneInstallment += (payments.Amount + payments.PreviousBalance);
                            }

                            count++;
                        }

                        rtn.PreviousBalance = sumOfAllPaymentsForOneInstallment;
                        previous = sumOfAllPaymentsForOneInstallment;
                    }
                }
                else
                {
                    rtn.PreviousBalance = 0;
                    previous = 0;
                }
                decimal Iamount = Decimal.Parse((rtn.InstallmentAmount).Replace(",", ""));
                rtn.DueAmount = Iamount - previous;

                bool displayButton = true;

                DateTime due = DateTime.Parse(rtn.InstallmentDueDate);

                displayButton = _closingMonthAppService.checkIfOpen(app.FK_branchid, due.Month, due.Year);

                decimal payment = (rtn.Payment == null ? 0 : rtn.Payment);

                if (displayButton)
                {
                    if (rtn.RemainingInstallments == "0" && (payment < rtn.DueAmount))
                    {
                        displayButton = false;
                        rtn.RestrictionError = "Not enough amount in this customer's account to Settle.";
                    }
                }
                else
                {
                    rtn.RestrictionError = "Month is not yet opened for this branch.";
                }

                if (displayButton)
                {
                    var instpayment = _earlySettlementAppService.GetEarlySettlementByApplicationId(ApplicationId).Result;
                    if (instpayment != null)
                    {
                        foreach (var es in instpayment)
                        {
                            if (es.isAuthorized == null)
                            {
                                displayButton = false;
                                rtn.RestrictionError = "Installment Payment can not be entered when early settlement entry is pending.";
                            }
                        }
                    }
                }

                if(displayButton)
                {
                    var lastCredit = Acc.transactions.Where(x => x.Type.ToLower() == "credit" && x.isAuthorized == true).OrderBy(x => x.SortDate).LastOrDefault();
                    if (lastCredit != null)
                    {
                        rtn.DepositDate = lastCredit.DepositDate.ToString("O");
                       // rtn.RestrictionError = "For Testing .";

                    }
                    else
                    {
                        displayButton = false;
                        rtn.RestrictionError = "Please credit amount first into account.";
                        //rtn.DepositDate = DateTime.Today.ToString("O");
                        rtn.DepositDate = DateTime.Now.ToString("O");
                    }
                }

                rtn.displayButton = displayButton;



                return rtn;


            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        #endregion
    }
}
