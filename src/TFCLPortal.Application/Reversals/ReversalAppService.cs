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
using TFCLPortal.Reversals.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.Transactions;
using TFCLPortal.InstallmentPayments;
using TFCLPortal.AuthorizeInstallmentPayments;
using TFCLPortal.Schedules;
using TFCLPortal.EarlySettlements;
using TFCLPortal.Applications.Dto;
using TFCLPortal.NotificationLogs;

namespace TFCLPortal.Reversals
{
    public class ReversalAppService : TFCLPortalAppServiceBase, IReversalAppService
    {
        private readonly IRepository<Reversal, Int32> _ReversalRepository;
        private readonly IRepository<CustomerAccount, Int32> _CustomerAccountRepository;
        private readonly IRepository<Transaction, Int32> _TransactionRepository;
        private readonly IRepository<InstallmentPayment, Int32> _InstallmentPaymentRepository;
        private readonly IRepository<Schedule, Int32> _ScheduleRepository;
        private readonly IRepository<ScheduleInstallment, Int32> _ScheduleInstallmentRepository;
        private readonly IRepository<AuthorizeInstallmentPayment, Int32> _AuthorizeInstallmentPaymentRepository;
        private readonly IRepository<EarlySettlement, Int32> _EarlySettlementRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly INotificationLogAppService _notificationLogAppService;

        private string Reversals = "Reversal";
        public ReversalAppService(INotificationLogAppService notificationLogAppService,IRepository<EarlySettlement, Int32> EarlySettlementRepository,IRepository<ScheduleInstallment, Int32> ScheduleInstallmentRepository,IRepository<Schedule, Int32> ScheduleRepository,IScheduleAppService scheduleAppService,IRepository<AuthorizeInstallmentPayment, Int32> AuthorizeInstallmentPaymentRepository, IRepository<InstallmentPayment, Int32> InstallmentPaymentRepository, IRepository<Transaction, Int32> TransactionRepository, IRepository<CustomerAccount, Int32> CustomerAccountRepository, IApplicationAppService applicationAppService, IRepository<Reversal, Int32> ReversalRepository)
        {
            _notificationLogAppService = notificationLogAppService;
            _EarlySettlementRepository = EarlySettlementRepository;
            _ScheduleInstallmentRepository = ScheduleInstallmentRepository;
            _ScheduleRepository = ScheduleRepository;
            _AuthorizeInstallmentPaymentRepository = AuthorizeInstallmentPaymentRepository;
            _InstallmentPaymentRepository = InstallmentPaymentRepository;
            _TransactionRepository = TransactionRepository;
            _CustomerAccountRepository = CustomerAccountRepository;
            _applicationAppService = applicationAppService;
            _ReversalRepository = ReversalRepository;
        }

        public async Task<string> CreateReversal(CreateReversalDto input)
        {
            string ResponseString = "";

            try
            {

                var Reversal = ObjectMapper.Map<Reversal>(input);
                await _ReversalRepository.InsertAsync(Reversal);
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", Reversals));
            }
        }

        public ReversalListDto GetReversalById(int Id)
        {
            try
            {
                var Reversal = _ReversalRepository.Get(Id);

                return ObjectMapper.Map<ReversalListDto>(Reversal);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Reversals));
            }
        }

        public List<ReversalListDto> GetReversals()
        {
            try
            {
                var Reversal = _ReversalRepository.GetAllList();
                var reversalLists = ObjectMapper.Map<List<ReversalListDto>>(Reversal);

                var apps = _applicationAppService.GetAllApplicationsList();
                var accounts = _CustomerAccountRepository.GetAllList();
                var transactions = _TransactionRepository.GetAllList();

                foreach (var item in reversalLists)
                {
                    if (item.TransactionId != 0)
                    {
                        var transaction = transactions.Where(x => x.Id == item.TransactionId && x.IsDeleted == false).FirstOrDefault();
                        var account = accounts.Where(x => x.Id == transaction.Fk_AccountId).FirstOrDefault();
                        var app = apps.Where(x => x.Id == transaction.ApplicationId).FirstOrDefault();

                        item.ClientId = app.ClientID;
                        item.ClientName = app.ClientName;
                        item.SchoolName = app.SchoolName;
                        item.Amount = transaction.Amount;
                        item.Balance = account.Balance;
                        item.CNIC = account.CNIC;

                    }
                }

                return reversalLists;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Reversals));
            }
        }

        public ReversalListDto GetReversalDetailsById(int id)
        {
            try
            {
                var Reversal = _ReversalRepository.Get(id);
                var reversal = ObjectMapper.Map<ReversalListDto>(Reversal);

                var apps = _applicationAppService.GetAllApplicationsList();
                var accounts = _CustomerAccountRepository.GetAllList();
                var transactions = _TransactionRepository.GetAllList();

                if (reversal.TransactionId != 0)
                {
                    var transaction = transactions.Where(x => x.Id == reversal.TransactionId).FirstOrDefault();
                    var account = accounts.Where(x => x.Id == transaction.Fk_AccountId).FirstOrDefault();
                    var transactionList = transactions.Where(x => x.Fk_AccountId == account.Id && x.Id>=reversal.TransactionId).ToList();
                    var app = apps.Where(x => x.Id == transaction.ApplicationId).FirstOrDefault();

                    reversal.ClientId = app.ClientID;
                    reversal.ClientName = app.ClientName;
                    reversal.SchoolName = app.SchoolName;
                    reversal.Amount = transaction.Amount;
                    reversal.Balance = account.Balance;
                    reversal.CNIC = account.CNIC;
                    reversal.transactions = transactionList;

                }

                return reversal;


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Reversals));
            }
        }

        public bool ReversalAuthorization(int Id, string Decision, string Reason)
        {
            if (Decision == "Authorize")
            {
                var reversal = GetReversalDetailsById(Id);

                bool isInstallmentPaid = false;
                bool isEarlySettled = false;

                decimal amountToBeReversed = 0;

                if (reversal.transactions.Count > 1)
                {
                    foreach (var transaction in reversal.transactions)
                    {
                        if (transaction.Id != reversal.TransactionId)
                        {
                            var revTrans = _TransactionRepository.Get(transaction.Id);
                            revTrans.isReversed = true;
                            amountToBeReversed += revTrans.Amount;
                            _TransactionRepository.Update(revTrans);
                            CurrentUnitOfWork.SaveChanges();

                            if (transaction.Details.Contains("Principal Collection") || transaction.Details.Contains("Markup Collection"))
                            {
                                isInstallmentPaid = true;
                            }

                            if (transaction.Details.Contains("Early Settlement Charges"))
                            {
                                isEarlySettled = true;
                            }
                        }

                    }

                    Transaction t = new Transaction();
                    t.Amount = amountToBeReversed;
                    t.DepositDate = DateTime.Now;
                    t.Type = "Reversal";
                    t.Details = "Reversal of Entry; Amount : " + reversal.Amount + ", Deposit Date : " + reversal.transactions[0].DepositDate.ToString("dd-MMM-yyyy");
                    t.ApplicationId = reversal.transactions[0].ApplicationId;
                    t.Reference = "Reversal";
                    t.Fk_AccountId = reversal.transactions[0].Fk_AccountId;
                    t.AmountWords = "";
                    t.ModeOfPaymentOther = reversal.transactions[0].ModeOfPaymentOther;
                    t.ModeOfPayment = reversal.transactions[0].ModeOfPayment;
                    t.CompanyBankId = reversal.transactions[0].CompanyBankId;
                    t.BalBefore = reversal.transactions[0].BalBefore;
                    t.BalAfter = reversal.transactions[0].BalAfter;
                    t.isAuthorized = true;
                    _TransactionRepository.Insert(t);

                    CustomerAccount ca = _CustomerAccountRepository.Get(reversal.transactions[0].Fk_AccountId);
                    ca.Balance = (amountToBeReversed + ca.Balance);
                    _CustomerAccountRepository.Update(ca);

                }
                else if (reversal.transactions.Count == 1)
                {
                    var revTrans = _TransactionRepository.Get(reversal.TransactionId);
                    revTrans.isReversed = true;
                    _TransactionRepository.Update(revTrans);
                    CurrentUnitOfWork.SaveChanges();

                    CustomerAccount ca = _CustomerAccountRepository.Get(reversal.transactions[0].Fk_AccountId);
                    ca.Balance -=revTrans.Amount;
                    _CustomerAccountRepository.Update(ca);
                }



                //Installment Payments
                if (isInstallmentPaid)
                {
                    List<int> instNumber = new List<int>();
                    int applicationid = reversal.transactions[0].ApplicationId;

                    foreach (var item in reversal.transactions)
                    {
                        if (reversal.transactions.IndexOf(item) != 0)
                        {
                            if (item.Details.Contains("Inst No # "))
                            {
                                try
                                {
                                    string tmpstr = item.Details;
                                    tmpstr = tmpstr.Replace("Partial Markup Collection Inst No # ", "");
                                    tmpstr = tmpstr.Replace("Markup Collection Inst No # ", "");
                                    tmpstr = tmpstr.Replace("Markup Collection from Previous Balance Inst No # ", "");
                                    tmpstr = tmpstr.Replace("Partial Principal Collection Inst No # ", "");
                                    tmpstr = tmpstr.Replace("Principal Collection Inst No # ", "");
                                    tmpstr = tmpstr.Replace("Collection Inst No # ", "");

                                    //int inst = Int32.Parse(tmpstr);
                                    int inst = Convert.ToInt32(tmpstr);
                                    instNumber.Add(inst);
                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                            }
                        }
                    }

                    if (instNumber != null)
                    {
                        var schedule = _ScheduleRepository.GetAllList(x => x.ApplicationId == applicationid).FirstOrDefault();
                        var scheduleinstallments = _ScheduleInstallmentRepository.GetAllList(x => x.FK_ScheduleId == schedule.Id).ToList();
                        foreach (var item in instNumber)
                        {
                            var installmentpayments = _InstallmentPaymentRepository.GetAllList(x => x.ApplicationId == applicationid && x.NoOfInstallment == item);
                            if (installmentpayments != null)
                            {
                                foreach(var payment in installmentpayments)
                                {
                                    _InstallmentPaymentRepository.Delete(payment);
                                }
                            }
                            var installmentpaymentsauthorizations = _AuthorizeInstallmentPaymentRepository.GetAllList(x => x.ApplicationId == applicationid && x.NoOfInstallment == item);
                            if (installmentpaymentsauthorizations != null)
                            {
                                foreach (var payment in installmentpaymentsauthorizations)
                                {
                                    _AuthorizeInstallmentPaymentRepository.Delete(payment);
                                }
                            }

                            if(scheduleinstallments!=null)
                            {
                                var currentInst = scheduleinstallments.Where(x => x.InstNumber == item.ToString()).FirstOrDefault();
                                currentInst.isMarkupPaid = false;
                                currentInst.isPrincipalPaid = false;
                                currentInst.isPaid = false;
                                currentInst.PaymentDate = null;
                                _ScheduleInstallmentRepository.Update(currentInst);
                            }

                        }




                    }


                }

                //Early Settlement
                if (isEarlySettled)
                {
                    int applicationid = reversal.transactions[0].ApplicationId;

                    var earlySettlment = _EarlySettlementRepository.GetAllList(x => x.ApplicationId == applicationid).FirstOrDefault();
                    _EarlySettlementRepository.Delete(earlySettlment);
                    _applicationAppService.ChangeApplicationState(ApplicationState.Disbursed, applicationid, "Disbursed after Early Settlement Reversal");
                }
                //Reversal Authorization
                var rev = _ReversalRepository.Get(Id);
                rev.isAuthorized = true;
                _ReversalRepository.Update(rev);
                CurrentUnitOfWork.SaveChanges();


                _notificationLogAppService.SendNotification(63, "Reversal Approved", "Reversal entry against Client ID : "+reversal.ClientId+" has been authorized");

            }
            else if (Decision == "Reject")
            {
                var rev = _ReversalRepository.Get(Id);
                rev.isAuthorized = false;
                _ReversalRepository.Update(rev);
                CurrentUnitOfWork.SaveChanges();
            }

            return true;
        }
    }
}
