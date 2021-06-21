using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.ApplicantTypes
{
    public interface IApplicantTypeAppService : IApplicationService
    {
        List<ApplicantTypeListDto> GetAllList();
        Task<ListResultDto<ApplicantTypeListDto>> GetAllApplicantTypees();

    }
}
