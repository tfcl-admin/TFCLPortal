
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ManagmentCommitteeDecisions.Dto
{
    [AutoMapTo(typeof(ManagmentCommitteeDecision))]
    public class CreateManagmentCommitteeDecisionDto
    {
        public int fk_userid { get; set; }
        public int ApplicationId { get; set; }
        public string Decision { get; set; }
        public string Reason { get; set; }
    }
}
