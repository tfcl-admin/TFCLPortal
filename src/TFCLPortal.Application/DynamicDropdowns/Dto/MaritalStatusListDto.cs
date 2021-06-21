using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.MaritalStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(MaritalStatus))]
    public class MaritalStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}
