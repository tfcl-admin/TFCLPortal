using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.CompanyBankAccounts.Dto;

namespace TFCLPortal.CompanyBankAccounts
{
  public  interface ICompanyBankAccountAppService : IApplicationService
    {

        CompanyBankAccountListDto GetCompanyBankAccountById(int Id);
        Task CreateCompanyBankAccount(CreateCompanyBankAccountDto input);
        Task<string> UpdateCompanyBankAccount(UpdateCompanyBankAccountDto input);
        List<CompanyBankAccountListDto> GetCompanyBankAccountListDetail();


    }
}
