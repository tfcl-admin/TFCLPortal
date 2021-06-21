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
    public class ProductAppService : TFCLPortalAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, Int32> _productRepository;
        private string product = "product";

        public ProductAppService(IRepository<Product, Int32> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(CreateProductDto input)
        {
            try
            {
                var products = ObjectMapper.Map<Product>(input);
                await _productRepository.InsertAsync(products);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", product));
            }
        }

        public List<ProductListDto> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllIncluding(x => x.ProductDetails).ToList();

                return ObjectMapper.Map<List<ProductListDto>>(products);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", product));
            }
        }

        public ProductListDto GetProductById(int Id)
        {
            try
            {
                var products = _productRepository.GetAllIncluding(x => x.ProductDetails).Where(b => b.Id == Id).FirstOrDefault();

                return ObjectMapper.Map<ProductListDto>(products);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", product));
            }
        }
        public async  Task<string> UpdateProduct(UpdateProductDto input)
        {
            string ResponseString = " Succesfully Updated";
            try
            {
                var products = _productRepository.Get(input.Id);
                if (products != null && products.Id > 0)
                {
                    ObjectMapper.Map(input, products);
                    await _productRepository.UpdateAsync(products);
                    CurrentUnitOfWork.SaveChanges();

                }
            }

            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", product));
            }
            return ResponseString;
        }
    }
}
