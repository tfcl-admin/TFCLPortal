using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Transactions.Dto
{
    [AutoMapFrom(typeof(Transaction))]
    public class TransactionListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public DateTime DepositDate { get; set; }
        public string Reference { get; set; }
        public string CNIC { get; set; }
        public string ClientID { get; set; }
        public string Branch { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public int ApplicationId { get; set; }
        public int Fk_AccountId { get; set; }
        public string Details { get; set; }
        public string AmountWords { get; set; }
        public int CompanyBankId { get; set; }
        public string ModeOfPayment { get; set; }
        public string ModeOfPaymentOther { get; set; }
        public bool? isAuthorized { get; set; }
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }
    }
}
