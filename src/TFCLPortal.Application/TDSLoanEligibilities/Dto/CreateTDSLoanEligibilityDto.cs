using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TDSLoanEligibilities.Dto
{
    [AutoMapTo(typeof(TDSLoanEligibility))]
    public class CreateTDSLoanEligibilityDto
    {
        public int ApplicationId { get; set; }
        public string LoanAmountRequried { get; set; }
        public string LoanTenureRequested { get; set; }
        public string NuOfInstallmentPerYear { get; set; }
        public string Mark_Up { get; set; }

        public string MonthlyBusinessSale { get; set; }
        public string MonthlyBusinessSaleSharingPercentage { get; set; }
        public string MonthlyBusinessSaleConsidered { get; set; }

        public string MonthlyBusinessExpenses { get; set; }
        public string MonthlyBusinessExpensesSharingPercentage { get; set; }
        public string MonthlyBusinessExpensesConsidered { get; set; }

        public string MonthlyIncome { get; set; }
        public string OtherIncome { get; set; }
        public string GrossBusinessIncome { get; set; }
        public string MonthlyExposure { get; set; }
        public string NetBusinessIncome { get; set; }
        public string HouseholdExpenses { get; set; }

        public string MaxIncomeForTfclPayment { get; set; }
        public string TfclEmiPayment { get; set; }
        public string InstallmentRatio { get; set; }
        public string CollateralValue { get; set; }
        public string AllowedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }
        public string ActualLtvPercentage { get; set; }

        public string LoanEligibilityStatusOnEMI { get; set; }
        public string LoanEligibilityStatusOnLTV { get; set; }

    }
}
