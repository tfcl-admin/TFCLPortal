using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.LegalStatuses
{
    [Table("LegalStatus")]
    public class LegalStatus : FullAuditedEntity<Int32>
    {
        public string Name { get; set; }

    }
}
