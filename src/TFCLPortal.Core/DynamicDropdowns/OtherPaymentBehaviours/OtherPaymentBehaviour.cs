
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.OtherPaymentBehaviours
{
    [Table("OtherPaymentBehaviour")]
    public class OtherPaymentBehaviour : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}