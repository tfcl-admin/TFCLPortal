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
using TFCLPortal.ExposureDetails.Dto;
using TFCLPortal.HouseholdIncomesExpenses.Dto;
using TFCLPortal.OtherDetails.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.GuarantorDetails.Dto;
using TFCLPortal.Preferences.Dto;
using TFCLPortal.ForSDES.Dto;
using TFCLPortal.LoanEligibilities.Dto;

namespace TFCLPortal.UpdateAllScreens.Dto
{
    public class UpdateAllScreenDto
    {
        public int ApplicationId { get; set; }
        public UpdatePersonalDetailDto updatePersonalDetail { get; set; }
        public UpdateBusinessPlanDto   updateBusinessPlan { get; set; }
        public UpdateContactDetailDto  updateContactDetail { get; set; }
        public UpdateOtherDetailDto    updateOtherDetail { get; set; }
        public CreateBankAccountDto updateBankAccount { get; set; }
        public CreateCollateralDetailDto updateCollateralDetail { get; set; }
        public UpdateAssetLiabilityDetailDto updateAssetLiabilityDetail { get; set; }
        public CreateBusinessIncomeDto updateBusinessIncomeDetail { get; set; }
        public UpdateBusinessExpenseDto updateBusinessExpenseDetail { get; set; }
        public UpdateHouseholdIncomeParentDto updateHouseholdIncomeDetail { get; set; }
        public CreateCoApplicantDetailInput updateCoApplicantDetail { get; set; }
        public CreateGuarantorDetailInput updateGuarantorDetail { get; set; }
        public CreatePreferenceInput updatePreferenceDetail { get; set; }
        public EditForSDEInput updateForSDEDetail { get; set; }
        public UpdateLoanEligibilityDto updateLoanEligiblity { get; set; }
        public CreateExposureDetailDto updateExposureDetail { get; set; }
        public CreateBusinessDetailDto updateBusinessDetail { get; set; }
    }
}
