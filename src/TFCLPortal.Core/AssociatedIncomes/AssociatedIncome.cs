using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.AssociatedIncomes
{
    [Table("AssociatedIncome")]
    public class AssociatedIncome : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string isAssociatedIncome { get; set; }
        public string GrandTotalAssociatedIncome { get; set; }
    }
}
