using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.PropertyTypes
{
    public interface IPropertyTypeAppService : IApplicationService
    {
        Task<ListResultDto<PropertyTypeListDto>> GetAllPropertyType();
        Task CreatePropertyType(CreatePropertyTypeDto input);
        List<PropertyTypeListDto> GetAllList();
    }
}
