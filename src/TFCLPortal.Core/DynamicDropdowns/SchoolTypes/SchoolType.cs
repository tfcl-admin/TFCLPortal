using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.SchoolTypes
{
    [Table("SchoolType")]
    public class SchoolType : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
