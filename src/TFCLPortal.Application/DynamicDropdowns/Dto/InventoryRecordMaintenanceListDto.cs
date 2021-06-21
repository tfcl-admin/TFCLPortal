using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.InventoryRecordMaintenances;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(InventoryRecordMaintenance))]
    public class InventoryRecordMaintenanceListDto : Entity
    {
        public string Name { get; set; }
    }
}
