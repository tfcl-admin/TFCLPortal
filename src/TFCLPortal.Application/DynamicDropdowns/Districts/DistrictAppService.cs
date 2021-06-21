using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Districts
{
    public class DistrictAppService : TFCLPortalAppServiceBase, IDistrictAppService
    {
        private readonly IRepository<District> _districtrepo;
        public DistrictAppService(IRepository<District> districtrepo)
        {
            _districtrepo = districtrepo;
        }
        public async Task CreateDistrict(CreateDistrictDto input)
        {
            try
            {
                var district = ObjectMapper.Map<District>(input);
                await _districtrepo.InsertAsync(district);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "District"));
            }
        }

        public async Task<ListResultDto<DistrictListDto>> GetAllDistrict()
        {
            try
            {
                var district = await _districtrepo.GetAllListAsync();


                return new ListResultDto<DistrictListDto>(
                    ObjectMapper.Map<List<DistrictListDto>>(district)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "District"));
            }
        }

        public List<DistrictListDto> GetAllList()
        {
            var district = _districtrepo.GetAllList();
            return ObjectMapper.Map<List<DistrictListDto>>(district);
        }
    }
}
