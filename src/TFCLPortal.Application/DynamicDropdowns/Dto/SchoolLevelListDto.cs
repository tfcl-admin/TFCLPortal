using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.SchoolLevels;
using TFCLPortal.TDSBusinessNatures;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(SchoolLevel))]
    public class SchoolLevelListDto : Entity
    {
        public string Name { get; set; }

    }
}
