using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssetLiabilityDetails.Dto;
using TFCLPortal.BankAccountDetails.Dto;
using TFCLPortal.BusinessDetails.Dto;
using TFCLPortal.BusinessExpenses.Dto;
using TFCLPortal.BusinessIncomes.Dto;
using TFCLPortal.BusinessPlans.Dto;
using TFCLPortal.CoApplicantDetails.Dto;
using TFCLPortal.CollateralDetails.Dto;
using TFCLPortal.ContactDetails.Dto;
using TFCLPortal.DynamicDropdowns.Dto;
using TFCLPortal.ExposureDetails.Dto;
using TFCLPortal.ForSDES.Dto;
using TFCLPortal.GuarantorDetails.Dto;
using TFCLPortal.HouseholdIncomesExpenses.Dto;
using TFCLPortal.Applications.Dto;
using TFCLPortal.OtherDetails.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Preferences.Dto;
using TFCLPortal.LoanEligibilities.Dto;

namespace TFCLPortal.AllScreensSaveMethod.Dto
{
    public class FinalSyncDto
    {
        public int ApplicationId { get; set; }
        public CreatePersonalDetailDto createPersonalDetail { get; set; }
        public CreateBusinessPlanDto createBusinessPlan { get; set; }
        public CreateContactDetailDto createContactDetail { get; set; }
        public CreateBusinessDetailDto createBusinessDetail { get; set; }
        public CreateOtherDetailDto createOtherDetail { get; set; }
        public CreateBankAccountDto createBankAccount { get; set; }
        public CreateCollateralDetailDto createCollateralDetail { get; set; }
        public CreateExposureDetailDto createExposureDetail { get; set; }
        public CreateAssetLiabilityDetailDto createAssetLiabilityDetail { get; set; }
        public CreateBusinessIncomeDto createBusinessIncomeDetail { get; set; }
        public CreateBusinessExpenseDto createBusinessExpenseDetail { get; set; }
        public CreateHouseholdIncomeParentDto createHouseholdIncomeDetail { get; set; }
        public CreateCoApplicantDetailInput createCoApplicantDetail { get; set; }
        public CreateGuarantorDetailInput createGuarantorDetail { get; set; }
        public CreatePreferenceInput createPreferenceDetail { get; set; }
        public CreateForSDEInput createForSDEDetail { get; set; }
        public CreateLoanEligibilityDto createLoanEligiblity { get; set; }




    }
}
