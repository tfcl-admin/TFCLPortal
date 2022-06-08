using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DeceasedSettlements.Dto
{
    [AutoMapTo(typeof(DeceasedSettlement))]
    public  class CreateDeceasedSettlement
    {
        public int ApplicationId { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsMarkupAmount { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public decimal AmountDeposited { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }

        public bool? isManagerAuthorized { get; set; }
        public string ManagerRejectionReason { get; set; }
        public string ProofUrl { get; set; }
        public IFormFile file { get; set; }

    }
}
