using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.NonAssociatedIncomeChilds
{
    [Table("NonAssociatedIncomeChild")]
    public class NonAssociatedIncomeChild : AuditedEntity<int>
    {
        public int Fk_NonAssociatedIncome { get; set; }
        public int? OtherOccupation { get; set; }
        public string OtherOccupationOthers { get; set; }
        public int? SourceOfIncome { get; set; }
        public string SourceOfIncomeOthers { get; set; }
        public bool? DocumentProof { get; set; }
        public string ActualRevenue { get; set; }
        public string ConsideredPercentage { get; set; }
        public string ConsideredAmount { get; set; }
    }
}
