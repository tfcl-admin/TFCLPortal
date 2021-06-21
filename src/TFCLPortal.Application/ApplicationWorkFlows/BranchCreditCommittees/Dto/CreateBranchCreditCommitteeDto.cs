using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees.Dto
{
    [AutoMapTo(typeof(BranchCreditCommittee))]
    public  class CreateBranchCreditCommitteeDto
    {
        public long SDE1_UserId { get; set; }
        public long SDE2_UserId { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }
    }
}
