
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(InventoryRecordMaintenance))]
    public class CreateInventoryRecordMaintenanceDto
    {
        public string Name { get; set; }
    }
}
