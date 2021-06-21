using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SpouseStatuses
{
    public interface ISpouseStatusAppService : IApplicationService
    {
        List<SpouseStatusListDto> GetAllList();
        Task<ListResultDto<SpouseStatusListDto>> GetAllSpouseStatuses();

    }
}


