using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessIncomeSchoolAcademies
{
    [Table("BusinessIncomeSchoolAcademy")]
    public class BusinessIncomeSchoolAcademy : FullAuditedEntity<Int32>
    {
        public int Fk_BusinessIncomeChild { get; set; }
        public string AcademyName { get; set; }
        public string TotalFeeCalculation { get; set; }
        public string CollectionEfficiency { get; set; }
        public string ConsideredAcademyFee { get; set; }
        public string ActualStudents { get; set; }
        public string ConsideredStudents { get; set; }
        public string StudentDifference { get; set; }
        public string ReasonForDifference { get; set; }

        public string classesTotalStudents { get; set; }
        public string classesTotalAvgFee { get; set; }
    }
}

