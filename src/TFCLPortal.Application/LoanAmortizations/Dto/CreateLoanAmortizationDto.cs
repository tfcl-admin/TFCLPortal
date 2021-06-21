using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Applications.Dto;
using TFCLPortal.LoanAmortizationChilds.Dto;


namespace TFCLPortal.LoanAmortizations.Dto
{
    [AutoMapTo(typeof(LoanAmortization))]
    public class CreateLoanAmortizationDto
    {
        public int Fk_Product { get; set; }
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
        public string SchoolName { get; set; }
        public int ApplicationId { get; set; }

        public decimal GraceDaysAmount { get; set; }
        public ApplicationListDto Applicationdata { get; set; }
        public List<CreateLoanAmortizationChildDto> LoanAmortizationChilds { get; set; }


    }
}
