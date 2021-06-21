using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.CompanyTypes
{
    public class CompanyTypeAppService : TFCLPortalAppServiceBase, ICompanyTypeAppService
    {
        private readonly IRepository<CompanyType> _CompanyTypeRepository;

        public CompanyTypeAppService(IRepository<CompanyType> CompanyTypeRepository)
        {
            _CompanyTypeRepository = CompanyTypeRepository;
        }

        public async Task<ListResultDto<CompanyTypeListDto>> GetAllCompanyType()
        {
            try
            {
                var CompanyTypeList = await _CompanyTypeRepository.GetAllListAsync();


                return new ListResultDto<CompanyTypeListDto>(
                    ObjectMapper.Map<List<CompanyTypeListDto>>(CompanyTypeList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Company Type"));
            }
        }

        public List<CompanyTypeListDto> GetAllList()
        {
            var CompanyTypeList = _CompanyTypeRepository.GetAllList();
            return ObjectMapper.Map<List<CompanyTypeListDto>>(CompanyTypeList);
        }
    }
}
