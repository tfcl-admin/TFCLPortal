using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DescripentScreens.Dto;

namespace TFCLPortal.DescripentScreens
{
    public interface IDescripentScreenAppService : IApplicationService
    {
        DescripentScreenListDto GetDescripentScreenById(int Id);
        Task CreateDescripentScreen(CreateDescripentScreenDto input);
        Task<string> UpdateDescripentScreen(UpdateDescripentScreenDto input);
        DescripentScreenListDto GetDescripentScreenByApplicationId(int ApplicationId, int Fk_screenId, string ScreenStatus);
    }
}
