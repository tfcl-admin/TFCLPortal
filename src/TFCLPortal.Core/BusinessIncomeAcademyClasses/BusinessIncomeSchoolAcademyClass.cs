using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessIncomeAcademyClasses
{
    [Table("BusinessIncomeSchoolAcademyClass")]
    public class BusinessIncomeSchoolAcademyClass : FullAuditedEntity<Int32>
    {
        public int Fk_BusinessIncomeChildAcademy { get; set; }
        public string ClassName { get; set; }
        public string NoOfStudents { get; set; }
        public string PerStudentFee { get; set; }
        public string TotalFee { get; set; }
    }
}
