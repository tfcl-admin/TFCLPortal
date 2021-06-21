using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Banks
{
    [Table("Bank")]
    public class Bank : FullAuditedEntity<int>
    {
        public string Name { get; set; }

    }
}
