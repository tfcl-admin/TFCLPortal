using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ExposureDetailChilds
{
    [Table("ExposureDetailChild")]
    public class ExposureDetailChild : FullAuditedEntity<Int32>
    {
        public int Fk_ExpoDetailID { get; set; }
        public int? BankName { get; set; }
        public string Others { get; set; }
        public string CreditBureauReported { get; set; }
        public string TypeOfFacilityTE { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal MonthlyInstallmentPayment { get; set; }
 
    }
}
