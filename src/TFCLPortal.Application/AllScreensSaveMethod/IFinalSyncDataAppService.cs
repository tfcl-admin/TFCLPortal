using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AllScreensSaveMethod.Dto;

namespace TFCLPortal.AllScreensSaveMethod
{
    public interface IFinalSyncDataAppService :IApplicationService
    {
        Task<string> FinalSyncDataToServer(FinalSyncDto createFinalSync);
    }
}
