using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using TFCLPortal.DynamicDropdowns.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
//NEW DROPDOWN API Addition Class APP Service

namespace TFCLPortal.DynamicDropdowns.RespondantDesignations
{
    public class RespondantDesignationAppService : TFCLPortalAppServiceBase, IRespondantDesignationAppService
    {
        private readonly IRepository<RespondantDesignation> _RespondantDesignationRepository;
        public RespondantDesignationAppService(IRepository<RespondantDesignation> repository)
        {
            _RespondantDesignationRepository = repository;
        }

        public List<RespondantDesignationListDto> GetAllList()
        {
            var respondantDesignationList = _RespondantDesignationRepository.GetAllList();
            return ObjectMapper.Map<List<RespondantDesignationListDto>>(respondantDesignationList);
        }

        public async Task<ListResultDto<RespondantDesignationListDto>> GetAllRespondantDesignations()
        {
            try
            {
                var respondantDesignationList = await _RespondantDesignationRepository.GetAllListAsync();


                return new ListResultDto<RespondantDesignationListDto>(
                    ObjectMapper.Map<List<RespondantDesignationListDto>>(respondantDesignationList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Respondant Designation"));
            }
        }

    }
}
