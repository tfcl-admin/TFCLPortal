using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ContactSources
{
    public class ContactSourceAppService : TFCLPortalAppServiceBase, IContactSourceAppService
    {
        private readonly IRepository<ContactSource> _ContactSourceRepository;
        public ContactSourceAppService(IRepository<ContactSource> repository)
        {
            _ContactSourceRepository = repository;
        }
        public async Task<ListResultDto<ContactSourceListDto>> GetAllContactSourcees()
        {
            try
            {
                var ContactSourceList = await _ContactSourceRepository.GetAllListAsync();


                return new ListResultDto<ContactSourceListDto>(
                    ObjectMapper.Map<List<ContactSourceListDto>>(ContactSourceList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Contact Source"));
            }
        }

        public List<ContactSourceListDto> GetAllList()
        {
            var ContactSourceList = _ContactSourceRepository.GetAllList();
            return ObjectMapper.Map<List<ContactSourceListDto>>(ContactSourceList);
        }
    }
}
