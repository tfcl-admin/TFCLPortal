using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Targets.Dto;

namespace TFCLPortal.Targets
{
    public interface ITargetAppService : IApplicationService
    {
        TargetListDto GetTargetById(int Id);
        Task<string> CreateTarget(CreateTargetDto input);
        Task<string> UpdateTarget(UpdateTargetDto input);
        List<TargetListDto> GetAllAlocatedTarget();
        List<TargetProducts> getProducts();
    }
}
