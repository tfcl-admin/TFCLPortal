using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.RelationshipWithApplicants;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(RelationshipWithApplicant))]
    public class RelationshipWithApplicantListDto : Entity
    {
        public string Name { get; set; }
    }
}
