using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LandTypes
{
    public interface ILandTypeAppService : IApplicationService
    {
        Task<ListResultDto<LandTypeListDto>> GetAllLandType();
        Task CreateLandType(CreateLandTypeDto input);
        List<LandTypeListDto> GetAllList();
    }
}
