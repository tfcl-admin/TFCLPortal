using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.HouseholdIncomesExpenses
{
    [Table("HouseholdIncomeExpense")]
    public class HouseholdIncomeExpense : FullAuditedEntity<Int32>
    {
        public int fk_HouseHoldParentID { get; set; }
        public string HouseholdOwnerName { get; set; }
        public string HouseholdIncome { get; set; }
        public string HouseRent { get; set; }
        public string Food { get; set; }
        public string Clothing { get; set; }
        public string Medical { get; set; }
        public string Utilities { get; set; }
        public string Educational { get; set; }
        public string LoanInstallment { get; set; }
        public string CommitteeInstallment { get; set; }
        public string OtherHouseholdExpenses { get; set; }
        public string ProvisionalHouseholdExpenses { get; set; }
        public string NetTotal { get; set; }
        public string Internet { get; set; } //NEW
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        public string MonthlyEIfee { get; set; }
        public string MonthlyTuitionfee { get; set; }
        public string MonthlyQarifee { get; set; }
        public string VanTransportationOfDependents { get; set; }
        public string OtherEducationalExpenses { get; set; }
        public string HouseHoldTransportation { get; set; }


        public string AdditionalFieldLabel1 { get; set; }
        public string AdditionalFieldValue1 { get; set; }
        public string AdditionalFieldLabel2 { get; set; }
        public string AdditionalFieldValue2 { get; set; }
        public string AdditionalFieldLabel3 { get; set; }
        public string AdditionalFieldValue3 { get; set; }

        public string RepairAndMentinence { get; set; }
        public string TotalHouseHoldExpense { get; set; }
    }
}
