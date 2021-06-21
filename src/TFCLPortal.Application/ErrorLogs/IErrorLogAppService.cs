using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ErrorLogs
{
    public interface IErrorLogAppService : IApplicationService
    {
        void SaveErrorLog(String FunctionName, String ErrorSubject, String ErrorDescription);

        List<ErrorLogDto> GetAllList();

    }
}
