using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.Transactions.Dto;

namespace TFCLPortal.Transactions.Dto
{
    public class TransactionAppService : TFCLPortalAppServiceBase, ITransactionAppService
    {
        private readonly IRepository<Transaction, Int32> _TransactionRepository;
        private readonly IRepository<CustomerAccount, Int32> _CustomerAccountRepository;
        private readonly IRepository<Applicationz, Int32> _ApplicationzRepository;
        private string company = "Transaction";
        public TransactionAppService(IRepository<Applicationz, Int32> ApplicationzRepository, IRepository<CustomerAccount, Int32> CustomerAccountRepository, IRepository<Transaction, Int32> TransactionRepository)
        {
            _ApplicationzRepository = ApplicationzRepository;
            _CustomerAccountRepository = CustomerAccountRepository;
            _TransactionRepository = TransactionRepository;
        }
        public async Task CreateTransaction(CreateTransactionDto input)
        {
            try
            {
                var Transaction = ObjectMapper.Map<Transaction>(input);
                await _TransactionRepository.InsertAsync(Transaction);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", company));
            }
        }
        public TransactionListDto GetTransactionById(int Id)
        {
            try
            {
                var Transaction = _TransactionRepository.Get(Id);

                return ObjectMapper.Map<TransactionListDto>(Transaction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }

        }
        public List<TransactionListDto> GetTransactionByAccountId(int AccountId)
        {
            try
            {
                var Transaction = _TransactionRepository.GetAllList(x => x.Fk_AccountId == AccountId).ToList();
                var returnList=ObjectMapper.Map<List<TransactionListDto>>(Transaction);
                var apps = _ApplicationzRepository.GetAllList();
                if (returnList.Count>0)
                {
                    foreach(var tr in returnList)
                    {
                        if(tr.ApplicationId!=0)
                        {
                            var app= apps.Where(x => x.Id == tr.ApplicationId).FirstOrDefault();
                            tr.ClientID = app.ClientID;
                        }
                    }
                }

                return returnList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }

        }
        public List<TransactionListDto> GetTransactionListDetail()
        {
            try
            {
                var Transaction = _TransactionRepository.GetAllList();

                var TransactionMapped = ObjectMapper.Map<List<TransactionListDto>>(Transaction);

                foreach (var tran in TransactionMapped)
                {
                    var acc = _CustomerAccountRepository.Get(tran.Fk_AccountId);
                    tran.Name = acc.Name;
                    tran.CNIC = acc.CNIC;
                }

                return TransactionMapped;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }
        }

        public async Task<string> UpdateTransaction(UpdateTransactionDto input)
        {
            string ResponseString = "";
            try
            {
                var Transaction = _TransactionRepository.Get(input.Id);
                if (Transaction != null && Transaction.Id > 0)
                {
                    ObjectMapper.Map(input, Transaction);
                    await _TransactionRepository.UpdateAsync(Transaction);
                    CurrentUnitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", company));
            }
            return ResponseString;
        }

        public List<TransactionListDto> GetUnAuthTransactionListDetail()
        {
            try
            {
                var Transaction = _TransactionRepository.GetAllList(x => x.isAuthorized == null);

                var TransactionMapped = ObjectMapper.Map<List<TransactionListDto>>(Transaction);

                foreach (var tran in TransactionMapped)
                {
                    var acc = _CustomerAccountRepository.Get(tran.Fk_AccountId);
                    tran.Name = acc.Name;
                    tran.CNIC = acc.CNIC;
                }

                return TransactionMapped;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }
        }
    }
}
