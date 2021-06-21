using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.CollateralDetails;
using TFCLPortal.DynamicDropdowns.CollateralOwnerships;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(CollateralOwnership))]
    public class CollateralOwnershipListDto : Entity
    {
        public string Name { get; set; }
    }
}
