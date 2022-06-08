using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.BuildingConditions
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("BuildingCondition")]
    public class BuildingCondition : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
