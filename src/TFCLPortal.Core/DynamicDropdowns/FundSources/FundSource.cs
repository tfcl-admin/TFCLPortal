using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.FundSources
{
    [Table("FundSource")]
    public class FundSource : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
