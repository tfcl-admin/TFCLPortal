using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications.Dto;
using TFCLPortal.CustomerAccounts.Dto;

namespace TFCLPortal.CustomerAccounts
{
    public interface ICustomerAccountAppService : IApplicationService
    {
        CustomerAccountListDto GetCustomerAccountById(int Id);
        CustomerAccountListDto GetCustomerAccountByApplicationId(int ApplicationId);
        Task<string> CreateCustomerAccount(CreateCustomerAccountDto input);
        Task<string> UpdateCustomerAccount(UpdateCustomerAccountDto input);
        Task<CustomerAccountListDto> GetCustomerAccountByCNIC(string CNIC);
        List<CustomerAccountListDto> GetAllCustomerAccounts();
        bool CheckCustomerAccountByCNIC(string CNIC);
        List<ApplicationListDto> GetApplicationDetailsByAccountId(int AccountId);
        bool UpdateAccountBalance(int accountid, decimal balance);
    }
}
