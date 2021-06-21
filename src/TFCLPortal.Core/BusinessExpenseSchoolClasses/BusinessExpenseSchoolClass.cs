using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BusinessExpenseSchoolClasses
{
    [Table("BusinessExpenseSchoolClass")]
    public class BusinessExpenseSchoolClass : FullAuditedEntity<Int32>
    {
        public int Fk_BusinessExpenseSchool { get; set; }
        public string ClassNameOrSubject { get; set; }

        public int? Designation { get; set; }
        public int? Gender { get; set; }
        public string Salary { get; set; }
    }
}
