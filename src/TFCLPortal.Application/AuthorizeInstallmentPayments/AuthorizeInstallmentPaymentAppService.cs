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
        private readonly IRepository<ScheduleInstallment, int> _scheduleInstallmentRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ICustomerAccountAppService _customerAccountAppAppService;
        private readonly IInstallmentPaymentAppService _installmentPaymentAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IScheduleAppService _scheduleAppService;

        #endregion
        #region Constructor 
        public AuthorizeInstallmentPaymentAppService(IRepository<ScheduleInstallment, int> scheduleInstallmentRepository, IRepository<AuthorizeInstallmentPayment> AuthorizeInstallmentPaymentRepository,
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
            _AuthorizeInstallmentPaymentRepository = AuthorizeInstallmentPaymentRepository;
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
        public int Create(CreateAuthorizeInstallmentPayment createAuthorizeInstallmentPayment)
        {
            try
            {
                var AuthorizeInstallmentPayment = ObjectMapper.Map<AuthorizeInstallmentPayment>(createAuthorizeInstallmentPayment);
                return _AuthorizeInstallmentPaymentRepository.InsertAndGetId(AuthorizeInstallmentPayment);

            }
            catch (Exception ex)
            {
                return -1;
            }
        }




        public async Task<string> DeductInstallmentPayment(CreateInstallmentPayment payment)
        {
            try
            {


                var schedule = _scheduleAppService.GetScheduleByApplicationId(payment.ApplicationId).Result;
                var firstUnpaidInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber != "G*").FirstOrDefault();
                var indexOfLastPaidInstallment = schedule.installmentList.IndexOf(firstUnpaidInstallment) - 1;
                var acc = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                ScheduleInstallmenttListDto lastPaidInstallment = new ScheduleInstallmenttListDto();

                if (indexOfLastPaidInstallment != -1)
                {
                    lastPaidInstallment = schedule.installmentList[indexOfLastPaidInstallment];
                }

                var scheduleInstallment = _scheduleInstallmentRepository.Get(firstUnpaidInstallment.Id);
                decimal actualPayment = 0;
                decimal paidAmount = payment.Amount;
                decimal excessShortForLastPaidInstallment = 0;
                var Exists = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(payment.ApplicationId);
                if (Exists.Result != null || Exists.Result.Count >= 0)
                {
                    decimal existingAmountForSingleInstallment = 0;
                    foreach (var existingPayment in Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber && x.isAuthorized == true))
                    {
                        existingAmountForSingleInstallment += (existingPayment.Amount);//0
                    }

                    if (lastPaidInstallment != null)
                    {
                        if (lastPaidInstallment.InstNumber != "G*" && lastPaidInstallment.InstNumber != null && lastPaidInstallment.InstNumber != "")
                        {
                            var lastPaidinstallmentPayment = Exists.Result.Where(x => x.NoOfInstallment == Int32.Parse(lastPaidInstallment.InstNumber)).ToList();
                            if (lastPaidinstallmentPayment.Count == 1)
                            {
                                excessShortForLastPaidInstallment = lastPaidinstallmentPayment[0].ExcessShortPayment;
                            }
                            else if (lastPaidinstallmentPayment.Count > 1)
                            {
                                excessShortForLastPaidInstallment = lastPaidinstallmentPayment.LastOrDefault().ExcessShortPayment;
                            }
                        }
                        paidAmount += existingAmountForSingleInstallment + excessShortForLastPaidInstallment;
                    }

                    actualPayment = paidAmount;
                }

                decimal totalPaidForThisInst = paidAmount;
                paidAmount -= Decimal.Parse(scheduleInstallment.installmentAmount);

                payment.isAuthorized = true;
                _installmentPaymentAppService.Create(payment);


                decimal markupForThisInstallment = decimal.Parse(scheduleInstallment.markup == "--" ? "0" : scheduleInstallment.markup.Replace(",", ""));

                var gracePeriodInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber == "G*").FirstOrDefault();
                if (gracePeriodInstallment != null)
                {
                    var graceInstallment = _scheduleInstallmentRepository.Get(gracePeriodInstallment.Id);
                    decimal graceAmount = Decimal.Parse(graceInstallment.markup);
                    decimal gracePaidAmount = 0;
                    gracePaidAmount = paidAmount - graceAmount;

                    if (gracePaidAmount >= -100)
                    {
                        string n1 = "Grace Days Markup Collection";
                        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, graceAmount, n1, payment.ModeOfPayment);
                        _scheduleAppService.SetPaid(graceInstallment.Id, "Installment", payment.DepositDate);
                    }
                    else
                    {
                        string n1 = "Grace Days Partial Markup Collection";
                        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, paidAmount, n1, payment.ModeOfPayment);
                        _scheduleAppService.SetPaid(graceInstallment.Id, "Installment", payment.DepositDate);
                    }

                }

                //if (scheduleInstallment.isMarkupPaid == false)
                //{
                //    if (actualPayment >= markupForThisInstallment)
                //    {
                //        markupForThisInstallment -= (totalPaidForThisInst - payment.Amount);

                //        if (excessShortForLastPaidInstallment > 0)
                //        {
                //            string n1 = "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                //            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n1, payment.ModeOfPayment);
                //        }

                //        if (excessShortForLastPaidInstallment < 0)
                //        {
                //            excessShortForLastPaidInstallment *= -1;

                //            string n1 = "Previous Installment Deduction";
                //            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n1, payment.ModeOfPayment);
                //        }

                //        string n2 = "Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                //        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, markupForThisInstallment, n2, payment.ModeOfPayment);

                //        actualPayment -= (markupForThisInstallment + (totalPaidForThisInst - acc.Balance));

                //        decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                //        //var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                //        if (actualPayment > 0)
                //        {
                //            if (actualPayment >= principalForThisInstallment)
                //            {
                //                //decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                //                //var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                //                if (Exists.Result.Where(x => x.NoOfInstallment == Int32.Parse(scheduleInstallment.InstNumber)).Count() > 1)
                //                {
                //                    principalForThisInstallment -= (totalPaidForThisInst - payment.Amount - markupForThisInstallment);
                //                }

                //                //principalForThisInstallment -= (totalPaidForThisInst - markupForThisInstallment);

                //                if (actualPayment >= principalForThisInstallment)
                //                {
                //                    string n1 = "Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                //                    _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, principalForThisInstallment, n1, payment.ModeOfPayment);
                //                    actualPayment -= principalForThisInstallment;
                //                }
                //                else
                //                {
                //                    string n1 = "Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                //                    _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, actualPayment, n1, payment.ModeOfPayment);
                //                    actualPayment = 0;
                //                }


                //                if (scheduleInstallment.isPrincipalPaid = true)
                //                {
                //                    if (actualPayment > 0 && (principalForThisInstallment + markupForThisInstallment) < Decimal.Parse(scheduleInstallment.installmentAmount))
                //                    {
                //                        decimal amountToDeduct = Decimal.Parse(scheduleInstallment.installmentAmount) - (principalForThisInstallment + markupForThisInstallment);
                //                        //var accupdate2 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);
                //                        if (scheduleInstallment.InstNumber == "1")
                //                        {
                //                            string n1 = "Grace Days Markup Collection";
                //                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, amountToDeduct, n1, payment.ModeOfPayment);
                //                            actualPayment -= amountToDeduct;
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                string n1 = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                //                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, actualPayment, n1, payment.ModeOfPayment);
                //                actualPayment -= principalForThisInstallment;
                //            }
                //        }

                //    }
                //    else
                //    {
                //        if (excessShortForLastPaidInstallment > 0)
                //        {
                //            string n2 = "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                //            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n2, payment.ModeOfPayment);
                //        }

                //        if (excessShortForLastPaidInstallment < 0)
                //        {
                //            excessShortForLastPaidInstallment *= -1;

                //            string n2 = "Previous Installment Deduction";
                //            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n2, payment.ModeOfPayment);
                //            payment.Amount -= excessShortForLastPaidInstallment;
                //        }

                //        string n1 = "Partial Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                //        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n1, payment.ModeOfPayment);
                //        actualPayment -= markupForThisInstallment;
                //    }
                //}
                //else if (scheduleInstallment.isMarkupPaid == true)
                //{
                //    actualPayment -= markupForThisInstallment;

                //    if (actualPayment > 0)
                //    {
                //        if (scheduleInstallment.isPrincipalPaid == false)
                //        {
                //            decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                //            var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);


                //            if (actualPayment >= (principalForThisInstallment - 100))
                //            {
                //                //principalForThisInstallment -= (totalPaidForThisInst - acc.Balance - markupForThisInstallment);

                //                string n2 = "Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                //                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n2, payment.ModeOfPayment);

                //                actualPayment -= (principalForThisInstallment-100);

                //                if (scheduleInstallment.isPrincipalPaid == true)
                //                {
                //                    if (actualPayment > 0 && (principalForThisInstallment + markupForThisInstallment) < Decimal.Parse(scheduleInstallment.installmentAmount))
                //                    {
                //                        decimal amountToDeduct = Decimal.Parse(scheduleInstallment.installmentAmount) - (principalForThisInstallment + markupForThisInstallment);

                //                        string n3 = "Collection Inst No # " + scheduleInstallment.InstNumber;
                //                        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, amountToDeduct, n3, payment.ModeOfPayment);
                //                        actualPayment -= amountToDeduct;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                string n3 = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                //                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n3, payment.ModeOfPayment);
                //            }


                //            actualPayment -= principalForThisInstallment;
                //        }
                //    }
                //}
                //else
                //{
                //    string n3 = "Collection Inst No # " + scheduleInstallment.InstNumber;
                //    _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n3, payment.ModeOfPayment);
                //}




                //if (paidAmount >= -100)
                //{
                //    scheduleInstallment.isPaid = true;
                //    scheduleInstallment.PaymentDate = payment.DepositDate;
                //    _scheduleInstallmentRepository.Update(scheduleInstallment);
                //    CurrentUnitOfWork.SaveChanges();


                //    var allUnpaidInstallments = _scheduleInstallmentRepository.GetAllList(x => x.FK_ScheduleId == schedule.Id && (x.isPaid == false || x.isPaid == null));
                //    if (allUnpaidInstallments.Count < 1)
                //    {
                //        _applicationAppService.ChangeApplicationState(ApplicationState.Settled, payment.ApplicationId, "All Installments Paid");

                //        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                //        fWobj.ApplicationId = payment.ApplicationId;
                //        fWobj.Action = "All Installments Paid";
                //        fWobj.ActionBy = (int)AbpSession.UserId;
                //        fWobj.ApplicationState = ApplicationState.Settled;
                //        fWobj.isActive = true;

                //        _finalWorkflowAppService.CreateFinalWorkflow(fWobj);
                //    }
                //}

            }
            catch (Exception ex)
            {
                return "Failed";
            }
            return "Success";
        }
        public async Task<string> DeductInstallmentPaymentRevised(CreateInstallmentPayment payment)
        {
            try
            {


                var schedule = _scheduleAppService.GetScheduleByApplicationId(payment.ApplicationId).Result;
                var firstUnpaidInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber != "G*").FirstOrDefault();
                var indexOfLastPaidInstallment = schedule.installmentList.IndexOf(firstUnpaidInstallment) - 1;
                var acc = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                ScheduleInstallmenttListDto lastPaidInstallment = new ScheduleInstallmenttListDto();

                if (indexOfLastPaidInstallment != -1)
                {
                    lastPaidInstallment = schedule.installmentList[indexOfLastPaidInstallment];
                }

                var scheduleInstallment = _scheduleInstallmentRepository.Get(firstUnpaidInstallment.Id);
                decimal actualPayment = 0;
                decimal paidAmount = payment.Amount;
                decimal excessShortForLastPaidInstallment = 0;
                var Exists = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(payment.ApplicationId);
                if (Exists.Result != null || Exists.Result.Count >= 0)
                {
                    decimal existingAmountForSingleInstallment = 0;
                    foreach (var existingPayment in Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber && x.isAuthorized == true))
                    {
                        existingAmountForSingleInstallment += (existingPayment.Amount);//0
                    }

                    if (lastPaidInstallment != null)
                    {
                        if (lastPaidInstallment.InstNumber != "G*" && lastPaidInstallment.InstNumber != null && lastPaidInstallment.InstNumber != "")
                        {
                            var lastPaidinstallmentPayment = Exists.Result.Where(x => x.NoOfInstallment == Int32.Parse(lastPaidInstallment.InstNumber)).ToList();
                            if (lastPaidinstallmentPayment.Count == 1)
                            {
                                excessShortForLastPaidInstallment = lastPaidinstallmentPayment[0].ExcessShortPayment;
                            }
                            else if (lastPaidinstallmentPayment.Count > 1)
                            {
                                excessShortForLastPaidInstallment = lastPaidinstallmentPayment.LastOrDefault().ExcessShortPayment;
                            }
                        }
                        paidAmount += existingAmountForSingleInstallment + excessShortForLastPaidInstallment;
                    }

                    actualPayment = paidAmount;
                }

                decimal totalPaidForThisInst = paidAmount;
                paidAmount -= Decimal.Parse(scheduleInstallment.installmentAmount);

                payment.isAuthorized = true;
                _installmentPaymentAppService.Create(payment);


                decimal markupForThisInstallment = decimal.Parse(scheduleInstallment.markup == "--" ? "0" : scheduleInstallment.markup.Replace(",", ""));

                var gracePeriodInstallment = schedule.installmentList.Where(x => x.InstNumber == "G*").FirstOrDefault();
                if (gracePeriodInstallment != null)
                {
                    if (gracePeriodInstallment.isPaid != true)
                    {
                        var graceInstallment = _scheduleInstallmentRepository.Get(gracePeriodInstallment.Id);
                        decimal graceAmount = Decimal.Parse(graceInstallment.markup);
                        decimal gracePaidAmount = 0;
                        gracePaidAmount = totalPaidForThisInst - graceAmount;

                        if (gracePaidAmount >= -100)
                        {
                            decimal gracepayment = graceAmount - (totalPaidForThisInst - payment.Amount);

                            string n1 = "Grace Days Markup Collection";
                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, gracepayment, n1, payment.ModeOfPayment);
                            _scheduleAppService.SetPaid(graceInstallment.Id, "Installment", payment.DepositDate);

                            actualPayment -= graceAmount;
                        }
                        else
                        {
                            string n1 = "Grace Days Partial Markup Collection";
                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, totalPaidForThisInst, n1, payment.ModeOfPayment);
                            //_scheduleAppService.SetPaid(graceInstallment.Id, "Installment", payment.DepositDate);
                            actualPayment -= totalPaidForThisInst;
                        }

                        if (actualPayment < markupForThisInstallment)
                        {
                            string n1 = "Partial Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, actualPayment, n1, payment.ModeOfPayment);
                            actualPayment = 0;
                        }
                    }
                }


                if (scheduleInstallment.isMarkupPaid == false && actualPayment > 0)
                {
                    if (actualPayment >= markupForThisInstallment)
                    {
                        markupForThisInstallment -= (totalPaidForThisInst - payment.Amount);

                        if (excessShortForLastPaidInstallment > 0)
                        {
                            string n1 = "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n1, payment.ModeOfPayment);
                        }

                        if (excessShortForLastPaidInstallment < 0)
                        {
                            excessShortForLastPaidInstallment *= -1;

                            var matchingTransactions = acc.transactions.Where(x => x.Amount == excessShortForLastPaidInstallment).ToList();
                            if (matchingTransactions != null)
                            {
                                string n1 = "Previous Installment Deduction";
                                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n1, payment.ModeOfPayment);
                                actualPayment -= excessShortForLastPaidInstallment;
                                markupForThisInstallment -= excessShortForLastPaidInstallment;
                            }

                        }

                        if (gracePeriodInstallment != null)
                        {
                            if (scheduleInstallment.InstNumber == "1" && gracePeriodInstallment.isMarkupPaid)
                            {
                                markupForThisInstallment += decimal.Parse(gracePeriodInstallment.markup.Replace(",", ""));
                            }
                        }

                        string n2 = "Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, markupForThisInstallment, n2, payment.ModeOfPayment);
                        _scheduleAppService.SetPaid(scheduleInstallment.Id, "Markup", payment.DepositDate);

                        actualPayment -= (markupForThisInstallment + (totalPaidForThisInst - acc.Balance));

                        decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                        //var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                        if (actualPayment > 0)
                        {
                            if (actualPayment >= principalForThisInstallment)
                            {
                                //decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                                //var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                                //if (Exists.Result.Where(x => x.NoOfInstallment == Int32.Parse(scheduleInstallment.InstNumber)).Count() > 1)
                                //{
                                //    principalForThisInstallment -= (totalPaidForThisInst - payment.Amount - markupForThisInstallment);
                                //}

                                //principalForThisInstallment -= (totalPaidForThisInst - markupForThisInstallment);

                                if (actualPayment >= principalForThisInstallment)
                                {
                                    string n1 = "Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                    _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, principalForThisInstallment, n1, payment.ModeOfPayment);
                                    _scheduleAppService.SetPaid(scheduleInstallment.Id, "Principal", payment.DepositDate);
                                    actualPayment -= principalForThisInstallment;
                                }
                                else
                                {
                                    string n1 = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                    _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, actualPayment, n1, payment.ModeOfPayment);
                                    _scheduleAppService.SetPaid(scheduleInstallment.Id, "Markup", payment.DepositDate);
                                    actualPayment = 0;
                                }

                            }
                            else
                            {
                                string n1 = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, actualPayment, n1, payment.ModeOfPayment);
                                actualPayment -= principalForThisInstallment;
                            }
                        }

                    }
                    else
                    {
                        if (excessShortForLastPaidInstallment > 0)
                        {
                            string n2 = "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n2, payment.ModeOfPayment);
                        }

                        if (excessShortForLastPaidInstallment < 0)
                        {
                            excessShortForLastPaidInstallment *= -1;

                            var matchingTransactions = acc.transactions.Where(x => x.Amount == excessShortForLastPaidInstallment && x.Details.Contains("Previous Installment Deduction")).ToList();
                            if (matchingTransactions.Count == 0)
                            {
                                string n2 = "Previous Installment Deduction";
                                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, excessShortForLastPaidInstallment, n2, payment.ModeOfPayment);
                                actualPayment -= excessShortForLastPaidInstallment;
                                payment.Amount -= excessShortForLastPaidInstallment;
                            }
                        }

                        if (payment.Amount > 0)
                        {
                            string n1 = "Partial Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                            _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n1, payment.ModeOfPayment);
                        }
                        //actualPayment -= markupForThisInstallment;
                    }
                }
                else if (scheduleInstallment.isMarkupPaid == true)
                {
                    actualPayment -= markupForThisInstallment;

                    if (scheduleInstallment.InstNumber == "1")
                    {
                        var gDays = schedule.installmentList.Where(x => x.InstNumber == "G*").FirstOrDefault();
                        if (gDays != null)
                        {
                            actualPayment -= Decimal.Parse(gDays.markup.Replace(",", ""));
                        }
                    }

                    if (actualPayment > 0)
                    {
                        if (scheduleInstallment.isPrincipalPaid == false)
                        {
                            decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                            var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);


                            if (actualPayment >= (principalForThisInstallment - 100))
                            {
                                //principalForThisInstallment -= (totalPaidForThisInst - acc.Balance - markupForThisInstallment);

                                string n2 = "Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n2, payment.ModeOfPayment);
                                _scheduleAppService.SetPaid(scheduleInstallment.Id, "Principal", payment.DepositDate);

                                actualPayment -= (principalForThisInstallment - 100);

                                //if (scheduleInstallment.isPrincipalPaid == true)
                                //{
                                //    if (actualPayment > 0 && (principalForThisInstallment + markupForThisInstallment) < Decimal.Parse(scheduleInstallment.installmentAmount))
                                //    {
                                //        decimal amountToDeduct = Decimal.Parse(scheduleInstallment.installmentAmount) - (principalForThisInstallment + markupForThisInstallment);

                                //        string n3 = "Collection Inst No # " + scheduleInstallment.InstNumber;
                                //        _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, amountToDeduct, n3, payment.ModeOfPayment);
                                //        actualPayment -= amountToDeduct;
                                //    }
                                //}
                            }
                            else
                            {
                                string n3 = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n3, payment.ModeOfPayment);
                            }


                            actualPayment -= principalForThisInstallment;
                        }
                    }
                }
                //else
                //{
                //    string n3 = "Collection Inst No # " + scheduleInstallment.InstNumber;
                //    _customerAccountAppAppService.Debit(acc.Id, payment.ApplicationId, payment.Amount, n3, payment.ModeOfPayment);
                //}




                if (paidAmount >= -100)
                {
                    scheduleInstallment.isPaid = true;
                    scheduleInstallment.PaymentDate = payment.DepositDate;
                    _scheduleInstallmentRepository.Update(scheduleInstallment);
                    CurrentUnitOfWork.SaveChanges();


                    var allUnpaidInstallments = _scheduleInstallmentRepository.GetAllList(x => x.FK_ScheduleId == schedule.Id && (x.isPaid == false || x.isPaid == null));
                    if (allUnpaidInstallments.Count < 1)
                    {
                        _applicationAppService.ChangeApplicationState(ApplicationState.Settled, payment.ApplicationId, "All Installments Paid");

                        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                        fWobj.ApplicationId = payment.ApplicationId;
                        fWobj.Action = "All Installments Paid";
                        fWobj.ActionBy = (int)AbpSession.UserId;
                        fWobj.ApplicationState = ApplicationState.Settled;
                        fWobj.isActive = true;

                        _finalWorkflowAppService.CreateFinalWorkflow(fWobj);
                    }
                }

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
                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId && x.isAuthorized == true).ToList();
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

                var applications = _applicationAppService.GetApplicationList("", 0);

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

                        var app = applications.Where(x => x.Id == child.ApplicationId).FirstOrDefault();
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

        public async Task<List<AuthorizeInstallmentPaymentListDto>> GetAllAuthorizeInstallmentPaymentsUnAuthorized()
        {
            try
            {
                var AuthorizeInstallmentPayment = _AuthorizeInstallmentPaymentRepository.GetAllList(x => x.isAuthorized == null);
                var payments = ObjectMapper.Map<List<AuthorizeInstallmentPaymentListDto>>(AuthorizeInstallmentPayment);

                var applications = _applicationAppService.GetApplicationList("", 0);

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

                        var app = applications.Where(x => x.Id == child.ApplicationId).FirstOrDefault();
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

        public bool InstallmentPayment(CreateAuthorizeInstallmentPayment payment)
        {
            try
            {
                var paymentCreation = Create(payment);

                if (paymentCreation != -1)
                {
                    var paymentData = GetAuthorizeInstallmentPaymentById(paymentCreation).Result;
                    if (paymentData != null)
                    {
                        CreateInstallmentPayment installmentPayment = new CreateInstallmentPayment();

                        installmentPayment.ApplicationId = paymentData.ApplicationId;
                        installmentPayment.InstallmentDueDate = paymentData.InstallmentDueDate;
                        installmentPayment.InstallmentAmount = paymentData.InstallmentAmount;
                        installmentPayment.NoOfInstallment = paymentData.NoOfInstallment;
                        installmentPayment.PreviousBalance = paymentData.PreviousBalance;
                        installmentPayment.DueAmount = paymentData.DueAmount;
                        installmentPayment.ModeOfPayment = paymentData.ModeOfPayment;
                        installmentPayment.Amount = paymentData.Amount;
                        installmentPayment.ExcessShortPayment = paymentData.ExcessShortPayment;
                        installmentPayment.AmountWords = paymentData.AmountWords;
                        installmentPayment.LateDays = paymentData.LateDays;
                        installmentPayment.LateDaysPenalty = paymentData.LateDaysPenalty;
                        installmentPayment.DepositDate = DateTime.Parse(paymentData.DepositDate.ToString("yyyy-MM-dd hh:mm:ss tt"));
                        installmentPayment.isLateDaysApplied = paymentData.isLateDaysApplied;

                        CreateInstallmentPayment(installmentPayment);
                    }
                }
                return true;
            }
            catch //(Exception ex)
            {
                return false;
                //throw new UserFriendlyException(L("GetMethodError{0}", "payment"));
            }
        }

        public bool CreateInstallmentPayment(CreateInstallmentPayment payment)
        {
            try
            {
                var schedule = _scheduleAppService.GetScheduleByApplicationId(payment.ApplicationId).Result;
                if (schedule != null)
                {
                    if (schedule.installmentList.Where(x => x.InstNumber == payment.NoOfInstallment.ToString()).FirstOrDefault().isPaid != true)
                    {
                        var payments = _installmentPaymentAppService.GetAllInstallmentPaymentByApplicationId(payment.ApplicationId).Result;
                        if (payments == null)
                        {
                            AuthorizeInstallmentPayment(payment.AuthorizationId);

                            DeductInstallmentPaymentRevised(payment);
                        }
                        else
                        {
                            var lastpayment = payments.Where(x => x.NoOfInstallment == payment.NoOfInstallment).OrderByDescending(x => x.Id).FirstOrDefault();
                            if (lastpayment != null)
                            {
                                if ((DateTime.Now - lastpayment.CreationTime).TotalMinutes >= 10)
                                {
                                    AuthorizeInstallmentPayment(payment.AuthorizationId);

                                    DeductInstallmentPaymentRevised(payment);
                                }
                            }
                            else
                            {
                                AuthorizeInstallmentPayment(payment.AuthorizationId);

                                DeductInstallmentPaymentRevised(payment);
                            }
                        }

                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AuthorizeInstallmentPayment(int Id)
        {
            try
            {
                var getInstallmentPayment = _AuthorizeInstallmentPaymentRepository.Get(Id);
                if (getInstallmentPayment != null)
                {
                    getInstallmentPayment.isAuthorized = true;
                    _AuthorizeInstallmentPaymentRepository.Update(getInstallmentPayment);
                    CurrentUnitOfWork.SaveChanges();
                }

            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}
