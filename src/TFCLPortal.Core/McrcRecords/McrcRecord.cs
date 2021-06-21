using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Applications;
using TFCLPortal.Authorization.Users;

namespace TFCLPortal.McrcRecords
{
    [Table("McrcRecord")]
    public class McrcRecord : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public int User3Id { get; set; }
        public int User4Id { get; set; }
        public int User5Id { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }

    }
}
