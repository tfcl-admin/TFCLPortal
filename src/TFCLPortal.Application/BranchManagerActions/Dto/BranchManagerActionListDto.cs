using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BranchManagerActions.Dto
{
    [AutoMapFrom(typeof(BranchManagerAction))]
    public class BranchManagerActionListDto : FullAuditedEntity<int>
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
