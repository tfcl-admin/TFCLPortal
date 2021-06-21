using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.DynamicDropdowns.ProductTypes;

namespace TFCLPortal.LoanAmortizations
{
    [Table("LoanAmortization")]
    public  class LoanAmortization:FullAuditedEntity<Int32>
    {
        public int Fk_Product { get; set; }

        [ForeignKey("Fk_Product")]
        public ProductType Product { get; set; }
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

        public List<LoanAmortizationChild> LoanAmortizationChilds { get; set; }

    }
}
