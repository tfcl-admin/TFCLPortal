using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace TFCLPortal.PaymentChargesDeviationMatrix
{
    [Table("PaymentChargesDeviationMatrix")]
    public class PaymentChargesDeviationMatric : FullAuditedEntity<Int32>
    {
        public string Type { get; set; }
        public Decimal MaxAmount { get; set; }
        public decimal Percentage { get; set; }
    }
}
