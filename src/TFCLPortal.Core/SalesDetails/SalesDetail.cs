using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.SalesDetails
{
    [Table("SalesDetail")]
    public class SalesDetail : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string grandTotalSalesToBeConsidered { get; set; }
    }
}
