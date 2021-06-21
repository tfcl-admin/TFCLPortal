using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.WorkFlows.Dto;

namespace TFCLPortal.ApplicationWorkFlows.WorkFlows
{
  public  interface IWorkFlowAppService : IApplicationService
    {
        Task<WorkFlowListDto> GetWorkFlowById(int Id);
        Task CreateWorkFlow(CreateWorkFlowDto input);
        Task<string> UpdateWorkFlow(UpdateWorkFlowDto input);
        WorkFlowListDto GetWorkFlowByName(string name);
    }
}
