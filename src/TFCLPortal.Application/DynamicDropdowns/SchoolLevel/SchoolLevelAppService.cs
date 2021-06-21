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

namespace TFCLPortal.DynamicDropdowns.SchoolLevels
{
    public class SchoolLevelAppService : TFCLPortalAppServiceBase, ISchoolLevelAppService
    {
        private readonly IRepository<SchoolLevel> _SchoolLevelRepository;
        public SchoolLevelAppService(IRepository<SchoolLevel> repository)
        {
            _SchoolLevelRepository = repository;
        }

        public List<SchoolLevelListDto> GetAllList()
        {
            var SchoolLevelList = _SchoolLevelRepository.GetAllList();
            return ObjectMapper.Map<List<SchoolLevelListDto>>(SchoolLevelList);
        }

        public async Task<ListResultDto<SchoolLevelListDto>> GetAllSchoolLevels()
        {
            try
            {
                var SchoolLevelList = _SchoolLevelRepository.GetAllListAsync();

                return new ListResultDto<SchoolLevelListDto>(
                   ObjectMapper.Map<List<SchoolLevelListDto>>(SchoolLevelList)
               );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "School Level"));
            }
        }

    }
}
