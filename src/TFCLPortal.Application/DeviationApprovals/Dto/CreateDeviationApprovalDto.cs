using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DeviationApprovals.Dto
{
    [AutoMapTo(typeof(DeviationApproval))]
    public class CreateDeviationApprovalDto
    {
        public int ApplicationId { get; set; }
        public string Reason { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string DocumentUrl { get; set; }
    }
}
