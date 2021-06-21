using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessIncomeSchoolClasses
{
    [Table("BusinessIncomeSchoolClass")]
    public class BusinessIncomeSchoolClass : FullAuditedEntity<Int32>
    {
        public int Fk_BusinessIncomeChild { get; set; }
        public string ClassName { get; set; }

        public string MaleStudents { get; set; }
        public string FemaleStudents { get; set; }
        public string NoOfStudents { get; set; }

        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }
    }
}
