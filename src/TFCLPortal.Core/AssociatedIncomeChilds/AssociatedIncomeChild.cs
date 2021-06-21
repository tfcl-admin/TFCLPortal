using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.AssociatedIncomeChilds
{
    [Table("AssociatedIncomeChild")]
    public class AssociatedIncomeChild : AuditedEntity<int>
    {
        public int Fk_AssociatedIncome { get; set; }
        public string isAssociatedIncome { get; set; }
        public string BranchName { get; set; }
        public string TotalAssociatedIncome { get; set; }
    }
}
