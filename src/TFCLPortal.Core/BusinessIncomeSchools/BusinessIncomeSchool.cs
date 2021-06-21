using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessIncomeSchools
{
    [Table("BusinessIncomeSchool")]
    public class BusinessIncomeSchool : FullAuditedEntity<Int32>
    {
        public int Fk_BusinessIncome { get; set; }
        public string SchoolName { get; set; }

        public string TotalStudentsMale { get; set; }
        public string TotalStudentsFemale { get; set; }
        public string TotalStudentsTotal { get; set; }
        public string TotalAvgFee { get; set; }



        public string ClassName { get; set; }
        public string NoOfStudents { get; set; }
        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }

        //New
        public string totalFeeCollection { get; set; }
        public string CollectionEfficiency { get; set; }
        public string GenderBalance { get; set; }
        public string ActualStudents { get; set; }
        public string StudentsConsidered { get; set; }
        public string StudentsDifference { get; set; }
        public string ReasonForDifference { get; set; }
        public string StudentTeacherRatio { get; set; }
        public string StudentClassroomRatio { get; set; }
        public string ConsideredSchoolFee { get; set; }
    }
}
