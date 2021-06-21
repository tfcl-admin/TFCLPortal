using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ApplicantReputation))]
    public class ApplicantReputationListDto : Entity
    {
        public string Name { get; set; }
    }
}
