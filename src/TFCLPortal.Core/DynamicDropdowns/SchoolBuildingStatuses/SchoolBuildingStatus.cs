using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.BuildingStatuses
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("BuildingStatus")]
    public class BuildingStatus : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
