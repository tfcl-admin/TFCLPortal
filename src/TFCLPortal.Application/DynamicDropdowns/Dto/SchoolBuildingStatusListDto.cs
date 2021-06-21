using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.BuildingStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(BuildingStatus))]
    public class BuildingStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}
