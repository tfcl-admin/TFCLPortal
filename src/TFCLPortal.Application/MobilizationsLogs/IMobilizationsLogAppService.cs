using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.MobilizationsLogs.Dto;

namespace TFCLPortal.MobilizationsLogs
{
    public interface IMobilizationsLogAppService : IApplicationService
    {
        MobilizationsLogResponse CreateMobilizationsLog(CreateMobilizationsLogDto input);

        List<MobilizationsLogListDto> GetMobilizationsLogList();

    }
}
