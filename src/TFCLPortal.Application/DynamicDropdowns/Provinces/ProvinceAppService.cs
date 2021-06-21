using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Provinces
{
    public class ProvinceAppService : TFCLPortalAppServiceBase, IProvinceAppService
    {
        private readonly IRepository<Province> _ProvinceRepository;
        public ProvinceAppService(IRepository<Province> ProvinceRepository)
        {
            _ProvinceRepository = ProvinceRepository;
        }
        public async Task CreateProvince(CreateProvinceDto input)
        {
            try
            {
                var Province = ObjectMapper.Map<Province>(input);
                await _ProvinceRepository.InsertAsync(Province);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Province"));
            }
        }

        public List<ProvinceListDto> GetAllList()
        {
            var Province = _ProvinceRepository.GetAllList();
            return ObjectMapper.Map<List<ProvinceListDto>>(Province);
        }

        public async Task<ListResultDto<ProvinceListDto>> GetAllProvince()
        {
            try
            {
                var Province = await _ProvinceRepository.GetAllListAsync();
                return new ListResultDto<ProvinceListDto>(
                    ObjectMapper.Map<List<ProvinceListDto>>(Province)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Province"));
            }
        }
    }
}
