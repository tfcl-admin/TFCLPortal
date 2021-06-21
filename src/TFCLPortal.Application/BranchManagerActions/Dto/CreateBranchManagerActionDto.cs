using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BranchManagerActions.Dto
{
    [AutoMapTo(typeof(BranchManagerAction))]
    public class CreateBranchManagerActionDto
    {
        public string ActionType { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenName { get; set; }
        public string Reason { get; set; }
        public bool isActive { get; set; }
        public bool isReSubmitted { get; set; }
        public string ActionBy { get; set; }
    }
}
