using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Ownership
{
   public interface IOwnershipAppService : IApplicationService
    {
        Task<ListResultDto<OwnershipStatusListDto>> GetAllOwnershipStatus();
        Task CreateOwnershipStatus(CreateOwnershipStatusDto input);
        List<OwnershipStatusListDto> GetAllList();
    }
}
