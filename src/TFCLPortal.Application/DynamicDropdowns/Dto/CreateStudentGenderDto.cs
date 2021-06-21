using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.StudentsGender;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(StudentGender))]
    public class CreateStudentGenderDto
    {
        public string Name { get; set; }
    }
}
