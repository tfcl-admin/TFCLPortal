using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DeceasedAuthorizations.Dto
{
   [ AutoMapFrom(typeof(DeceasedAuthorization))]
   public class DeceasedAuthorizationListDto : Entity<int>
    {
        public int ApplicationId { get; set; }

        public string ClientName { get; set; }
        public string CNIC { get; set; }
        public string ClientID { get; set; }
        public string SchoolName { get; set; }

        public string DateOfDeath { get; set; }
        public string ReasonOfDeath { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
        public string VerifiedBy { get; set; }

        public string ProofUrl { get; set; }
    }
}
