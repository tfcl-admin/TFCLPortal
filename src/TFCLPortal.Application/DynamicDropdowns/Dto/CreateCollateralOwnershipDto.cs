using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.CollateralOwnerships;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(CollateralOwnership))]
    public class CreateCollateralOwnershipDto
    {
        public string Name { get; set; }
    }
}
