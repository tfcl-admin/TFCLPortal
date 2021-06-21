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

namespace TFCLPortal.DynamicDropdowns.BusinessTypes
{
    public class BusinessTypeAppService : TFCLPortalAppServiceBase, IBusinessTypeAppService
    {
        private readonly IRepository<BusinessType> _BusinessTypeRepository;
        public BusinessTypeAppService(IRepository<BusinessType> repository)
        {
            _BusinessTypeRepository = repository;
        }
        public List<BusinessTypeListDto> GetAllList()
        {
            var BusinessTypeList = _BusinessTypeRepository.GetAllList();
            return ObjectMapper.Map<List<BusinessTypeListDto>>(BusinessTypeList);
        }

        public async Task<ListResultDto<BusinessTypeListDto>> GetAllBusinessType()
        {
            try
            {
                var BusinessTypeList = await _BusinessTypeRepository.GetAllListAsync();


                return new ListResultDto<BusinessTypeListDto>(
                    ObjectMapper.Map<List<BusinessTypeListDto>>(BusinessTypeList)
                );

            }
            catch (Exception ex)
            { 
                throw new UserFriendlyException(L("DropdownListError{0}", "Business Type"));
            }
        }
    }
}
