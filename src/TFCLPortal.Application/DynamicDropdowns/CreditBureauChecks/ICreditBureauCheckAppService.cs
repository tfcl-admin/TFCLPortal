using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CreditBureauChecks
{
    public interface ICreditBureauCheckAppService : IApplicationService
    {
        List<CreditBureauCheckListDto> GetAllList();
        Task<ListResultDto<CreditBureauCheckListDto>> GetAllCreditBureauChecks();

    }
}

