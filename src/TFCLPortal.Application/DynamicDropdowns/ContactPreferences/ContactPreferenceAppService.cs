using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.ContactPreferences;

namespace TFCLPortal.DynamicDropdowns.ContactPreferences
{
    public class ContactPreferenceAppService : TFCLPortalAppServiceBase, IContactPreferenceAppService
    {
        private readonly IRepository<ContactPreference> _ContactPreferenceRepository;
        public ContactPreferenceAppService(IRepository<ContactPreference> repository)
        {
            _ContactPreferenceRepository = repository;
        }
        public List<ContactPreferencesListDto> GetAllList()
        {
            var ContactPreferenceList = _ContactPreferenceRepository.GetAllList();
            return ObjectMapper.Map<List<ContactPreferencesListDto>>(ContactPreferenceList);
        }

        public async Task<ListResultDto<ContactPreferencesListDto>> GetAllContactPreference()
        {
            try
            {
                var ContactPreferenceList = await _ContactPreferenceRepository.GetAllListAsync();


                return new ListResultDto<ContactPreferencesListDto>(
                    ObjectMapper.Map<List<ContactPreferencesListDto>>(ContactPreferenceList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Business Nature"));
            }
        }
    }
}
