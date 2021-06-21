using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Ownership;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    
    [AutoMapTo(typeof(OwnershipStatus))]
    public class CreateOwnershipStatusDto
    {

        public string Name { get; set; }
    }
}
