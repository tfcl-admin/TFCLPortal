using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.NonAssociatedIncomes
{
    [Table("NonAssociatedIncome")]
    public class NonAssociatedIncome : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string isNonAssociatedIncome { get; set; }
        public string TotalNonAssociatedIncome { get; set; }
    }
}
