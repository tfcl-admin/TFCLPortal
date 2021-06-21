using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.Districts
{
    [Table("District")]
    public class District : AuditedEntity<Int32>
    {
        public string Name { get; set; }
        public int Fk_ProvinceId { get; set; }
        
    }
}
