using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ReasonOfDeclines;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ReasonOfDecline))]
    public class ReasonOfDeclineListDto : Entity
    {
        public string Name { get; set; }
    }
}
