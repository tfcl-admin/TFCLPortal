using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.ICollateralOwnerships;

namespace TFCLPortal.DynamicDropdowns.CollateralOwnerships
{
    public class CollateralOwnAppService : TFCLPortalAppServiceBase, ICollateralOwnAppService
    {
        private readonly IRepository<CollateralOwnership> _collateralOwnershiprepo;

        public CollateralOwnAppService(IRepository<CollateralOwnership> collateralOwnership)
        {
            _collateralOwnershiprepo = collateralOwnership;
        }

        public async Task CreateCollateralOwnership(CreateCollateralOwnershipDto input)
        {
            try
            {
                var collateralOwn = ObjectMapper.Map<CollateralOwnership>(input);
                await _collateralOwnershiprepo.InsertAsync(collateralOwn);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "collateralOwnership"));
            }
        }

        public async Task<ListResultDto<CollateralOwnershipListDto>> GetAllCollateralOwnership()
        {
            try
            {
                var collateralown = await _collateralOwnershiprepo.GetAllListAsync();


                return new ListResultDto<CollateralOwnershipListDto>(
                    ObjectMapper.Map<List<CollateralOwnershipListDto>>(collateralown)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "collateralOwnership"));
            }
        }

        public List<CollateralOwnershipListDto> GetAllList()
        {

            var collateralOwnershiplist = _collateralOwnershiprepo.GetAllList();
            return ObjectMapper.Map<List<CollateralOwnershipListDto>>(collateralOwnershiplist);
        }
    }
}
