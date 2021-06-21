using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AllScreensSaveMethod.Dto;
using TFCLPortal.AssetLiabilityDetails;
using TFCLPortal.BankAccountDetails;
using TFCLPortal.BusinessDetails;
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
using TFCLPortal.Applications;
using TFCLPortal.OtherDetails;
using TFCLPortal.PersonalDetails;
using TFCLPortal.Preferences;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.LoanEligibilities;
using Abp.UI;

namespace TFCLPortal.AllScreensSaveMethod
{
    public class FinalSyncDataAppService : TFCLPortalAppServiceBase, IFinalSyncDataAppService
    {
        private readonly IPersonalDetailAppService _personalDetailAppService;
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IContactDetailAppService _contactDetailAppService;
        private readonly IBusinessDetailsAppService _businessDetailAppService;
        private readonly IOtherDetailAppService _otherDetailAppService;
        private readonly ICollateralDetailAppService _collateralDetailAppService;
        private readonly IExposureDetailAppService _exposureDetailAppService;
        private readonly IAssetLiabilityDetailAppService _createAssetLiabilityAppService;
        private readonly IBusinessIncomeAppService _businessIncomeAppService;
        private readonly IBusinessExpenseAppService _businessExpenseAppService;
        private readonly IHouseholdIncomeAppService _householdIncomeAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IPreferenceAppService _preferenceAppService;
        private readonly IForSDEAppService _forSDEAppService;
        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        
        public FinalSyncDataAppService(
            IPersonalDetailAppService personalDetailAppService,
            IBusinessPlanAppService businessPlanAppService,
            IContactDetailAppService contactDetailAppService,
            IBusinessDetailsAppService businessDetailAppService,
            IOtherDetailAppService otherDetailAppService,
            ICollateralDetailAppService collateralDetailAppService,
            IExposureDetailAppService exposureDetailAppService,
            IAssetLiabilityDetailAppService assetLiabilityDetailAppService,
            IBusinessIncomeAppService businessIncomeAppService,
            IBusinessExpenseAppService businessExpenseAppService,
            IHouseholdIncomeAppService householdIncomeAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
            IPreferenceAppService preferenceAppService,
            IForSDEAppService forSDEAppService,
            IBankAccountAppService bankAccountAppService,
            IApplicationAppService applicationAppService,
            ILoanEligibilityAppService loanEligibilityAppService
            )
        {
            _personalDetailAppService = personalDetailAppService;
            _businessPlanAppService = businessPlanAppService;
            _contactDetailAppService = contactDetailAppService;
            _businessDetailAppService = businessDetailAppService;
            _otherDetailAppService = otherDetailAppService;
            _collateralDetailAppService = collateralDetailAppService;
            _exposureDetailAppService = exposureDetailAppService;
            _createAssetLiabilityAppService = assetLiabilityDetailAppService;
            _businessIncomeAppService = businessIncomeAppService;
            _businessExpenseAppService = businessExpenseAppService;
            _householdIncomeAppService = householdIncomeAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _preferenceAppService = preferenceAppService;
            _forSDEAppService = forSDEAppService;
            _bankAccountAppService = bankAccountAppService;
            _applicationAppService = applicationAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
        }


        public async Task<string> FinalSyncDataToServer(FinalSyncDto createFinalSync)
        {
             string ResponseString = "";
            try
            {
                
                int applicationId = createFinalSync.createPersonalDetail.ApplicationId;
                await _personalDetailAppService.CreatePersonalDetail(createFinalSync.createPersonalDetail);
                await _businessPlanAppService.CreateBusinessPlan(createFinalSync.createBusinessPlan);

                await _contactDetailAppService.CreateContactDetail(createFinalSync.createContactDetail);
                await _businessDetailAppService.CreateBusinessDetail(createFinalSync.createBusinessDetail);
                await _otherDetailAppService.CreateOtherDetail(createFinalSync.createOtherDetail);
                await _collateralDetailAppService.CreateCollateralDetail(createFinalSync.createCollateralDetail);
                await _exposureDetailAppService.CreateExposureDetail(createFinalSync.createExposureDetail);
                await _createAssetLiabilityAppService.CreateAssetLiabilityDetail(createFinalSync.createAssetLiabilityDetail);
                await _businessIncomeAppService.CreateBusinessIncome(createFinalSync.createBusinessIncomeDetail);
                await _businessExpenseAppService.CreateBusinessExpense(createFinalSync.createBusinessExpenseDetail);
                _householdIncomeAppService.CreateHouseholdIncome(createFinalSync.createHouseholdIncomeDetail);
                await _coApplicantDetailAppService.Create(createFinalSync.createCoApplicantDetail, createFinalSync.ApplicationId);
                await _guarantorDetailAppService.Create(createFinalSync.createGuarantorDetail, applicationId);
                await _preferenceAppService.Create(createFinalSync.createPreferenceDetail, createFinalSync.ApplicationId);
                await _forSDEAppService.Create(createFinalSync.createForSDEDetail);
                await _bankAccountAppService.CreateBankDetail(createFinalSync.createBankAccount,createFinalSync.ApplicationId);
                await _loanEligibilityAppService.CreateLoanEligibility(createFinalSync.createLoanEligiblity);


                ///change application state to submitted
               _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, applicationId, "");
                var workFlow =_applicationAppService.UserInRole(WorkFlowState.VO);
                CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();
                createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                createWorkFlow.ApplicationId = applicationId;
                createWorkFlow.IsActive = true;
                createWorkFlow.Status = ApplicationState.Submitted;

                await _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                ResponseString = "Records Sync successfully to Server";

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Sorry data is not sync to Server"));
            }
            return ResponseString;
        }
    }
}
