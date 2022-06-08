using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssetLiabilityDetails.Dto;
using TFCLPortal.AssociatedIncomeDetails.Dto;
using TFCLPortal.BankAccountDetails.Dto;
using TFCLPortal.BusinessDetails.Dto;
using TFCLPortal.BusinessExpenses.Dto;
using TFCLPortal.BusinessIncomes.Dto;
using TFCLPortal.BusinessPlans.Dto;
using TFCLPortal.CoApplicantDetails.Dto;
using TFCLPortal.CollateralDetails.Dto;
using TFCLPortal.ContactDetails.Dto;
using TFCLPortal.ExposureDetails.Dto;
using TFCLPortal.ForSDES.Dto;
using TFCLPortal.GuarantorDetails.Dto;
using TFCLPortal.HouseholdIncomesExpenses.Dto;
using TFCLPortal.LoanEligibilities.Dto;
using TFCLPortal.NonAssociatedIncomeDetails.Dto;
using TFCLPortal.OtherDetails.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Preferences.Dto;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Mobilizations;
using TFCLPortal.ApplicationWiseDeviationVariables.Dto;


using TFCLPortal.DependentEducationDetails.Dto;
using TFCLPortal.TdsInventoryDetails.Dto;
using TFCLPortal.SalesDetails.Dto;
using TFCLPortal.TDSLoanEligibilities.Dto;
using TFCLPortal.BusinessDetailsTDS.Dto;
using TFCLPortal.TDSBusinessExpenses.Dto;
using TFCLPortal.PurchaseDetails.Dto;

using TFCLPortal.EmploymentDetails.Dto;
using TFCLPortal.SalaryDetails.Dto;
using TFCLPortal.TJSLoanEligibilities;
using TFCLPortal.TJSLoanEligibilities.Dto;

namespace TFCLPortal.AllScreensGetByAppID.Dto
{

    public class GetDataForCRSdto
    {
        public int ApplicationId { get; set; }
        public string ClientName { get; set; }
        public string CNICNo { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public string ClientID { get; set; }
        public string BranchCode { get; set; }
        public string LoanPurpose { get; set; }
        public string MarkupApplied { get; set; }
        public string LoanAmountRequested { get; set; }
        public string Tenure { get; set; }
        public int Classrooms { get; set; }
        public int Enrollments { get; set; }
        public int TeachingStaff { get; set; }
        public int NonTeachingStaff { get; set; }
        public string AvgMonthlyFee { get; set; }
        public List<collateralListDto> Collaterals { get; set; }


        //Personal Data
        public int Age { get; set; }
        public int YearsAtResidence { get; set; }
        public string OtherBusinessIncome { get; set; }
        public string TaxFiler { get; set; }
        public string expInSchoolYears { get; set; }
        public string InstallmentRatio { get; set; }
        public string CoApplicantAvailable { get; set; }
        public string BankingTransactionHistory { get; set; }
        public string ResidenceAccommodationType { get; set; }
        public int YearsAtBusiness { get; set; }
        public int SchoolYears { get; set; }
        public int TotalStudents { get; set; }
        public string BusinessPlaceStatus { get; set; }
        public string SchoolType { get; set; }
        public string LegalStatus { get; set; }
        public string StructuralFinancialRecords { get; set; }
        public string IsSchoolRegistered { get; set; }
        public string EveningAcademy { get; set; }
        public string ClientBusinessRadius { get; set; }
        public string SchoolLevel { get; set; }
        public string SeperateAccountantAvailable { get; set; }
        public string AdvanceAccounts { get; set; }
        public string UtillityBill { get; set; }


        //Financial Data
        public int LoanCycles { get; set; }
        public string PreviousYear { get; set; }
        public int NoOfClassrooms { get; set; }
        public int NoOfStudents { get; set; }
        public int NoOfTeachingStaff { get; set; }
        public int NoOfNonTeachingStaff { get; set; }
        public string TotalRevenue { get; set; }
        public string TotalExpensesFromSalary { get; set; }
        public string TotalExpensesFromRentMortgage { get; set; }
        public string TotalExpensesFromDebt { get; set; }
        public string AllOtherExpenses { get; set; }
        public string TotalProfit { get; set; }
        public string spouseFamilyOtherIncomeName { get; set; }
        public string ProfitMargin { get; set; }
        public string TotalAsset { get; set; }
        public string CurrentAsset { get; set; }
        public string TotalLiabilities { get; set; }
        public string CurrentLiabilities { get; set; }
        public string WorkingCapital { get; set; }

        public string CurrTotalRevenue { get; set; }
        public string CurrTotalExpensesFromSalary { get; set; }
        public string CurrTotalExpensesFromRentMortgage { get; set; }
        public string CurrTotalExpensesFromDebt { get; set; }
        public string CurrAllOtherExpenses { get; set; }
        public string CurrTotalProfit { get; set; }
        public string CurrspouseFamilyOtherIncomeName { get; set; }
        public string CurrProfitMargin { get; set; }
        public string CurrTotalAsset { get; set; }
        public string CurrCurrentAsset { get; set; }
        public string CurrTotalLiabilities { get; set; }
        public string CurrCurrentLiabilities { get; set; }
        public string CurrWorkingCapital { get; set; }

        public string PrevAvgMonthlyFee { get; set; }
        public string ChangeInClassrooms { get; set; }
        public string ChangeInStudents { get; set; }
        public string ChangeInTeachers { get; set; }
        public string CreditHistoryAvailable { get; set; }

        //Non Financial Data
        public string BuildingConditionName { get; set; }
        public string PowerBackup { get; set; }
        public string FirstAid { get; set; }
        public string AyasPresent { get; set; }
        public string SeperateWashrooms { get; set; }
        public string ProperLighting { get; set; }
        public string CleanWater { get; set; }
        public string FunctionalComputerLab { get; set; }
        public string SchoolManagementSystem { get; set; }
        public string SchoolDecor { get; set; }
        public string LearningAid { get; set; }
        public string TeacherTrainings { get; set; }
        public string ChildProtection { get; set; }
        public string EmergencyExits { get; set; }
        public string SecurityGuards { get; set; }
        public string HealthEnvironment { get; set; }
        public string BusinessSuccession { get; set; }
        public string otherPaymentBehaviour { get; set; }
        public int DropoutStudents { get; set; }
        public decimal DropoutStudentsRatio { get; set; }
        public decimal StudentTeacherRatio { get; set; }
        public decimal CollateralCoverage { get; set; }

        public decimal CurrentALDRatio { get; set; }
        public string ChangeInProfitMargin { get; set; }        
        public string ChangeInAsset { get; set; }        
        public string ChangeInRevenue { get; set; }        
        public string ChangeInTotalExpenses { get; set; }        
        public string ChangeInTotalProfit { get; set; }        
        public decimal InstallmentIncome { get; set; }        



        //Psychometric
        public string PercentageToStealName { get; set; }
        public string AvoidConflictName { get; set; }
        public string MotivationToRunSchoolName { get; set; }
        public string BusinessLuck { get; set; }
        public string HopefulForFutureName { get; set; }
        public string DigitalInitiativesName { get; set; }
        public string TeacherTrainingsName { get; set; }
        public string ParentEngagementName { get; set; }
        public string MixExpenses { get; set; }
        public string ComparedFee { get; set; }
    }
    public class collateralListDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string marketValue { get; set; }
        public string forcedSaleValue { get; set; }
    }


}
