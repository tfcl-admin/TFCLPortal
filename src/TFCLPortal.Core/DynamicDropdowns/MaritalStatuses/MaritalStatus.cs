using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.MaritalStatuses
{
    [Table("MaritalStatus")]
    public class MaritalStatus : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
