using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.AppScreenStatuses
{
    [Table("AppScreenStatus")]
    public class AppScreenStatus : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public string ScreenStatus { get; set; }
    }
}
