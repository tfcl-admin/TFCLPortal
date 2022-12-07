using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Klasses
{
    [Table("Klass")]
    public class Klass : FullAuditedEntity<Int32>
    {
         
        public string Name { get; set; }
        public int TotalStudents { get; set; }
    }
}
