using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.AcademicSessions
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("AcademicSession")]
    public class AcademicSession : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
