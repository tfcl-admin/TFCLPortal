using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.InventoryEntrySources
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("InventoryEntrySource")]
    public class InventoryEntrySource : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
