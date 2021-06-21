using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.LoanAmortizations
{
    [Table("LoanAmortizationChild")]
    public  class LoanAmortizationChild:FullAuditedEntity<Int32>
    {

        [ForeignKey("Fk_LoanAmortization")]
        public LoanAmortization LoanAmortization { get; set; }
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
