using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ProductMarkupRates.Dto;

namespace TFCLPortal.ProductMarkupRates
{
    public interface IProductAppService : IApplicationService
    {
        ProductListDto GetProductById(int Id);
        Task CreateProduct(CreateProductDto input);
        Task<string> UpdateProduct(UpdateProductDto input);
        List<ProductListDto> GetAllProducts();
    }
}
