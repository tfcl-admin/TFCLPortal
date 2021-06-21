using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BccDecisions.Dto;

namespace TFCLPortal.BccDecisions
{
    public interface IBccDecisionAppService : IApplicationService
    {
        BccDecisionListDto GetBccDecisionById(int Id);
        Task CreateBccDecision(CreateBccDecisionDto input);
        Task<string> UpdateBccDecision(UpdateBccDecisionDto input);
        List<BccDecisionListDto> GetBccDecisionList();
    }
}
