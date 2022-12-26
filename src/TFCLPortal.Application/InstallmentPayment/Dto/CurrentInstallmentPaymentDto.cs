using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.InstallmentPayments.Dto
{
   //[ AutoMapFrom(typeof(InstallmentPayment))]
   public class CurrentInstallmentPaymentDto //: FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string ClientId { get; set; } // 
        public string ClientName { get; set; } // 
        public string InstallmentDueDate { get; set; } // 
        public string InstallmentAmount { get; set; } // 
        public string InstallmentNumber { get; set; } // 
        public string RemainingInstallments { get; set; } // 
        public decimal PreviousBalance { get; set; } // 
        public decimal DueAmount { get; set; } //// 
        public decimal Payment { get; set; } //// 
        public string RestrictionError { get; set; } //// 
        public bool displayButton { get; set; } //// 
      
    }
}
