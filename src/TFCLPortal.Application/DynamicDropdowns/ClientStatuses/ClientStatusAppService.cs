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

namespace TFCLPortal.DynamicDropdowns.ClientStatuses
{
    public class ClientStatusAppService : TFCLPortalAppServiceBase, IClientStatusAppService
    {
        private readonly IRepository<ClientStatus> _clientStatusRepository;
        public ClientStatusAppService(IRepository<ClientStatus> repository)
        {
            _clientStatusRepository = repository;
        }
        public async Task<ListResultDto<ClientStatusListDto>> GetAllClientStatuses()
        {
            try
            {
                var ClientStatusList = await _clientStatusRepository.GetAllListAsync();


                return new ListResultDto<ClientStatusListDto>(
                    ObjectMapper.Map<List<ClientStatusListDto>>(ClientStatusList)
                );

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("DropdownListError{0}", "Respondant Designation"));
            }
        }

        public List<ClientStatusListDto> GetAllList()
        {
            var ClientStatusList = _clientStatusRepository.GetAllList();
            return ObjectMapper.Map<List<ClientStatusListDto>>(ClientStatusList);
        }
    }
}
