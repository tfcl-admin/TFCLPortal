using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.EnhancementRequests
{
    [Table("EnhancementRequests")]
    public class EnhancementRequest : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; }
        public int RequestState { get; set; }
    }
}
