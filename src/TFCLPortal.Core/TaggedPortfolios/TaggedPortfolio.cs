using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TaggedPortfolios
{
    [Table("TaggedPortfolio")]
    public class TaggedPortfolio : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public int OldUserId { get; set; }
        public int NewUserId { get; set; }
        public string Comments { get; set; }
        public bool? isApproved { get; set; }
    }
}
