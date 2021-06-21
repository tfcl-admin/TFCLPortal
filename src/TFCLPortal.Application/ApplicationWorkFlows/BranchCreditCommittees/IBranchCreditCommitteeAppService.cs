using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees.Dto;

namespace TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees
{
   public interface IBranchCreditCommitteeAppService : IApplicationService
    {
        BranchCreditCommitteeListDto GetBranchCreditCommitteeListDetailById(int Id);
        int CreateBranchCreditCommitteeDetail(CreateBranchCreditCommitteeDto input);
        Task<string> UpdateBranchCreditCommittee(UpdateBranchCreditCommitteeDto input);
        BranchCreditCommitteeListDto GetBranchCreditCommitteeListByApplicationId(int ApplicationId);
        List<BranchCreditCommitteeListDto> GetBranchCreditCommitteeList();
        List<BranchCreditCommitteeListDto> GetBranchCreditCommitteeListSDEUserId(int SDEUserId);
        Task<List<ApplicationDto>> GetBranchCreditCommitteeListByScreenCode(string applicationState, int? branchId, bool showAll = false,bool IsAdmin=false);
    }
}
