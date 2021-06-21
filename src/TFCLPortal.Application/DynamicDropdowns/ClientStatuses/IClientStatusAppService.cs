using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ClientStatuses
{
    public interface IClientStatusAppService : IApplicationService
    {
        List<ClientStatusListDto> GetAllList();
        Task<ListResultDto<ClientStatusListDto>> GetAllClientStatuses();

    }
}
