using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BranchManagerActions
{
    [Table("BranchManagerAction")]
    public class BranchManagerAction : FullAuditedEntity<int>
    {
        public string ActionType { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenName { get; set; }
        public string Reason { get; set; }
        public bool isActive { get; set; }
        public bool isReSubmitted { get; set; }
        public string ActionBy { get; set; }
    }
}
