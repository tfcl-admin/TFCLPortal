using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.DropdownUpdateStatuses
{
    [Table("DropdownUpdateStatus")]
    public class DropdownUpdateStatus : AuditedEntity<Int32>
    {
        public bool UpdateStatus { get; set; }

    }
}
