using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.LoanEligibilities.Dto
{
    [AutoMapTo(typeof(LoanEligibility))]
    public class CreateLoanEligibilityDto
    {
        public string LoanAmountRequried { get; set; }
        public string LoanTenureRequested { get; set; }
        public string NuOfInstallmentPerYear { get; set; }
        public string Mark_Up { get; set; }
        public string MonthlyBusinessIncome { get; set; } //Gross Total Income
        public string MonthlyBusinessExpenses { get; set; } 
        public string NetBusinessIncome { get; set; }
        public string PerProfitShare { get; set; }
        public string LoanDeduction { get; set; }
        public string NetTakeHomeBusinessIncome { get; set; }
        public string MontlyHouseholdIncome { get; set; }
        public string MaxIncomeForTFCL { get; set; }
        public string MonthlyPaymentEmi { get; set; }
        public string InstallmentRatio { get; set; }
        public string CollateralValue { get; set; }
        public string AllowedLtvCategory { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }
        public string StatusEmi { get; set; }
        public string StatusLTV { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        
        //NEW 54
        public string MonthlySchoolFeeIncome { get; set; }
        public string MonthlySchoolExpenses { get; set; }
        public string SchoolSharingPercentage { get; set; }
        public string MonthlyAcademyFeeIncome { get; set; }
        public string MonthlyAcademyExpenses { get; set; }
        public string AcademySharingPercentage { get; set; }
        public string TotalAssociatedIncome { get; set; }
        public string AssociatedSharingPercentage{ get; set; }
        public string NetAssociatedIncome { get; set; }
        public string TotalSchoolnAssociatedIncomeBeforeExpenses { get; set; }
        public string TotalSchoolnAcademyExpenses { get; set; }
        public string PercentageSAExpenseAgainstSAIncome { get; set; }
        public string MinConsideredPercentage { get; set; }
        public string ConsideredSnAExpenses { get; set; }
        public string TotalSchoolnAssociatedNetExpense { get; set; }
        public string TotalNonAssociatedIncome { get; set; }
        public string NonAssociatedSharingPercentage { get; set; }
        public string NetNonAssociatedIncome { get; set; }
        public string PercentageOfNAIAgainstTotalSchRevenue { get; set; }
        public string NonAssociatedMaxConsideredPercentage { get; set; }
        public string ConsideredNonAssociatedIncome { get; set; }
        public string GrossIncome { get; set; }
        public string MonthlyExposure { get; set; }
        public string NetIncomeBeforeHHexp { get; set; }
        public string MonthlyHouseHoldExpense { get; set; }
        public string PercentageOfHHEAgainstNetBusinessIncome { get; set; }
        public string MinConsideredPercentageOfHHE { get; set; }
        public string ConsideredAmountHHE { get; set; }

        public string AllCollateralMarketValue { get; set; }
        public string MaxAllowedLTVAllCollateral { get; set; }
        public string ActualLTVPercentageAllCollateral { get; set; }




        //public string BuildingCollateralValue { get; set; }
        //public string BuildingLTVPercentage { get; set; }
        //public string BuildingMaxFinancingAllowed { get; set; }
        //public string BuildingActualLTV  { get; set; }

        //public string LandCollateralValue { get; set; }
        //public string LandLTVPercentage { get; set; }
        //public string LandMaxFinancingAllowed { get; set; }
        //public string LandActualLTV { get; set; }


        //public string VehicleCollateralValue { get; set; }
        //public string VehicleLTVPercentage { get; set; }
        //public string VehicleMaxFinancingAllowed { get; set; }
        //public string VehicleActualLTV { get; set; }


        //public string TDRCollateralValue { get; set; }
        //public string TDRLTVPercentage { get; set; }
        //public string TDRMaxFinancingAllowed { get; set; }
        //public string TDRActualLTV { get; set; }


        //public string FranchiseCollateralValue { get; set; }
        //public string FranchiseLTVPercentage { get; set; }
        //public string FranchiseMaxFinancingAllowed { get; set; }
        //public string FranchiseActualLTV { get; set; }


        //public string GoldCollateralValue { get; set; }
        //public string GoldLTVPercentage { get; set; }
        //public string GoldMaxFinancingAllowed { get; set; }
        //public string GoldActualLTV { get; set; }


        public string LoanEligibilityStatusOnEMI { get; set; }
        public string LoanEligibilityStatusOnLTV { get; set; }



    }
}
