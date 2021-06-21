using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BankAccountDetails.Dto;

namespace TFCLPortal.BankAccountDetails
{
  public interface IBankAccountAppService : IApplicationService
    {
        Task <List<BankAccountListDto>> GetBankAccountDetailById(int Id);
        Task CreateBankDetail(CreateBankAccountDto input, int applicationId);
        bool CheckBankAccountDetailByApplicationId(int ApplicationId);
        Task<string> UpdateBankAccountDetail(List<UpdateBankDto> input);
        Task <List<BankAccountListDto>> GetBankAccountDetailByApplicationId(int ApplicationId);
    }
}
