using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DeceasedAuthorizations.Dto
{
    [AutoMapTo(typeof(DeceasedAuthorization))]
    public  class CreateDeceasedAuthorization
    {
        public int ApplicationId { get; set; }

        public string ClientName { get; set; }
        public string CNIC { get; set; }

        public string DateOfDeath { get; set; }
        public string ReasonOfDeath { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
        public string VerifiedBy { get; set; }

        public string ProofUrl { get; set; }

        public IFormFile file { get; set; }

    }
}
