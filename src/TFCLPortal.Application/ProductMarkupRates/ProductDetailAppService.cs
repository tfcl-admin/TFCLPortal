using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ProductMarkupRates.Dto;

namespace TFCLPortal.ProductMarkupRates
{
    public class ProductDetailAppService : TFCLPortalAppServiceBase, IProductDetailAppService
    {
        private readonly IRepository<ProductDetail, Int32> _productDetailRepository;
        private string productdetails = "product Detail";
        public ProductDetailAppService(IRepository<ProductDetail, Int32> productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        public async Task CreateProductDetail(CreateProductDetailDto input)
        {
            try
            {
                var productdetal = ObjectMapper.Map<ProductDetail>(input);
                await _productDetailRepository.InsertAsync(productdetal);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", productdetails));
            }
        }

        public List<ProductDetailListDto> GetAllProductDetail()
        {
            try
            {
                var productsDetail = _productDetailRepository.GetAll();

                return ObjectMapper.Map<List<ProductDetailListDto>>(productsDetail);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", productdetails));
            }
        }

        public ProductDetailListDto GetProductDetailById(int Id)
        {
            try
            {
                var productdetal = _productDetailRepository.Get(Id);

                return ObjectMapper.Map<ProductDetailListDto>(productdetal);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", productdetails));
            }
        }

        public List<ProductDetailListDto> GetProductDetailByProductId(int Fk_ProductKey)
        {
            try
            {
                var productdetal = _productDetailRepository.GetAllList().Where(x => x.Fk_ProductId == Fk_ProductKey).ToList();

                return ObjectMapper.Map<List<ProductDetailListDto>>(productdetal);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", productdetails));
            }
        }

        public async Task<string> UpdateProductDetail(UpdateProductDetailDto input)
        {
            string ResponseString = "";
            try
            {
                var productdetal = _productDetailRepository.Get(input.Id);
                if (productdetal != null && productdetal.Id > 0)
                {
                    ObjectMapper.Map(input, productdetal);
                    await _productDetailRepository.UpdateAsync(productdetal);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", productdetails));
            }
            return ResponseString;
        }
    }
}
