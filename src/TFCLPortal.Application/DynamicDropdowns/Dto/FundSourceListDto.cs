using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.FundSources;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(FundSource))]
    public class FundSourceListDto : Entity
    {
        public string Name { get; set; }
    }
}
