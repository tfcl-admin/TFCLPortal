using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DeviationApprovals.Dto
{
    [AutoMapFrom(typeof(DeviationApproval))]
    public class DeviationApprovalListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string Reason { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string DocumentUrl { get; set; }
    }
}
