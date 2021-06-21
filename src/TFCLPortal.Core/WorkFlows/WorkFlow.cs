using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.WorkFlows
{
    [Table("WorkFlow")]
    public class WorkFlow: FullAuditedEntity<Int32>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
    }
}
