using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ReferenceChecks
{
    public interface IReferenceCheckAppService : IApplicationService
    {
        Task<ListResultDto<ReferenceCheckListDto>> GetAllReferenceCheck();
        Task CreateReferenceCheck(CreateReferenceCheckDto input);
        List<ReferenceCheckListDto> GetAllList();
    }
}
