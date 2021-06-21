using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Districts
{
    public interface IDistrictAppService : IApplicationService
    {
        Task<ListResultDto<DistrictListDto>> GetAllDistrict();
        Task CreateDistrict(CreateDistrictDto input);
        List<DistrictListDto> GetAllList();
    }
}
