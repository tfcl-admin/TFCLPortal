using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Ownership;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(OwnershipStatus))]
    public class OwnershipStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}
