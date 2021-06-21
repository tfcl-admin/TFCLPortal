using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TdsInventoryDetailChilds
{
    [Table("TdsInventoryDetailChild")]
    public class TdsInventoryDetailChild : AuditedEntity<int>
    {
        public int Fk_TdsInventoryDetail { get; set; }
        public string BusinessName { get; set; }
        public string TotalInventoryQty { get; set; }
        public string TotalInventoryPurchasePrice { get; set; }
        public string TotalInventoryTotalPurchasePrice { get; set; }
        public string TotalInventorySalePrice { get; set; }
        public string TotalInventoryTotalSalePrice { get; set; }
        public string TotalVariancePercentage { get; set; }
        public int InventoryRecordMaintenance { get; set; }
        public int InventoryEntrySource { get; set; }
        public string TotalGrossMargin { get; set; }

    }
}
