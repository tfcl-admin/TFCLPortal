using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ApiCallLogs.Dto
{
    [AutoMapTo(typeof(ApiCallLog))]
    public class CreateApiCallLogDto
    {
        public string FunctionName { get; set; }
        public string Input { get; set; }

    }
}
