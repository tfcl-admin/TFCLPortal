using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.SchoolTypes
{
    public interface ISchoolTypeAppService : IApplicationService
    {
        Task<ListResultDto<SchoolTypeListDto>> GetAllSchoolType();
        Task CreateSchoolType(CreateSchoolTypeDto input);
        List<SchoolTypeListDto> GetAllList();
    }
}
