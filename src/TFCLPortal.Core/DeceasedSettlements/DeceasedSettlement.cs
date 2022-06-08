using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DeceasedSettlements
{
    [Table("DeceasedSettlement")]
    public class DeceasedSettlement : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsMarkupAmount { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public decimal AmountDeposited { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
        public string ProofUrl { get; set; }

        public bool? isManagerAuthorized { get; set; }
        public string ManagerRejectionReason { get; set; }
    }
}
