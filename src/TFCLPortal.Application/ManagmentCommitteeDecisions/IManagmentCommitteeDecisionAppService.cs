using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ManagmentCommitteeDecisions.Dto;

namespace TFCLPortal.ManagmentCommitteeDecisions
{
    public interface IManagmentCommitteeDecisionAppService : IApplicationService
    {
        ManagmentCommitteeDecisionListDto GetManagmentCommitteeDecisionById(int Id);
        Task CreateManagmentCommitteeDecision(CreateManagmentCommitteeDecisionDto input);
        Task<string> UpdateManagmentCommitteeDecision(UpdateManagmentCommitteeDecisionDto input);
        List<ManagmentCommitteeDecisionListDto> GetManagmentCommitteeDecisionList();
    }
}
