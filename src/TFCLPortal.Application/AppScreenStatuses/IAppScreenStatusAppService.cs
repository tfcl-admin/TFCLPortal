using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AppScreenStatuses.Dto;

namespace TFCLPortal.AppScreenStatuses
{
   public interface IAppScreenStatusAppService : IApplicationService
    {
        Task<AppScreenStatusListDto> GetAppScreenStatusById(int Id);
        Task CreateAppScreenStatus(CreateAppScreenStatusDto input);
        Task<string> UpdateAppScreenStatus(UpdateAppScreenStatusDto input);
    }
}
