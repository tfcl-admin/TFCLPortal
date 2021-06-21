using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ICollateralOwnerships
{
    public interface ICollateralOwnAppService : IApplicationService
    {
        Task<ListResultDto<CollateralOwnershipListDto>> GetAllCollateralOwnership();
        Task CreateCollateralOwnership(CreateCollateralOwnershipDto input);
        List<CollateralOwnershipListDto> GetAllList();
    }
}
