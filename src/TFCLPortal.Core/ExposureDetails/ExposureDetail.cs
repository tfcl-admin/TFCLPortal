using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ExposureDetails
{
    [Table("ExposureDetail")]
    public class ExposureDetail : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string GuaranteedTFCLLoan { get; set; }
        public string GuaranteeTFCLAmount { get; set; }
        public string ExistingBankExposure { get; set; }
        
        public string TotalAmount { get; set; }
        
        public decimal TotalInstallmentpayment { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        //NEW
        public DateTime? ExistingExposureAsOn { get; set; }
        public DateTime? CreditBureauGeneration { get; set; }

        public string guaranteedAmountFI { get; set; }
        public string GuaranteedFiLoan { get; set; }

        public string AppNoTfclLoanGuarantee { get; set; }
        public string ApplicantNameTfclLoanGuarantee { get; set; }

    }
}
