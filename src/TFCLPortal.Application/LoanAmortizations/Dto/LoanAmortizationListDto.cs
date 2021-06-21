using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.LoanAmortizations.Dto
{
    [AutoMapFrom(typeof(LoanAmortization))]
    public class LoanAmortizationListDto:EntityDto
    {

        public int Fk_Product { get; set; }

        public int ApplicationId { get; set; }
        public decimal LoanAmount { get; set; }
        public int Tenure { get; set; }
        public decimal TotalInstallmentPayment { get; set; }
        public decimal InstallmentPayment { get; set; }
        public decimal APR { get; set; }
        public decimal IntrestAmount { get; set; }
        public decimal IRR { get; set; }
        public DateTime LoanDisbursementDate { get; set; }
        public int GraceDays { get; set; }
        public DateTime LoanStartDate { get; set; }
        public decimal MarkUp { get; set; }
        public decimal NetMarkup { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public string ScreenCode { get; set; }
        public string Comments { get; set; }
        public decimal GraceDaysAmount { get; set; }
    }
}
