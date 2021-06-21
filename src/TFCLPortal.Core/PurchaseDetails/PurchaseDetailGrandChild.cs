using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.PurchaseDetails
{
    [Table("PurchaseDetailGrandChild")]
    public class PurchaseDetailGrandChild : FullAuditedEntity<Int32>
    {
        public int Fk_PurchaseDetailChildId { get; set; }

        public string SrNo { get; set; }
        public string ItemName { get; set; }
        public string PerUnitPurchasePrice { get; set; }
        public string MonthlyPurchaseUnit { get; set; }
        public string TotalPurchase { get; set; }

    }
}
