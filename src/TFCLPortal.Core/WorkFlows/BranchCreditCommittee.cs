using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Applications;
using TFCLPortal.Authorization.Users;

namespace TFCLPortal.WorkFlows
{
    [Table("BranchCreditCommittee")]
    public class BranchCreditCommittee : FullAuditedEntity<Int32>
    {
        public long? SDE1_UserId { get; set; }

        [ForeignKey("SDE1_UserId")]
        public User SDE1_User { get; set; }
        public long? SDE2_UserId { get; set; }

        [ForeignKey("SDE2_UserId")]
        public User SDE2_User { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }


        [ForeignKey("ApplicationId")]
        public Applicationz Applications { get; set; }

    }
}
