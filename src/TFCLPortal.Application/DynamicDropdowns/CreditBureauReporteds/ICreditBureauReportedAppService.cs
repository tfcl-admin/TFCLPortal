using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CreditBureauReporteds
{
    public interface ICreditBureauReportedAppService : IApplicationService
    {
        List<CreditBureauReportedListDto> GetAllList();
        Task<ListResultDto<CreditBureauReportedListDto>> GetAllCreditBureauReporteds();

    }
}

