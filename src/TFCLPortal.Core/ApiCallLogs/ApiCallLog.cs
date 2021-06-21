using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ApiCallLogs
{
    [Table("ApiCallLog")]
    public class ApiCallLog : FullAuditedEntity<Int32>
    {
        public string FunctionName { get; set; }
        public string Input { get; set; }

    }
}
