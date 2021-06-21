using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.SchoolTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(SchoolType))]
    public class CreateSchoolTypeDto
    {
        public string Name { get; set; }
    }
}
