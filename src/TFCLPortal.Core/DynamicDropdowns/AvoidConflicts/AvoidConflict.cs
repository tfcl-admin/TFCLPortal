using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.AvoidConflicts
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("AvoidConflict")]
    public class AvoidConflict : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
