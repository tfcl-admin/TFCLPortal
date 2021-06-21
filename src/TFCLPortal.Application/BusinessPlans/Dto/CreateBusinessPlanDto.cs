using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessPlans.Dto
{
    [AutoMapTo(typeof(BusinessPlan))]
    public class CreateBusinessPlanDto
    {

        public int ApplicationId { get; set; }
        public string BranchCode { get; set; }
        public string ApplicationNo { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int Purpose { get; set; }
        public string PEPs { get; set; }
        public string ClientExistInCelBel { get; set; }
        public string PurposeOfLoanUtilization { get; set; }
        public string TotalInvestmentRequired { get; set; }
        public string AmountWorkingCapital { get; set; }
        public string AmountCapitalExpenditure { get; set; }
        public string ClientShare { get; set; }
        public string LoanAmountRecommended { get; set; }
        public string RequiredLoanAmount { get; set; }
        public int LoanTenureRequested { get; set; }
        public string CollateralGiven { get; set; }
        public string SchoolName { get; set; }
        public int PaymentFrequency { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string LoanTenureRequestedName { get; set; }

        //NEW fields

        public string clientID { get; set; }
        public int? clientStatus { get; set; }
        public int? ReasonOfDecline { get; set; }
        public string ReasonOfDecineOthers { get; set; }
        public int? CreditBureauCheck { get; set; }
        public bool? OverDues { get; set; }
        public string ApprovalTaken { get; set; }
        public bool? AmlCftCheck { get; set; }
        public bool? AmlCftClearance { get; set; }
        public bool? ClientInCell { get; set; }
        public bool? ClientInBell { get; set; }

        public string PurposeOfLoanUtilizationDetails { get; set; }

        public int? LoanPurposeClassification { get; set; }

        public string LoanPurposeClassificationOthers { get; set; }

    }
}
