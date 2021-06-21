using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SchoolTypes
{
    public class SchoolTypeAppService : TFCLPortalAppServiceBase, ISchoolTypeAppService
    {

        private readonly IRepository<SchoolType> _SchoolTyperepo;
        public SchoolTypeAppService(IRepository<SchoolType> SchoolTyperepo)
        {
            _SchoolTyperepo = SchoolTyperepo;
        }

        public async Task CreateSchoolType(CreateSchoolTypeDto input)
        {
            try
            {
                var scholType = ObjectMapper.Map<SchoolType>(input);
                await _SchoolTyperepo.InsertAsync(scholType);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownCreateError{0}", "School Type"));
            }
        }

        public List<SchoolTypeListDto> GetAllList()
        {
            var schoolTypelist = _SchoolTyperepo.GetAllList();
            return ObjectMapper.Map<List<SchoolTypeListDto>>(schoolTypelist);
        }

        public async Task<ListResultDto<SchoolTypeListDto>> GetAllSchoolType()
        {
            try
            {
                var schoolTypelist = await _SchoolTyperepo.GetAllListAsync();


                return new ListResultDto<SchoolTypeListDto>(
                    ObjectMapper.Map<List<SchoolTypeListDto>>(schoolTypelist)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "School Type"));
            }
        }
    }
}
