using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ExposureDetails.Dto
{
    [AutoMapFrom(typeof(ExposureDetail))]
    public class ExposureDetailListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string GuaranteedTFCLLoan { get; set; }
        public string GuaranteeTFCLAmount { get; set; }
        public string ExistingBankExposure { get; set; }
        public string BankName { get; set; }
        public string TypeOfFacilityTE { get; set; }
        public string LoanAmount { get; set; }
        public string OutstandingAmount { get; set; }
        public string TotalAmount { get; set; }
        public decimal MonthlyInstallmentPayment { get; set; }
        public decimal TotalInstallmentpayment { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public List<ExposureDetailChildListDto> exposureDetailsList { get; set; }

        //NEW
        public DateTime? ExistingExposureAsOn { get; set; }
        public DateTime? CreditBureauGeneration { get; set; }

        public string guaranteedAmountFI { get; set; }
        public string GuaranteedFiLoan { get; set; }

        public string AppNoTfclLoanGuarantee { get; set; }
        public string ApplicantNameTfclLoanGuarantee { get; set; }

    }
}
