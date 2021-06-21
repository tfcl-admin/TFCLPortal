using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.AcademicSessions
{
    public interface IAcademicSessionAppService : IApplicationService
    {
        List<AcademicSessionListDto> GetAllList();
        Task<ListResultDto<AcademicSessionListDto>> GetAllApplicantSources();

    }
}
