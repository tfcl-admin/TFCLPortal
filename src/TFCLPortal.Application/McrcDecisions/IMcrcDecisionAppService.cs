using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.McrcDecisions.Dto;

namespace TFCLPortal.McrcDecisions
{
    public interface IMcrcDecisionAppService : IApplicationService
    {
        McrcDecisionListDto GetMcrcDecisionById(int Id);
        Task CreateMcrcDecision(CreateMcrcDecisionDto input);
        Task<string> UpdateMcrcDecision(UpdateMcrcDecisionDto input);
        List<McrcDecisionListDto> GetMcrcDecisionList();
    }
}
