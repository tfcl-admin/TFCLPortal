using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.WriteOffs
{
    [Table("WriteOff")]
    public class WriteOff : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsMarkupAmount { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public string RecoveryStatus { get; set; }
        public decimal RebatePercentage { get; set; }
        public decimal TotalAmountPayableRebate { get; set; }
        public decimal AmountDeposited { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
    }
}
