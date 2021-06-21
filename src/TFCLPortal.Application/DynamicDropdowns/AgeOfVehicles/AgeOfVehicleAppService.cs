using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.AgeOfVehicles
{
    public class AgeOfVehicleAppService : TFCLPortalAppServiceBase, IAgeOfVehicleAppService
    {
        private readonly IRepository<AgeOfVehicle> _ageOfVehicleRepository;

        public AgeOfVehicleAppService(IRepository<AgeOfVehicle> ageOfVehicleRepository)
        {
            _ageOfVehicleRepository = ageOfVehicleRepository;
        }

        public async Task<ListResultDto<AgeOfVehicleListDto>> GetAllAgeOfVehicle()
        {
            try
            {
                var AgeOfVehicleList = await _ageOfVehicleRepository.GetAllListAsync();


                return new ListResultDto<AgeOfVehicleListDto>(
                    ObjectMapper.Map<List<AgeOfVehicleListDto>>(AgeOfVehicleList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Age Of Vehicle"));
            }
        }

        public List<AgeOfVehicleListDto> GetAllList()
        {
            var AgeOfVehicleList = _ageOfVehicleRepository.GetAllList();
            return ObjectMapper.Map<List<AgeOfVehicleListDto>>(AgeOfVehicleList);
        }
    }
}
