using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ProductTypes
{
    public interface IProductTypeAppService : IApplicationService
    {
        Task<ListResultDto<ProductTypeListDto>> GetAllProductType();
        Task CreateProductType(CreateProductTypeDto input);
        List<ProductTypeListDto> GetAllList();
    }
}
