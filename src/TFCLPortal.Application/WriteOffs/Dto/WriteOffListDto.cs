using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.WriteOffs.Dto
{
   [ AutoMapFrom(typeof(WriteOff))]
   public class WriteOffListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsMarkupAmount { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public string RecoveryStatus { get; set; }
        public decimal RebatePercentage { get; set; }
        public decimal TotalAmountPayableRebate { get; set; }
        public decimal AmountDeposited { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string CNIC { get; set; }
        public string SchoolName { get; set; }
        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
    }
}
