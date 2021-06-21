using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ForSDES.Dto
{
    [AutoMapTo(typeof(ForSDE))]
    public  class CreateForSDEInput
    {
        public int ApplicantReputationId { get; set; }
        public string DoubtfulComment { get; set; }
        public int UtilityBillPaymentId { get; set; }
        public int Delayed { get; set; }
        public int referenceCheckId { get; set; }
        public string KnowApplicantSince { get; set; }
        public decimal RecommendedLoanAmount { get; set; }
        public string RecommendedTenure { get; set; }
        public string RecommendedGracePeriod { get; set; }
        public string UtilizationOfLoan { get; set; }
        public string ObservationComment { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
    }
}
