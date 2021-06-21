using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LoanTenureRequireds
{
    public interface ILoanTenureRequiredAppService : IApplicationService
    {
        Task<ListResultDto<LoanTenureRequiredListDto>> GetAllLoanTenureRequired();
        Task CreateLoanTenureRequired(CreateLoanTenureRequiredDto input);
        List<LoanTenureRequiredListDto> GetAllList();
    }
}
