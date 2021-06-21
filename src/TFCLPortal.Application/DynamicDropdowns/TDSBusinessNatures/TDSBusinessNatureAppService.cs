using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.SchoolCategories;
using TFCLPortal.TDSBusinessNatures;

namespace TFCLPortal.DynamicDropdowns.TDSBusinessNatures
{
    public class TDSBusinessNatureAppService : TFCLPortalAppServiceBase, ITDSBusinessNatureAppService
    {
        private readonly IRepository<TDSBusinessNature> _TDSBusinessNatureRepository;
        public TDSBusinessNatureAppService(IRepository<TDSBusinessNature> repository)
        {
            _TDSBusinessNatureRepository = repository;
        }
        public List<TDSBusinessNatureListDto> GetAllList()
        {
            var TDSBusinessNatureList = _TDSBusinessNatureRepository.GetAllList();
            return ObjectMapper.Map<List<TDSBusinessNatureListDto>>(TDSBusinessNatureList);
        }

        public async Task<ListResultDto<TDSBusinessNatureListDto>> GetAllSchoolCategory()
        {
            try
            {
                var TDSBusinessNatureList = await _TDSBusinessNatureRepository.GetAllListAsync();


                return new ListResultDto<TDSBusinessNatureListDto>(
                    ObjectMapper.Map<List<TDSBusinessNatureListDto>>(TDSBusinessNatureList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "School Category"));
            }
        }
    }
}
