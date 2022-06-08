using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ExposureDetailChilds;

namespace TFCLPortal.ExposureDetails.Dto
{
    [AutoMapTo(typeof(ExposureDetailChild))]
    public class UpdateExposureChildDto:Entity<int>
    {

        public int Fk_ExpoDetailID { get; set; }
        public int? BankName { get; set; }
        public string Others { get; set; }
        public string CreditBureauReported { get; set; }
        public string TypeOfFacilityTE { get; set; }
        public int LiabilityType { get; set; }

        public DateTime? ExpiryDate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal MonthlyInstallmentPayment { get; set; }
    }
}
