using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.ManagmentCommitteeDecisions.Dto
{
    [AutoMapFrom(typeof(ManagmentCommitteeDecision))]
    public class ManagmentCommitteeDecisionListDto : FullAuditedEntityDto
    {
        public int fk_userid { get; set; }
        public int ApplicationId { get; set; }
        public string Decision { get; set; }
        public string Reason { get; set; }
    }
}
