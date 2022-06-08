using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DeceasedSettlements.Dto
{
   [ AutoMapFrom(typeof(DeceasedSettlement))]
   public class DeceasedSettlementListDto : Entity<int>
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


        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string CNIC { get; set; }
        public string SchoolName { get; set; }

        public string ProofUrl { get; set; }

    }
}
