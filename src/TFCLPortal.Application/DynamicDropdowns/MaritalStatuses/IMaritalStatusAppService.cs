using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.MaritalStatuses
{
    public interface IMaritalStatusAppService : IApplicationService
    {
        Task<ListResultDto<MaritalStatusListDto>> GetAllMaritalStatus();
        Task CreateMaritalStatus(CreateMaritalStatusDto input);
        List<MaritalStatusListDto> GetAllList();
    }
}
