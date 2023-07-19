using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.LatePaymentAuthorization
{
    [Table("LatePaymentAuthorization")]
    public class LatePaymentAuthorization : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public int LateDays { get; set; }
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }
        public decimal TotalPunishment { get; set; }
        public bool? isAuthorized { get; set; }
    }
}
