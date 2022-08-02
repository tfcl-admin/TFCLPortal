using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Transactions;

namespace TFCLPortal.Reversals.Dto
{
    [AutoMapFrom(typeof(Reversal))]
    public class ReversalListDto : FullAuditedEntityDto
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string SchoolName { get; set; }
        public string CNIC { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int InitiatedBy { get; set; }
        public int TransactionId { get; set; }
        public int AuthorizedBy { get; set; }
        public string Details { get; set; }
        public bool? isAuthorized { get; set; }

        public List<Transaction> transactions { get; set; }

    }
}
