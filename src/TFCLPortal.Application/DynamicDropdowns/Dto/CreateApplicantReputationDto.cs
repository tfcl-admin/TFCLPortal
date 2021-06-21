using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ApplicantReputations;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(ApplicantReputation))]
    public class CreateApplicantReputationDto
    {
        public string Name { get; set; }
    }
}
