using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ExposureDetailChilds;

namespace TFCLPortal.ExposureDetails.Dto
{
    [AutoMapTo(typeof(ExposureDetail))]
    public class UpdateExposureDetailDto 
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string GuaranteedTFCLLoan { get; set; }
        public string GuaranteeTFCLAmount { get; set; }
        public string ExistingBankExposure { get; set; }
        
        public string TotalAmount { get; set; }
        public decimal TotalInstallmentpayment { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public List<UpdateExposureChildDto> exposureDetailsList { get; set; }

        public DateTime? ExistingExposureAsOn { get; set; }
        public DateTime? CreditBureauGeneration { get; set; }

        public string guaranteedAmountFI { get; set; }
        public string FIAmount { get; set; }

        public string AppNoTfclLoanGuarantee { get; set; }
        public string ApplicantNameTfclLoanGuarantee { get; set; }



    }
}
