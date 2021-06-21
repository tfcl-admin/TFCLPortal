using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessExpenses
{
    [Table("BusinessExpense")]
    public class BusinessExpense : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public decimal TeacherSalary { get; set; }
        public decimal OtherSalary { get; set; }
        public decimal Rent { get; set; }
        public decimal Utilities { get; set; }
        public decimal Entertainment { get; set; }
        public decimal RepairMaintenance { get; set; }
        public decimal Transportation { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal TotalMonthlyExpneses { get; set; }
        public decimal ProvisisonExpneses { get; set; }
        public decimal NetMonthlyBusinessExpense { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        //NEW
        public string nGrandTotalBusinessExpense { get; set; }
        public string nPercentageOfBeAgaintNETbI { get; set; }
        public string nMinConsideredPercentage { get; set; }
        public string nConsideredBusinessExpense { get; set; }
    }
}
