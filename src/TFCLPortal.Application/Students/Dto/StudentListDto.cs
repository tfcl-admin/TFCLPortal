using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentListDto : EntityDto
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string ClassName { get; set; }
    }
}
