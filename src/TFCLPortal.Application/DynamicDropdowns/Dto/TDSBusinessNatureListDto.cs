using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TDSBusinessNatures;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(TDSBusinessNature))]
    public class TDSBusinessNatureListDto : Entity
    {
        public string Name { get; set; }

    }
}
