using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.WriteOffs.Dto
{
    [AutoMapTo(typeof(WriteOff))]
    public  class CreateWriteOff
    {
        public int ApplicationId { get; set; }
        public decimal OsPrincipalAmount { get; set; }
        public decimal OsMarkupAmount { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public string RecoveryStatus { get; set; }
        public decimal RebatePercentage { get; set; }
        public decimal TotalAmountPayableRebate { get; set; }
        public decimal AmountDeposited { get; set; }

        public bool? isAuthorized { get; set; }
        public string RejectionReason { get; set; }
    }
}
