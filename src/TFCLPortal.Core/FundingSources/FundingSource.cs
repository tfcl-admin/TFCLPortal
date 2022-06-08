using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.FundingSources
{
    [Table("FundingSource")]
    public class FundingSource : FullAuditedEntity<int>
    {
        public string Name { get; set; }

    }
}
