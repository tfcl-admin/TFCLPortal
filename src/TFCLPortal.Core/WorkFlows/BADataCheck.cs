using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Applications;

namespace TFCLPortal.WorkFlows
{
    [Table("BADataCheck")]
    public class BADataCheck : FullAuditedEntity<Int32>
    {
        public int Fk_UserId { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Applicationz Applications { get; set; }
        public int SDE_UserId { get; set; }
        public int BA_UserId { get; set; }
        public string DocumentKey { get; set; }
        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
        public string BaseUrl { get; set; }
    }
}
