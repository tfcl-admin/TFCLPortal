using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.CleanWaters
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("CleanWater")]
    public class CleanWater : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
