using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BranchManagerActions.Dto;

namespace TFCLPortal.BranchManagerActions
{
    public interface IBranchManagerActionAppService : IApplicationService
    {
        BranchManagerActionListDto GetBranchManagerActionById(int Id);
        List<BranchManagerActionListDto> GetBranchManagerActionByApplicationId(int ApplicationId);
        Task CreateBranchManagerAction(CreateBranchManagerActionDto input);
        Task<string> UpdateBranchManagerAction(UpdateBranchMangerActionDto input);
        string DeleteBranchManagerAction(BranchManagerActionListDto input);
        List<BranchManagerActionListDto> GetBranchManagerActionListDetail();

        List<DiscrepentScreensListDto> getDiscrepentedForms(int ApplicationId);

    }
}
