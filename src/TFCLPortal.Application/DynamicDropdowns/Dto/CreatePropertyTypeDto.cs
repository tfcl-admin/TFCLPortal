using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.PropertyTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(PropertyType))]
    public class CreatePropertyTypeDto
    {
        public string Name { get; set; }
    }
}
