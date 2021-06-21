using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.McrcStates
{
    [Table("McrcState")]
    public class McrcState : FullAuditedEntity<Int32>
    {
        public int Fk_UserId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_McrcId { get; set; }

    }
}
