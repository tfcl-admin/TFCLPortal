using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.InventoryEntrySources
{
    public interface IInventoryEntrySourceAppService : IApplicationService
    {
        List<InventoryEntrySourceListDto> GetAllList();
        Task<ListResultDto<InventoryEntrySourceListDto>> GetAllApplicantSources();

    }
}
