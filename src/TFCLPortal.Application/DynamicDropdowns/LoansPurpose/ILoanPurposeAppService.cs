using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoansPurpose
{
   public interface ILoanPurposeAppService : IApplicationService
    {
        Task<ListResultDto<LoanPurposeListDto>> GetAllLoanPurposeAsync();
        Task CreateLoanPurposeAsync(CreateLoanPurposeDto input);
        List<LoanPurposeListDto> GetAllList();
    }
}
