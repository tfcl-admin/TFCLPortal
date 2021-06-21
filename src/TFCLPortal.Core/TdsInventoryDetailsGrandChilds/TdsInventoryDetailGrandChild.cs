using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TdsInventoryDetailGrandChilds
{
    [Table("TdsInventoryDetailGrandChild")]
    public class TdsInventoryDetailGrandChild : AuditedEntity<int>
    {
        public int Fk_TdsInventoryDetailChild { get; set; }
        public string ItemName { get; set; }
        public string qty { get; set; }
        public string PurchasedPrice { get; set; }
        public string TotalPurchasedPrice { get; set; }
        public string SalePrice { get; set; }
        public string TotalSalePrice { get; set; }
        public string GrossMargin { get; set; }
        public string PhysicallyVerified { get; set; }
        public string VariancePercentage { get; set; }
    }
}
