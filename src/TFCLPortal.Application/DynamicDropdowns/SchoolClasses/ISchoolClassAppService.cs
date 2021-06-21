using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SchoolClasses
{
    public interface ISchoolClassAppService : IApplicationService
    {
        Task<ListResultDto<SchoolClassListDto>> GetAllSchoolClass();
        Task CreateSchoolClass(CreateSchoolClassDto input);
        List<SchoolClassListDto> GetAllList();
    }
}
