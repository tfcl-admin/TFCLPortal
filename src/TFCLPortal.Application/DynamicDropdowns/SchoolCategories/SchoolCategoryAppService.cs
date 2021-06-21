using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SchoolCategories
{
    public class SchoolCategoryAppService : TFCLPortalAppServiceBase, ISchoolCategoryAppService
    {
        private readonly IRepository<SchoolCategory> _SchoolCategoryRepository;
        public SchoolCategoryAppService(IRepository<SchoolCategory> repository)
        {
            _SchoolCategoryRepository = repository;
        }

        public List<SchoolCategoryListDto> GetAllList()
        {
            var SchoolCategoryList = _SchoolCategoryRepository.GetAllList();
            return ObjectMapper.Map<List<SchoolCategoryListDto>>(SchoolCategoryList);
        }

        public async Task<ListResultDto<SchoolCategoryListDto>> GetAllSchoolCategory()
        {
            try
            {
                var SchoolCategoryList = await _SchoolCategoryRepository.GetAllListAsync();


                return new ListResultDto<SchoolCategoryListDto>(
                    ObjectMapper.Map<List<SchoolCategoryListDto>>(SchoolCategoryList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "School Category"));
            }
        }

    }
}
