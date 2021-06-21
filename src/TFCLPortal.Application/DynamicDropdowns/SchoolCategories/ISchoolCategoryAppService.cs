using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;
namespace TFCLPortal.DynamicDropdowns.SchoolCategories
{
    public interface ISchoolCategoryAppService : IApplicationService
    {
        List<SchoolCategoryListDto> GetAllList();
        Task<ListResultDto<SchoolCategoryListDto>> GetAllSchoolCategory();

    }
}
