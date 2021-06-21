using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.NatureOfEmployments
{
    public class NatureOfEmploymentAppService : TFCLPortalAppServiceBase, INatureOfEmploymentAppService
    {
        private readonly IRepository<NatureOfEmployment> _NatureOfEmploymentRepository;

        public NatureOfEmploymentAppService(IRepository<NatureOfEmployment> NatureOfEmploymentRepository)
        {
            _NatureOfEmploymentRepository = NatureOfEmploymentRepository;
        }

        public async Task<ListResultDto<NatureOfEmploymentListDto>> GetAllNatureOfEmployment()
        {
            try
            {
                var NatureOfEmploymentList = await _NatureOfEmploymentRepository.GetAllListAsync();


                return new ListResultDto<NatureOfEmploymentListDto>(
                    ObjectMapper.Map<List<NatureOfEmploymentListDto>>(NatureOfEmploymentList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Company Type"));
            }
        }

        public List<NatureOfEmploymentListDto> GetAllList()
        {
            var NatureOfEmploymentList = _NatureOfEmploymentRepository.GetAllList();
            return ObjectMapper.Map<List<NatureOfEmploymentListDto>>(NatureOfEmploymentList);
        }
    }
}
