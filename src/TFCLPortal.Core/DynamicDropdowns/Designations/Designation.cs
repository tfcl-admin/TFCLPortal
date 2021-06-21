using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.Designations
{
    //NEW DROPDOWN API Addition 

    [Table("Designation")]
    public class Designation : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
