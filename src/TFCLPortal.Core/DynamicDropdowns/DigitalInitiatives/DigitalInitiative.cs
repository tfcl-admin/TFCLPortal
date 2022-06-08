using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.DigitalInitiatives
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("DigitalInitiative")]
    public class DigitalInitiative : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
