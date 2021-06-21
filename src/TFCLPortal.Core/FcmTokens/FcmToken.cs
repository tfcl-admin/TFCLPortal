using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.FcmTokens
{
    [Table("FcmToken")]
    public class FcmToken : FullAuditedEntity<Int32>
    {
        public int FK_UserId { get; set; }
        public string Token { get; set; }

    }
}
