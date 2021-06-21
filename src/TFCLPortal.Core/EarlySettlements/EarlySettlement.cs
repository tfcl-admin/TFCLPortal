using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.EarlySettlements
{
    [Table("EarlySettlement")]
    public class EarlySettlement : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
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
        public decimal MarkupPayable { get; set; }
        public decimal PrincipalPayable { get; set; }
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
