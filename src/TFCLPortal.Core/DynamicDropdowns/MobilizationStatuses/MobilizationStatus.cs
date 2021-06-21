using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.MobilizationStatuses
{
    [Table("MobilizationStatus")]
    public class MobilizationStatus : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
