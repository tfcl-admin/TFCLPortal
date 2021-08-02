using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.NotificationLogs
{
    [Table("NotificationLog")]
    public class NotificationLog : FullAuditedEntity<Int32>
    {
        public int Reciever_UserId { get; set; }
        public string Reciever_Token { get; set; }
        public string title { get; set; }
        public string Body { get; set; }
        public bool isRead { get; set; }
    }
}
