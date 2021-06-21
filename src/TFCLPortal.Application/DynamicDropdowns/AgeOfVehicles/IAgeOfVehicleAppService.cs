using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.AgeOfVehicles
{
    public interface IAgeOfVehicleAppService : IApplicationService
    {
        List<AgeOfVehicleListDto> GetAllList();
        Task<ListResultDto<AgeOfVehicleListDto>> GetAllAgeOfVehicle();
    }
}
