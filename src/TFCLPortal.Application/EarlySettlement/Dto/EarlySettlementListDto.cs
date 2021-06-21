using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.EarlySettlements.Dto
{
   [ AutoMapFrom(typeof(EarlySettlement))]
   public class EarlySettlementListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string CNIC { get; set; }
        public string SchoolName { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal Markup { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsMarkupAmount { get; set; }
        public DateTime LastPaidInstallmentDate { get; set; }
        public DateTime TentativeSettlementDate { get; set; }
        public decimal OneDayMarkup { get; set; }
        public decimal DaysConsumed { get; set; }
        public bool isEarlySettlementCharges { get; set; }
        public decimal EarlySettlmentCharges { get; set; }
        public decimal FEDonESC { get; set; }
        public decimal PrincipalPayable { get; set; }
        public decimal MarkupPayable { get; set; }
        public decimal previousBalance { get; set; }
        public decimal totalAmountPayable { get; set; }
        public decimal amountDeposited { get; set; }

        public bool isLateDays { get; set; }
        public decimal LatePaymentCharges { get; set; }
        public decimal FEDonLPC { get; set; }

        public bool? isAuthorized { get; set; }
        public string rejectionReason { get; set; }
    }
}
