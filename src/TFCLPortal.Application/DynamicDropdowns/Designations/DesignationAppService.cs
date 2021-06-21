using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Designations
{
    public class DesignationAppService : TFCLPortalAppServiceBase, IDesignationAppService
    {
        private readonly IRepository<Designation> _designationRepository;
        public DesignationAppService(IRepository<Designation> designationRepository)
        {
            _designationRepository = designationRepository;
        }

        public async Task<ListResultDto<DesignationListDto>> GetAllDesignations()
        {
            try
            {
                var designations = await _designationRepository.GetAllListAsync();


                return new ListResultDto<DesignationListDto>(
                    ObjectMapper.Map<List<DesignationListDto>>(designations)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Designations"));
            }
        }

        public List<DesignationListDto> GetAllList()
        {

            var designations = _designationRepository.GetAllList();
            return ObjectMapper.Map<List<DesignationListDto>>(designations);
        }
    }
}
