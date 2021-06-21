using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ReferenceCheck))]
    public class ReferenceCheckListDto : Entity
    {
        public string Name { get; set; }
    }
}
