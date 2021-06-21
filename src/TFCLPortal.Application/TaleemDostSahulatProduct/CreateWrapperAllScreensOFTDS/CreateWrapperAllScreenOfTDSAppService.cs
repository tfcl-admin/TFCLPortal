using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.AssetLiabilityDetails;
using TFCLPortal.BankAccountDetails;
using TFCLPortal.BusinessExpenses;
using TFCLPortal.BusinessIncomes;
using TFCLPortal.BusinessPlans;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.CollateralDetails;
using TFCLPortal.ContactDetails;
using TFCLPortal.ExposureDetails;
using TFCLPortal.ForSDES;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.HouseholdIncomesExpenses;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.OtherDetails;
using TFCLPortal.PersonalDetails;
using TFCLPortal.Preferences;
//using TFCLPortal.TaleemDostSahulatProduct.BusinessDetailsTDS;
using TFCLPortal.TaleemDostSahulatProduct.CreateWrapperAllScreensOFTDS.Dto;
using TFCLPortal.TaleemDostSahulatProduct.FinancialInformationsTDS;
using TFCLPortal.TaleemDostSahulatProduct.SalesPurchasesTDS;

namespace TFCLPortal.TaleemDostSahulatProduct.CreateWrapperAllScreensOFTDS
{
    public class CreateWrapperAllScreenOfTDSAppService : TFCLPortalAppServiceBase, ICreateWrapperAllScreenOfTDSAppService
    {
        private readonly IPersonalDetailAppService _personalDetailAppService;
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IContactDetailAppService _contactDetailAppService;
        //private readonly IBusinessDetailsTDSAppService _businessDetailTDSAppService;
        private readonly IOtherDetailAppService _otherDetailAppService;
        private readonly ICollateralDetailAppService _collateralDetailAppService;
        private readonly IExposureDetailAppService _exposureDetailAppService;
        private readonly IAssetLiabilityDetailAppService _createAssetLiabilityAppService;
        //private readonly IBusinessIncomeAppService _businessIncomeAppService;
        //private readonly IBusinessExpenseAppService _businessExpenseAppService;
        //private readonly IHouseholdIncomeAppService _householdIncomeAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IPreferenceAppService _preferenceAppService;
        private readonly IForSDEAppService _forSDEAppService;
        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly IApplicationAppService _applicationAppService;
       // private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly IFinancialInformationTDSAppService _financialInformationTDSAppService;
        private readonly ISalesPurchaseTDSAppService _salespurchaseTDSAppService;

        public CreateWrapperAllScreenOfTDSAppService(
           IPersonalDetailAppService personalDetailAppService,
           IBusinessPlanAppService businessPlanAppService ,
           IContactDetailAppService contactDetailAppService ,
           //IBusinessDetailsTDSAppService businessDetailTDSAppService,
           IOtherDetailAppService otherDetailAppService,
           ICollateralDetailAppService collateralDetailAppService,
           IExposureDetailAppService exposureDetailAppService,
           IAssetLiabilityDetailAppService assetLiabilityDetailAppService,
           //IBusinessIncomeAppService businessIncomeAppService,
           //IBusinessExpenseAppService businessExpenseAppService,
           //IHouseholdIncomeAppService householdIncomeAppService,
           ICoApplicantDetailAppService coApplicantDetailAppService,
           IGuarantorDetailAppService guarantorDetailAppService,
           IPreferenceAppService preferenceAppService,
           IForSDEAppService forSDEAppService,
           IBankAccountAppService bankAccountAppService,
            IApplicationAppService applicationAppService,
            //ILoanEligibilityAppService loanEligibilityAppService,
            IFinancialInformationTDSAppService financialInformationTDSAppService,
            ISalesPurchaseTDSAppService salespurchaseTDSAppService
            )
        {
            _personalDetailAppService = personalDetailAppService;
            _businessPlanAppService = businessPlanAppService;
            _contactDetailAppService = contactDetailAppService;
            //_businessDetailTDSAppService = businessDetailTDSAppService;
            _otherDetailAppService = otherDetailAppService;
            _collateralDetailAppService = collateralDetailAppService;
            _exposureDetailAppService = exposureDetailAppService;
            _createAssetLiabilityAppService = assetLiabilityDetailAppService;
            //_businessIncomeAppService = businessIncomeAppService;
            //_businessExpenseAppService = businessExpenseAppService;
            //_householdIncomeAppService = householdIncomeAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _preferenceAppService = preferenceAppService;
            _forSDEAppService = forSDEAppService;
            _bankAccountAppService = bankAccountAppService;
            _applicationAppService = applicationAppService;
            //_loanEligibilityAppService = loanEligibilityAppService;
            _financialInformationTDSAppService = financialInformationTDSAppService;
            _salespurchaseTDSAppService = salespurchaseTDSAppService;
        }

        public async Task<string> CreateWrapperAllScreen(CreateAllScreenForTDSDto createAllScreen)
        {
            string ResponseString = "";
            try
            {

                int applicationId = createAllScreen.createPersonalDetail.ApplicationId;
                await _personalDetailAppService.CreatePersonalDetail(createAllScreen.createPersonalDetail);
                await _businessPlanAppService.CreateBusinessPlan(createAllScreen.createBusinessPlan);

                await _contactDetailAppService.CreateContactDetail(createAllScreen.createContactDetail);
                //await _businessDetailTDSAppService.CreateBusinessDetailTDS(createAllScreen.createBusinessDetail);
                await _salespurchaseTDSAppService.CreateSalesPurchaseTDS(createAllScreen.createSalePurchase);
                await _financialInformationTDSAppService.CreateFinancialInformationTDSTDS(createAllScreen.createFinancialInformation);

                await _otherDetailAppService.CreateOtherDetail(createAllScreen.createOtherDetail);
                await _collateralDetailAppService.CreateCollateralDetail(createAllScreen.createCollateralDetail);
                await _exposureDetailAppService.CreateExposureDetail(createAllScreen.createExposureDetail);
                await _createAssetLiabilityAppService.CreateAssetLiabilityDetail(createAllScreen.createAssetLiabilityDetail);
                //await _businessIncomeAppService.CreateBusinessIncome(createAllScreen.createBusinessIncomeDetail);
                //await _businessExpenseAppService.CreateBusinessExpense(createAllScreen.createBusinessExpenseDetail);
                //await _householdIncomeAppService.CreateHouseholdIncome(createAllScreen.createHouseholdIncomeDetail);
                await _coApplicantDetailAppService.Create(createAllScreen.createCoApplicantDetail, createAllScreen.ApplicationId);
                await _guarantorDetailAppService.Create(createAllScreen.createGuarantorDetail, applicationId);
                await _preferenceAppService.Create(createAllScreen.createPreferenceDetail, createAllScreen.ApplicationId);
                await _forSDEAppService.Create(createAllScreen.createForSDEDetail);
                await _bankAccountAppService.CreateBankDetail(createAllScreen.createBankAccount, createAllScreen.ApplicationId);
                //await _loanEligibilityAppService.CreateLoanEligibility(createAllScreen.createLoanEligiblity);


                // / change application state to submitted
                _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, applicationId, "");
                var workFlow = _applicationAppService.UserInRole(WorkFlowState.VO);
                CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();
                createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                createWorkFlow.ApplicationId = applicationId;
                createWorkFlow.IsActive = true;
                createWorkFlow.Status = "Current";

                await _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                ResponseString = "Records Sync successfully to Server";

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Sorry data of All Screen can not proceed"));
            }
            return ResponseString;
        }
    }
}
