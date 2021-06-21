using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.LoanAmortizationChild.Dto
{
    [AutoMapTo(typeof(TFCLPortal.LoanAmortizations.LoanAmortizationChild))]
    public class CreateLoanAmortizationChildDto
    {

    
        public int Fk_LoanAmortization { get; set; }
        public int TotalInstallmentCount { get; set; }
        public int InstallmentSerial { get; set; }
        public DateTime InstallmentDueDate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal TotalInstallment { get; set; }
        public DateTime InstallmentPaidDate { get; set; }
        public int LateDayDFD { get; set; }
        public decimal RemainingBalance { get; set; }
        public string PaymentStatus { get; set; }

    }
}
