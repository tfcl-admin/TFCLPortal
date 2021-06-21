using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TdsInventoryDetailChilds;

namespace TFCLPortal.TdsInventoryDetails.Dto
{
    [AutoMapTo(typeof(TdsInventoryDetailChild))]
    public class CreateTdsInventoryDetailChildDto
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
        public string TotalGrossMargin { get; set; }
        public int InventoryEntrySource { get; set; }
        public List<CreateTdsInventoryDetailGrandChildDto> TdsInventoryDetailGrandChilds { get; set; }
    }
}
