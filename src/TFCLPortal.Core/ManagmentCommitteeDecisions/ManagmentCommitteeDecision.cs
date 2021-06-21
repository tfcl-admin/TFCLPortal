using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ManagmentCommitteeDecisions
{
    [Table("ManagmentCommitteeDecision")]
    public class ManagmentCommitteeDecision : FullAuditedEntity<int>
    {
        public int fk_userid { get; set; }
        public int ApplicationId { get; set; }
        public string Decision { get; set; }
        public string Reason { get; set; }
    }
}
