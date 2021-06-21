using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DeviationApprovals.Dto;

namespace TFCLPortal.DeviationApprovals
{
    public interface IDeviationApprovalAppService : IApplicationService
    {
        Task<string> CreateDeviationApproval(CreateDeviationApprovalDto input);
        Task<string> UpdateDeviationApproval(UpdateDeviationApprovalDto input);
        DeviationApprovalListDto GetDeviationApprovalById(int Id);
        Task<List<DeviationApprovalListDto>> GetDeviationApprovalByApplicationId(int ApplicationId);
    }
}
