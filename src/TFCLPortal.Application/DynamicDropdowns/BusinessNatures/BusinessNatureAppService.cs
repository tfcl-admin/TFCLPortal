using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.BusinessNatures;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.BusinessNatures
{
    public class BusinessNatureAppService : TFCLPortalAppServiceBase, IBusinessNatureAppService
    {
        private readonly IRepository<BusinessNature> _BusinessNatureRepository;
        public BusinessNatureAppService(IRepository<BusinessNature> repository)
        {
            _BusinessNatureRepository = repository;
        }
        public List<BusinessNatureListDto> GetAllList()
        {
            var BusinessNatureList = _BusinessNatureRepository.GetAllList();
            return ObjectMapper.Map<List<BusinessNatureListDto>>(BusinessNatureList);
        }

        public async Task<ListResultDto<BusinessNatureListDto>> GetAllBusinessNature()
        {
            try
            {
                var BusinessNatureList = await _BusinessNatureRepository.GetAllListAsync();


                return new ListResultDto<BusinessNatureListDto>(
                    ObjectMapper.Map<List<BusinessNatureListDto>>(BusinessNatureList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Business Nature"));
            }
        }
    }
}
