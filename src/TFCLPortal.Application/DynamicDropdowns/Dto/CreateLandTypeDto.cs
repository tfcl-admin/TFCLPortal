using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LandTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(LandType))]
    public class CreateLandTypeDto
    {
        public string Name { get; set; }
    }
}
