using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ReasonForNotBeingInteresteds;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ReasonForNotBeingInterested))]
    public class ReasonForNotBeingInterestedListDto : Entity
    {
        public string Name { get; set; }
    }
}
