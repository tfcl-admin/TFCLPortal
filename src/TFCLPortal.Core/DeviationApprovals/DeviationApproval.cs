using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DeviationApprovals
{
    [Table("DeviationApproval")]
    public class DeviationApproval : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string Reason { get; set; } 
        public string FieldName { get; set; } 
        public string OldValue { get; set; } 
        public string NewValue { get; set; }
        public string DocumentUrl { get; set; }

    }
}
