using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CollateralTypes
{
    public interface ICollateralTypeAppService : IApplicationService
    {
        Task<ListResultDto<CollateralTypeListDto>> GetAllCollateralType();
        Task CreateCollateralType(CreateCollateralTypeDto input);
        List<CollateralTypeListDto> GetAllList();
    }
}
