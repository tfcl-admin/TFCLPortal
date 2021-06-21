using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.PropertyTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(PropertyType))]
    public class PropertyTypeListDto : Entity
    {
        public string Name { get; set; }
    }
}
