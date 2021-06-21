using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ErrorLogs
{
    [AutoMapFrom(typeof(ErrorLog))]
    public class ErrorLogDto : Entity
    {
        public DateTime ErrorDate { get; set; }
        public string FunctionName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
