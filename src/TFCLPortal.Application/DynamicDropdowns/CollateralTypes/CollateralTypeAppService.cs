using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CollateralTypes
{
    public class CollateralTypeAppService : TFCLPortalAppServiceBase, ICollateralTypeAppService
    {
        private readonly IRepository<CollateralType> _collateralTyperepo;

        public CollateralTypeAppService(IRepository<CollateralType> collateralType)
        {
            _collateralTyperepo = collateralType;
        }

        public async Task CreateCollateralType(CreateCollateralTypeDto input)
        {
            try
            {
                var collateraltype = ObjectMapper.Map<CollateralType>(input);
                await _collateralTyperepo.InsertAsync(collateraltype);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "collateralType"));
            }
        }

        public async Task<ListResultDto<CollateralTypeListDto>> GetAllCollateralType()
        {
            try
            {
                var collateraltype = await _collateralTyperepo.GetAllListAsync();


                return new ListResultDto<CollateralTypeListDto>(
                    ObjectMapper.Map<List<CollateralTypeListDto>>(collateraltype)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "collateralType"));
            }
        }

        public List<CollateralTypeListDto> GetAllList()
        {

            var collateraltypelist = _collateralTyperepo.GetAllList();
            return ObjectMapper.Map<List<CollateralTypeListDto>>(collateraltypelist);
        }
    }
}
