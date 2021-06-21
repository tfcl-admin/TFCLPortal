using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.DynamicDropdowns.InventoryEntrySources;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(InventoryEntrySource))]
    public class InventoryEntrySourceListDto : Entity
    {
        public string Name { get; set; }
    }
}
