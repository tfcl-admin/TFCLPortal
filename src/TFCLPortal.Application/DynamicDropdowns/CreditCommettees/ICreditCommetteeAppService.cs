using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CreditCommettees
{
    public interface ICreditCommetteeAppService : IApplicationService
    {
        Task<ListResultDto<CreditCommetteeListDto>> GetAllCreditCommettee();
        Task CreateCreditCommettee(CreateCreditCommetteeDto input);
        List<CreditCommetteeListDto> GetAllList();
    }
}
