using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ClientStatuses
{
    [Table("ClientStatus")]
    public class ClientStatus : FullAuditedEntity<Int32>
    {
        public string Name { get; set; }

    }
}
