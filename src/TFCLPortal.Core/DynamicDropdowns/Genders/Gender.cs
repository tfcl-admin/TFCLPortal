using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.Genders
{
    [Table("Gender")]
    public class Gender : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
