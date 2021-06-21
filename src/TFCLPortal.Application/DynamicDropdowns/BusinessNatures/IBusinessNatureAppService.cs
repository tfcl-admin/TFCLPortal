using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.BusinessNatures
{
    public interface IBusinessNatureAppService : IApplicationService
    {
        List<BusinessNatureListDto> GetAllList();
        Task<ListResultDto<BusinessNatureListDto>> GetAllBusinessNature();
    }
}
