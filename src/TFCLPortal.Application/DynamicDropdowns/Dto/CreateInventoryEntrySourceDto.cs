
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.InventoryEntrySources;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(InventoryEntrySource))]
    public class CreateInventoryEntrySourceDto
    {
        public string Name { get; set; }
    }
}
