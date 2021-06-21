using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ApiCallLogs.Dto
{
    [AutoMapTo(typeof(ApiCallLog))]
    public class ApiCallLogListDto : EntityDto
    {
        public string FunctionName { get; set; }
        public string Input { get; set; }

    }
}
