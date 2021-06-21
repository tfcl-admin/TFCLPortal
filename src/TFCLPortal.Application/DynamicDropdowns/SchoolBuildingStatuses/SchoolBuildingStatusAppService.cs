using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes;

namespace TFCLPortal.DynamicDropdowns.BuildingStatuses
{
    public class BuildingStatusAppService : TFCLPortalAppServiceBase, IBuildingStatusAppService
    {
        private readonly IRepository<BuildingStatus> _BuildingStatusRepository;
        public BuildingStatusAppService(IRepository<BuildingStatus> repository)
        {
            _BuildingStatusRepository = repository;
        }

        public List<BuildingStatusListDto> GetAllList()
        {
            var BuildingStatusList = _BuildingStatusRepository.GetAllList();
            return ObjectMapper.Map<List<BuildingStatusListDto>>(BuildingStatusList);
        }

        public async Task<ListResultDto<BuildingStatusListDto>> GetAllOtherSourceOfIncome()
        {
            try
            {
                var BuildingStatusList = await _BuildingStatusRepository.GetAllListAsync();


                return new ListResultDto<BuildingStatusListDto>(
                    ObjectMapper.Map<List<BuildingStatusListDto>>(BuildingStatusList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Other Source Of Income"));
            }
        }

    }
}
