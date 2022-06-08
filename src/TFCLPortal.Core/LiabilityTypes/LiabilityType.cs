using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.LiabilityTypes
{
    [Table("LiabilityType")]
    public class LiabilityType : FullAuditedEntity<Int32>
    {
        public string Name { get; set; }

    }
}
