using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;

namespace TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates
{
  public  interface IApplicationDescripantDeclineStateAppService : IApplicationService
    {
        Task<ApplicationDescripantDeclineStateListDto> GetApplicationDescripantDeclineById(int Id);
        Task CreateApplicationDescripantDecline(CreateApplicationDescripantDeclineStateDto input);
        Task<string> UpdateApplicationDescripantDecline(UpdateApplicationDescripantDeclineStateDto input);
        Task<ApplicationDescripantDeclineStateListDto> GetApplicationDescripantDeclineApplicationId(int ApplicationId);
    }
}
