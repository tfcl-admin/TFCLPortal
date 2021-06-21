using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Branches.Dto;

namespace TFCLPortal.Branches
{
 
  public  interface IBranchDetailAppService : IApplicationService
    {
        BranchDetailList GetBranchDetailById(int Id);
        Task CreateBranchDetail(CreateBranchDetail input);
        Task<string> UpdateBranchDetail(UpdateBranchDetail input);
        List<BranchDetailList> GetBranchListDetail();
    }
}
