using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TdsInventoryDetails
{
    [Table("TdsInventoryDetail")]
    public class TdsInventoryDetail : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string GrandTotalSalePrice { get; set; }
        public string GrandTotalPurchasePrice { get; set; }
    }
}
