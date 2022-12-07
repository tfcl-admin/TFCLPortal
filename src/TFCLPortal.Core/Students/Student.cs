using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Students
{
    [Table("Student")]
    public class Student : FullAuditedEntity<Int32>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
    }
}
