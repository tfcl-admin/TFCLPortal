using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("InventoryRecordMaintenance")]
    public class InventoryRecordMaintenance : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
