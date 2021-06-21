using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.UpdateAllScreens.Dto;

namespace TFCLPortal.UpdateAllScreens
{
    public interface IUpdateAllScreenAppService : IApplicationService
    {
        Task<string> UpdateAllScreensData(UpdateAllScreenDto updateAllScreen);
        Task<List<string>> SubmitApplication(int ApplicationId, int SDE_ID);
        Task<List<string>> ReSubmitApplication(int ApplicationId, int SDE_ID);
        List<int> getUserIdsByPermission(int branchId, string role);
    }
}
