using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.CreditBureauReporteds
{
    [Table("CreditBureauReported")]
    public class CreditBureauReported : AuditedEntity<Int32>
    {
        public string Name { get; set; }

    }
}
