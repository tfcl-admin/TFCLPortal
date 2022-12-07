using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Students.Dto;

namespace TFCLPortal.Students
{
  public  interface IStudentAppService : IApplicationService
    {

        StudentListDto GetStudentById(int Id);
        Task CreateStudent(CreateStudentDto input);
        List<StudentListDto> GetStudentList();

    }
}
