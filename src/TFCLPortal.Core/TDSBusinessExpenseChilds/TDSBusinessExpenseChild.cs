using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TDSBusinessExpenses
{
    [Table("TDSBusinessExpenseChild")]
    public class TDSBusinessExpenseChild : FullAuditedEntity<Int32>
    {
        public int Fk_TDSBusinessExpenseid  { get; set; }
       
        public string BusinessName { get; set; }
        public string TotalSalary { get; set; }
        public string Purchases  { get; set; }
        public string StaffSalary { get; set; }
        public string RentAmount { get; set; }
        public string Utilities { get; set; }
        public string Entertainment { get; set; }
        public string RepairMaintenance { get; set; }
        public string Transportation { get; set; }
        public string Carriage { get; set; }
        public string Committee { get; set; }
        public string Tax { get; set; }
        public string Internet { get; set; }

        public string OtherExpenses { get; set; }


        public string OtherExpenseLabelOne { get; set; }
        public string OtherExpenseValueOne { get; set; }
        public string OtherExpenseLabelTwo { get; set; }
        public string OtherExpenseValueTwo { get; set; }
        public string OtherExpenseLabelThree { get; set; }
        public string OtherExpenseValueThree { get; set; }

        public string TotalMonthlyExpenses { get; set; }
        public string ProvisionOfExpenses { get; set; }
        public string AmountOfProvision { get; set; }
        public string MonthlyBusinessExpenses { get; set; }


    }
}
