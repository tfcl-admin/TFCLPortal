using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.StudentsGender;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(StudentGender))]
    public class StudentGenderListDto : Entity
    {
        public string Name { get; set; }
    }
}
