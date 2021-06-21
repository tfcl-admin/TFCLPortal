using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.StudentsGender
{
    public interface IStudentGenderAppService: IApplicationService
    {
        Task<ListResultDto<StudentGenderListDto>> GetAllStudentGender();
        Task CreateStudentGender(CreateStudentGenderDto input);
        List<StudentGenderListDto> GetAllList();
    }
}
