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
using TFCLPortal.Branches;
using TFCLPortal.PsychometricIndicators;
using TFCLPortal.SchoolFinancials;
using TFCLPortal.SchoolNonFinancials;
using TFCLPortal.Schedules;
using TFCLPortal.InstallmentPayments;
using System.Linq;
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.LoanStatuses;

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
        private readonly ISchoolFinancialAppService _schoolFinancialAppService;
        private readonly ISchoolNonFinancialAppService _schoolNonFinancialAppService;
        private readonly IPsychometricIndicatorAppService _psychometricIndicatorAppService;

        private readonly ISalaryDetailsAppService _salaryDetailsAppService;
        private readonly IEmploymentDetailAppService _employmentDetailAppService;
        private readonly IRepository<TaggedPortfolio> _taggedPortfolioRepository;
        private readonly IRepository<Applicationz> _applicationRepository;
        private readonly IRepository<LoanStatus> _loanStatusRepository;
        private readonly IRepository<Branch> _branchRepository;
        private static IScheduleAppService _scheduleAppService;
        private readonly IInstallmentPaymentAppService _installmentPaymentAppService;


        public AllScreenGetByAppIdAppService(
            IPersonalDetailAppService personalDetailAppService,
            ISalaryDetailsAppService salaryDetailsAppService,
            IInstallmentPaymentAppService installmentPaymentAppService,
            IPsychometricIndicatorAppService psychometricIndicatorAppService,
            IEmploymentDetailAppService employmentDetailAppService,
            IBusinessPlanAppService businessPlanAppService,
            IContactDetailAppService contactDetailAppService,
            ISchoolFinancialAppService schoolFinancialAppService,
            IRepository<Applicationz> applicationRepository,
            IBusinessDetailsAppService businessDetailAppService,
            IOtherDetailAppService otherDetailAppService,
            ICollateralDetailAppService collateralDetailAppService,
            IRepository<LoanStatus> loanStatusRepository,
            IExposureDetailAppService exposureDetailAppService,
            IAssetLiabilityDetailAppService assetLiabilityDetailAppService,
            IBusinessIncomeAppService businessIncomeAppService,
            IBusinessExpenseAppService businessExpenseAppService,
            IHouseholdIncomeAppService householdIncomeAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService,
            IScheduleAppService scheduleAppService,
            ITJSLoanEligibilityAppService tJSLoanEligibilityAppService,
            IRepository<Branch> branchRepository,
            ISchoolNonFinancialAppService schoolNonFinancialAppService,
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
            _installmentPaymentAppService = installmentPaymentAppService;
            _scheduleAppService = scheduleAppService;
            _loanStatusRepository = loanStatusRepository;
            _schoolNonFinancialAppService = schoolNonFinancialAppService;
            _schoolFinancialAppService = schoolFinancialAppService;
            _psychometricIndicatorAppService = psychometricIndicatorAppService;
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
            _applicationRepository = applicationRepository;
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
            _branchRepository = branchRepository;
            _tdsInventoryDetailAppService = tdsInventoryDetailAppService;
            _salesDetailAppService = salesDetailAppService;
            _purchaseDetailAppService = purchaseDetailAppService;
            _tDSBusinessExpenseAppService = tDSBusinessExpenseAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _businessDetailsTDSAppService = businessDetailsTDSAppService;
            _dependentEducationDetailsAppService = dependentEducationDetailsAppService;
            _salaryDetailsAppService = salaryDetailsAppService;
            _employmentDetailAppService = employmentDetailAppService;
        }

        public async Task<GetDataForCRSdto> getDataForCRS(int ApplicationId)
        {
            try
            {
                GetDataForCRSdto data = new GetDataForCRSdto();

                var currentApp = _applicationAppService.GetApplicationById(ApplicationId);
                var apps = _applicationRepository.GetAllListAsync().Result;
                if (apps != null && currentApp != null)
                {
                    data.ApplicationId = currentApp.Id;
                    data.ClientID = currentApp.ClientID;
                    data.ClientName = currentApp.ClientName;
                    data.SchoolName = currentApp.SchoolName;
                    data.CNICNo = currentApp.CNICNo;

                    var branch = _branchRepository.Get(currentApp.FK_branchid);
                    data.BranchCode = branch == null ? "--" : branch.BranchCode;

                    var bp = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId);
                    data.LoanPurpose = bp == null ? "--" : bp.Result.PurposeOfLoanUtilization;
                    data.LoanAmountRequested = bp == null ? "--" : bp.Result.LoanAmountRecommended;
                    data.Tenure = bp == null ? "--" : bp.Result.LoanTenureRequestedName;


                    var LE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
                    if (LE != null)
                    {
                        data.MarkupApplied = LE.Mark_Up;

                        decimal ir = decimal.Parse(LE.InstallmentRatio);
                        if (ir < 30)
                        {
                            data.InstallmentRatio = "Below 30%";
                        }
                        else if (ir < 40)
                        {
                            data.InstallmentRatio = "30% - 40%";
                        }
                        else if (ir < 40)
                        {
                            data.InstallmentRatio = "30% - 40%";
                        }
                        else if (ir < 50)
                        {
                            data.InstallmentRatio = "40% - 50%";
                        }
                        else if (ir < 60)
                        {
                            data.InstallmentRatio = "50% - 60%";
                        }
                        else if (ir < 10000)
                        {
                            data.InstallmentRatio = "Over 60%";
                        }


                        data.CollateralCoverage = decimal.Parse(LE.ActualLTVPercentageAllCollateral);
                        data.InstallmentIncome = decimal.Parse(LE.InstallmentRatio.Replace("%", "").Replace(" ", ""));


                    }

                    bool coApp = _coApplicantDetailAppService.CheckCoApplicantDetailByApplicationId(ApplicationId);
                    if (coApp)
                    {
                        data.CoApplicantAvailable = "Yes";
                    }
                    else
                    {
                        data.CoApplicantAvailable = "No";
                    }


                    data.LoanCycles = apps.FindAll(x => x.CNICNo == currentApp.CNICNo && (x.ScreenStatus != "Decline")).Count;
                    var pd = _personalDetailAppService.GetPersonalDetailByApplicationId(ApplicationId).Result;
                    if (pd != null)
                    {
                        data.Age = GetAge((DateTime)pd.BirthDate);

                        if (pd.isActiveTaxPayer == null || pd.isActiveTaxPayer == false)
                        {
                            data.TaxFiler = "No";
                        }
                        else
                        {
                            data.TaxFiler = "Yes";
                        }
                    }

                    var bd = _businessDetailAppService.GetBusinessDetailByApplicationId(ApplicationId).Result;
                    if (bd != null)
                    {
                        data.expInSchoolYears = bd.TotalExperienceInEducationIndustry;
                        if (bd.school_Branches != null)
                        {
                            data.YearsAtBusiness = ((DateTime.Now - (DateTime)bd.school_Branches[0].CurrentAddressSince).Days) / 365;
                            data.SchoolYears = ((DateTime.Now - (DateTime)bd.school_Branches[0].EstablishedSince).Days) / 365;
                            data.BusinessPlaceStatus = bd.school_Branches[0].OwnershipStatusName;
                            data.SchoolType = bd.school_Branches[0].BusinessTypeName;
                            data.LegalStatus = bd.school_Branches[0].LegalStatusName;
                            data.IsSchoolRegistered = bd.school_Branches[0].RegistrationStatus;
                            if (bd.school_Branches[0].isAcademy == null || bd.school_Branches[0].isAcademy == false)
                            {
                                data.EveningAcademy = "No";
                            }
                            else
                            {
                                data.EveningAcademy = "Yes";
                            }
                            data.SchoolLevel = bd.school_Branches[0].SchoolLevelName;


                            if (bd.school_Branches[0].NoOfBranchAccount > 0)
                            {
                                data.SeperateAccountantAvailable = "Yes";
                            }
                            else
                            {
                                decimal LoanAmount = decimal.Parse(LE.LoanAmountRequried);

                                if (LoanAmount <= 4000000)
                                {
                                    data.SeperateAccountantAvailable = "No, loan amount under 4mn";
                                }
                                else
                                {
                                    data.SeperateAccountantAvailable = "No, loan amount over 4mn";
                                }
                            }

                            data.Classrooms = bd.school_Branches[0].ClassRooms;
                            data.TeachingStaff = bd.school_Branches[0].TotalTeachingStaffTotal;
                            data.NonTeachingStaff = bd.school_Branches[0].NonTeachingStaffTotal;



                        }
                    }

                    var bi = _businessIncomeAppService.GetBusinessIncomeByApplicationId(ApplicationId);
                    if (bi != null)
                    {
                        if (bi.businessChildLists != null)
                        {
                            data.TotalStudents = Int32.Parse(bi.businessChildLists[0].StudentsConsidered);
                            data.Enrollments = Int32.Parse(bi.businessChildLists[0].StudentsConsidered);
                            data.AvgMonthlyFee = (Int32.Parse(bi.businessChildLists[0].TotalAvgFee) / bi.businessChildLists[0].BusinessIncomeSchoolClasses.Count).ToString();

                        }
                    }

                    var be = _businessExpenseAppService.GetBusinessExpenseByApplicationId(ApplicationId).Result;
                    var ed = _exposureDetailAppService.GetExposureDetailByApplicationId(ApplicationId).Result;


                    var cd = _contactDetailAppService.GetContactDetailByApplicationId(ApplicationId).Result;
                    if (cd != null)
                    {
                        data.ResidenceAccommodationType = cd.OwnershipStatusName;
                        data.YearsAtResidence = ((DateTime.Now - (DateTime)cd.CurrentAddressSince).Days) / 365;
                    }


                    //data.LoanCycles = apps.FindAll(x => x.CNICNo == currentApp.CNICNo && (x.ScreenStatus != "Decline")).Count;

                    var pi = _psychometricIndicatorAppService.GetPsychometricIndicatorByApplicationId(ApplicationId).Result;
                    if (pi != null)
                    {
                        data.PercentageToStealName = pi.PercentageToStealName;
                        data.AvoidConflictName = pi.AvoidConflictName;
                        data.MotivationToRunSchoolName = pi.MotivationToRunSchoolName;
                        data.BusinessLuck = (pi.BusinessLuck == 0 ? "False" : "True");
                        data.HopefulForFutureName = pi.HopefulForFutureName;
                        data.DigitalInitiativesName = pi.DigitalInitiativesName;
                        data.TeacherTrainingsName = pi.TeacherTrainingsName;
                        data.ParentEngagementName = pi.ParentEngagementName;
                        data.MixExpenses = pi.MixExpenses;
                        data.ComparedFee = pi.ComparedFee;
                    }

                    var sf = _schoolFinancialAppService.GetSchoolFinancialByApplicationId(ApplicationId).Result;
                    if (sf != null)
                    {
                        //data.BankingTransactionHistory = sf.;
                        data.OtherBusinessIncome = sf.spouseFamilyOtherIncomeName;
                        data.PreviousYear = sf.PreviousYear;
                        data.NoOfClassrooms = sf.NoOfClassrooms;
                        data.NoOfStudents = sf.NoOfStudents;
                        data.NoOfTeachingStaff = sf.NoOfTeachingStaff;
                        data.NoOfNonTeachingStaff = sf.NoOfNonTeachingStaff;

                        data.TotalRevenue = sf.TotalRevenue;
                        data.TotalExpensesFromSalary = sf.TotalExpensesFromSalary;
                        data.TotalExpensesFromRentMortgage = sf.TotalExpensesFromRentMortgage;
                        data.TotalExpensesFromDebt = sf.TotalExpensesFromDebt;
                        data.AllOtherExpenses = sf.AllOtherExpenses;
                        data.TotalProfit = sf.TotalProfit;
                        data.spouseFamilyOtherIncomeName = sf.spouseFamilyOtherIncomeName;
                        data.ProfitMargin = sf.ProfitMargin;
                        data.TotalAsset = sf.TotalAsset;
                        data.CurrentAsset = sf.CurrentAsset;
                        data.TotalLiabilities = sf.TotalLiabilities;
                        data.CurrentLiabilities = sf.CurrentLiabilities;
                        data.WorkingCapital = sf.WorkingCapital;
                        data.PrevAvgMonthlyFee = sf.AvgMonthlyFee;

                        //------------------------------------------------------------------------------------------------------------------------
                        decimal totalRevenueCurr = 0;

                        if (bi != null)
                        {
                            totalRevenueCurr += decimal.Parse(bi.nGrandTotalSchoolFeeIncome.Replace(",", "")) + decimal.Parse(bi.nGrandTotalAcademyFeeIncome.Replace(",", ""));
                        }

                        var ai = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(ApplicationId);

                        if (ai != null)
                        {
                            totalRevenueCurr += decimal.Parse(ai.GrandTotalAssociatedIncome.Replace(",", ""));
                        }

                        var nai = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(ApplicationId);

                        if (nai != null)
                        {
                            totalRevenueCurr += decimal.Parse(nai.TotalNonAssociatedIncome.Replace(",", ""));
                        }

                        data.CurrTotalRevenue = totalRevenueCurr.ToString();

                        if (totalRevenueCurr > decimal.Parse(data.TotalRevenue))
                        {
                            data.ChangeInRevenue = "Increasing";
                        }
                        else if (totalRevenueCurr < decimal.Parse(data.TotalRevenue))
                        {
                            data.ChangeInRevenue = "Decreasing";
                        }
                        else
                        {
                            data.ChangeInRevenue = "No Change";
                        }
                        //------------------------------------------------------------------------------------------------------------------------

                        decimal totalExpFromSalaryCurr = 0;
                        if (be != null)
                        {
                            foreach (var school in be.businessExpenseSchool)
                            {
                                totalExpFromSalaryCurr += decimal.Parse(school.TeacherSalary.Replace(",", "")) + decimal.Parse(school.OtherSalary.Replace(",", ""));

                                if (school.businessExpenseSchoolAcademies != null)
                                {
                                    foreach (var academy in school.businessExpenseSchoolAcademies)
                                    {
                                        totalExpFromSalaryCurr += decimal.Parse(academy.TeacherSalary.Replace(",", "")) + decimal.Parse(academy.OtherSalary.Replace(",", ""));
                                    }
                                }

                            }
                        }
                        data.CurrTotalExpensesFromSalary = totalExpFromSalaryCurr.ToString();
                        //------------------------------------------------------------------------------------------------------------------------
                        decimal totalExpFromRentCurr = 0;
                        if (be != null)
                        {
                            foreach (var school in be.businessExpenseSchool)
                            {
                                totalExpFromRentCurr += decimal.Parse(school.RentAmount.Replace(",", ""));
                                if (school.businessExpenseSchoolAcademies != null)
                                {
                                    foreach (var academy in school.businessExpenseSchoolAcademies)
                                    {
                                        totalExpFromRentCurr += decimal.Parse(school.RentAmount.Replace(",", ""));
                                    }
                                }
                            }
                        }
                        data.CurrTotalExpensesFromRentMortgage = totalExpFromRentCurr.ToString();
                        //------------------------------------------------------------------------------------------------------------------------
                        decimal totalExpFromDebtCurr = 0;
                        if (ed != null)
                        {
                            totalExpFromDebtCurr += ed.TotalInstallmentpayment;
                        }
                        data.CurrTotalExpensesFromDebt = totalExpFromDebtCurr.ToString();
                        //------------------------------------------------------------------------------------------------------------------------

                        decimal AllOtherExpensesCurr = 0;
                        if (be != null)
                        {
                            AllOtherExpensesCurr += decimal.Parse(be.nGrandTotalBusinessExpense.Replace(",", ""));
                            AllOtherExpensesCurr -= (totalExpFromDebtCurr + totalExpFromRentCurr + totalExpFromSalaryCurr);
                        }
                        data.CurrAllOtherExpenses = AllOtherExpensesCurr.ToString();
                        //------------------------------------------------------------------------------------------------------------------------

                        decimal TotalProfitCurr = 0;

                        TotalProfitCurr = totalRevenueCurr - (AllOtherExpensesCurr + totalExpFromDebtCurr + totalExpFromRentCurr + totalExpFromSalaryCurr);

                        data.CurrTotalProfit = TotalProfitCurr.ToString();

                        decimal AllExpensesCurr = AllOtherExpensesCurr + totalExpFromDebtCurr + totalExpFromRentCurr + totalExpFromSalaryCurr;
                        decimal AllExpenses = decimal.Parse(data.AllOtherExpenses) + decimal.Parse(data.TotalExpensesFromDebt) + decimal.Parse(data.TotalExpensesFromRentMortgage) + decimal.Parse(data.TotalExpensesFromSalary);

                        if (AllExpensesCurr > AllExpenses)
                        {
                            data.ChangeInTotalExpenses = "Increasing";
                        }
                        else if (AllExpensesCurr < AllExpenses)
                        {
                            data.ChangeInTotalExpenses = "Decreasing";
                        }
                        else
                        {
                            data.ChangeInTotalExpenses = "No Change";
                        }

                        //------------------------------------------------------------------------------------------------------------------------

                        decimal ProfitMarginCurr = 0;

                        ProfitMarginCurr = TotalProfitCurr / totalRevenueCurr * 100;

                        data.CurrProfitMargin = ProfitMarginCurr.ToString();
                        //------------------------------------------------------------------------------------------------------------------------


                        if (ProfitMarginCurr > decimal.Parse(data.ProfitMargin))
                        {
                            data.ChangeInProfitMargin = "Increasing";
                        }
                        else if (ProfitMarginCurr < decimal.Parse(data.ProfitMargin))
                        {
                            data.ChangeInProfitMargin = "Decreasing";
                        }
                        else
                        {
                            data.ChangeInProfitMargin = "No Change";
                        }

                        //------------------------------------------------------------------------------------------------------------------------

                        var ald = _createAssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(ApplicationId).Result;
                        if (ald != null)
                        {
                            data.CurrTotalAsset = ald.TotalBusinessAsset.ToString();
                            data.CurrCurrentAsset = ald.CurrTotalCurrentAssets;
                            data.CurrTotalLiabilities = ald.TotalBusinessLiability.ToString();
                            data.CurrCurrentLiabilities = ald.CurrTotalCurrentLiabilities;

                            //------------------------------------------------------------------------------------------------------------------------


                            if (decimal.Parse(data.CurrTotalAsset) > decimal.Parse(data.TotalAsset))
                            {
                                data.ChangeInAsset = "Increasing";
                            }
                            else if (decimal.Parse(data.CurrTotalAsset) < decimal.Parse(data.TotalAsset))
                            {
                                data.ChangeInAsset = "Decreasing";
                            }
                            else
                            {
                                data.ChangeInAsset = "No Change";
                            }

                            //------------------------------------------------------------------------------------------------------------------------


                            if (decimal.Parse(data.CurrTotalProfit) > decimal.Parse(data.TotalProfit))
                            {
                                data.ChangeInTotalProfit = "Increasing";
                            }
                            else if (decimal.Parse(data.CurrTotalProfit) < decimal.Parse(data.TotalProfit))
                            {
                                data.ChangeInTotalProfit = "Decreasing";
                            }
                            else
                            {
                                data.ChangeInTotalProfit = "No Change";
                            }
                        }

                        //------------------------------------------------------------------------------------------------------------------------


                    }
                    var sde = _forSDEAppService.GetForSDEByApplicationId(ApplicationId).Result;
                    if (sde != null)
                    {
                        data.UtillityBill = sde.utilityName;
                    }
                    var lrd = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                    if (lrd != null)
                    {
                        data.CurrWorkingCapital = lrd.AmountWorkingCapital;
                    }

                    var snf = _schoolNonFinancialAppService.GetSchoolNonFinancialByApplicationId(ApplicationId).Result;
                    if (snf != null)
                    {
                        data.BankingTransactionHistory = snf.TransactionHistoryName;
                        data.StructuralFinancialRecords = snf.FinancialRecordsName;
                        data.BusinessSuccession = snf.BusinessSuccession;
                        data.ClientBusinessRadius = snf.BusinessRadiusName;

                        data.BuildingConditionName = snf.BuildingConditionName;
                        data.PowerBackup = snf.PowerBackup;
                        data.FirstAid = snf.FirstAid;
                        data.AyasPresent = snf.AyasPresent;
                        data.SeperateWashrooms = snf.SeperateWashrooms;
                        data.ProperLighting = snf.ProperLighting;
                        data.CleanWater = snf.CleanWater;
                        data.FunctionalComputerLab = snf.FunctionalComputerLab;
                        data.SchoolManagementSystem = snf.SchoolManagementSystem;
                        data.SchoolDecor = snf.SchoolDecor;
                        data.LearningAid = snf.LearningAid;
                        data.TeacherTrainings = snf.TeacherTrainings;
                        data.ChildProtection = snf.ChildProtection;
                        data.EmergencyExits = snf.EmergencyExits;
                        data.SecurityGuards = snf.SecurityGuards;
                        data.HealthEnvironment = snf.HealthEnvironment;
                        data.otherPaymentBehaviour = snf.OtherPaymentBehaviourName;
                        data.DropoutStudents = snf.DropoutStudents;

                        if (data.TotalStudents != 0 && snf.DropoutStudents != 0)
                        {
                            data.DropoutStudentsRatio = snf.DropoutStudents / data.TotalStudents * 100;
                        }
                        else
                        {
                            data.DropoutStudentsRatio = 0;
                        }

                        if (data.TotalStudents != 0 && data.TeachingStaff != 0)
                        {
                            data.StudentTeacherRatio = data.TotalStudents / data.TeachingStaff * 100;
                        }
                        else
                        {
                            data.StudentTeacherRatio = 0;
                        }

                    }

                    var colD = _collateralDetailAppService.GetCollateralDetailByApplicationId(ApplicationId).Result;
                    if (colD != null)
                    {
                        List<collateralListDto> collateralList = new List<collateralListDto>();
                        foreach (var item in colD.createCollateralLandBuilding)
                        {
                            collateralListDto collateral = new collateralListDto();
                            collateral.id = item.Id;
                            collateral.title = "Land/Building : " + item.propertyTypeName;
                            collateral.marketValue = item.LandBuildingMarketPrice;
                            collateral.forcedSaleValue = item.AppliedLtvPercentage;
                            collateralList.Add(collateral);
                        }

                        foreach (var item in colD.createCollateralVehicle)
                        {
                            collateralListDto collateral = new collateralListDto();
                            collateral.id = item.Id;
                            collateral.title = "Vehicle : " + item.MAKE;
                            collateral.marketValue = item.MarketValue;
                            collateral.forcedSaleValue = item.AppliedLtvPercentage;
                            collateralList.Add(collateral);
                        }

                        foreach (var item in colD.createCollateralTDR)
                        {
                            collateralListDto collateral = new collateralListDto();
                            collateral.id = item.Id;
                            collateral.title = "TDR";
                            collateral.marketValue = item.AmountTDR;
                            collateral.forcedSaleValue = item.AppliedLtvPercentage;
                            collateralList.Add(collateral);
                        }
                        data.Collaterals = collateralList;
                    }

                    if (data.Enrollments > data.NoOfStudents)
                    {
                        data.ChangeInStudents = "Increasing";
                    }
                    else if (data.Enrollments < data.NoOfStudents)
                    {
                        data.ChangeInStudents = "Decreasing";
                    }
                    else
                    {
                        data.ChangeInStudents = "No Change";
                    }

                    if (data.TeachingStaff > data.NoOfTeachingStaff)
                    {
                        data.ChangeInTeachers = "Increasing";
                    }
                    else if (data.TeachingStaff < data.NoOfTeachingStaff)
                    {
                        data.ChangeInTeachers = "Decreasing";
                    }
                    else
                    {
                        data.ChangeInTeachers = "No Change";
                    }

                    if (data.Classrooms > data.NoOfClassrooms)
                    {
                        data.ChangeInClassrooms = "Increasing";
                    }
                    else if (data.Classrooms < data.NoOfClassrooms)
                    {
                        data.ChangeInClassrooms = "Decreasing";
                    }
                    else
                    {
                        data.ChangeInClassrooms = "No Change";
                    }

                    // FINANCIAL RISK SCORE

                    if ((data.CurrCurrentAsset != "0" && data.CurrCurrentAsset != "" && data.CurrCurrentAsset != null) && (data.CurrCurrentLiabilities != "0" && data.CurrCurrentLiabilities != "" && data.CurrCurrentLiabilities != null))
                    {
                        data.CurrentALDRatio = decimal.Parse(data.CurrCurrentAsset) / decimal.Parse(data.CurrCurrentLiabilities) * 100;
                    }
                    else
                    {
                        data.CurrentALDRatio = 0;
                    }

                    if (data.LoanCycles > 1)
                    {
                        data.CreditHistoryAvailable = "Yes";
                    }
                    else
                    {
                        if (ed != null)
                        {
                            if (ed.ExistingBankExposure == "YES")
                            {
                                data.CreditHistoryAvailable = "Yes";
                            }
                            else if (ed.ExistingBankExposure == "NO")
                            {
                                data.CreditHistoryAvailable = "No";
                            }
                        }
                        else
                        {
                            data.CreditHistoryAvailable = "No";
                        }
                    }

                    if (lrd != null)
                    {
                        if (lrd.OverDues == true)
                        {
                            data.AdvanceAccounts = "None";
                        }
                        else
                        {
                            if (lrd.CreditBureauCheckName == "NTF" || lrd.CreditBureauCheckName == "Zero Delays" || lrd.CreditBureauCheckName == "Good Repayment History")
                            {
                                data.AdvanceAccounts = "Less than 30 days";
                            }
                            else if (lrd.CreditBureauCheckName == "Delays in Payment" || lrd.CreditBureauCheckName == "Write-Off")
                            {
                                data.AdvanceAccounts = "More than 30 days";
                            }
                        }
                    }


                }




                return data;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "All Screens by (Application ID =" + ApplicationId + " )"));
            }
        }

        public static Int32 GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
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

                var schoolFinancialDetails = await _schoolFinancialAppService.GetSchoolFinancialByApplicationId(ApplicationId);
                var schoolNonFinancialDetails = await _schoolNonFinancialAppService.GetSchoolNonFinancialByApplicationId(ApplicationId);
                var psychometricIndicators = await _psychometricIndicatorAppService.GetPsychometricIndicatorByApplicationId(ApplicationId);


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
                allScreenGetByAppId.listForSchoolFinancialDetails = schoolFinancialDetails;
                allScreenGetByAppId.listForSchoolNonFinancialDetails = schoolNonFinancialDetails;
                allScreenGetByAppId.listForPsychometricDetails = psychometricIndicators;

                if (employmentDetails.Count > 0)
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
                        if (app.ScreenStatus != "decline")
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

                var apps = _taggedPortfolioRepository.GetAllList(s => s.NewUserId == SDE_Id && s.isApproved == true);

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


        public async Task<List<LoanStatusDto>> getUpdatedStatus()
        {
            List<LoanStatusDto> list = new List<LoanStatusDto>();

            try
            {
                var s = await _scheduleAppService.GetScheduleList();
                var allInstallmentspaid = _installmentPaymentAppService.GetAllInstallmentPayments();



                foreach (var schedule in s)
                {
                    LoanStatusDto ls = new LoanStatusDto();


                    ls.ApplicationId = schedule.ApplicationId;
                    ls.Tenure = Int32.Parse(schedule.Tenure);
                    var unpaidInstallments = schedule.installmentList.FindAll(x => x.isPaid != true);
                    var Installmentspaid = allInstallmentspaid.Result.Where(x => x.ApplicationId == schedule.ApplicationId).ToList();

                    //Unpaid Installment Details

                    if (unpaidInstallments.Count != 0)
                    {
                        var latestInstallment = unpaidInstallments[0];
                        ls.CurrentInstallmentNo = latestInstallment.InstNumber;
                        ls.CurrentInstallmentPrincipal = ConvertToDecimal(latestInstallment.principal);
                        ls.CurrentInstallmentMarkup = ConvertToDecimal(latestInstallment.markup);
                        ls.CurrentInstallmentAmount = ConvertToDecimal(latestInstallment.installmentAmount);
                        ls.CurrentOutstandingPrincipal = ConvertToDecimal(latestInstallment.OsPrincipal_Closing);

                        if (latestInstallment.InstNumber != "G*")
                        {
                            ls.CurrentInstallmentDueDate = DateTime.Parse(latestInstallment.InstallmentDueDate);
                            ls.CurrentLateDays = (DateTime.Now - ls.CurrentInstallmentDueDate).Days < 0 ? 0 : (DateTime.Now - ls.CurrentInstallmentDueDate).Days;
                        }

                        //Unpaid Installment Payment Details
                        if (latestInstallment.InstNumber != "0")
                        {
                            var paidInstByInstNo = Installmentspaid.Where(x => x.NoOfInstallment.ToString() == latestInstallment.InstNumber);

                            decimal sumOfAmountsPerInstallment = 0;
                            decimal excessShort = 0;
                            foreach (var paidInstallment in paidInstByInstNo)
                            {
                                sumOfAmountsPerInstallment += paidInstallment.Amount;
                                excessShort = paidInstallment.ExcessShortPayment;
                            }
                            ls.CurrentPaidAmount = sumOfAmountsPerInstallment;
                            ls.CurrentExcessShort = excessShort;

                            sumOfAmountsPerInstallment = 0;
                        }
                        else
                        {

                            var AllDefferedInstallments = schedule.installmentList.Where(x => x.InstNumber == latestInstallment.InstNumber).ToList();
                            var indexOfThisInstallment = AllDefferedInstallments.IndexOf(latestInstallment);

                            var paidDeferredInstallments = Installmentspaid.Where(x => x.NoOfInstallment.ToString() == "0").ToList();
                            try
                            {
                                IGrouping<DateTime, InstallmentPaymentListDto> lastInstallmentDate;

                                lastInstallmentDate = Installmentspaid.Where(x => x.isAuthorized == true).GroupBy(x => x.InstallmentDueDate).OrderBy(x => x.Key).LastOrDefault();

                                if (lastInstallmentDate != null)
                                {
                                    var requiredPayments = Installmentspaid.Where(x => x.InstallmentDueDate == lastInstallmentDate.Key).ToList();

                                    decimal sumOfAmountsPerInstallment = 0;
                                    decimal excessShort = 0;

                                    int appid = schedule.ApplicationId;

                                    foreach (var payment in requiredPayments)
                                    {
                                        if (latestInstallment.isPaid == true)
                                        {
                                            sumOfAmountsPerInstallment += payment.Amount;
                                            excessShort += payment.ExcessShortPayment;
                                        }
                                        else
                                        {
                                            excessShort = payment.ExcessShortPayment;

                                        }
                                        //lastpaidInstallment.LastPaymentDate = payment.DepositDate;
                                    }

                                    ls.CurrentPaidAmount = sumOfAmountsPerInstallment;
                                    ls.CurrentExcessShort = excessShort;
                                }

                                //var paidDeferredInstallmentOnThisIndex = paidDeferredInstallments[indexOfThisInstallment];
                                //installment.PaidAmount = paidDeferredInstallmentOnThisIndex.Amount.ToString();
                                //installment.ExcessShort = paidDeferredInstallmentOnThisIndex.ExcessShortPayment.ToString();

                            }
                            catch
                            {

                            }

                        }

                    }

                    //Paid Installment Details

                    var paidInstallments = schedule.installmentList.FindAll(x => x.isPaid == true);

                    if (paidInstallments.Count != 0)
                    {
                        var lastpaidInstallment = paidInstallments[paidInstallments.Count - 1];
                        ls.LastInstallmentNo = lastpaidInstallment.InstNumber;
                        ls.LastInstallmentPrincipal = ConvertToDecimal(lastpaidInstallment.principal);
                        ls.LastInstallmentMarkup = ConvertToDecimal(lastpaidInstallment.markup);
                        ls.LastInstallmentAmount = ConvertToDecimal(lastpaidInstallment.installmentAmount);
                        ls.LastPaidDate = (DateTime)lastpaidInstallment.PaymentDate;
                        ls.LastOutstandingPrincipal = ConvertToDecimal(lastpaidInstallment.OsPrincipal_Closing);
                        if (lastpaidInstallment.InstNumber != "G*")
                        {
                            ls.LastInstallmentDueDate = DateTime.Parse(lastpaidInstallment.InstallmentDueDate);
                            ls.LastLateDays = (ls.LastPaidDate - ls.LastInstallmentDueDate).Days < 0 ? 0 : (ls.LastPaidDate - ls.LastInstallmentDueDate).Days;
                        }

                        //Paid Installment Payment Details

                        if (lastpaidInstallment.InstNumber != "0")
                        {
                            var paidInstByInstNo = Installmentspaid.Where(x => x.NoOfInstallment.ToString() == lastpaidInstallment.InstNumber);

                            decimal sumOfAmountsPerInstallment = 0;
                            decimal excessShort = 0;
                            foreach (var paidInstallment in paidInstByInstNo)
                            {
                                sumOfAmountsPerInstallment += paidInstallment.Amount;
                                excessShort = paidInstallment.ExcessShortPayment;
                            }
                            ls.LastPaidAmount = sumOfAmountsPerInstallment;
                            ls.LastExcessShort = excessShort;

                            sumOfAmountsPerInstallment = 0;
                        }
                        else
                        {

                            var AllDefferedInstallments = schedule.installmentList.Where(x => x.InstNumber == lastpaidInstallment.InstNumber).ToList();
                            var indexOfThisInstallment = AllDefferedInstallments.IndexOf(lastpaidInstallment);

                            var paidDeferredInstallments = Installmentspaid.Where(x => x.NoOfInstallment.ToString() == "0").ToList();
                            try
                            {
                                IGrouping<DateTime, InstallmentPaymentListDto> lastInstallmentDate;
                              
                                    lastInstallmentDate = Installmentspaid.Where(x => x.isAuthorized == true).GroupBy(x => x.InstallmentDueDate).OrderBy(x => x.Key).LastOrDefault();

                                if (lastInstallmentDate != null)
                                {
                                    var requiredPayments = Installmentspaid.Where(x => x.InstallmentDueDate == lastInstallmentDate.Key).ToList();

                                    decimal sumOfAmountsPerInstallment = 0;
                                    decimal excessShort = 0;

                                    int appid = schedule.ApplicationId;

                                    foreach (var payment in requiredPayments)
                                    {
                                        if (lastpaidInstallment.isPaid == true)
                                        {
                                            sumOfAmountsPerInstallment += payment.Amount;
                                            excessShort += payment.ExcessShortPayment;
                                        }
                                        else
                                        {
                                            excessShort = payment.ExcessShortPayment;

                                        }
                                        //lastpaidInstallment.LastPaymentDate = payment.DepositDate;
                                    }

                                    ls.LastPaidAmount = sumOfAmountsPerInstallment;
                                    ls.LastExcessShort = excessShort;
                                }

                                //var paidDeferredInstallmentOnThisIndex = paidDeferredInstallments[indexOfThisInstallment];
                                //installment.PaidAmount = paidDeferredInstallmentOnThisIndex.Amount.ToString();
                                //installment.ExcessShort = paidDeferredInstallmentOnThisIndex.ExcessShortPayment.ToString();

                            }
                            catch
                            {

                            }

                        }

                    }



                    list.Add(ls);




                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }


            return list;
        }


        public async Task<string> getUpdatedStatusAndInsert()
        {

            try
            {
                List<LoanStatusDto> statuses = await getUpdatedStatus();
                if (statuses.Count > 0)
                {
                    var ExistingStatus = _loanStatusRepository.GetAllList();

                    foreach(var existing in ExistingStatus)
                    {
                        await _loanStatusRepository.DeleteAsync(existing);
                    }
                    
                    CurrentUnitOfWork.SaveChanges();

                    foreach (var status in statuses)
                    {
                        LoanStatus ls = new LoanStatus();

                        ls = ObjectMapper.Map<LoanStatus>(status);

                        await _loanStatusRepository.InsertAsync(ls);

                    }

                }
                return "Success. " + statuses.Count + " Loan(s) status updated";
            }
            catch (Exception ex)
            {
                return "Error. "+ex.ToString();
            }
        }

        public decimal ConvertToDecimal(string str)
        {
            if (str != ""&& str!="--")
            {
                return decimal.Parse(str.Replace(",", ""));
            }
            else
            {
                return 0;
            }
        }

    }
}
