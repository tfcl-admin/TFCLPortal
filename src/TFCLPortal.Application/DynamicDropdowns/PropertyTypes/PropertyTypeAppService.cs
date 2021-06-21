using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.PropertyTypes
{
    public class PropertyTypeAppService : TFCLPortalAppServiceBase, IPropertyTypeAppService
    {
        private readonly IRepository<PropertyType> _PropertyTyperepo;
        public PropertyTypeAppService(IRepository<PropertyType> PropertyTyperepo)
        {
            _PropertyTyperepo = PropertyTyperepo;
        }

        public async Task CreatePropertyType(CreatePropertyTypeDto input)
        {
            try
            {
                var propertyType = ObjectMapper.Map<PropertyType>(input);
                await _PropertyTyperepo.InsertAsync(propertyType);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Property Type"));
            }
        }

        public List<PropertyTypeListDto> GetAllList()
        {
            var propertyTypelist = _PropertyTyperepo.GetAllList();
            return ObjectMapper.Map<List<PropertyTypeListDto>>(propertyTypelist);
        }

        public async Task<ListResultDto<PropertyTypeListDto>> GetAllPropertyType()
        {
            try
            {
                var propertytypelist = await _PropertyTyperepo.GetAllListAsync();


                return new ListResultDto<PropertyTypeListDto>(
                    ObjectMapper.Map<List<PropertyTypeListDto>>(propertytypelist)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Property Type"));
            }
        }
    }
}
