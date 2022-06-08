using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DeceasedAuthorizations
{
    [Table("DeceasedAuthorization")]
    public class DeceasedAuthorization : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        
        public string ClientName { get; set; }
        public string CNIC { get; set; }

        public string DateOfDeath { get; set; }
        public string ReasonOfDeath { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
        public string VerifiedBy { get; set; }
        public string ProofUrl { get; set; }
    }
}
