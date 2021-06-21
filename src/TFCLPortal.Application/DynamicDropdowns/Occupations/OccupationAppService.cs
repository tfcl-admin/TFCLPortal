using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.StudentsGender;

namespace TFCLPortal.DynamicDropdowns.Occupations
{
    public class OccupationAppService : TFCLPortalAppServiceBase, IOccupationAppService
    {
        private readonly IRepository<Occupation> _occupationRepository;
        public OccupationAppService(IRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        
        public async Task<ListResultDto<OccupationListDto>> GetAllOccupation()
        {
            try
            {
                var occupation = await _occupationRepository.GetAllListAsync();


                return new ListResultDto<OccupationListDto>(
                    ObjectMapper.Map<List<OccupationListDto>>(occupation)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Occupation"));
            }
        }

        public async Task CreateOccupation(CreateOccupationDto input)
        {
            try
            {
                var occupation = ObjectMapper.Map<Occupation>(input);
                await _occupationRepository.InsertAsync(occupation);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "Occupation"));
            }
        }

        public List<OccupationListDto> GetAllList()
        {

            var occupationlist = _occupationRepository.GetAllList();
            return ObjectMapper.Map<List<OccupationListDto>>(occupationlist);
        }

    }
}
