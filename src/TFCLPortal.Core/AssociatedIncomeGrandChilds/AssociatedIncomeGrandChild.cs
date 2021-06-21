using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.AssociatedIncomeGrandChilds
{
    [Table("AssociatedIncomeGrandChild")]
    public class AssociatedIncomeGrandChild : AuditedEntity<int>
    {
        public int Fk_AssociatedIncomeChild { get; set; }
        public int? OtherAssociatedIncome { get; set; }
        public string OtherAssociatedIncomeOthers { get; set; }
        public bool? DocumentProof { get; set; }
        public string NumberOfStudents { get; set; }
        public string AvgCharges { get; set; }
        public string ProfitMargin { get; set; }
        public string YearlyRevenue { get; set; }
        public string MonthlyRevenue { get; set; }
        public string OtherAssociatedIncomeAmount { get; set; }
        public string ConsideredPercentage { get; set; }
        public string ConsideredAmount { get; set; }
    }
}
