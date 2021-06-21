using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Provinces
{
    public interface IProvinceAppService : IApplicationService
    {
        Task<ListResultDto<ProvinceListDto>> GetAllProvince();
        Task CreateProvince(CreateProvinceDto input);
        List<ProvinceListDto> GetAllList();
    }
}
