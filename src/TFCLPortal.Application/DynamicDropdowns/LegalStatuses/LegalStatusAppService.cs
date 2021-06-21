using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.BusinessNatures;

namespace TFCLPortal.DynamicDropdowns.LegalStatuses
{
    public class LegalStatusAppService : TFCLPortalAppServiceBase, ILegalStatusAppService
    {
        private readonly IRepository<LegalStatus> _LegalStatusRepository;
        public LegalStatusAppService(IRepository<LegalStatus> repository)
        {
            _LegalStatusRepository = repository;
        }

        public List<LegalStatusListDto> GetAllList()
        {
            var LegalStatusList = _LegalStatusRepository.GetAllList();
            return ObjectMapper.Map<List<LegalStatusListDto>>(LegalStatusList);
        }

        public async Task<ListResultDto<LegalStatusListDto>> GetAllLegalStatus()
        {
            try
            {
                var LegalStatusList = _LegalStatusRepository.GetAllListAsync();

                return new ListResultDto<LegalStatusListDto>(
                   ObjectMapper.Map<List<LegalStatusListDto>>(LegalStatusList)
               );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "School Level"));
            }
        }

    }
}
