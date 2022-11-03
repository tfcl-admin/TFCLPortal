using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ClosingMonths
{
    [Table("ClosingMonth")]
    public class ClosingMonth : FullAuditedEntity<Int32>
    {
        public DateTime closingDate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int BranchId { get; set; }

    }
}
