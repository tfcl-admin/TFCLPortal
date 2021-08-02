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
using TFCLPortal.UpdateAllScreens.Dto;
using TFCLPortal.DescripentScreens;
using TFCLPortal.DescripentScreens.Dto;
using System.Linq;
using TFCLPortal.AssociatedIncomeDetails;
using TFCLPortal.NonAssociatedIncomeDetails;
using TFCLPortal.FilesUploads;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.BranchManagerActions;
using TFCLPortal.BranchManagerActions.Dto;
using TFCLPortal.FinalWorkflows.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using TFCLPortal.NotificationLogs;
using TFCLPortal.Roles.Dto;
using TFCLPortal.Users;
using Microsoft.AspNetCore.Identity;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Users.Dto;
using Abp.Domain.Repositories;
using TFCLPortal.Branches;
using TFCLPortal.DependentEducationDetails;
using TFCLPortal.TdsInventoryDetails;
using TFCLPortal.SalesDetails;
using TFCLPortal.PurchaseDetails;
using TFCLPortal.BusinessDetailsTDS;
using TFCLPortal.TDSBusinessExpenses;
using TFCLPortal.TDSLoanEligibilities;

namespace TFCLPortal.UpdateAllScreens
{
    public class UpdateAllScreenAppService : TFCLPortalAppServiceBase, IUpdateAllScreenAppService
    {
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IPersonalDetailAppService _personalDetailAppService;
        private readonly IDependentEducationDetailsAppService _dependentEducationDetailsAppService;
        private readonly IContactDetailAppService _contactDetailAppService;
        private readonly IBusinessDetailsAppService _businessDetailAppService;
        private readonly ICollateralDetailAppService _collateralDetailAppService;
        private readonly IExposureDetailAppService _exposureDetailAppService;
        private readonly IAssetLiabilityDetailAppService _AssetLiabilityAppService;
        private readonly IBusinessIncomeAppService _businessIncomeAppService;
        private readonly ITdsInventoryDetailAppService _tdsInventoryDetailAppService;
        private readonly IBusinessExpenseAppService _businessExpenseAppService;
        private readonly ITDSBusinessExpenseAppService _tDSBusinessExpenseAppService;
        private readonly IHouseholdIncomeAppService _householdIncomeAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IPreferenceAppService _preferenceAppService;
        private readonly IForSDEAppService _forSDEAppService;
        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IDescripentScreenAppService _descripentScreenAppService;
        private readonly IAssociatedIncomeAppService _associatedIncomeAppService;
        private readonly INonAssociatedIncomeAppService _nonAssociatedIncomeAppService;
        private readonly IFilesUploadAppService _filesUploadAppService;
        private readonly IBranchManagerActionAppService _branchManagerActionAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IOtherDetailAppService _otherDetailAppService;
        private readonly INotificationLogAppService _notificationLogAppService;
        private readonly IUserAppService _userAppService;
        private readonly IRepository<Branch> _branchRepository;
        private readonly UserManager _userManager;
        private readonly ISalesDetailAppService _salesDetailAppService;
        private readonly IPurchaseDetailAppService _purchaseDetailAppService;
        private readonly IBusinessDetailsTDSAppService _businessDetailsTDSAppService;


        public UpdateAllScreenAppService(
            IPersonalDetailAppService personalDetailAppService,
            IBusinessPlanAppService businessPlanAppService,
            ISalesDetailAppService salesDetailAppService,
            IPurchaseDetailAppService purchaseDetailAppService,
            IContactDetailAppService contactDetailAppService,
            IBusinessDetailsAppService businessDetailAppService,
            IOtherDetailAppService otherDetailAppService,
            ICollateralDetailAppService collateralDetailAppService,
            IExposureDetailAppService exposureDetailAppService,
            IAssetLiabilityDetailAppService assetLiabilityDetailAppService,
            IBusinessIncomeAppService businessIncomeAppService,
            IBusinessExpenseAppService businessExpenseAppService,
            IFinalWorkflowAppService finalWorkflowAppService,
            ITdsInventoryDetailAppService tdsInventoryDetailAppService,
            IBusinessDetailsTDSAppService businessDetailsTDSAppService,
            IHouseholdIncomeAppService householdIncomeAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
            IPreferenceAppService preferenceAppService,
            IForSDEAppService forSDEAppService,
            ITDSLoanEligibilityAppService tDSLoanEligibilityAppService,
            ITDSBusinessExpenseAppService tDSBusinessExpenseAppService,
            IRepository<Branch> branchRepository,
            IDependentEducationDetailsAppService dependentEducationDetailsAppService,
            IBankAccountAppService bankAccountAppService,
            IAssociatedIncomeAppService associatedIncomeAppService,
            INonAssociatedIncomeAppService nonAssociatedIncomeAppService,
            IApplicationAppService applicationAppService,
            ILoanEligibilityAppService loanEligibilityAppService,
            IDescripentScreenAppService descripentScreenAppService,
            IBranchManagerActionAppService branchManagerActionAppService,
            IFilesUploadAppService filesUploadAppService,
            INotificationLogAppService notificationLogAppService,
            IUserAppService userAppService,
            UserManager userManager
            )
        {
            _personalDetailAppService = personalDetailAppService;
            _businessPlanAppService = businessPlanAppService;
            _contactDetailAppService = contactDetailAppService;
            _businessDetailAppService = businessDetailAppService;
            _tDSBusinessExpenseAppService = tDSBusinessExpenseAppService;
            _otherDetailAppService = otherDetailAppService;
            _collateralDetailAppService = collateralDetailAppService;
            _exposureDetailAppService = exposureDetailAppService;
            _AssetLiabilityAppService = assetLiabilityDetailAppService;
            _businessIncomeAppService = businessIncomeAppService;
            _businessExpenseAppService = businessExpenseAppService;
            _householdIncomeAppService = householdIncomeAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _preferenceAppService = preferenceAppService;
            _finalWorkflowAppService = finalWorkflowAppService;
            _tdsInventoryDetailAppService = tdsInventoryDetailAppService;
            _forSDEAppService = forSDEAppService;
            _dependentEducationDetailsAppService = dependentEducationDetailsAppService;
            _bankAccountAppService = bankAccountAppService;
            _applicationAppService = applicationAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
            _descripentScreenAppService = descripentScreenAppService;
            _associatedIncomeAppService = associatedIncomeAppService;
            _nonAssociatedIncomeAppService = nonAssociatedIncomeAppService;
            _filesUploadAppService = filesUploadAppService;
            _branchManagerActionAppService = branchManagerActionAppService;
            _notificationLogAppService = notificationLogAppService;
            _userAppService = userAppService;
            _branchRepository = branchRepository;
            _userManager = userManager;
            _salesDetailAppService = salesDetailAppService;
            _purchaseDetailAppService = purchaseDetailAppService;
            _businessDetailsTDSAppService = businessDetailsTDSAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
        }

        private async Task UpdateScreenStatusAsync(int applicationId, int Id)
        {
            UpdateDescripentScreenDto updatedescripentScreenDto = new UpdateDescripentScreenDto();
            var descrepentScreen = _descripentScreenAppService.GetDescripentScreenByApplicationId(applicationId, Id, "Discrepant");
            updatedescripentScreenDto.Fk_ScreenId = descrepentScreen.Fk_ScreenId;
            updatedescripentScreenDto.Id = descrepentScreen.Id;
            updatedescripentScreenDto.ScreenStatus = "Closed";
            updatedescripentScreenDto.ScreenCode = descrepentScreen.ScreenCode;
            updatedescripentScreenDto.Fk_CreaterUserId = descrepentScreen.Fk_CreaterUserId;
            updatedescripentScreenDto.ApplicationId = descrepentScreen.ApplicationId;
            updatedescripentScreenDto.Comments = descrepentScreen.Comments;
            await _descripentScreenAppService.UpdateDescripentScreen(updatedescripentScreenDto);

        }
        public async Task<string> UpdateAllScreensData(UpdateAllScreenDto updateAllScreen)
        {
            string ResponseString = "";
            try
            {


                int applicationId = updateAllScreen.ApplicationId;
                if (updateAllScreen.updatePersonalDetail != null)
                {
                    updateAllScreen.updatePersonalDetail.ScreenStatus = "Closed";
                    await _personalDetailAppService.UpdatePersonalDetail(updateAllScreen.updatePersonalDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updatePersonalDetail.ApplicationId, updateAllScreen.updatePersonalDetail.Id);

                }
                if (updateAllScreen.updateBusinessPlan != null)
                {
                    updateAllScreen.updateBusinessPlan.ScreenStatus = "Closed";
                    await _businessPlanAppService.UpdateBusinessPlan(updateAllScreen.updateBusinessPlan);
                    await UpdateScreenStatusAsync(updateAllScreen.updateBusinessPlan.ApplicationId, updateAllScreen.updateBusinessPlan.Id);

                }
                if (updateAllScreen.updateContactDetail != null)
                {
                    updateAllScreen.updateContactDetail.ScreenStatus = "Closed";
                    await _contactDetailAppService.UpdateContactDetail(updateAllScreen.updateContactDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updateContactDetail.ApplicationId, updateAllScreen.updateContactDetail.Id);
                }
                if (updateAllScreen.updateBusinessDetail != null)
                {
                    await _businessDetailAppService.CreateBusinessDetail(updateAllScreen.updateBusinessDetail);
                }
                if (updateAllScreen.updateOtherDetail != null)
                {
                    updateAllScreen.updateOtherDetail.ScreenStatus = "Closed";
                    await _otherDetailAppService.UpdateOtherDetail(updateAllScreen.updateOtherDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updateOtherDetail.ApplicationId, updateAllScreen.updateOtherDetail.Id);

                }
                if (updateAllScreen.updateCollateralDetail != null)
                {
                    await _collateralDetailAppService.CreateCollateralDetail(updateAllScreen.updateCollateralDetail);
                }
                if (updateAllScreen.updateExposureDetail != null)
                {
                    await _exposureDetailAppService.CreateExposureDetail(updateAllScreen.updateExposureDetail);
                }
                if (updateAllScreen.updateAssetLiabilityDetail != null)
                {
                    updateAllScreen.updateAssetLiabilityDetail.ScreenStatus = "Closed";
                    await _AssetLiabilityAppService.UpdateAssetLiabilityDetail(updateAllScreen.updateAssetLiabilityDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updateAssetLiabilityDetail.ApplicationId, updateAllScreen.updateAssetLiabilityDetail.Id);

                }
                if (updateAllScreen.updateBusinessIncomeDetail != null)
                {
                    await _businessIncomeAppService.CreateBusinessIncome(updateAllScreen.updateBusinessIncomeDetail);
                }
                if (updateAllScreen.updateBusinessExpenseDetail != null)
                {
                    updateAllScreen.updateBusinessExpenseDetail.ScreenStatus = "Closed";
                    await _businessExpenseAppService.UpdateBusinessExpense(updateAllScreen.updateBusinessExpenseDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updateBusinessExpenseDetail.ApplicationId, updateAllScreen.updateBusinessExpenseDetail.Id);

                }
                if (updateAllScreen.updateHouseholdIncomeDetail != null)
                {
                    //updateAllScreen.updateHouseholdIncomeDetail.ScreenStatus = "Closed";
                    await _householdIncomeAppService.UpdateHouseholdIncome(updateAllScreen.updateHouseholdIncomeDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updateHouseholdIncomeDetail.ApplicationId, updateAllScreen.updateHouseholdIncomeDetail.Id);

                }
                if (updateAllScreen.updateCoApplicantDetail != null)
                {
                    await _coApplicantDetailAppService.Create(updateAllScreen.updateCoApplicantDetail, applicationId);
                }
                if (updateAllScreen.updateGuarantorDetail != null)
                {

                    // updateAllScreen.updateGuarantorDetail.ScreenStatus = "Closed";
                    await _guarantorDetailAppService.Create(updateAllScreen.updateGuarantorDetail, applicationId);
                    // await UpdateScreenStatusAsync(updateAllScreen.updateGuarantorDetail.ApplicationId, updateAllScreen.updateGuarantorDetail.Id);

                }
                if (updateAllScreen.updatePreferenceDetail != null)
                {
                    await _preferenceAppService.Create(updateAllScreen.updatePreferenceDetail, applicationId);
                }
                if (updateAllScreen.updateForSDEDetail != null)
                {
                    updateAllScreen.updateForSDEDetail.ScreenStatus = "Closed";
                    await _forSDEAppService.Update(updateAllScreen.updateForSDEDetail);
                    await UpdateScreenStatusAsync(updateAllScreen.updateForSDEDetail.ApplicationId, updateAllScreen.updateForSDEDetail.Id);

                }
                if (updateAllScreen.updateBankAccount != null)
                {
                    await _bankAccountAppService.CreateBankDetail(updateAllScreen.updateBankAccount, applicationId);
                }
                if (updateAllScreen.updateLoanEligiblity != null)
                {
                    updateAllScreen.updateLoanEligiblity.ScreenStatus = "Closed";
                    await _loanEligibilityAppService.UpdateLoanEligibilityDetail(updateAllScreen.updateLoanEligiblity);
                    await UpdateScreenStatusAsync(updateAllScreen.updateLoanEligiblity.ApplicationId, updateAllScreen.updateLoanEligiblity.Id);

                }

                //var Descrepents = _applicationAppService.GetDescripentApplicationbyApplicationId(applicationId);
                //var count = Descrepents.DescripentScreens.Where(x => x.ScreenStatus.Contains("Discrepant")).Count();
                //if (count == 0)
                //{
                //    ///change application state to submitted
                //    _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, applicationId, "");


                //    var workFlow = _applicationAppService.UserInRole(WorkFlowState.VO);

                //    CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                //    createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                //    createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                //    createWorkFlow.ApplicationId = applicationId;
                //    createWorkFlow.IsActive = true;
                //    createWorkFlow.Status = "Current";

                //    await _applicationAppService.ChangeWorkFlowState(createWorkFlow);

                //}





                ResponseString = "Records Updated successfully to Server";

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Sorry data is not update to Server"));
            }
            return ResponseString;
        }
        public async Task<List<string>> SubmitApplication(int ApplicationId, int SDE_ID)
        {
            List<string> ResponseString = new List<string>();
            try
            {
                var app = _applicationAppService.GetApplicationById(ApplicationId);
                if (app != null)
                {
                    if (app.ProductType == 1 || app.ProductType == 2) { 
                        if (!_businessPlanAppService.CheckBusinessPlanByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Loan Requisition Details not found.");
                        }
                        if (!_personalDetailAppService.CheckPersonalDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Personal Details not found.");
                        }
                        if (!_contactDetailAppService.CheckContactDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Contact Details not found.");
                        }
                        if (!_businessDetailAppService.CheckBusinessDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Business Details not found.");
                        }
                        if (!_collateralDetailAppService.CheckCollateralDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Collateral Details not found.");
                        }
                        if (!_exposureDetailAppService.CheckExposureDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Exposure Details not found.");
                        }
                        if (!_AssetLiabilityAppService.CheckAssetLiabilityDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Asset Liability Details not found.");
                        }
                        if (!_businessIncomeAppService.CheckBusinessIncomeByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Business Income Details not found.");
                        }
                        if (!_associatedIncomeAppService.CheckAssociatedIncomeDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Associated Income Details not found.");
                        }
                        if (!_nonAssociatedIncomeAppService.CheckNonAssociatedIncomeDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Non-Associated Income Details not found.");
                        }
                        if (!_businessExpenseAppService.CheckBusinessExpenseByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Business Expense Details not found.");
                        }
                        if (!_householdIncomeAppService.CheckHouseholdIncomeByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Household Income/Expense Details not found.");
                        }
                        if (!_loanEligibilityAppService.CheckLoanEligibilityListByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Loan Eligibility not found.");
                        }
                        if (!_bankAccountAppService.CheckBankAccountDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Bank Account Details not found.");
                        }
                        //if (!_coApplicantDetailAppService.CheckCoApplicantDetailByApplicationId(ApplicationId))
                        //{
                        //    ResponseString.Add("Co-Applicant Details not found.");
                        //}
                        //if (!_guarantorDetailAppService.CheckGuarantorDetailByApplicationId(ApplicationId))
                        //{
                        //    ResponseString.Add("Guarantor Details not found.");
                        //}
                        if (!_preferenceAppService.CheckPreferencesByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Reference Details not found.");
                        }
                        if (!_forSDEAppService.CheckForSDEByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("SDE Recommendations not found.");
                        }
                        if (!_filesUploadAppService.CheckFilesByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Uploaded Files not found.");
                        }

                        if (ResponseString.Count > 0)
                        {
                            return ResponseString;
                        }
                        else
                        {
                            _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, ApplicationId, "");

                            var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);
                            CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();
                            createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                            createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                            createWorkFlow.ApplicationId = ApplicationId;
                            createWorkFlow.IsActive = true;
                            createWorkFlow.Status = ApplicationState.Submitted;

                            await _applicationAppService.ChangeWorkFlowState(createWorkFlow);

                            CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                            fWobj.ApplicationId = ApplicationId;
                            fWobj.Action = "Application Submitted";
                            fWobj.ActionBy = workFlow.Result.UserId;
                            fWobj.ApplicationState = ApplicationState.Submitted;
                            fWobj.isActive = true;

                            await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);


                            var appData = _applicationAppService.GetApplicationById(ApplicationId);
                            if (appData != null)
                            {
                                var userIds = getUserIdsByPermission(appData.FK_branchid, "Branch Manager");
                                foreach (var userid in userIds)
                                {
                                    var sde = _userAppService.GetUserById(appData.CreatorUserId);
                                    await _notificationLogAppService.SendNotification(userid, "Application Submitted", appData.ClientID + " has been Submitted by " + sde.Result.FullName);
                                    //Notification To Administrator
                                    var branchName = _branchRepository.Get(appData.FK_branchid).BranchName;
                                    await _notificationLogAppService.SendNotification(2, "Application Submitted in " + branchName + " Branch", appData.ClientID + " has been Submitted by " + sde.Result.FullName);
                                }
                            }




                            ResponseString = null;

                        }
                        //var Descrepents = _applicationAppService.GetDescripentApplicationbyApplicationId(applicationId);
                        //var count = Descrepents.DescripentScreens.Where(x => x.ScreenStatus.Contains("Discrepant")).Count();
                        //if (count == 0)
                        //{
                        //    ///change application state to submitted
                        //    _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, applicationId, "");


                        //    var workFlow = _applicationAppService.UserInRole(WorkFlowState.VO);

                        //    CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        //    createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                        //    createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        //    createWorkFlow.ApplicationId = applicationId;
                        //    createWorkFlow.IsActive = true;
                        //    createWorkFlow.Status = "Current";

                        //    await _applicationAppService.ChangeWorkFlowState(createWorkFlow);

                        //}
                    }
                    if (app.ProductType == 8 || app.ProductType == 9)
                    {
                        if (!_businessPlanAppService.CheckBusinessPlanByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Loan Requisition Details not found.");
                        }
                        if (!_personalDetailAppService.CheckPersonalDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Personal Details not found.");
                        }
                        if (!_dependentEducationDetailsAppService.CheckDependentEducationDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Dependent Education Details not found.");
                        }
                        if (!_contactDetailAppService.CheckContactDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Contact Details not found.");
                        }
                        if (!_businessDetailsTDSAppService.CheckBusinessDetailTDSByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Business Details not found.");
                        }
                        if (!_collateralDetailAppService.CheckCollateralDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Collateral Details not found.");
                        }
                        if (!_exposureDetailAppService.CheckExposureDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Exposure Details not found.");
                        }
                        if (!_tdsInventoryDetailAppService.CheckTdsInventoryDetailDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Inventory Details not found.");
                        }
                        if (!_AssetLiabilityAppService.CheckAssetLiabilityDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Asset Liability Details not found.");
                        }
                        if (!_salesDetailAppService.CheckSalesDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Sales Details not found.");
                        }
                        if (!_purchaseDetailAppService.CheckPurchaseDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Purchase Details not found.");
                        }
                        if (!_nonAssociatedIncomeAppService.CheckNonAssociatedIncomeDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Other Income Details not found.");
                        }
                        if (!_tDSBusinessExpenseAppService.CheckTDSBusinessExpenseByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Business Expense Details not found.");
                        }
                        if (!_householdIncomeAppService.CheckHouseholdIncomeByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Household Income/Expense Details not found.");
                        }
                        if (!_tDSLoanEligibilityAppService.CheckTDSLoanEligibilityListByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Loan Eligibility not found.");
                        }
                        if (!_bankAccountAppService.CheckBankAccountDetailByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Bank Account Details not found.");
                        }
                        //if (!_coApplicantDetailAppService.CheckCoApplicantDetailByApplicationId(ApplicationId))
                        //{
                        //    ResponseString.Add("Co-Applicant Details not found.");
                        //}
                        //if (!_guarantorDetailAppService.CheckGuarantorDetailByApplicationId(ApplicationId))
                        //{
                        //    ResponseString.Add("Guarantor Details not found.");
                        //}
                        if (!_preferenceAppService.CheckPreferencesByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Reference Details not found.");
                        }
                        if (!_forSDEAppService.CheckForSDEByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("SDE Recommendations not found.");
                        }
                        if (!_filesUploadAppService.CheckFilesByApplicationId(ApplicationId))
                        {
                            ResponseString.Add("Uploaded Files not found.");
                        }

                        if (ResponseString.Count > 0)
                        {
                            return ResponseString;
                        }
                        else
                        {
                            _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, ApplicationId, "");

                            var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);
                            CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();
                            createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                            createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                            createWorkFlow.ApplicationId = ApplicationId;
                            createWorkFlow.IsActive = true;
                            createWorkFlow.Status = ApplicationState.Submitted;

                            await _applicationAppService.ChangeWorkFlowState(createWorkFlow);

                            CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                            fWobj.ApplicationId = ApplicationId;
                            fWobj.Action = "Application Submitted";
                            fWobj.ActionBy = workFlow.Result.UserId;
                            fWobj.ApplicationState = ApplicationState.Submitted;
                            fWobj.isActive = true;

                            await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);


                            var appData = _applicationAppService.GetApplicationById(ApplicationId);
                            if (appData != null)
                            {
                                var userIds = getUserIdsByPermission(appData.FK_branchid, "Branch Manager");
                                foreach (var userid in userIds)
                                {
                                    var sde = _userAppService.GetUserById(appData.CreatorUserId);
                                    await _notificationLogAppService.SendNotification(userid, "Application Submitted", appData.ClientID + " has been Submitted by " + sde.Result.FullName);
                                    //Notification To Administrator
                                    var branchName = _branchRepository.Get(appData.FK_branchid).BranchName;
                                    await _notificationLogAppService.SendNotification(2, "Application Submitted in " + branchName + " Branch", appData.ClientID + " has been Submitted by " + sde.Result.FullName);
                                    //Sending Notifications to BA
                                    await _notificationLogAppService.SendNotification(63, "Application Submitted in " + branchName + " Branch", appData.ClientID + " has been Submitted by " + sde.Result.FullName);
                                }
                            }

                            ResponseString = null;

                        }
                        //var Descrepents = _applicationAppService.GetDescripentApplicationbyApplicationId(applicationId);
                        //var count = Descrepents.DescripentScreens.Where(x => x.ScreenStatus.Contains("Discrepant")).Count();
                        //if (count == 0)
                        //{
                        //    ///change application state to submitted
                        //    _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, applicationId, "");


                        //    var workFlow = _applicationAppService.UserInRole(WorkFlowState.VO);

                        //    CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        //    createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                        //    createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        //    createWorkFlow.ApplicationId = applicationId;
                        //    createWorkFlow.IsActive = true;
                        //    createWorkFlow.Status = "Current";

                        //    await _applicationAppService.ChangeWorkFlowState(createWorkFlow);

                        //}
                    }
                }
                 else
                {
                    ResponseString.Add("Invalid Application ID.");
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Sorry data is not update to Server"));
            }
            return ResponseString;
        }
        public async Task<List<string>> ReSubmitApplication(int ApplicationId, int SDE_ID)
        {
            List<string> ResponseString = new List<string>();

            try
            {
                if (ApplicationId != 0)
                {

                    var EarlierAction = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == true && x.isReSubmitted == false).ToList();
                    if (EarlierAction.Count > 0)
                    {
                        foreach (var item in EarlierAction)
                        {
                            UpdateBranchMangerActionDto obj = new UpdateBranchMangerActionDto();
                            obj.Id = item.Id;
                            obj.ActionType = item.ActionType;
                            obj.ApplicationId = item.ApplicationId;
                            obj.ScreenName = item.ScreenName;
                            obj.Reason = item.Reason;
                            obj.ActionBy = item.ActionBy;
                            obj.isActive = true;
                            obj.isReSubmitted = true;
                            var update = _branchManagerActionAppService.UpdateBranchManagerAction(obj);
                        }


                        var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);
                        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                        fWobj.ApplicationId = ApplicationId;
                        fWobj.Action = "Application Re-Submitted";
                        fWobj.ActionBy = workFlow.Result.UserId;
                        fWobj.ApplicationState = ApplicationState.Submitted;
                        fWobj.isActive = true;

                        await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                        //ResponseString.Add( = "Application has been Resubmitted Successfully!";
                        _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, ApplicationId, "Resubmitted By SDE");

                        var appData = _applicationAppService.GetApplicationById(ApplicationId);
                        if (appData != null)
                        {
                            var userIds = getUserIdsByPermission(appData.FK_branchid, "Branch Manager");
                            foreach (var userid in userIds)
                            {
                                var sde = _userAppService.GetUserById(appData.CreatorUserId);
                                await _notificationLogAppService.SendNotification(userid, "Application Resubmitted", appData.ClientID + " has been Resubmitted by " + sde.Result.FullName);
                                //Notification To Administrator
                                var branchName = _branchRepository.Get(appData.FK_branchid).BranchName;
                                await _notificationLogAppService.SendNotification(2, "Application Resubmitted in " + branchName + " Branch", appData.ClientID + " has been Resubmitted by " + sde.Result.FullName);
                                //await _notificationLogAppService.SendNotification(2, "Application Resubmitted in " + appData.Brances.BranchName + " Branch", appData.ClientID + " has been Resubmitted by " + sde.Result.FullName);
                                //Sending Notifications to BA
                                await _notificationLogAppService.SendNotification(63, "Application Resubmitted in " + branchName + " Branch", appData.ClientID + " has been Resubmitted by " + sde.Result.FullName);
                            }
                        }


                    }
                    else
                    {
                        ResponseString.Add("Invalid Application ID.");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Sorry data is not update to Server"));
            }
            return ResponseString;
        }
        public List<int> getUserIdsByPermission(int branchId, string role)
        {
            List<int> returnList = new List<int>();
            IEnumerable<UserDto> users;
            //var users = _userAppService.GetAllList().Where(x => x.BranchId == branchId);
            if (branchId != 0)
            {
                users = _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue }).Result.Items.Where(x => x.BranchId == branchId); // Paging not implemented yet
            }
            else
            {
                users = _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue }).Result.Items; // Paging not implemented yet
            }




            foreach (var userdto in users)
            {
                User user = new User();
                ObjectMapper.Map(userdto, user);

                bool isAssigned = _userManager.IsInRoleAsync(user, role).Result;

                if (isAssigned)
                {
                    returnList.Add((int)user.Id);
                }
            }



            return returnList;
        }

    }
}
