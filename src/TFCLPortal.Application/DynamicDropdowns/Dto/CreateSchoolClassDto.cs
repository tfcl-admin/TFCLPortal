using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.SchoolClasses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(SchoolClass))]
    public class CreateSchoolClassDto
    {
        public string Name { get; set; }
    }
}
