using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.Mobilizations.Dto;

namespace TFCLPortal.Applications
{
    public interface IApiCallLogAppService : IApplicationService
    {
        string CreateApplication(CreateApiCallLogDto input);
        List<ApiCallLogListDto> GetAllList();
    }
}
