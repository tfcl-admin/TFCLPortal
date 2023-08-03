using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.StudentDetails.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.StudentDetails
{
    public interface IStudentDetailAppService : IApplicationService
    {
 
        StudentDetailDto GetStudentDetailById(int Id);
        Task<string> CreateStudentDetail(CreateStudentDetailDto input);
        Task<string> UpdateStudentDetail(UpdateStudentDetailDto input);
        //bool CheckStudentDetailByApplicationId(int ApplicationId);

        Task<StudentDetailDto> GetStudentDetailByApplicationId(int ApplicationId);

    }
}
