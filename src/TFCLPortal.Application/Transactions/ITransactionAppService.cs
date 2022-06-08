using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Transactions.Dto;

namespace TFCLPortal.Transactions
{
  public  interface ITransactionAppService : IApplicationService
    {

        TransactionListDto GetTransactionById(int Id);
        Task CreateTransaction(CreateTransactionDto input);
        Task<string> UpdateTransaction(UpdateTransactionDto input);
        List<TransactionListDto> GetTransactionListDetail();
        List<TransactionListDto> GetTransactionByAccountId(int AccountId);
        List<TransactionListDto> GetUnAuthTransactionListDetail();
    }
}
