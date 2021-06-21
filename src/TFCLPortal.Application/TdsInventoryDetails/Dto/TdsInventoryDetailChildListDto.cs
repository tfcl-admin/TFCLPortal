using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.TdsInventoryDetailChilds;
using TFCLPortal.TdsInventoryDetailGrandChilds;

namespace TFCLPortal.TdsInventoryDetails.Dto
{
    [AutoMapFrom(typeof(TdsInventoryDetailChild))]
    public class TdsInventoryDetailChildListDto : Entity
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
        public string InventoryRecordMaintenanceName { get; set; }
        public int InventoryEntrySource { get; set; }
        public string TotalGrossMargin { get; set; }
        public string InventoryEntrySourceName { get; set; }
        public List<TdsInventoryDetailGrandChildListDto> TdsInventoryDetailGrandChilds { get; set; }
}
}
