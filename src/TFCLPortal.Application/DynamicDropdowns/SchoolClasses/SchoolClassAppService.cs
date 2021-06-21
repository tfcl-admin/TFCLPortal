using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SchoolClasses
{
    public class SchoolClassAppService : TFCLPortalAppServiceBase, ISchoolClassAppService
    {
        private readonly IRepository<SchoolClass> _schoolClassRepository;
        public SchoolClassAppService(IRepository<SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task CreateSchoolClass(CreateSchoolClassDto input)
        {
            try
            {
                var schoolClass = ObjectMapper.Map<SchoolClass>(input);
                await _schoolClassRepository.InsertAsync(schoolClass);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "School Class"));
            }
        }

        public List<SchoolClassListDto> GetAllList()
        {
            var schoolClass = _schoolClassRepository.GetAllList();
            return ObjectMapper.Map<List<SchoolClassListDto>>(schoolClass);
        }

        public async Task<ListResultDto<SchoolClassListDto>> GetAllSchoolClass()
        {
            try
            {
                var schoolClass = await _schoolClassRepository.GetAllListAsync();



                return new ListResultDto<SchoolClassListDto>(
                    ObjectMapper.Map<List<SchoolClassListDto>>(schoolClass)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "School Class"));
            }
        }
    }
}
