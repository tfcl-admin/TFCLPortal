using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Occupations
{
    public interface IOccupationAppService : IApplicationService
    {
        Task<ListResultDto<OccupationListDto>> GetAllOccupation();
        Task CreateOccupation(CreateOccupationDto input);
        List<OccupationListDto> GetAllList();
    }
}
