using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.SpouseStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(SpouseStatus))]
    public class SpouseStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}
