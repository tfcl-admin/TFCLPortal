using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.NatureOfBusinesses
{
    public class NatureOfBusinessAppService : TFCLPortalAppServiceBase, INatureOfBusinessAppService
    {
        private readonly IRepository<NatureOfBusiness> _natureOfBusinessRepository;
        public NatureOfBusinessAppService(IRepository<NatureOfBusiness> natureOfBusinessRepository)
        {
            _natureOfBusinessRepository = natureOfBusinessRepository;

        }
        public async Task CreateNatureOfBusiness(CreateNatureOfBusinessDto input)
        {
            try
            {
                var natureofBusiness = ObjectMapper.Map<NatureOfBusiness>(input);
                await _natureOfBusinessRepository.InsertAsync(natureofBusiness);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Nature of Business"));
            }
        }

        public List<NatureOfBusinessListDto> GetAllList()
        {
            var natureofBusiness = _natureOfBusinessRepository.GetAllList();
            return ObjectMapper.Map<List<NatureOfBusinessListDto>>(natureofBusiness);
        }

        public async  Task<ListResultDto<NatureOfBusinessListDto>> GetAllNatureOfBusiness()
        {
            try
            {
                var natureofBusiness = await _natureOfBusinessRepository.GetAllListAsync();


                return new ListResultDto<NatureOfBusinessListDto>(
                    ObjectMapper.Map<List<NatureOfBusinessListDto>>(natureofBusiness)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Nature of Business"));
            }
        }
    }
}
