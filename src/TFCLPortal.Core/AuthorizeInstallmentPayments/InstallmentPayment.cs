using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.AuthorizeInstallmentPayments
{
    [Table("AuthorizeInstallmentPayment")]
    public class AuthorizeInstallmentPayment : FullAuditedEntity<int>
    {
        public DateTime EntryDate { get; set; }
        public int ApplicationId { get; set; }
        public int NatureOfPayment { get; set; } // Dropdown
        public string NatureOfPaymentOthers { get; set; }
        public DateTime InstallmentDueDate { get; set; }
        public decimal InstallmentAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ExcessShortPayment { get; set; }
        public string ModeOfPayment { get; set; }
        public string ModeOfPaymentOthers { get; set; }
        public decimal Amount { get; set; }
        public string AmountWords { get; set; }
        public DateTime DepositDate { get; set; }
        public int FK_CompanyBankId { get; set; }// Dropdown
        public bool isLateDaysApplied { get; set; }
        public int LateDays { get; set; }
        public decimal LateDaysPenalty { get; set; }
        public string RejectionReason { get; set; }
        public bool? isAuthorized { get; set; }
    }
}
