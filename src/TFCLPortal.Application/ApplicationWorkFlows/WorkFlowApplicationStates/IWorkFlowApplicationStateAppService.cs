using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;

namespace TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates
{
   public interface IWorkFlowApplicationStateAppService : IApplicationService
    {
        Task<WorkFlowApplicationStateListDto> GetWorkFlowApplicationStateDetailById(int Id);
        Task CreateWorkFlowApplicationState(CreateWorkFlowApplicationStateDto input);
        Task<string> UpdateWorkFlowApplicationState(UpdateWorkFlowApplicationStateDto input);
        WorkFlowApplicationStateListDto GetLastActiveWorkFlow(int ApplicationId);
        WorkFlowApplicationStateListDto GetLastActiveWorkFlowByState(int ApplicationId,string State);
        Task<WorkFlowApplicationStateListDto> GetWorkFlowApplicationStateListByApplicationId(int ApplicationId);
    }
}
