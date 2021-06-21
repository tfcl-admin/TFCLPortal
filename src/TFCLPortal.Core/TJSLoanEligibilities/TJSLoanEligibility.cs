using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TJSLoanEligibilities
{
    [Table("TJSLoanEligibilities")]
   public class TJSLoanEligibility : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string LoanAmountRequired { get; set; }
        public string LoanTenureRequested { get; set; }
        public string NuOfInstallmentPerYear { get; set; }
        public string Mark_Up { get; set; }

        public string NetMonthlySalary { get; set; }
        public string OtherIncome { get; set; }
        public string TotalIncome { get; set; }
        public string MonthlyExposure { get; set; }

        public string NetIncome { get; set; }
        public string HouseholdExpenses { get; set; }
        public string MaxIncomeForTfclPayment { get; set; }
        public string TfclEmiPayment { get; set; }
        public string InstallmentRatio { get; set; }
        //public string MonthlyBusinessExpenses { get; set; }
        //public string MonthlyBusinessExpensesSharingPercentage { get; set; }
        //public string MonthlyBusinessExpensesConsidered { get; set; }

        //public string GrossBusinessIncome { get; set; }
        //public string NetBusinessIncome { get; set; }
        
        //public string CollateralValue { get; set; }
        //public string AllowedLtvPercentage { get; set; }
        //public string MaxFinancingAllowedLTV { get; set; }
        //public string ActualLtvPercentage { get; set; }

        //public string LoanEligibilityStatusOnEMI { get; set; }
        //public string LoanEligibilityStatusOnLTV { get; set; }
    }
}
