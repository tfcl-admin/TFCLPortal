using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.LoanNatures
{
    [Table("LoanNature")]
    public class LoanNature : FullAuditedEntity<Int32>
    {
        public string Name { get; set; }

    }
}
