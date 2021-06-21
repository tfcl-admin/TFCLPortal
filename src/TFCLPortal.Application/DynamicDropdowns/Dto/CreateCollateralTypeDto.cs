using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.CollateralTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(CollateralType))]
    public class CreateCollateralTypeDto
    {
        public string Name { get; set; }
    }
}
