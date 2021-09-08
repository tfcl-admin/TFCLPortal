using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.AllScreensGetByAppID.Dto;
using TFCLPortal.Applications;
using TFCLPortal.AssetLiabilityDetails;
using TFCLPortal.AssociatedIncomeDetails;
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
using TFCLPortal.LoanEligibilities;
using TFCLPortal.NonAssociatedIncomeDetails;
using TFCLPortal.OtherDetails;
using TFCLPortal.PersonalDetails;
using TFCLPortal.Mobilizations;
using TFCLPortal.Preferences;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;


using TFCLPortal.DependentEducationDetails;
using TFCLPortal.TdsInventoryDetails;
using TFCLPortal.SalesDetails;
using TFCLPortal.TDSLoanEligibilities;
using TFCLPortal.BusinessDetailsTDS;
using TFCLPortal.TDSBusinessExpenses;
using TFCLPortal.PurchaseDetails;
using TFCLPortal.SalaryDetails;
using TFCLPortal.EmploymentDetails;
using TFCLPortal.TJSLoanEligibilities;
using TFCLPortal.TaggedPortfolios;
using Abp.Domain.Repositories;

namespace TFCLPortal.AllScreensGetByAppID
{
    public class AllScreenGetByAppIdAppService : TFCLPortalAppServiceBase, IAllScreenGetByAppIdAppService
    {
        private readonly IMobilizationAppService _mobilizationAppService;
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
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly ITJSLoanEligibilityAppService _tJSLoanEligibilityAppService;

        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly IAssociatedIncomeAppService _associatedIncomeAppService;
        private readonly INonAssociatedIncomeAppService _nonAssociatedIncomeAppService;

        private readonly ITdsInventoryDetailAppService _tdsInventoryDetailAppService;
        private readonly ISalesDetailAppService _salesDetailAppService;
        private readonly IPurchaseDetailAppService _purchaseDetailAppService;
        private readonly ITDSBusinessExpenseAppService _tDSBusinessExpenseAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IBusinessDetailsTDSAppService _businessDetailsTDSAppService;
        private readonly IDependentEducationDetailsAppService _dependentEducationDetailsAppService;

        private readonly ISalaryDetailsAppService _salaryDetailsAppService;
        private readonly IEmploymentDetailAppService _employmentDetailAppService;
        private readonly IRepository<TaggedPortfolio> _taggedPortfolioRepository;


        public AllScreenGetByAppIdAppService(
            IPersonalDetailAppService personalDetailAppService,
            ISalaryDetailsAppService salaryDetailsAppService,
            IEmploymentDetailAppService employmentDetailAppService,
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
            ITJSLoanEligibilityAppService tJSLoanEligibilityAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
              IAssociatedIncomeAppService associatedIncomeAppService,
            INonAssociatedIncomeAppService nonAssociatedIncomeAppService,
            IPreferenceAppService preferenceAppService,
            IMobilizationAppService mobilizationAppService,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            IForSDEAppService forSDEAppService,
            IBankAccountAppService bankAccountAppService,
            IApplicationAppService applicationAppService,
            ILoanEligibilityAppService loanEligibilityAppService,
            ITdsInventoryDetailAppService tdsInventoryDetailAppService,
        ISalesDetailAppService salesDetailAppService,
        IPurchaseDetailAppService purchaseDetailAppService,
        ITDSBusinessExpenseAppService tDSBusinessExpenseAppService,
        ITaggedPortfolioAppService taggedPortfolioAppService,
        ITDSLoanEligibilityAppService tDSLoanEligibilityAppService,
        IBusinessDetailsTDSAppService businessDetailsTDSAppService,
        IRepository<TaggedPortfolio> taggedPortfolioRepository,
        IDependentEducationDetailsAppService dependentEducationDetailsAppService
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
            _tJSLoanEligibilityAppService = tJSLoanEligibilityAppService;
            _businessExpenseAppService = businessExpenseAppService;
            _householdIncomeAppService = householdIncomeAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _associatedIncomeAppService = associatedIncomeAppService;
            _nonAssociatedIncomeAppService = nonAssociatedIncomeAppService;
            _preferenceAppService = preferenceAppService;
            _mobilizationAppService = mobilizationAppService;
            _applicationAppService = applicationAppService;
            _forSDEAppService = forSDEAppService;
            _bankAccountAppService = bankAccountAppService;
            _taggedPortfolioRepository = taggedPortfolioRepository;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
            _loanEligibilityAppService = loanEligibilityAppService;

            _tdsInventoryDetailAppService = tdsInventoryDetailAppService;
            _salesDetailAppService= salesDetailAppService;
            _purchaseDetailAppService = purchaseDetailAppService;
            _tDSBusinessExpenseAppService = tDSBusinessExpenseAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _businessDetailsTDSAppService = businessDetailsTDSAppService;
            _dependentEducationDetailsAppService = dependentEducationDetailsAppService;
            _salaryDetailsAppService = salaryDetailsAppService;
            _employmentDetailAppService = employmentDetailAppService;
        }

        public async Task<AllScreenGetByAppIdDto> AllScreenGetByApplicationId(int ApplicationId)
        {
            string ResponseString = "";
            try
            {
                var businessplan = await _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId);
                var personeldetail = await _personalDetailAppService.GetPersonalDetailByApplicationId(ApplicationId);
                var contactdetail = await _contactDetailAppService.GetContactDetailByApplicationId(ApplicationId);
                var businesdetail = await _businessDetailAppService.GetBusinessDetailByApplicationId(ApplicationId);
                var otherdetail = await _otherDetailAppService.GetOtherDetailByApplicationId(ApplicationId);
                var colateraldetail = await _collateralDetailAppService.GetCollateralDetailByApplicationId(ApplicationId);
                var exposuredetail = await _exposureDetailAppService.GetExposureDetailByApplicationId(ApplicationId);
                var assetliabailty = await _createAssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(ApplicationId);
                var businessincome = _businessIncomeAppService.GetBusinessIncomeByApplicationId(ApplicationId);
                var businesexpense = await _businessExpenseAppService.GetBusinessExpenseByApplicationId(ApplicationId);
                var household = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(ApplicationId);
                var coapplicantdetail = await _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(ApplicationId);
                var guarantordetail = await _guarantorDetailAppService.GetGuarantorDetailByApplicationId(ApplicationId);
                var prefrence = await _preferenceAppService.GetPreferencesByApplicationId(ApplicationId);
                var forSDE = await _forSDEAppService.GetForSDEByApplicationId(ApplicationId);
                var bankaccount = await _bankAccountAppService.GetBankAccountDetailByApplicationId(ApplicationId);
                var loanEligibilty = await _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId);
                var associatedIncome = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(ApplicationId);
                var nonAssociatedIncome = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(ApplicationId);

                var dependentEducationDetail = await _dependentEducationDetailsAppService.GetDependentEducationDetailByApplicationId(ApplicationId);
                var tdsInventoryDetail = await _tdsInventoryDetailAppService.GetTdsInventoryDetailDetailByApplicationId(ApplicationId);
                var salesDetail = await _salesDetailAppService.GetSalesDetailByApplicationId(ApplicationId);
                var purchaseDetail = await _purchaseDetailAppService.GetPurchaseDetailByApplicationId(ApplicationId);
                var tTDSLoanEligibility = await _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(ApplicationId);
                var businessDetailTDS = await _businessDetailsTDSAppService.GetBusinessDetailTDSByApplicationId(ApplicationId);
                var tDSBusinessExpense = await _tDSBusinessExpenseAppService.GetTDSBusinessExpenseByApplicationId(ApplicationId);

                var salaryDetails = await _salaryDetailsAppService.GetSalaryDetailByApplicationId(ApplicationId);
                var employmentDetails = await _employmentDetailAppService.GetEmploymentDetailByApplicationId(ApplicationId);
                var tjSLoanEligibility = await _tJSLoanEligibilityAppService.GetTJSLoanEligibilityListByApplicationId(ApplicationId);


                AllScreenGetByAppIdDto allScreenGetByAppId = new AllScreenGetByAppIdDto();
                allScreenGetByAppId.listBusinessPlan = businessplan;
                allScreenGetByAppId.listPersonalDetail = personeldetail;
                allScreenGetByAppId.listContactDetail = contactdetail;
                allScreenGetByAppId.listBusinessDetail = businesdetail;
                allScreenGetByAppId.listCollateralDetail = colateraldetail;
                allScreenGetByAppId.listExposureDetail = exposuredetail;
                allScreenGetByAppId.listAssetLiabilityDetail = assetliabailty;
                allScreenGetByAppId.listBusinessIncomeDetail = businessincome;
                allScreenGetByAppId.listAssociatedIncomeDetail = associatedIncome;
                allScreenGetByAppId.listNonAssociatedIncomeDetail = nonAssociatedIncome;
                allScreenGetByAppId.listBusinessExpenseDetail = businesexpense;
                allScreenGetByAppId.listHouseholdIncomeDetail = household;
                allScreenGetByAppId.listCoApplicantDetail = coapplicantdetail;
                allScreenGetByAppId.listGuarantorDetail = guarantordetail;
                allScreenGetByAppId.listReferenceDetail = prefrence;
                allScreenGetByAppId.listForSDERecommendationDetail = forSDE;
                allScreenGetByAppId.listBankAccount = bankaccount;
                allScreenGetByAppId.listLoanEligibilities = loanEligibilty;
                //TDS TJS BUSINESS
                allScreenGetByAppId.listForDependentEducationDetail = dependentEducationDetail;
                allScreenGetByAppId.listForTdsInventoryDetail = tdsInventoryDetail;
                allScreenGetByAppId.listForSalesDetail = salesDetail;
                allScreenGetByAppId.listForPurchaseDetail = purchaseDetail;
                allScreenGetByAppId.listForTDSLoanEligibility = tTDSLoanEligibility;
                allScreenGetByAppId.listForBusinessDetailTDS = businessDetailTDS;
                allScreenGetByAppId.listForTDSBusinessExpense = tDSBusinessExpense;
                //TDS TJS BUSINESS
                allScreenGetByAppId.listForSalaryDetail = salaryDetails;

                if(employmentDetails.Count>0)
                {
                    EmploymentList employmentList = new EmploymentList();
                    employmentList.ApplicationId = ApplicationId;
                    employmentList.createEmploymentInput = employmentDetails;
                    allScreenGetByAppId.listForEmploymentDetail = employmentList;
                }
                else
                {
                    allScreenGetByAppId.listForEmploymentDetail = null;
                }

                allScreenGetByAppId.listForTJSLoanEligibility = tjSLoanEligibility;



                return allScreenGetByAppId;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "All Screens by (Application ID =" + ApplicationId + " )"));
            }
        }

        public async Task<AllScreenGetBySDEidDto> AllScreenGetBySdeId(int SDE_Id)
        {
            string ResponseString = "";
            try
            {
                AllScreenGetBySDEidDto returnList = new AllScreenGetBySDEidDto();

                List<AllScreenGetByAppIdDto> list = new List<AllScreenGetByAppIdDto>();
                var apps = _applicationAppService.GetAllApplicationsByUserId(SDE_Id);
                if (apps != null)
                {
                    foreach (var app in apps)
                    {

                        int ApplicationId = app.Id;
                        var Deviation = await _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationIdAsync(ApplicationId);
                        var Application = _applicationAppService.GetApplicationById(ApplicationId);
                        var businessplan = await _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId);
                        var personeldetail = await _personalDetailAppService.GetPersonalDetailByApplicationId(ApplicationId);
                        var contactdetail = await _contactDetailAppService.GetContactDetailByApplicationId(ApplicationId);
                        var businesdetail = await _businessDetailAppService.GetBusinessDetailByApplicationId(ApplicationId);
                        //var otherdetail = _otherDetailAppService.GetOtherDetailByApplicationId(ApplicationId);
                        var colateraldetail = await _collateralDetailAppService.GetCollateralDetailByApplicationId(ApplicationId);
                        var exposuredetail = await _exposureDetailAppService.GetExposureDetailByApplicationId(ApplicationId);
                        var assetliabailty = await _createAssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(ApplicationId);
                        var businessincome = _businessIncomeAppService.GetBusinessIncomeByApplicationId(ApplicationId);
                        var businesexpense = await _businessExpenseAppService.GetBusinessExpenseByApplicationId(ApplicationId);
                        var household = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(ApplicationId);
                        var coapplicantdetail = await _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(ApplicationId);
                        var guarantordetail = await _guarantorDetailAppService.GetGuarantorDetailByApplicationId(ApplicationId);
                        var prefrence = await _preferenceAppService.GetPreferencesByApplicationId(ApplicationId);
                        var forSDE = await _forSDEAppService.GetForSDEByApplicationId(ApplicationId);
                        var bankaccount = await _bankAccountAppService.GetBankAccountDetailByApplicationId(ApplicationId);
                        var loanEligibilty = await _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId);
                        var associatedIncome = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(ApplicationId);
                        var nonAssociatedIncome = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(ApplicationId);

                        AllScreenGetByAppIdDto allScreenGetByAppId = new AllScreenGetByAppIdDto();
                        allScreenGetByAppId.ApplicationId = ApplicationId;
                        allScreenGetByAppId.listDeviation = Deviation;
                        allScreenGetByAppId.listBusinessPlan = businessplan;
                        allScreenGetByAppId.listPersonalDetail = personeldetail;
                        allScreenGetByAppId.listContactDetail = contactdetail;
                        allScreenGetByAppId.listBusinessDetail = businesdetail;
                        allScreenGetByAppId.listCollateralDetail = colateraldetail;
                        allScreenGetByAppId.listExposureDetail = exposuredetail;
                        allScreenGetByAppId.listAssetLiabilityDetail = assetliabailty;
                        allScreenGetByAppId.listBusinessIncomeDetail = businessincome;
                        allScreenGetByAppId.listAssociatedIncomeDetail = associatedIncome;
                        allScreenGetByAppId.listNonAssociatedIncomeDetail = nonAssociatedIncome;
                        allScreenGetByAppId.listBusinessExpenseDetail = businesexpense;
                        allScreenGetByAppId.listHouseholdIncomeDetail = household;
                        allScreenGetByAppId.listCoApplicantDetail = coapplicantdetail;
                        allScreenGetByAppId.listGuarantorDetail = guarantordetail;
                        allScreenGetByAppId.listReferenceDetail = prefrence;
                        allScreenGetByAppId.listForSDERecommendationDetail = forSDE;
                        allScreenGetByAppId.listBankAccount = bankaccount;
                        allScreenGetByAppId.listLoanEligibilities = loanEligibilty;
                        allScreenGetByAppId.listApplication = Application;

                        list.Add(allScreenGetByAppId);
                    }
                }

                //var mobilizaitons= _mobilizationAppService.GetMobilizationListBySdeId(SDE_Id);


                var mobilizationList = _mobilizationAppService.GetMobilizationListBySdeId(SDE_Id);
                List<GetMobilizationListDto> mobreturnList = new List<GetMobilizationListDto>();

                int x = 1;

                foreach (var mob in mobilizationList)
                {
                    bool exist = false;

                    foreach (var app in list)
                    {
                        if (mob.CNICNo == app.listApplication.CNICNo)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        mobreturnList.Add(mob);
                    }


                }

                foreach (var mob in mobreturnList) // Requirement for TT
                {
                    mob.MobilizationTableID = x++;
                }


                returnList.Applications = list;
                returnList.Mobilizations = mobreturnList;

                return returnList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "All Screens by (SDE ID =" + SDE_Id + " )"));
            }
        }

        public async Task<AllScreenGetBySDEidDto> AllScreenGetBySdeIdImproved(int SDE_Id)
        {
            string ResponseString = "";
            try
            {
                AllScreenGetBySDEidDto returnList = new AllScreenGetBySDEidDto();

                List<AllScreenGetByAppIdDto> list = new List<AllScreenGetByAppIdDto>();
                var apps = _applicationAppService.GetAllApplicationsByUserId(SDE_Id);
                if (apps != null)
                {
                    foreach (var app in apps)
                    {
                        if(app.ScreenStatus!="decline")
                        {
                            int ApplicationId = app.Id;
                            var Deviation = await _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationIdAsync(ApplicationId);
                            var Application = _applicationAppService.GetApplicationById(ApplicationId);
                            AllScreenGetByAppIdDto allScreenGetByAppId = new AllScreenGetByAppIdDto();
                            allScreenGetByAppId.ApplicationId = ApplicationId;
                            allScreenGetByAppId.listDeviation = Deviation;
                            allScreenGetByAppId.listApplication = Application;

                            list.Add(allScreenGetByAppId);
                        }
                    }
                }

                //var mobilizaitons= _mobilizationAppService.GetMobilizationListBySdeId(SDE_Id);


                var mobilizationList = _mobilizationAppService.GetMobilizationListBySdeId(SDE_Id);
                List<GetMobilizationListDto> mobreturnList = new List<GetMobilizationListDto>();

                int x = 1;

                foreach (var mob in mobilizationList)
                {
                    bool exist = false;

                    foreach (var app in list)
                    {
                        if (mob.CNICNo == app.listApplication.CNICNo)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        mobreturnList.Add(mob);
                    }


                }

                foreach (var mob in mobreturnList) // Requirement for TT
                {
                    mob.MobilizationTableID = x++;
                }


                returnList.Applications = list;
                returnList.Mobilizations = mobreturnList;

                return returnList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "All Screens by (SDE ID =" + SDE_Id + " )"));
            }
        }

        public async Task<AllScreenGetBySDEidDto> AllScreenGetBySdeIdImprovedTaggedPortfolio(int SDE_Id)
        {
            string ResponseString = "";
            try
            {
                AllScreenGetBySDEidDto returnList = new AllScreenGetBySDEidDto();

                var apps = _taggedPortfolioRepository.GetAllList(s => s.NewUserId == SDE_Id&&s.isApproved==true);

                List<AllScreenGetByAppIdDto> list = new List<AllScreenGetByAppIdDto>();
                //var apps = _applicationAppService.GetAllApplicationsByUserId(SDE_Id);
                if (apps != null)
                {
                    foreach (var app in apps)
                    {

                        int ApplicationId = app.ApplicationId;
                        var Deviation = await _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationIdAsync(ApplicationId);
                        var Application = _applicationAppService.GetApplicationById(ApplicationId);
                        AllScreenGetByAppIdDto allScreenGetByAppId = new AllScreenGetByAppIdDto();
                        allScreenGetByAppId.ApplicationId = ApplicationId;
                        allScreenGetByAppId.listDeviation = Deviation;
                        allScreenGetByAppId.listApplication = Application;

                        list.Add(allScreenGetByAppId);
                    }
                }

                //var mobilizaitons= _mobilizationAppService.GetMobilizationListBySdeId(SDE_Id);


                var mobilizationList = _mobilizationAppService.GetMobilizationListBySdeId(SDE_Id);
                List<GetMobilizationListDto> mobreturnList = new List<GetMobilizationListDto>();

                //int x = 1;

                //foreach (var mob in mobilizationList)
                //{
                //    bool exist = false;

                //    foreach (var app in list)
                //    {
                //        if (mob.CNICNo == app.listApplication.CNICNo)
                //        {
                //            exist = true;
                //        }
                //    }

                //    if (!exist)
                //    {
                //        mobreturnList.Add(mob);
                //    }


                //}

                //foreach (var mob in mobreturnList) // Requirement for TT
                //{
                //    mob.MobilizationTableID = x++;
                //}


                returnList.Applications = list;
                returnList.Mobilizations = mobreturnList;

                return returnList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "All Screens by (SDE ID =" + SDE_Id + " )"));
            }
        }
    }
}
