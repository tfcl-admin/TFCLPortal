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
    public class AllScreenGetByAppIdDto
    {
        public int ApplicationId { get; set; }
        public ApplicationWiseDeviationVariableListDto listDeviation { get; set; }
        public ApplicationListDto listApplication { get; set; }
        public BusinessPlanListDto listBusinessPlan { get; set; }
        public PersonalDetailDto listPersonalDetail { get; set; }
        public ContactDetailListDto listContactDetail { get; set; }
        public BusinessDetailDto listBusinessDetail { get; set; }
        public CollateralDetailListDto listCollateralDetail { get; set; }
        public ExposureDetailListDto listExposureDetail { get; set; }
        public AssetLiabilityDetailListDto listAssetLiabilityDetail { get; set; }
        public BusinessIncomeListDto listBusinessIncomeDetail { get; set; }
        public AssociatedIncomeListDto listAssociatedIncomeDetail { get; set; }//
        public NonAssociatedIncomeListDto listNonAssociatedIncomeDetail { get; set; }//
        public BusinessExpenseListDto listBusinessExpenseDetail { get; set; }
        public HouseholdIncomeParentListDto listHouseholdIncomeDetail { get; set; }//
        public LoanEligibilityListDto listLoanEligibilities { get; set; }
        public List<BankAccountListDto> listBankAccount { get; set; }
        public List<CoApplicantDetailListDto> listCoApplicantDetail { get; set; }
        public List<GuarantorDetailListDto> listGuarantorDetail { get; set; }
        public List<PreferencesListDto> listReferenceDetail { get; set; }
        public ForSDEListDto listForSDERecommendationDetail { get; set; }

        public DependentEducationDetailListDto listForDependentEducationDetail { get; set; }
        public TdsInventoryDetailListDto listForTdsInventoryDetail { get; set; }
        public SalesDetailListDto listForSalesDetail { get; set; }
        public PurchaseDetailListDto listForPurchaseDetail { get; set; }
        public TDSLoanEligibilityListDto listForTDSLoanEligibility { get; set; }
        public ParentBusinessDetailTDSListDto listForBusinessDetailTDS { get; set; }
        public TDSBusinessExpenseListDto listForTDSBusinessExpense { get; set; }

        public EmploymentList listForEmploymentDetail { get; set; }
        public SalaryDetailDto listForSalaryDetail { get; set; }
        public TJSLoanEligibilityListDto listForTJSLoanEligibility { get; set; }


        //public OtherDetailListDto listOtherDetail { get; set; }

    }

    public class AllScreenGetBySDEidDto
    {
        public List<AllScreenGetByAppIdDto> Applications { get; set; }
        public List<GetMobilizationListDto> Mobilizations { get; set; }

        //public OtherDetailListDto listOtherDetail { get; set; }

    }

    public class EmploymentList
    {
        public int ApplicationId { get; set; }
        public List<EmploymentDetailListDto> createEmploymentInput { get; set; }
    }
}
