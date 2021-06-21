using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ProductMarkupRates.Dto;

namespace TFCLPortal.ProductMarkupRates
{
    public interface IProductDetailAppService : IApplicationService
    {
        ProductDetailListDto GetProductDetailById(int Id);
        Task CreateProductDetail(CreateProductDetailDto input);
        Task<string> UpdateProductDetail(UpdateProductDetailDto input);
        List<ProductDetailListDto> GetAllProductDetail();
        List<ProductDetailListDto> GetProductDetailByProductId(int Fk_ProductKey);
    }
}
