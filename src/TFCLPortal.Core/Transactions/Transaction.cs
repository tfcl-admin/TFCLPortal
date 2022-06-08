using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Transactions
{
    [Table("Transaction")]
    public class Transaction : FullAuditedEntity<int>
    {
        public DateTime DepositDate { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public int ApplicationId { get; set; }
        public string Reference { get; set; }
        public int Fk_AccountId { get; set; }
        public string AmountWords { get; set; }
        public string ModeOfPaymentOther { get; set; }
        public int CompanyBankId { get; set; }
        public string ModeOfPayment { get; set; }
        public bool? isAuthorized { get; set; }
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }
    }
}
