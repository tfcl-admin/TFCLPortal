using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ExposureDetails.Dto
{
    [AutoMapTo(typeof(ExposureDetail))]
    public class CreateExposureDetailDto
    {
        public int ApplicationId { get; set; }
        public string GuaranteedTFCLLoan { get; set; }
        public string GuaranteeTFCLAmount { get; set; }
        public string ExistingBankExposure { get; set; }
        
        public string TotalAmount { get; set; }
       
        public decimal TotalInstallmentpayment { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        public DateTime? ExistingExposureAsOn { get; set; }
        public DateTime? CreditBureauGeneration { get; set; }

        public string guaranteedAmountFI { get; set; }
        public string GuaranteedFiLoan { get; set; }

        public string AppNoTfclLoanGuarantee { get; set; }
        public string ApplicantNameTfclLoanGuarantee { get; set; }

        public List<UpdateExposureChildDto> exposureDetailsList { get; set; }


        public bool isNew { get; set; }
        public string CurrentTotalAmount { get; set; }
        public string CurrentTotalInstallmentpayment { get; set; }
        public string LongtermTotalAmount { get; set; }
        public string LongtermInstallmentpayment { get; set; }

        // public List<ExposureDetailListDto> AddAnotherExposure { get; set; }
    }
}
