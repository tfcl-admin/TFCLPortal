using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.MobilizationStatuses
{
    public interface IMobilizationStatusAppService : IApplicationService
    {
        Task<ListResultDto<MobilizationStatusListDto>> GetAllMobilizationStatus();
        Task CreateMobilizationStatus(CreateMobilizationStatusDto input);
        List<MobilizationStatusListDto> GetAllList();
    }
}
