using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Designations
{
    public interface IDesignationAppService : IApplicationService
    {
        Task<ListResultDto<DesignationListDto>> GetAllDesignations();
        List<DesignationListDto> GetAllList();
    }
}
