using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.Students.Dto
{
   public class UpdateStudentDto : CreateStudentDto
    {
        public int Id { get; set; }
    }
}
