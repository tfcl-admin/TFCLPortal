using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ErrorLogs
{
    [Table("ErrorLog")]
    public class ErrorLog : FullAuditedEntity<Int32>
    {
        public DateTime ErrorDate { get; set; }
        public string FunctionName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

    }
}
