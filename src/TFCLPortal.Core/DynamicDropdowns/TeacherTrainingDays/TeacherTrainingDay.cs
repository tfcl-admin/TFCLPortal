using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.TeacherTrainingDays
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("TeacherTrainingDay")]
    public class TeacherTrainingDay : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
