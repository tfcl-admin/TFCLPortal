using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ReasonOfDeclines
{
    public interface IReasonOfDeclineAppService : IApplicationService
    {
        List<ReasonOfDeclineListDto> GetAllList();
        Task<ListResultDto<ReasonOfDeclineListDto>> GetAllReasonOfDeclines();

    }
}


