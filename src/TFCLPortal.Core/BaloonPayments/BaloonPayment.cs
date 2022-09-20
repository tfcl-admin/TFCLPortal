using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BaloonPayments
{
    [Table("BaloonPayment")]
   public class BaloonPayment : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public int Fk_ScheduleTempId { get; set; }
        public decimal BaloonPaymentAmount { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal BpcAmount { get; set; }
        public decimal FEDonBPC { get; set; }
        public decimal TotalPayableBP { get; set; }
        public bool isPaid { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
