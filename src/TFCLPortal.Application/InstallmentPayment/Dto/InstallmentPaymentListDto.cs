using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.InstallmentPayments.Dto
{
   [ AutoMapFrom(typeof(InstallmentPayment))]
   public class InstallmentPaymentListDto : Entity<int>
    {
        public DateTime EntryDate { get; set; }
        public int ApplicationId { get; set; }
        public int NatureOfPayment { get; set; } // Dropdown
        public string NatureOfPaymentName { get; set; } // Dropdown
        public DateTime InstallmentDueDate { get; set; }
        public decimal InstallmentAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public string NatureOfPaymentOthers { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal DueAmount { get; set; }
        public string ModeOfPayment { get; set; }
        public string ModeOfPaymentOthers { get; set; }
        public decimal ExcessShortPayment { get; set; }
        public decimal Amount { get; set; }
        public string AmountWords { get; set; }
        public DateTime DepositDate { get; set; }
        public int FK_CompanyBankId { get; set; }// Dropdown
        public string CompanyBankName { get; set; }// Dropdown
        public bool isLateDaysApplied { get; set; }
        public int LateDays { get; set; }
        public decimal LateDaysPenalty { get; set; }
        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }

        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string SchoolName { get; set; }
        public int branchId { get; set; }



    }
}
