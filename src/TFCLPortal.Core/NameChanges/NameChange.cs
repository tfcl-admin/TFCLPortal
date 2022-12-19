using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.NameChanges
{
    [Table("NameChange")]
    public class NameChange : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string OldClientName { get; set; }
        public string NewClientName { get; set; }
        public string OldBusinessName { get; set; }
        public string NewBusinessName { get; set; }

    }
}
