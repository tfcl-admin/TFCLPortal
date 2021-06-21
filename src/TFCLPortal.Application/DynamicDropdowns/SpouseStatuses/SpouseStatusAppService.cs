using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ClientStatuses;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SpouseStatuses
{
    public class SpouseStatusAppService : TFCLPortalAppServiceBase, ISpouseStatusAppService
    {
        private readonly IRepository<SpouseStatus> _SpouseStatusRepository;
        public SpouseStatusAppService(IRepository<SpouseStatus> repository)
        {
            _SpouseStatusRepository = repository;
        }
        public async Task<ListResultDto<SpouseStatusListDto>> GetAllSpouseStatuses()
        {
            try
            {
                var SpouseStatusList = await _SpouseStatusRepository.GetAllListAsync();


                return new ListResultDto<SpouseStatusListDto>(
                    ObjectMapper.Map<List<SpouseStatusListDto>>(SpouseStatusList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Spouse Status"));
            }
        }


        public List<SpouseStatusListDto> GetAllList()
        {
            var SpouseStatusList = _SpouseStatusRepository.GetAllList();
            return ObjectMapper.Map<List<SpouseStatusListDto>>(SpouseStatusList);
        }

    }
}
