using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.FinalWorkflows
{
    [Table("FinalWorkflow")]
    public class FinalWorkflow : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public int ActionBy { get; set; }
        public string Action { get; set; }
        public bool isActive { get; set; }
        public string ApplicationState { get; set; }
    }
}
