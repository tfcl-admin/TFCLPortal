using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ProductTypes
{
    public class ProductTypeAppService : TFCLPortalAppServiceBase, IProductTypeAppService
    {

        private readonly IRepository<ProductType> _ProductTyperepo;
        public ProductTypeAppService(IRepository<ProductType> ProductTyperepo)
        {
            _ProductTyperepo = ProductTyperepo;
        }

        public async Task CreateProductType(CreateProductTypeDto input)
        {
            try
            {
                var productType = ObjectMapper.Map<ProductType>(input);
                await _ProductTyperepo.InsertAsync(productType);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Product Type"));
            }
        }

        public List<ProductTypeListDto> GetAllList()
        {
            var productTypelist = _ProductTyperepo.GetAllList();
            return ObjectMapper.Map<List<ProductTypeListDto>>(productTypelist);
        }

        public async Task<ListResultDto<ProductTypeListDto>> GetAllProductType()
        {
            try
            {
                var productTypelist = await _ProductTyperepo.GetAllListAsync();


                return new ListResultDto<ProductTypeListDto>(
                    ObjectMapper.Map<List<ProductTypeListDto>>(productTypelist)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Product Type"));
            }
        }
    }
}
