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
using TFCLPortal.Branches;
using TFCLPortal.CustomerAccounts.Dto;
using TFCLPortal.DynamicDropdowns.Districts;
using TFCLPortal.DynamicDropdowns.Ownership;
using TFCLPortal.DynamicDropdowns.Provinces;
using TFCLPortal.DynamicDropdowns.RentAgreementSignatories;
using TFCLPortal.Transactions;

namespace TFCLPortal.CustomerAccounts
{
    public class CustomerAccountAppService : TFCLPortalAppServiceBase, ICustomerAccountAppService
    {
        private readonly IRepository<CustomerAccount, Int32> _CustomerAccountRepository;
        private readonly IRepository<Transaction, Int32> _TransactionRepository;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ITransactionAppService _transactionAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private string CustomerAccounts = "Contact Detail";
        public CustomerAccountAppService(IRepository<CustomerAccount, Int32> CustomerAccountRepository,
            IRepository<OwnershipStatus> ownershipStatusRepository,
            IRepository<Province> provinceRepository,
            ITransactionAppService transactionAppService,
            IBranchDetailAppService branchDetailAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<Transaction, Int32> TransactionRepository,
            IApplicationAppService applicationAppService,
            IRepository<RentAgreementSignatory> rentAgreementSignatoryRepository,
            IRepository<District> districtRepository)
        {
            _transactionAppService = transactionAppService;
            _CustomerAccountRepository = CustomerAccountRepository;
            _applicationAppService = applicationAppService;
            _apiCallLogAppService = apiCallLogAppService;
            _TransactionRepository = TransactionRepository;
            _branchDetailAppService= branchDetailAppService;
        }
        public async Task<string> CreateCustomerAccount(CreateCustomerAccountDto input)
        {
            string ResponseString = "";

            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateCustomerAccount";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _CustomerAccountRepository.GetAllList().Where(x => x.CNIC == input.CNIC).FirstOrDefault();

                if (IsExist != null)
                {
                    var Customer = _CustomerAccountRepository.Get(IsExist.Id);
                    await _CustomerAccountRepository.DeleteAsync(Customer);
                }
                
                    var CustomerAccount = ObjectMapper.Map<CustomerAccount>(input);
                    await _CustomerAccountRepository.InsertAsync(CustomerAccount);

                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", CustomerAccounts));
            }
        }

        public  CustomerAccountListDto GetCustomerAccountById(int Id)
        {
            try
            {
                var CustomerAccount =  _CustomerAccountRepository.Get(Id);

                return ObjectMapper.Map<CustomerAccountListDto>(CustomerAccount);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }



        public async Task<string> UpdateCustomerAccount(UpdateCustomerAccountDto input)
        {
            string ResponseString = "";
            try
            {
                var CustomerAccount = _CustomerAccountRepository.Get(input.Id);
                if (CustomerAccount != null && CustomerAccount.Id > 0)
                {
                    ObjectMapper.Map(input, CustomerAccount);
                    await _CustomerAccountRepository.UpdateAsync(CustomerAccount);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", CustomerAccounts));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", CustomerAccounts));
            }
        }

        public async Task<CustomerAccountListDto> GetCustomerAccountByCNIC(string CNIC)
        {
            try
            {
                var CustomerAccount =  _CustomerAccountRepository.FirstOrDefault(x=>x.CNIC==CNIC);

                var contact= ObjectMapper.Map<CustomerAccountListDto>(CustomerAccount);

                if (contact != null)
                {
                    //if (contact.OwnershipStatus != 0)
                    //{
                    //    var OwnershipStatus = _ownershipStatusRepository.Get(contact.OwnershipStatus);
                    //    contact.OwnershipStatusName = OwnershipStatus.Name;
                    //}
                    //if (contact.permanentProvince != 0)
                    //{
                    //    var permanentProvince = _provinceRepository.Get(contact.permanentProvince);
                    //    contact.PermanentProvinceName = permanentProvince.Name;
                    //}
                    //if (contact.PresentProvince != 0)
                    //{
                    //    var presentprovince = _provinceRepository.Get(contact.PresentProvince);
                    //    contact.PresentProvinceName = presentprovince.Name;
                    //}
                    //if (contact.permanentDistrict != 0)
                    //{
                    //    var permanentDistrict = _districtRepository.Get(contact.permanentDistrict);
                    //    contact.PermanentDistrictName = permanentDistrict.Name;
                    //}
                    //if (contact.PresentDistrict != 0)
                    //{
                    //    var PresentDistrict = _districtRepository.Get(contact.PresentDistrict);
                    //    contact.PresentDistrictName = PresentDistrict.Name;
                    //}
                    //if (contact.RentAgreementSignatory != null && contact.RentAgreementSignatory != 0)
                    //{
                    //    var RentAgreementSignatory = _rentAgreementSignatoryRepository.Get((int)contact.RentAgreementSignatory);
                    //    contact.RentAgreementSignatoryName = RentAgreementSignatory.Name;
                    //}
                    //if(contact.CurrentAddressSince!=null)
                    //{
                    //    if (contact.LastModificationTime != null)
                    //    {
                    //    contact.currentAddressDuration = getDuration((DateTime)contact.CurrentAddressSince, (DateTime)contact.LastModificationTime);
                    //    }
                    //    else
                    //    {
                    //        contact.currentAddressDuration = getDuration((DateTime)contact.CurrentAddressSince, contact.CreationTime);
                    //    }
                    //}

                }
                return contact;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }

        public CustomerAccountListDto GetCustomerAccountByCNICwithTransactions(string CNIC)
        {
            try
            {
                var CustomerAccount = _CustomerAccountRepository.FirstOrDefault(x => x.CNIC == CNIC);

                var contact = ObjectMapper.Map<CustomerAccountListDto>(CustomerAccount);

                if (contact != null)
                {
                    contact.transactions = _transactionAppService.GetTransactionByAccountId(contact.Id);
                }
                return contact;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }

        public bool CheckCustomerAccountByCNIC(string CNIC)
        {
            try
            {
                var CustomerAccount = _CustomerAccountRepository.GetAllList().Where(x => x.CNIC == CNIC).FirstOrDefault();
                if (CustomerAccount != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }

        public List<CustomerAccountListDto> GetAllCustomerAccounts()
        {
            try
            {
                var CustomerAccount = _CustomerAccountRepository.GetAllList();

                var apps = _applicationAppService.GetAllApplicationsList();

                var branches = _branchDetailAppService.GetBranchListDetail();

                var contact = ObjectMapper.Map<List<CustomerAccountListDto>>(CustomerAccount);

                foreach(var acc in contact)
                {
                    var app = apps.Where(x => x.CNICNo == acc.CNIC && x.ScreenStatus == "Disbursed").FirstOrDefault();
                    if(app!=null)
                    {
                        acc.ClientId = app.ClientID;
                        var branch= branches.Where(x => x.Id == app.FK_branchid).FirstOrDefault();
                        acc.Branch = branch.BranchCode;
                    }
                    else
                    {
                        app = apps.Where(x => x.CNICNo == acc.CNIC && (x.ScreenStatus.Contains("Settled")|| x.ScreenStatus.Contains("Deceased") || x.ScreenStatus.Contains("Write"))).FirstOrDefault();
                        if (app != null)
                        {
                            var branch = branches.Where(x => x.Id == app.FK_branchid).FirstOrDefault();
                            acc.Branch = branch.BranchCode;

                            if (app.ScreenStatus=="Settled")
                            {
                                acc.ClientId = app.ClientID+" (s)";
                            }
                            else if (app.ScreenStatus == "Early Settled")
                            {
                                acc.ClientId = app.ClientID + " (es)";
                            }
                            else if (app.ScreenStatus == "Deceased")
                            {
                                acc.ClientId = app.ClientID + " (d)";
                            }
                            else if (app.ScreenStatus == "Write Off")
                            {
                                acc.ClientId = app.ClientID + " (WO)";
                            }
                            else
                            {
                                acc.ClientId = app.ClientID;
                            }
                        }
                    }
                }
               
                return contact;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }

        public List<ApplicationListDto> GetApplicationDetailsByAccountId(int AccountId)
        {
            try
            {
                var account = _CustomerAccountRepository.Get(AccountId);
                var loans = _applicationAppService.GetAllApplicationsList().Where(x => x.CNICNo == account.CNIC && x.ScreenStatus!=ApplicationState.Decline).ToList();
                return loans;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }

        public CustomerAccountListDto GetCustomerAccountByApplicationId(int ApplicationId)
        {
            try
            {
                var app = _applicationAppService.GetApplicationById(ApplicationId);
                var CustomerAccount = _CustomerAccountRepository.GetAllList(x=>x.CNIC==app.CNICNo).FirstOrDefault();
                var result = ObjectMapper.Map<CustomerAccountListDto>(CustomerAccount);

                if (result != null)
                {
                    result.transactions = _transactionAppService.GetTransactionByAccountId(result.Id);
                }


                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", CustomerAccounts));
            }
        }

        public bool UpdateAccountBalance(int accountid,decimal balance)
        {
            try
            {
                var app = _CustomerAccountRepository.Get(accountid);
                app.Balance = balance;
                _CustomerAccountRepository.Update(app);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Debit(int accountid,int Applicationid, decimal amount,string Narration,string modeOfPayment)
        {
            try
            {
                var acc = GetCustomerAccountByApplicationId(Applicationid);
                Transaction transaction = new Transaction();
                transaction.AmountWords = NumberToWords((int)amount);
                transaction.Type = "Debit";
                transaction.Details = Narration;// "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                transaction.ModeOfPayment = modeOfPayment;// payment.ModeOfPayment;
                transaction.isAuthorized = true;
                transaction.Fk_AccountId = accountid;// acc.Id;
                transaction.ApplicationId = Applicationid;// payment.ApplicationId;
                transaction.BalBefore = acc.Balance;
                transaction.Amount = amount;// excessShortForLastPaidInstallment;
                transaction.BalAfter = (acc.Balance-amount);
                var t1 = _TransactionRepository.Insert(transaction);
                var c1 = UpdateAccountBalance(acc.Id, transaction.BalAfter);
                CurrentUnitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }


    }
}
