using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.PurchaseDetails
{
    [Table("PurchaseDetail")]
    public class PurchaseDetail : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string grandTotalPurchaseToBeConsidered { get; set; }
    }
}
