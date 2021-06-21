using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.LegalStatuses
{
    public interface ILegalStatusAppService : IApplicationService
    {
        List<LegalStatusListDto> GetAllList();
        Task<ListResultDto<LegalStatusListDto>> GetAllLegalStatus();
    }
}
