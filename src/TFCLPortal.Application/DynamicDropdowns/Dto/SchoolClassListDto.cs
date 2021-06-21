using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.SchoolClasses;
using TFCLPortal.DynamicDropdowns.SchoolTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(SchoolClass))]
    public class SchoolClassListDto : Entity
    {
        public string Name { get; set; }
    }
}
