using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Users.Dto;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees.Dto
{
    [AutoMapFrom(typeof(BranchCreditCommittee))]
    public  class BranchCreditCommitteeListDto : FullAuditedEntityDto<int>
    {
        public long SDE1_UserId { get; set; }
        public long SDE2_UserId { get; set; }
        public UserDto SDE1_User { get; set; }
      
       
        public UserDto SDE2_User { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }
        public ApplicationListDto Applications { get; set; }



    }
}
