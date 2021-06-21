using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.FinalWorkflows.Dto;

namespace TFCLPortal.FinalWorkflows
{
    public interface IFinalWorkflowAppService : IApplicationService
    {
        Task<string> CreateFinalWorkflow(CreateFinalWorkflowDto Input);
        List<FinalWorkflowListDto> GetAllList();
        List<FinalWorkflowListDto> GetFinalWorkflowByApplicationId(int ApplicationId);
        FinalWorkflowListDto GetLastFinalWorkflowByApplicationId(int ApplicationId);
        //string CreateFinalWorkflow(CreateFinalWorkflowDto Input, bool test);
    }
}
