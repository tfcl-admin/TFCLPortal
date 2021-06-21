using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LandTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(LandType))]
    public class LandTypeListDto : Entity
    {
        public string Name { get; set; }
    }
}
