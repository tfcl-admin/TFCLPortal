using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.TFSLoanTenureRequireds
{
    public interface ITFSLoanTenureRequiredAppService : IApplicationService
    {
        Task<ListResultDto<TFSLoanTenureRequiredListDto>> GetAllTFSLoanTenureRequired();
        Task CreateTFSLoanTenureRequired(CreateTFSLoanTenureRequiredDto input);
        List<TFSLoanTenureRequiredListDto> GetAllList();
    }
}
