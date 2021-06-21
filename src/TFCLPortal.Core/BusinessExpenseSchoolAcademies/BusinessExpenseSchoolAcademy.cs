using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessExpenseSchoolAcademies
{
    [Table("BusinessExpenseSchoolAcademy")]
    public class BusinessExpenseSchoolAcademy : FullAuditedEntity<Int32>
    {
        public int Fk_BusinessExpenseSchool { get; set; }
        public string AcademyName { get; set; }
        public string TeacherSalary { get; set; }
        public string OtherSalary { get; set; }
        public string RentAmount { get; set; }
        public string Utilities { get; set; }
        public string Entertainment { get; set; }
        public string RepairAndMaintenance { get; set; }
        public string Transportation { get; set; }
        public string Stationary { get; set; }
        public string RoyaltyFee { get; set; }
        public string Committee { get; set; }
        public string InternetCharges { get; set; }
        public string OtherExpenses { get; set; }
        public string TotalMonthlyExpenses { get; set; }
        public string ProvisionOfExpenses { get; set; }
        public string MonthlyBusinessExpenses { get; set; }

        public string AdditionalFieldLabel1 { get; set; }
        public string AdditionalFieldValue1 { get; set; }
        public string AdditionalFieldLabel2 { get; set; }
        public string AdditionalFieldValue2 { get; set; }
        public string AdditionalFieldLabel3 { get; set; }
        public string AdditionalFieldValue3 { get; set; }
    }
}

