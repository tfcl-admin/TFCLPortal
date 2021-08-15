using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Dependency;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.AssetLiabilityDetails;
using TFCLPortal.AssetLiabilityDetails.Dto;
using TFCLPortal.BankAccountDetails;
using TFCLPortal.BankAccountDetails.Dto;
using TFCLPortal.BusinessExpenses;
using TFCLPortal.BusinessExpenses.Dto;
using TFCLPortal.BusinessIncomes;
using TFCLPortal.BusinessIncomes.Dto;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.CoApplicantDetails.Dto;
using TFCLPortal.BusinessDetails;
using TFCLPortal.BusinessPlans;
using TFCLPortal.CollateralDetails;
using TFCLPortal.ContactDetails;
using TFCLPortal.Controllers;
using TFCLPortal.ExposureDetails;
using TFCLPortal.ExposureDetails.Dto;
using TFCLPortal.ForSDES;
using TFCLPortal.ForSDES.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.GuarantorDetails.Dto;
using TFCLPortal.HouseholdIncomesExpenses;
using TFCLPortal.HouseholdIncomesExpenses.Dto;
using TFCLPortal.OtherDetails;
using TFCLPortal.OtherDetails.Dto;
using TFCLPortal.PersonalDetails;
using TFCLPortal.Preferences;
using TFCLPortal.Preferences.Dto;
using TFCLPortal.BusinessDetails.Dto;
using TFCLPortal.CollateralDetails.Dto;
using TFCLPortal.BusinessPlans.Dto;
using TFCLPortal.ContactDetails.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Authentication;
using TFCLPortal.Authorization;
using TFCLPortal.FilesUploads;
using TFCLPortal.WorkFlows;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TFCLPortal.Web.Models.BADocumentUploads;
using Microsoft.AspNetCore.Http;
using TFCLPortal.Applications;
using TFCLPortal.ApplicationWorkFlows.BADataChecks.Dto;
using TFCLPortal.ApplicationWorkFlows.BADataChecks;
using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.LoanAmortizations;
using TFCLPortal.LoanAmortizationChilds.Dto;
using TFCLPortal.LoanAmortizations.Dto;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Applications.Dto;
using TFCLPortal.DescripentScreens;
using TFCLPortal.DescripentScreens.Dto;
using TFCLPortal.EntityFrameworkCore.Repositories;
using GemBox.Spreadsheet;
using TFCLPortal.TaleemSchoolAsasahs;
using TFCLPortal.TaleemSchoolSarmayas;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates;
using Abp.Notifications;
using Abp;
using Microsoft.AspNetCore.Identity;
using TFCLPortal.Users;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Branches;
using TFCLPortal.NonAssociatedIncomeDetails;
using TFCLPortal.AssociatedIncomeDetails;
using TFCLPortal.BranchManagerActions;
using TFCLPortal.BranchManagerActions.Dto;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.ApplicationWorkFlows.BccStates;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.McrcRecords;
using TFCLPortal.McrcStates;
using TFCLPortal.McrcStates.Dto;
using TFCLPortal.McrcDecisions;
using TFCLPortal.NotificationLogs;
using TFCLPortal.FcmTokens;
using TFCLPortal.FcmTokens.Dto;
using TFCLPortal.Web.Models.ViewApplication;
using TFCLPortal.Mobilizations;
using TFCLPortal.DependentEducationDetails;
using TFCLPortal.TdsInventoryDetails;
using TFCLPortal.SalesDetails;
using TFCLPortal.TDSLoanEligibilities;
using TFCLPortal.BusinessDetailsTDS;
using TFCLPortal.TDSBusinessExpenses;
using TFCLPortal.PurchaseDetails;
using Abp.Runtime.Validation;

namespace TFCLPortal.Web.Mvc.Controllers
{
    //[AbpMvcAuthorize]
    public class DashboardController : TFCLPortalControllerBase
    {

        private readonly INotificationLogAppService _notificationLogAppService;
        private readonly IPersonalDetailAppService _personalDetailAppService;
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IContactDetailAppService _contactDetailAppService;
        private readonly IBusinessDetailsAppService _businesDetailAppService;
        private readonly ICollateralDetailAppService _collateralDetailAppService;
        //private readonly IContactDetailAppService _contactDetailAppService;
        private readonly IOtherDetailAppService _otherDetailAppService;
        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IExposureDetailAppService _exposureDetailAppService;
        private readonly IBusinessIncomeAppService _businessIncomeAppService;
        private readonly IBusinessDetailsTDSAppService _businessDetailsTDSAppService;
        private readonly IBusinessExpenseAppService _businessExpenseAppService;
        private readonly IHouseholdIncomeAppService _householdIncomeAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IForSDEAppService _forSDEAppService;
        private readonly IPreferenceAppService _preferenceAppService;
        private readonly IAssetLiabilityDetailAppService _AssetLiabilityAppService;
        private readonly IFilesUploadAppService _FilesUploadAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IBADataCheckAppService _IBADataCheckAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ILoanAmortizationAppService _loanAmortizationAppService;
        private readonly IProductTypeAppService _productTypeAppService;
        private readonly IDescripentScreenAppService _descripentScreenAppService;
        private readonly ICustomRepository _customRepository;
        private readonly ITaleemSchoolAsasahAppService _taleemSchoolAsasahAppService;
        private readonly ITaleemSchoolSarmayaAppService _taleemSchoolSarmayaAppService;
        private readonly IApplicationDescripantDeclineStateAppService _applicationDescripantDeclineStateAppService;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private readonly INonAssociatedIncomeAppService _nonAssociatedIncomeAppService;
        private readonly IAssociatedIncomeAppService _associatedIncomeAppService;
        private readonly IBranchManagerActionAppService _branchManagerActionAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IBccStateAppService _bccStateAppService;
        private readonly IMcrcRecordAppService _mcrcRecordAppService;
        private readonly IMcrcStateAppService _mcrcStateAppService;
        private readonly IMcrcDecisionAppService _McrcDecisionAppService;
        private readonly IFcmTokenAppService _fcmTokenAppService;
        private readonly IMobilizationAppService _mobilizationAppService;
        private readonly ITdsInventoryDetailAppService _tdsInventoryDetailAppService;
        private readonly ISalesDetailAppService _salesDetailAppService;
        private readonly IPurchaseDetailAppService _purchaseDetailAppService;
        private readonly ITDSBusinessExpenseAppService _tDSBusinessExpenseAppService;
        private readonly IDependentEducationDetailsAppService _dependentEducationDetailsAppService;

        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;

        private readonly IHostingEnvironment _env;

        public DashboardController(IFcmTokenAppService fcmTokenAppService, ITDSLoanEligibilityAppService tDSLoanEligibilityAppService, ITDSBusinessExpenseAppService tDSBusinessExpenseAppService, IBusinessDetailsTDSAppService businessDetailsTDSAppService, IPurchaseDetailAppService purchaseDetailAppService, ISalesDetailAppService salesDetailAppService, ITdsInventoryDetailAppService tdsInventoryDetailAppService, IDependentEducationDetailsAppService dependentEducationDetailsAppService, IMobilizationAppService mobilizationAppService, INotificationLogAppService notificationLogAppService, IHostingEnvironment env, IMcrcDecisionAppService McrcDecisionAppService, IMcrcRecordAppService mcrcRecordAppService, IMcrcStateAppService mcrcStateAppService, IBccStateAppService bccStateAppService, IFinalWorkflowAppService finalWorkflowAppService, IAssociatedIncomeAppService associatedIncomeAppService, IBranchManagerActionAppService branchManagerActionAppService, INonAssociatedIncomeAppService nonAssociatedIncomeAppService, IUserAppService userAppService, UserManager userManager)
        {

            _userManager = userManager;
            _userAppService = userAppService;
            _mcrcStateAppService = mcrcStateAppService;
            _mcrcRecordAppService = mcrcRecordAppService;
            _fcmTokenAppService = fcmTokenAppService;
            _McrcDecisionAppService = McrcDecisionAppService;
            _dependentEducationDetailsAppService = dependentEducationDetailsAppService;
            _notificationLogAppService = notificationLogAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _purchaseDetailAppService = purchaseDetailAppService;
            _businessDetailsTDSAppService = businessDetailsTDSAppService;
            _tDSBusinessExpenseAppService = tDSBusinessExpenseAppService;
            _salesDetailAppService = salesDetailAppService;
            _personalDetailAppService = IocManager.Instance.Resolve<IPersonalDetailAppService>();
            //_personalDetailAppService = personalDetailAppService;
            //_contactDetailAppService = IocManager.Instance.Resolve<IContactDetailAppService>();
            _otherDetailAppService = IocManager.Instance.Resolve<IOtherDetailAppService>();
            _bankAccountAppService = IocManager.Instance.Resolve<IBankAccountAppService>();
            _exposureDetailAppService = IocManager.Instance.Resolve<IExposureDetailAppService>();
            _businessIncomeAppService = IocManager.Instance.Resolve<IBusinessIncomeAppService>();
            _businessExpenseAppService = IocManager.Instance.Resolve<IBusinessExpenseAppService>();
            _householdIncomeAppService = IocManager.Instance.Resolve<IHouseholdIncomeAppService>();
            _coApplicantDetailAppService = IocManager.Instance.Resolve<ICoApplicantDetailAppService>();
            _guarantorDetailAppService = IocManager.Instance.Resolve<IGuarantorDetailAppService>();
            _forSDEAppService = IocManager.Instance.Resolve<IForSDEAppService>();
            _preferenceAppService = IocManager.Instance.Resolve<IPreferenceAppService>();
            _AssetLiabilityAppService = IocManager.Instance.Resolve<IAssetLiabilityDetailAppService>();
            _taleemSchoolAsasahAppService = IocManager.Instance.Resolve<ITaleemSchoolAsasahAppService>();
            _taleemSchoolSarmayaAppService = IocManager.Instance.Resolve<ITaleemSchoolSarmayaAppService>();
            _applicationDescripantDeclineStateAppService = IocManager.Instance.Resolve<IApplicationDescripantDeclineStateAppService>();
            _tdsInventoryDetailAppService = tdsInventoryDetailAppService;
            _personalDetailAppService = IocManager.Instance.Resolve<IPersonalDetailAppService>();
            _businessPlanAppService = IocManager.Instance.Resolve<IBusinessPlanAppService>();
            _contactDetailAppService = IocManager.Instance.Resolve<IContactDetailAppService>();
            _businesDetailAppService = IocManager.Instance.Resolve<IBusinessDetailsAppService>();
            _collateralDetailAppService = IocManager.Instance.Resolve<ICollateralDetailAppService>();
            _FilesUploadAppService = IocManager.Instance.Resolve<IFilesUploadAppService>();
            _applicationAppService = IocManager.Instance.Resolve<IApplicationAppService>();
            _IBADataCheckAppService = IocManager.Instance.Resolve<IBADataCheckAppService>();
            _loanEligibilityAppService = IocManager.Instance.Resolve<ILoanEligibilityAppService>();
            _loanAmortizationAppService = IocManager.Instance.Resolve<ILoanAmortizationAppService>();
            _productTypeAppService = IocManager.Instance.Resolve<IProductTypeAppService>();
            _descripentScreenAppService = IocManager.Instance.Resolve<IDescripentScreenAppService>();
            _customRepository = IocManager.Instance.Resolve<ICustomRepository>();
            _notificationSubscriptionManager = IocManager.Instance.Resolve<INotificationSubscriptionManager>();
            _branchDetailAppService = IocManager.Instance.Resolve<BranchDetailAppService>();
            _nonAssociatedIncomeAppService = nonAssociatedIncomeAppService;
            _associatedIncomeAppService = associatedIncomeAppService;
            _branchManagerActionAppService = branchManagerActionAppService;
            _finalWorkflowAppService = finalWorkflowAppService;
            _bccStateAppService = bccStateAppService;
            _mobilizationAppService = mobilizationAppService;
            _env = env;
        }

        public async Task<IActionResult> Dashboard()
        {
            long? userid = _userManager.AbpSession.UserId;
            ViewBag.userid = (int)AbpSession.UserId;
            var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            int? branchId = currentuser.Result.BranchId;
            int branch = Convert.ToInt32(branchId);

            var dashbardList = await _applicationAppService.GetTFCLDashboardCountingData(branch);

            //GETTING MOBILIZATIONS COUNT
            bool admin = false;
            if (User.IsInRole("Admin"))
            {
                admin = true;
            }
            var applications = _applicationAppService.GetApplicationList("", branchId, true, admin);
            var mobilizationList = _mobilizationAppService.GetMobilizationList();
            if (branchId != null && branchId != 0)
            {
                mobilizationList = mobilizationList.Where(x => x.Fk_BranchId == branch).ToList();
            }

            List<GetMobilizationListDto> returnList = new List<GetMobilizationListDto>();

            foreach (var mob in mobilizationList)
            {
                bool exist = false;

                foreach (var apps in applications)
                {
                    if (mob.CNICNo == apps.CNICNo)
                    {
                        exist = true;
                    }
                }

                if (!exist)
                {
                    returnList.Add(mob);
                }
            }

            //GETTING MOBILIZATIONS COUNT

            string dt = DateTime.Now.ToString("yyyy-MM-dd");

            dashbardList.TodayMobilizations = returnList.Where(x => x.CreationTime.ToString("yyyy-MM-dd") == dt).ToList().Count;
            dashbardList.TodayApplications = applications.Where(x => x.AppDate.ToString("yyyy-MM-dd") == dt).ToList().Count;
            dashbardList.TodayMeetingWithClients = returnList.Where(x => x.NextMeeting.ToString("yyyy-MM-dd") == dt).ToList().Count;
            dashbardList.MobilizationCount = returnList.Count;

            return View(dashbardList);
            //return View();
        }

        public IActionResult Analytics()
        {
            return View();
        }

        public IActionResult Timeline(int ApplicationId)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(ApplicationId);
            var productDetail = _productTypeAppService.GetAllList().Where(x => x.Id == applicationDetail.ProductType).SingleOrDefault();

            ViewBag.AppId = applicationDetail.Id;
            ViewBag.ApplicationNo = String.IsNullOrEmpty(applicationDetail.ClientID) ? productDetail.ShortCode + "-" + applicationDetail.ApplicationNumber : applicationDetail.ClientID;

            ViewBag.appStatus = applicationDetail.ScreenStatus;
            ViewBag.appName = applicationDetail.ClientName;
            ViewBag.SchoolName = applicationDetail.SchoolName;


            var branch = _branchDetailAppService.GetBranchDetailById(applicationDetail.FK_branchid);
            if (branch != null)
            {
                ViewBag.branch = branch.BranchName;
            }
            else
            {
                ViewBag.branch = "N/A";
            }

            ViewBag.appDate = applicationDetail.CreationTime.ToString("dd MMM yyyy");


            ViewBag.appTime = applicationDetail.CreationTime.ToString("hh:mm:ss tt");
            var user = _userAppService.GetUserById(applicationDetail.CreatorUserId);
            ViewBag.SDE = user.Result.FullName;






            return View();

        }

        [HttpPost]
        public JsonResult CreateFCMtoken(CreateFcmTokenDto input)
        {

            string response = "";
            try
            {
                _fcmTokenAppService.CreateFcmToken(input);
                response = "Success";
            }
            catch (Exception ex)
            {

            }
            return Json(response);
        }

        [HttpPost]
        public JsonResult getAllNotifications()
        {

            try
            {
                var getNotifications = _notificationLogAppService.GetNotificationLogListByUserId((int)AbpSession.UserId).OrderByDescending(x => x.Id).Take(20).ToList();

                return Json(getNotifications);

            }
            catch (Exception ex)
            {
                return Json("");

            }
        }

        public IActionResult ViewNotifications()
        {

            try
            {
                var getNotifications = _notificationLogAppService.GetNotificationLogListByUserId((int)AbpSession.UserId).OrderByDescending(x => x.Id).ToList();

                return View(getNotifications);

            }
            catch (Exception ex)
            {
                return View();

            }
        }


        [HttpPost]
        public JsonResult markReadNotifications()
        {
            try
            {
                var markRead = _notificationLogAppService.MarkRead((int)AbpSession.UserId);
                return Json(markRead);
            }
            catch (Exception ex)
            {
                return Json("");

            }
        }

        [HttpPost]
        public JsonResult getNotificationsCount()
        {

            try
            {
                var getNotifications = _notificationLogAppService.GetNotificationLogListByUserId((int)AbpSession.UserId).Where(x=>x.isRead==false).Count();
                return Json(getNotifications);

            }
            catch (Exception ex)
            {
                return Json("");

            }
        }
        //[HttpPost]
        //public JsonResult getStateWiseCount()
        //{

        //    try
        //    {
        //        int? branch = Branchid();

        //        if (branch == null)
        //        {
        //            branch = 0;
        //        }

        //        var apps = _applicationAppService.GetTFCLDashboardCountingData((int)branch);

        //        return Json(apps.Result);

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("");

        //    }
        //}

        public int? Branchid()
        {
            long? userid = _userManager.AbpSession.UserId;

            var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            int? branchId = currentuser.Result.BranchId;
            if (branchId == null)
            {
                branchId = 0;
            }
            return branchId;
        }

        [HttpPost]
        public JsonResult ListFinalWorkflows(int ApplicationId)
        {
            String response = "";
            try
            {
                var EarlierAction = _finalWorkflowAppService.GetFinalWorkflowByApplicationId(ApplicationId).OrderByDescending(x => x.Id).ToList();
                if (EarlierAction.Count > 0)
                {
                    foreach (var action in EarlierAction)
                    {
                        var user = _userAppService.GetUserById(action.ActionBy);
                        if (user != null)
                        {
                            action.UserFullName = user.Result.FullName;

                        }
                    }
                    return Json(EarlierAction);
                }
                else
                {
                    return Json(response);
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> HighChartDataWeekly()
        {
            IList<dynamic> chartfinalData = new List<dynamic>();
            try
            {
                var Highchart = await _applicationAppService.GetHighChartWeekData();
                if (Highchart.Count == 0)
                {
                    string[] myArray = new string[0];
                    return Json(myArray);
                }
                var selectedGroupBy = Highchart.GroupBy(m =>
                new
                {

                    m.BranchName,

                }).ToDictionary(n => n.Key, n => n.ToList());

                foreach (var item in selectedGroupBy)
                {
                    var branchfirstweek = item.Value.Where(m => m.WeekNumber == 1).Select(m => m.TotalRecord).DefaultIfEmpty(0).FirstOrDefault();
                    var branchsecondweek = item.Value.Where(m => m.WeekNumber == 2).Select(m => m.TotalRecord).DefaultIfEmpty(0).FirstOrDefault();
                    var branchthirdweek = item.Value.Where(m => m.WeekNumber == 3).Select(m => m.TotalRecord).DefaultIfEmpty(0).FirstOrDefault();
                    var branchfourthweek = item.Value.Where(m => m.WeekNumber == 4).Select(m => m.TotalRecord).DefaultIfEmpty(0).FirstOrDefault();
                    var weekData = new
                    {
                        name = item.Key.BranchName.ToString(),
                        data = new int[] { branchfirstweek, branchsecondweek, branchthirdweek, branchfourthweek }
                    };
                    chartfinalData.Add(weekData);
                }
                return Json(chartfinalData.ToList());
            }
            catch (Exception ex)
            {


            }
            return Json(chartfinalData.ToList());
        }


        [HttpPost]
        public async Task<JsonResult> GetBranchPortfolioGraphData()
        {
            var Highchart = await _applicationAppService.GetBranchPortfolioGraphData();
            var selectedGroupBy = Highchart.GroupBy(m =>
            new
            {

                m.BranchName,

            }).ToDictionary(n => n.Key, n => n.ToList());
            IList<dynamic> chartfinalData = new List<dynamic>();
            foreach (var item in selectedGroupBy)
            {
                var branchfirstweek = item.Value.Select(m => m.TotalRecord).DefaultIfEmpty(0).FirstOrDefault();

                var weekData = new
                {
                    name = item.Key.BranchName.ToString(),
                    data = new int[] { branchfirstweek }
                };
                chartfinalData.Add(weekData);
            }
            return Json(chartfinalData.ToList());
        }


        [HttpPost]
        public async Task<JsonResult> GetPieChartProductWiseAmounts()
        {
            var Highchart = await _applicationAppService.GetProductWiseAmount();



            return Json(Highchart);
        }


        public async Task<JsonResult> GetMonthlyGraphDataa()
        {
            var Highchart = await _applicationAppService.GetMonthlyGraphData();
            var selectedGroupBy = Highchart.GroupBy(m =>
            new
            {

                m.BranchName

            }).ToDictionary(n => n.Key, n => n.ToList());
            IList<dynamic> chartfinalData = new List<dynamic>();
            foreach (var item in selectedGroupBy)
            {
                var january = item.Value.Where(m => m.Months == "January").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var february = item.Value.Where(m => m.Months == "February").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var march = item.Value.Where(m => m.Months == "March").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var april = item.Value.Where(m => m.Months == "April").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var may = item.Value.Where(m => m.Months == "May").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var june = item.Value.Where(m => m.Months == "June").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var july = item.Value.Where(m => m.Months == "July").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var august = item.Value.Where(m => m.Months == "August").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var september = item.Value.Where(m => m.Months == "September").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var octuber = item.Value.Where(m => m.Months == "Octuber").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var november = item.Value.Where(m => m.Months == "November").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();
                var december = item.Value.Where(m => m.Months == "December").Select(m => m.Record).DefaultIfEmpty(0).FirstOrDefault();


                var monthData = new
                {

                    name = item.Key.BranchName.ToString(),
                    data = new int[] { january, february, march, april, may, june, july, august, september, octuber, november, december }
                };
                chartfinalData.Add(monthData);
            }
            return Json(chartfinalData.ToList());
        }

        public IActionResult ViewApplication(int Id)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(Id);
            var productDetail = _productTypeAppService.GetAllList().Where(x => x.Id == applicationDetail.ProductType).SingleOrDefault();

            ViewBag.AppId = applicationDetail.Id;
            ViewBag.ApplicationNo = String.IsNullOrEmpty(applicationDetail.ClientID) ? productDetail.ShortCode + "-" + applicationDetail.ApplicationNumber : applicationDetail.ClientID;

            ViewBag.appStatus = applicationDetail.ScreenStatus;
            ViewBag.appName = applicationDetail.ClientName;
            ViewBag.SchoolName = applicationDetail.SchoolName;


            var branch = _branchDetailAppService.GetBranchDetailById(applicationDetail.FK_branchid);
            if (branch != null)
            {
                ViewBag.branch = branch.BranchName;
            }
            else
            {
                ViewBag.branch = "N/A";
            }

            ViewBag.appDate = applicationDetail.CreationTime.ToString("dd MMM yyyy");


            ViewBag.appTime = applicationDetail.CreationTime.ToString("hh:mm:ss tt");
            var user = _userAppService.GetUserById(applicationDetail.CreatorUserId);
            ViewBag.SDE = user.Result.FullName;




            return View();
        }

        public JsonResult getDisableScreenList(int Id)
        {
            List<string> disabledScreensList = new List<string>();
            if (_businessPlanAppService.CheckBusinessPlanByApplicationId(Id)) { disabledScreensList.Add("LRD"); }

            if (_personalDetailAppService.CheckPersonalDetailByApplicationId(Id)) { disabledScreensList.Add("PD"); }

            if (_contactDetailAppService.CheckContactDetailByApplicationId(Id)) { disabledScreensList.Add("CD"); }

            if (_businesDetailAppService.CheckBusinessDetailByApplicationId(Id)) { disabledScreensList.Add("BD"); }

            if (_collateralDetailAppService.CheckCollateralDetailByApplicationId(Id)) { disabledScreensList.Add("ColD"); }

            if (_exposureDetailAppService.CheckExposureDetailByApplicationId(Id)) { disabledScreensList.Add("ED"); }

            if (_AssetLiabilityAppService.CheckAssetLiabilityDetailByApplicationId(Id)) { disabledScreensList.Add("ALD"); }

            if (_businessIncomeAppService.CheckBusinessIncomeByApplicationId(Id)) { disabledScreensList.Add("BI"); }

            if (_associatedIncomeAppService.CheckAssociatedIncomeDetailByApplicationId(Id)) { disabledScreensList.Add("AI"); }

            if (_nonAssociatedIncomeAppService.CheckNonAssociatedIncomeDetailByApplicationId(Id)) { disabledScreensList.Add("NAI"); }

            if (_businessExpenseAppService.CheckBusinessExpenseByApplicationId(Id)) { disabledScreensList.Add("BE"); }

            if (_householdIncomeAppService.CheckHouseholdIncomeByApplicationId(Id)) { disabledScreensList.Add("HE"); }

            if (_loanEligibilityAppService.CheckLoanEligibilityListByApplicationId(Id)) { disabledScreensList.Add("LE"); }

            if (_bankAccountAppService.CheckBankAccountDetailByApplicationId(Id)) { disabledScreensList.Add("BAD"); }

            if (_coApplicantDetailAppService.CheckCoApplicantDetailByApplicationId(Id)) { disabledScreensList.Add("CoD"); }

            if (_guarantorDetailAppService.CheckGuarantorDetailByApplicationId(Id)) { disabledScreensList.Add("GD"); }

            if (_preferenceAppService.CheckPreferencesByApplicationId(Id)) { disabledScreensList.Add("RD"); }

            if (_FilesUploadAppService.CheckFilesByApplicationId(Id)) { disabledScreensList.Add("FU"); }

            if (_forSDEAppService.CheckForSDEByApplicationId(Id)) { disabledScreensList.Add("SDE"); }

            return Json(disabledScreensList);

        }


        public IActionResult Application(int Id)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(Id);
            var productDetail = _productTypeAppService.GetAllList().Where(x => x.Id == applicationDetail.ProductType).SingleOrDefault();

            ViewBag.AppId = applicationDetail.Id;
            ViewBag.ApplicationNo = String.IsNullOrEmpty(applicationDetail.ClientID) ? productDetail.ShortCode + "-" + applicationDetail.ApplicationNumber : applicationDetail.ClientID;

            ViewBag.appStatus = applicationDetail.ScreenStatus;
            ViewBag.appName = applicationDetail.ClientName;
            ViewBag.SchoolName = applicationDetail.SchoolName;

            //Checking existing Data in Tables Start
            //var isExistLRD = _businessPlanAppService.CheckBusinessPlanByApplicationId(Id);
            if (_businessPlanAppService.CheckBusinessPlanByApplicationId(Id)) { ViewBag.isExistLRD = 1; } else { ViewBag.isExistLRD = 0; }

            //var isExistPD = _personalDetailAppService.GetPersonalDetailByApplicationId(Id);
            if (_personalDetailAppService.CheckPersonalDetailByApplicationId(Id)) { ViewBag.isExistPD = 1; } else { ViewBag.isExistPD = 0; }

            //var isExistCD = _contactDetailAppService.GetContactDetailByApplicationId(Id);
            if (_contactDetailAppService.CheckContactDetailByApplicationId(Id)) { ViewBag.isExistCD = 1; } else { ViewBag.isExistCD = 0; }

            //var isExistBD = _businesDetailAppService.GetBusinessDetailByApplicationId(Id);
            if (_businesDetailAppService.CheckBusinessDetailByApplicationId(Id)) { ViewBag.isExistBD = 1; } else { ViewBag.isExistBD = 0; }

            //var isExistColD = _collateralDetailAppService.GetCollateralDetailByApplicationId(Id);
            if (_collateralDetailAppService.CheckCollateralDetailByApplicationId(Id)) { ViewBag.isExistColD = 1; } else { ViewBag.isExistColD = 0; }

            //var isExistED = _exposureDetailAppService.GetExposureDetailByApplicationId(Id);
            if (_exposureDetailAppService.CheckExposureDetailByApplicationId(Id)) { ViewBag.isExistED = 1; } else { ViewBag.isExistED = 0; }

            //var isExistALD = _AssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(Id);
            if (_AssetLiabilityAppService.CheckAssetLiabilityDetailByApplicationId(Id)) { ViewBag.isExistALD = 1; } else { ViewBag.isExistALD = 0; }

            //ViewBag.isExistBI = 0;
            //var isExistBI = _businessIncomeAppService.GetBusinessIncomeByApplicationId(Id);
            if (_businessIncomeAppService.CheckBusinessIncomeByApplicationId(Id)) { ViewBag.isExistBI = 1; } else { ViewBag.isExistBI = 0; }

            //ViewBag.isExistAI = 0; // Associated Income
            //var isExistAI = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(Id);
            if (_associatedIncomeAppService.CheckAssociatedIncomeDetailByApplicationId(Id)) { ViewBag.isExistAI = 1; } else { ViewBag.isExistAI = 0; }

            //ViewBag.isExistNAI = 0; // Non Associated Income
            //var isExistNAI = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(Id);
            if (_nonAssociatedIncomeAppService.CheckNonAssociatedIncomeDetailByApplicationId(Id)) { ViewBag.isExistNAI = 1; } else { ViewBag.isExistNAI = 0; }

            //ViewBag.isExistGTI = 0; // Gross Total Income
            //var isExistAI;//_A.GetContactDetailByApplicationId(Id);
            //if (isExistAI.Result != null) { ViewBag.isExistAI = 1; } else { ViewBag.isExistAI = 0; }

            //ViewBag.isExistBE = 0;

            //var isExistBE = _businessExpenseAppService.GetBusinessExpenseByApplicationId(Id);
            if (_businessExpenseAppService.CheckBusinessExpenseByApplicationId(Id)) { ViewBag.isExistBE = 1; } else { ViewBag.isExistBE = 0; }

            //var isExistHHIE = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(Id);
            if (_householdIncomeAppService.CheckHouseholdIncomeByApplicationId(Id)) { ViewBag.isExistHHIE = 1; } else { ViewBag.isExistHHIE = 0; }

            //ViewBag.isExistLO = 0;
            //var isExistLO = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(Id);
            if (_loanEligibilityAppService.CheckLoanEligibilityListByApplicationId(Id)) { ViewBag.isExistLO = 1; } else { ViewBag.isExistLO = 0; }

            //ViewBag.isExistBAD = 0;
            //var isExistBAD = _bankAccountAppService.GetBankAccountDetailByApplicationId(Id);
            if (_bankAccountAppService.CheckBankAccountDetailByApplicationId(Id)) { ViewBag.isExistBAD = 1; } else { ViewBag.isExistBAD = 0; }

            //ViewBag.isExistCAD = 0;
            //var isExistCAD = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(Id);
            if (_coApplicantDetailAppService.CheckCoApplicantDetailByApplicationId(Id)) { ViewBag.isExistCAD = 1; } else { ViewBag.isExistCAD = 0; }

            //ViewBag.isExistGD = 0;
            //var isExistGD = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(Id);
            if (_guarantorDetailAppService.CheckGuarantorDetailByApplicationId(Id)) { ViewBag.isExistGD = 1; } else { ViewBag.isExistGD = 0; }

            //ViewBag.isExistRD = 0;
            //var isExistRD = _preferenceAppService.GetPreferencesByApplicationId(Id);
            if (_preferenceAppService.CheckPreferencesByApplicationId(Id)) { ViewBag.isExistRD = 1; } else { ViewBag.isExistRD = 0; }

            //ViewBag.isExistUD = 0;
            //var isExistUD = _FilesUploadAppService.GetFilesByApplicationId(Id);
            if (_FilesUploadAppService.CheckFilesByApplicationId(Id)) { ViewBag.isExistUD = 1; } else { ViewBag.isExistUD = 0; }

            //ViewBag.isExistSR = 0;
            //var isExistSR = _forSDEAppService.GetForSDEByApplicationId(Id);
            if (_forSDEAppService.CheckForSDEByApplicationId(Id)) { ViewBag.isExistSR = 1; } else { ViewBag.isExistSR = 0; }



            //Checking existing Data in Tables END




            var branch = _branchDetailAppService.GetBranchDetailById(applicationDetail.FK_branchid);
            if (branch != null)
            {
                ViewBag.branch = branch.BranchName;
            }
            else
            {
                ViewBag.branch = "N/A";
            }

            ViewBag.appDate = applicationDetail.CreationTime.ToString("dd MMM yyyy");


            ViewBag.appTime = applicationDetail.CreationTime.ToString("hh:mm:ss tt");
            var user = _userAppService.GetUserById(applicationDetail.CreatorUserId);
            ViewBag.SDE = user.Result.FullName;




            return View();
        }
        public IActionResult TDSApplication(int Id)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(Id);
            var productDetail = _productTypeAppService.GetAllList().Where(x => x.Id == applicationDetail.ProductType).SingleOrDefault();

            ViewBag.AppId = applicationDetail.Id;
            ViewBag.ApplicationNo = String.IsNullOrEmpty(applicationDetail.ClientID) ? productDetail.ShortCode + "-" + applicationDetail.ApplicationNumber : applicationDetail.ClientID;

            ViewBag.appStatus = applicationDetail.ScreenStatus;
            ViewBag.appName = applicationDetail.ClientName;
            ViewBag.SchoolName = applicationDetail.SchoolName;
            //Checking existing Data in Tables Start
            //var isExistLRD = _businessPlanAppService.CheckBusinessPlanByApplicationId(Id);
            if (_businessPlanAppService.CheckBusinessPlanByApplicationId(Id)) { ViewBag.isExistLRD = 1; } else { ViewBag.isExistLRD = 0; }

            //var isExistPD = _personalDetailAppService.GetPersonalDetailByApplicationId(Id);
            if (_personalDetailAppService.CheckPersonalDetailByApplicationId(Id)) { ViewBag.isExistPD = 1; } else { ViewBag.isExistPD = 0; }

            if (_dependentEducationDetailsAppService.CheckDependentEducationDetailByApplicationId(Id)) { ViewBag.isExistDeD = 1; } else { ViewBag.isExistDeD = 0; }
            //var isExistCD = _contactDetailAppService.GetContactDetailByApplicationId(Id);
            if (_contactDetailAppService.CheckContactDetailByApplicationId(Id)) { ViewBag.isExistCD = 1; } else { ViewBag.isExistCD = 0; }

            //var isExistBD = _businesDetailAppService.GetBusinessDetailByApplicationId(Id);
            if (_businesDetailAppService.CheckBusinessDetailByApplicationId(Id)) { ViewBag.isExistBD = 1; } else { if (_businessDetailsTDSAppService.CheckBusinessDetailTDSByApplicationId(Id)) { ViewBag.isExistBD = 1; } else { ViewBag.isExistBD = 0; } }

            //var isExistColD = _collateralDetailAppService.GetCollateralDetailByApplicationId(Id);
            if (_collateralDetailAppService.CheckCollateralDetailByApplicationId(Id)) { ViewBag.isExistColD = 1; } else { ViewBag.isExistColD = 0; }

            //var isExistED = _exposureDetailAppService.GetExposureDetailByApplicationId(Id);
            if (_exposureDetailAppService.CheckExposureDetailByApplicationId(Id)) { ViewBag.isExistED = 1; } else { ViewBag.isExistED = 0; }

            //var isExistALD = _AssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(Id);
            if (_AssetLiabilityAppService.CheckAssetLiabilityDetailByApplicationId(Id)) { ViewBag.isExistALD = 1; } else { ViewBag.isExistALD = 0; }

            if (_tdsInventoryDetailAppService.CheckTdsInventoryDetailDetailByApplicationId(Id)) { ViewBag.isExistID = 1; } else { ViewBag.isExistID = 0; }
            //ViewBag.isExistBI = 0;
            //var isExistBI = _businessIncomeAppService.GetBusinessIncomeByApplicationId(Id);
            if (_businessIncomeAppService.CheckBusinessIncomeByApplicationId(Id)) { ViewBag.isExistBI = 1; } else { ViewBag.isExistBI = 0; }

            //ViewBag.isExistAI = 0; // Associated Income
            //var isExistAI = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(Id);
            if (_associatedIncomeAppService.CheckAssociatedIncomeDetailByApplicationId(Id)) { ViewBag.isExistAI = 1; } else { ViewBag.isExistAI = 0; }

            //ViewBag.isExistNAI = 0; // Non Associated Income
            //var isExistNAI = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(Id);
            if (_nonAssociatedIncomeAppService.CheckNonAssociatedIncomeDetailByApplicationId(Id)) { ViewBag.isExistNAI = 1; } else { ViewBag.isExistNAI = 0; }

            //ViewBag.isExistGTI = 0; // Gross Total Income
            if (_salesDetailAppService.CheckSalesDetailByApplicationId(Id)) { ViewBag.isExistSD = 1; } else { ViewBag.isExistSD = 0; }
            //var isExistAI;//_A.GetContactDetailByApplicationId(Id);
            if (_purchaseDetailAppService.CheckPurchaseDetailByApplicationId(Id)) { ViewBag.isExistPurD = 1; } else { ViewBag.isExistPurD = 0; }
            //if (isExistAI.Result != null) { ViewBag.isExistAI = 1; } else { ViewBag.isExistAI = 0; }

            //ViewBag.isExistBE = 0;

            //var isExistBE = _businessExpenseAppService.GetBusinessExpenseByApplicationId(Id);
            if (_businessExpenseAppService.CheckBusinessExpenseByApplicationId(Id)) { ViewBag.isExistBE = 1; } else { if (_tDSBusinessExpenseAppService.CheckTDSBusinessExpenseByApplicationId(Id)) { ViewBag.isExistBE = 1; } else { ViewBag.isExistBE = 0; } }

            //var isExistHHIE = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(Id);
            if (_householdIncomeAppService.CheckHouseholdIncomeByApplicationId(Id)) { ViewBag.isExistHHIE = 1; } else { ViewBag.isExistHHIE = 0; }

            //ViewBag.isExistLO = 0;
            //var isExistLO = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(Id);
            if (_loanEligibilityAppService.CheckLoanEligibilityListByApplicationId(Id)) { ViewBag.isExistLO = 1; } else { if (_tDSLoanEligibilityAppService.CheckTDSLoanEligibilityListByApplicationId(Id)) { ViewBag.isExistLO = 1; } else { ViewBag.isExistLO = 0; } }

            //ViewBag.isExistBAD = 0;
            //var isExistBAD = _bankAccountAppService.GetBankAccountDetailByApplicationId(Id);
            if (_bankAccountAppService.CheckBankAccountDetailByApplicationId(Id)) { ViewBag.isExistBAD = 1; } else { ViewBag.isExistBAD = 0; }

            //ViewBag.isExistCAD = 0;
            //var isExistCAD = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(Id);
            if (_coApplicantDetailAppService.CheckCoApplicantDetailByApplicationId(Id)) { ViewBag.isExistCAD = 1; } else { ViewBag.isExistCAD = 0; }

            //ViewBag.isExistGD = 0;
            //var isExistGD = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(Id);
            if (_guarantorDetailAppService.CheckGuarantorDetailByApplicationId(Id)) { ViewBag.isExistGD = 1; } else { ViewBag.isExistGD = 0; }

            //ViewBag.isExistRD = 0;
            //var isExistRD = _preferenceAppService.GetPreferencesByApplicationId(Id);
            if (_preferenceAppService.CheckPreferencesByApplicationId(Id)) { ViewBag.isExistRD = 1; } else { ViewBag.isExistRD = 0; }

            //ViewBag.isExistUD = 0;
            //var isExistUD = _FilesUploadAppService.GetFilesByApplicationId(Id);
            if (_FilesUploadAppService.CheckFilesByApplicationId(Id)) { ViewBag.isExistUD = 1; } else { ViewBag.isExistUD = 0; }

            //ViewBag.isExistSR = 0;
            //var isExistSR = _forSDEAppService.GetForSDEByApplicationId(Id);
            if (_forSDEAppService.CheckForSDEByApplicationId(Id)) { ViewBag.isExistSR = 1; } else { ViewBag.isExistSR = 0; }



            //Checking existing Data in Tables END




            var branch = _branchDetailAppService.GetBranchDetailById(applicationDetail.FK_branchid);
            if (branch != null)
            {
                ViewBag.branch = branch.BranchName;
            }
            else
            {
                ViewBag.branch = "N/A";
            }

            ViewBag.appDate = applicationDetail.CreationTime.ToString("dd MMM yyyy");


            ViewBag.appTime = applicationDetail.CreationTime.ToString("hh:mm:ss tt");
            var user = _userAppService.GetUserById(applicationDetail.CreatorUserId);
            ViewBag.SDE = user.Result.FullName;




            return View();
        }
        [AbpMvcAuthorize(PermissionNames.Pages_BM)]
        public ActionResult GetRoles()
        {
            return RedirectToAction("Index", "Roles");
        }
        [AbpMvcAuthorize(PermissionNames.Pages_Users)]
        public ActionResult GetUsers()
        {
            return RedirectToAction("Index", "Users");

        }
        [HttpPost]
        public IActionResult ReturnPartialView(string viewName, int ApplicationId)
        {
            if (ApplicationId > 0)
            {
                var applicationData = _applicationAppService.GetApplicationById(ApplicationId);


                if (viewName == "PERSONAL DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.PersonalAction = Actions.ActionType;
                        }
                    }
                    else
                    {

                        ViewBag.PersonalAction = "Hide";
                    }

                    var data = _personalDetailAppService.GetPersonalDetailByApplicationId(ApplicationId);
                    var fileUploads = _FilesUploadAppService.GetFilesByApplicationId(ApplicationId);
                    if (fileUploads != null)
                    {
                        var ApplicantPic = fileUploads.Where(x => x.ScreenCode == "applicant_photo").LastOrDefault();
                        if (ApplicantPic != null)
                        {
                            ViewBag.ApplicantPicUrl = ApplicantPic.BaseUrl;
                        }
                        else
                        {
                            ViewBag.ApplicantPicUrl = "";

                        }
                    }
                    else
                    {
                        ViewBag.ApplicantPicUrl = "";

                    }
                    //var currentApp = _applicationAppService.GetApplicationByApplicationId(ApplicationId);
                    //var IsVo = User.IsInRole("VO");
                    //var IsBm = User.IsInRole("BM");
                    //if (IsBm)
                    //{
                    //    if (currentApp.ScreenStatus == ApplicationState.VO_Verified)
                    //    {
                    //        ///change application state to  bm screening
                    //        _applicationAppService.ChangeApplicationState(ApplicationState.Screening, ApplicationId, "");
                    //    }
                    //}
                    //else if (IsVo)
                    //{
                    //    if (currentApp.ScreenStatus == ApplicationState.Submitted)
                    //    {
                    //        ///change application state to  verifcation
                    //        _applicationAppService.ChangeApplicationState(ApplicationState.Verification, ApplicationId, "");
                    //    }
                    //}
                    return PartialView("_personaldetails", data.Result);
                }
                else if (viewName == "DEPENDENTS EDUCATION DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.DependentAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.DependentAction = "Hide";
                    }
                    var data = _dependentEducationDetailsAppService.GetDependentEducationDetailByApplicationId(ApplicationId);
                    return PartialView("_dependentsEducationDetails", data.Result);
                }
                else if (viewName == "CONTACT DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.ContactAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.ContactAction = "Hide";
                    }
                    var data = _contactDetailAppService.GetContactDetailByApplicationId(ApplicationId);
                    return PartialView("_contactdetails", data.Result);
                }
                else if (viewName == "OTHER DETAILS")
                {
                    var data = _otherDetailAppService.GetOtherDetailByApplicationId(ApplicationId);
                    return PartialView("_otherdetails", data.Result);
                }
                else if (viewName == "BANK ACCOUNT DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.BankAccountDetailAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.BankAccountDetailAction = "Hide";
                    }
                    var data = _bankAccountAppService.GetBankAccountDetailByApplicationId(ApplicationId);
                    return PartialView("_bankAcDetails", data.Result);
                }
                else if (viewName == "EXPOSURE DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.ExposureAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.ExposureAction = "Hide";
                    }

                    var data = _exposureDetailAppService.GetExposureDetailByApplicationId(ApplicationId);
                    return PartialView("_exposuredetails", data.Result);
                }
                else if (viewName == "INVENTORY DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.InventoryAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.InventoryAction = "Hide";
                    }

                    var data = _tdsInventoryDetailAppService.GetTdsInventoryDetailDetailByApplicationId(ApplicationId);
                    return PartialView("_inventoryDetails", data.Result);
                }
                else if (viewName == "SALES DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.SalesAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.SalesAction = "Hide";
                    }
                    var data = _salesDetailAppService.GetSalesDetailByApplicationId(ApplicationId);
                    //var abc = data.businessChlid.Select(x => x.ClassName).FirstOrDefault();
                    return PartialView("_salesDetails", data.Result);
                }
                else if (viewName == "BUSINESS INCOME")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.BusinessIncomeAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.BusinessIncomeAction = "Hide";
                    }

                    var data = _businessIncomeAppService.GetBusinessIncomeByApplicationId(ApplicationId);
                    //var abc = data.businessChlid.Select(x => x.ClassName).FirstOrDefault();
                    return PartialView("_businessIncome", data);
                }
                else if (viewName == "PURCHASE DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.PurchaseAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.PurchaseAction = "Hide";
                    }

                    var data = _purchaseDetailAppService.GetPurchaseDetailByApplicationId(ApplicationId);

                    return PartialView("_purchaseDetails", data.Result);
                }
                else if (viewName == "BUSINESS EXPENSES")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.BusinessExpenseAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.BusinessExpenseAction = "Hide";
                    }

                    if (applicationData.ProductType == 8 || applicationData.ProductType == 9)
                    {
                        var data = _tDSBusinessExpenseAppService.GetTDSBusinessExpenseByApplicationId(ApplicationId);
                        return PartialView("_businessExpensesTds", data.Result);
                    }
                    else
                    {
                        var data = _businessExpenseAppService.GetBusinessExpenseByApplicationId(ApplicationId);

                        return PartialView("_businessExpenses", data.Result);
                    }
                }
                else if (viewName == "NON ASSOCIATED INCOME" || viewName == "OTHER INCOME DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.NonAssociatedAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.NonAssociatedAction = "Hide";
                    }

                    if (viewName == "NON ASSOCIATED INCOME")
                    {
                        ViewBag.FieldName = "TOTAL NON ASSOCIATED INCOME";
                    }
                    else if (viewName == "OTHER INCOME DETAILS")
                    {
                        ViewBag.FieldName = "TOTAL OTHER INCOME";
                    }

                    var data = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(ApplicationId);
                    return PartialView("_nonAssociatedIncome", data);
                }
                else if (viewName == "ASSOCIATED INCOME")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.ASSOCIATEDINCOMEAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.ASSOCIATEDINCOMEAction = "Hide";
                    }

                    var data = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(ApplicationId);
                    return PartialView("_AssociatedIncome", data);
                }
                else if (viewName == "HOUSEHOLD EXPENSES")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.HouseholdExpenseAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.HouseholdExpenseAction = "Hide";
                    }

                    var data = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(ApplicationId);
                    return PartialView("_montlyhouseholdIncome", data);
                }
                else if (viewName == "CO-APPLICANT DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.CoApplicantDetailAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.CoApplicantDetailAction = "Hide";
                    }

                    var data = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(ApplicationId);

                    var fileUploads = _FilesUploadAppService.GetFilesByApplicationId(ApplicationId).Where(x => x.ScreenCode == "co_applicant_photo");
                    if (fileUploads != null && data.Result.Count != 0)
                    {
                        foreach (var fileUpload in fileUploads)
                        {
                            var coapplicant = data.Result.Where(x => x.Id == fileUpload.Fk_idForName).SingleOrDefault();
                            if (coapplicant != null)
                            {
                                coapplicant.imageUrl = fileUpload.BaseUrl;
                            }
                        }

                    }
                    ViewBag.ApplicationId = ApplicationId;

                    return PartialView("_coapplicantdetails", data.Result);
                }
                else if (viewName == "GUARANTOR DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.GuarantorDetailAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.GuarantorDetailAction = "Hide";
                    }

                    var data = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(ApplicationId);

                    var fileUploads = _FilesUploadAppService.GetFilesByApplicationId(ApplicationId).Where(x => x.ScreenCode == "guarantor_photo");
                    if (fileUploads != null && data.Result.Count != 0)
                    {
                        foreach (var fileUpload in fileUploads)
                        {
                            var guarantor = data.Result.Where(x => x.Id == fileUpload.Fk_idForName).SingleOrDefault();
                            if (guarantor != null)
                            {
                                guarantor.imageUrl = fileUpload.BaseUrl;
                            }
                        }
                    }
                    ViewBag.ApplicationId = ApplicationId;

                    return PartialView("_guarantordetails", data.Result);
                }
                else if (viewName == "SDE RECOMMENDATIONS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.SDEAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.SDEAction = "Hide";
                    }

                    var data = _forSDEAppService.GetForSDEByApplicationId(ApplicationId);
                    return PartialView("_forSde", data.Result);
                }
                else if (viewName == "REFERENCES DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.ReferenceDetailAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.ReferenceDetailAction = "Hide";
                    }

                    var data = _preferenceAppService.GetPreferencesByApplicationId(ApplicationId);
                    return PartialView("_references", data.Result);
                }
                else if (viewName == "ASSET LIABILITY DETAILS")
                {

                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.AssetLiabilityAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.AssetLiabilityAction = "Hide";
                    }

                    var data = _AssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(ApplicationId);
                    return PartialView("_AssetLiablity", data.Result);
                }
                else if (viewName == "LOAN REQUISITION DETAILS")
                {
                    var data = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId);

                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.businessPlanAction = Actions.ActionType;
                        }

                    }
                    else
                    {
                        ViewBag.businessPlanAction = "Hide";
                    }

                    ViewBag.productId = applicationData.ProductType;

                    return PartialView("_businessPlan", data.Result);
                }
                else if (viewName == "BUSINESS DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.BusinessDetailAction = Actions.ActionType;
                        }
                    }
                    else
                    {

                        ViewBag.BusinessDetailAction = "Hide";
                    }

                    if (applicationData.ProductType == 8 || applicationData.ProductType == 9)
                    {
                        var data = _businessDetailsTDSAppService.GetBusinessDetailTDSByApplicationId(ApplicationId);
                        return PartialView("_businessDetailsTds", data.Result);
                    }
                    else
                    {
                        var data = _businesDetailAppService.GetBusinessDetailByApplicationId(ApplicationId);
                        return PartialView("_businessDetails", data.Result);
                    }


                }
                else if (viewName == "COLLATERAL DETAILS")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.CollateralDetailAction = Actions.ActionType;
                        }
                    }
                    else
                    {

                        ViewBag.CollateralDetailAction = "Hide";
                    }

                    var data = _collateralDetailAppService.GetCollateralDetailByApplicationId(ApplicationId);
                    return PartialView("_collateralValuationDetails", data.Result);
                }
                else if (viewName == "Uploaded Documents")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.UploadedDocumentsAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.UploadedDocumentsAction = "Hide";
                    }

                    var data = _FilesUploadAppService.GetFilesByApplicationId(ApplicationId);
                    //return RedirectToAction("DocumentUpload");
                    return PartialView("_attachDocuments", data);
                }
                else if (viewName == "LOAN ELIGIBILITY")
                {
                    if (applicationData.ScreenStatus == ApplicationState.Submitted)
                    {
                        var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == viewName.Replace(" ", "").ToLower()).FirstOrDefault();

                        if (Actions != null)
                        {
                            ViewBag.LoanEligibiltyAction = Actions.ActionType;
                        }
                    }
                    else
                    {
                        ViewBag.LoanEligibiltyAction = "Hide";
                    }
                    if (applicationData.ProductType == 8 || applicationData.ProductType == 9)
                    {
                        var data = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(ApplicationId);
                        return PartialView("_loaneligibilityTds", data.Result);
                    }
                    else
                    {
                        var data = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId);
                        //return RedirectToAction("DocumentUpload");
                        return PartialView("_loaneligibility", data.Result);
                    }

                }

                else
                    return PartialView(null);

            }
            else
                return PartialView(null);

        }

        [HttpPost]
        public JsonResult MarkScreened(int ApplicationId, string Screen)
        {
            String response = "";
            try
            {
                var EarlierAction = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.isReSubmitted == false && x.ScreenName == Screen.Replace(" ", "").ToLower() && x.ActionType == "Discrepent").FirstOrDefault();
                if (EarlierAction != null)
                {
                    _branchManagerActionAppService.DeleteBranchManagerAction(EarlierAction);
                }

                var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == Screen.Replace(" ", "").ToLower() && x.ActionType == "Screened").ToList();
                if (Actions.Count == 0)
                {
                    CreateBranchManagerActionDto input = new CreateBranchManagerActionDto();
                    input.ActionType = "Screened";
                    input.ApplicationId = ApplicationId;
                    input.ScreenName = Screen.Replace(" ", "").ToLower();
                    input.isActive = false;
                    input.isReSubmitted = true;

                    var result = _branchManagerActionAppService.CreateBranchManagerAction(input);
                    response = Screen + " has been screened successfully";
                }
                else
                {
                    response = Screen + " is already screened.";
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }


        public IActionResult DeclineApplication(int ApplicationId)
        {
            CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
            fWobj.ApplicationId = ApplicationId;
            fWobj.Action = "Decline";
            fWobj.ActionBy = (int)AbpSession.UserId;
            fWobj.ApplicationState = ApplicationState.Decline;
            fWobj.isActive = true;

            _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

            _applicationAppService.ChangeApplicationState(ApplicationState.Decline, ApplicationId, "Decline");

            return RedirectToAction("Applications", "Application");
        }

        [HttpPost]
        public JsonResult MarkDiscrepent(int ApplicationId, string Screen, string Reason)
        {
            String response = "";
            try
            {
                var EarlierAction = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.ScreenName == Screen.Replace(" ", "").ToLower() && x.ActionType == "Screened").FirstOrDefault();
                if (EarlierAction != null)
                {
                    _branchManagerActionAppService.DeleteBranchManagerAction(EarlierAction);
                }
                var Actions = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.isReSubmitted == false && x.ScreenName == Screen.Replace(" ", "").ToLower() && x.ActionType == "Discrepent").ToList();
                if (Actions.Count == 0)
                {
                    CreateBranchManagerActionDto input = new CreateBranchManagerActionDto();
                    input.ActionType = "Discrepent";
                    input.ApplicationId = ApplicationId;
                    input.ScreenName = Screen.Replace(" ", "").ToLower();
                    input.isActive = false;
                    input.isReSubmitted = false;
                    input.Reason = Reason;

                    var result = _branchManagerActionAppService.CreateBranchManagerAction(input);
                    response = Screen + " has been discrepented successfully";
                }
                else
                {
                    response = Screen + " is already discrepented.";
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public JsonResult getFormWiseStatus(int ApplicationId)
        {
            String response = "";
            try
            {
                var EarlierAction = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false).ToList();
                if (EarlierAction.Count > 0)
                {
                    return Json(EarlierAction);
                }
                else
                {
                    return Json(response);
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public JsonResult ListDiscrepencies(int ApplicationId)
        {
            String response = "";
            try
            {
                var EarlierAction = _branchManagerActionAppService.getDiscrepentedForms(ApplicationId).ToList();
                if (EarlierAction.Count > 0)
                {
                    return Json(EarlierAction);
                }
                else
                {
                    return Json(response);
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> PushDiscrepentFormsToSDE(int ApplicationId)
        {
            String response = "";
            try
            {
                var EarlierAction = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.isReSubmitted == false).ToList();
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
                        obj.isReSubmitted = false;
                        var update = _branchManagerActionAppService.UpdateBranchManagerAction(obj);
                    }

                    // var workFlow = _applicationAppService.UserInRole(WorkFlowState.BM);
                    CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                    fWobj.ApplicationId = ApplicationId;
                    fWobj.Action = "Discrepented By BM";
                    fWobj.ActionBy = (int)AbpSession.UserId;
                    fWobj.ApplicationState = ApplicationState.Discrepent;
                    fWobj.isActive = true;

                    await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                    response = "Application has been Discrepented Successfully!";
                    _applicationAppService.ChangeApplicationState(ApplicationState.Discrepent, ApplicationId, "Discrepented By BM");

                    var appData = _applicationAppService.GetApplicationById(ApplicationId);
                    _notificationLogAppService.SendNotification((int)appData.CreatorUserId, appData.ClientID + " has been Discrepented by the Branch Manger", "Branch Manger has Discrepented the Application " + appData.ClientID);



                    return Json(response);
                }
                else
                {
                    return Json(response);
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> PushToBCC(int ApplicationId)
        {
            String response = "";
            try
            {
                var EarlierAction = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(ApplicationId).Where(x => x.isActive == false && x.isReSubmitted == false).ToList();
                if (EarlierAction.Count > 0)
                {
                    response = "Some Discrepencies found in the Application!";
                    return Json(response);
                }
                else
                {


                    //var workFlow = _applicationAppService.UserInRole(WorkFlowState.BM);
                    CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                    fWobj.ApplicationId = ApplicationId;
                    fWobj.Action = "Sent to Branch Credit Committee";
                    fWobj.ActionBy = (int)AbpSession.UserId;
                    fWobj.ApplicationState = ApplicationState.Screened;
                    fWobj.isActive = true;

                    _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                    response = "Application has been Sent to Branch Credit Committee Successfully!";
                    _applicationAppService.ChangeApplicationStateAsync(ApplicationState.Screened, ApplicationId, "Screened By BM");

                    var appData = _applicationAppService.GetApplicationById(ApplicationId);
                    _notificationLogAppService.SendNotification((int)appData.CreatorUserId, appData.ClientID + " has been Screened by the Branch Manger", "Branch Manger has screened the application " + appData.ClientID);



                    var getMCRC = _mcrcStateAppService.GetMcrcStateListByApplicationId(ApplicationId).Result;
                    if (getMCRC.Count > 0)
                    {

                        var getMcrcDecision = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                        if (getMcrcDecision != null)
                        {

                            if (getMcrcDecision.Decision == "Discrepent")
                            {
                                var getBCC = _bccStateAppService.GetBccStateListByApplicationId(ApplicationId).Result;
                                if (getBCC != null)
                                {
                                    var userIdGroupByList = getBCC.GroupBy(x => x.Fk_UserId);

                                    foreach (var bcc in userIdGroupByList)
                                    {
                                        CreateBccStateDto createBccUser1Dto = new CreateBccStateDto();
                                        createBccUser1Dto.ApplicationId = ApplicationId;
                                        createBccUser1Dto.Fk_BccId = getBCC[0].Fk_BccId;
                                        createBccUser1Dto.Fk_UserId = bcc.Key;
                                        createBccUser1Dto.Status = "Active";
                                        _bccStateAppService.CreateBccStateDetail(createBccUser1Dto);
                                    }

                                    CreateFinalWorkflowDto fWobj2 = new CreateFinalWorkflowDto();
                                    fWobj2.ApplicationId = ApplicationId;
                                    fWobj2.Action = "Under BCC Review";
                                    fWobj2.ActionBy = (int)AbpSession.UserId;
                                    fWobj2.ApplicationState = ApplicationState.BCCReview;
                                    fWobj2.isActive = true;

                                    _finalWorkflowAppService.CreateFinalWorkflow(fWobj2);

                                    _applicationAppService.ChangeApplicationStateAsync(ApplicationState.BCCReview, ApplicationId, "Under BCC Review");

                                    response = "Application has been Sent to BCC-" + getBCC[0].Fk_BccId + " Successfully!";
                                }


                            }
                            else if (getMcrcDecision.Decision == "Discrepent & Represent")
                            {
                                var userIdGroupByList = getMCRC.GroupBy(x => x.Fk_UserId);

                                foreach (var mcrc in userIdGroupByList) // Calls multiple times 2nd time
                                {

                                    CreateMcrcStateDto createMCRCUserDto = new CreateMcrcStateDto();
                                    createMCRCUserDto.ApplicationId = ApplicationId;
                                    createMCRCUserDto.Fk_McrcId = getMCRC[0].Fk_McrcId;
                                    createMCRCUserDto.Fk_UserId = (int)mcrc.Key;
                                    createMCRCUserDto.Status = "Active";
                                    _mcrcStateAppService.CreateMcrcStateDetail(createMCRCUserDto);
                                }

                                CreateFinalWorkflowDto fWobj2 = new CreateFinalWorkflowDto();
                                fWobj2.ApplicationId = ApplicationId;
                                fWobj2.Action = "Under MCRC Review";
                                fWobj2.ActionBy = (int)AbpSession.UserId;
                                fWobj2.ApplicationState = ApplicationState.MCRCCreated;
                                fWobj2.isActive = true;

                                _finalWorkflowAppService.CreateFinalWorkflow(fWobj2);

                                _applicationAppService.ChangeApplicationStateAsync(ApplicationState.MCRCCreated, ApplicationId, "Under MCRC Review");
                                response = "Application has been Sent to MCRC-" + getMCRC[0].Fk_McrcId + " Successfully!";

                            }

                        }
                        else
                        {
                            var getBCC = _bccStateAppService.GetBccStateListByApplicationId(ApplicationId).Result;
                            if (getBCC != null)
                            {
                                var userIdGroupByList = getBCC.GroupBy(x => x.Fk_UserId);

                                foreach (var bcc in userIdGroupByList)
                                {
                                    CreateBccStateDto createBccUser1Dto = new CreateBccStateDto();
                                    createBccUser1Dto.ApplicationId = ApplicationId;
                                    createBccUser1Dto.Fk_BccId = getBCC[0].Fk_BccId;
                                    createBccUser1Dto.Fk_UserId = bcc.Key;
                                    createBccUser1Dto.Status = "Active";
                                    _bccStateAppService.CreateBccStateDetail(createBccUser1Dto);
                                }

                                CreateFinalWorkflowDto fWobj2 = new CreateFinalWorkflowDto();
                                fWobj2.ApplicationId = ApplicationId;
                                fWobj2.Action = "Under BCC Review";
                                fWobj2.ActionBy = (int)AbpSession.UserId;
                                fWobj2.ApplicationState = ApplicationState.BCCReview;
                                fWobj2.isActive = true;

                                _finalWorkflowAppService.CreateFinalWorkflow(fWobj2);

                                _applicationAppService.ChangeApplicationState(ApplicationState.BCCReview, ApplicationId, "Under BCC Review");

                                response = "Application has been Sent to BCC-" + getBCC[0].Fk_BccId + " Successfully!";
                            }
                        }
                    }
                    else
                    {

                        var getBCC = _bccStateAppService.GetBccStateListByApplicationId(ApplicationId).Result;
                        if (getBCC.Count > 0)
                        {
                            var userIdGroupByList = getBCC.GroupBy(x => x.Fk_UserId);


                            foreach (var bcc in userIdGroupByList)
                            {
                                CreateBccStateDto createBccUser1Dto = new CreateBccStateDto();
                                createBccUser1Dto.ApplicationId = ApplicationId;
                                createBccUser1Dto.Fk_BccId = getBCC[0].Fk_BccId;
                                createBccUser1Dto.Fk_UserId = (int)bcc.Key;
                                createBccUser1Dto.Status = "Active";
                                _bccStateAppService.CreateBccStateDetail(createBccUser1Dto);
                            }

                            CreateFinalWorkflowDto fWobj2 = new CreateFinalWorkflowDto();
                            fWobj2.ApplicationId = ApplicationId;
                            fWobj2.Action = "Under BCC Review";
                            fWobj2.ActionBy = (int)AbpSession.UserId;
                            fWobj2.ApplicationState = ApplicationState.BCCReview;
                            fWobj2.isActive = true;

                            _finalWorkflowAppService.CreateFinalWorkflow(fWobj2);

                            _applicationAppService.ChangeApplicationState(ApplicationState.BCCReview, ApplicationId, "Under BCC Review");

                            response = "Application has been Sent to BCC-" + getBCC[0].Fk_BccId + " Successfully!";

                            _notificationLogAppService.SendNotification((int)appData.CreatorUserId, appData.ClientID + " has been Screened by the Branch Manger", "Branch Manger has screened the application " + appData.ClientID);


                        }


                    }

                    return Json(response);
                }

            }
            catch (Exception ex)
            {
                _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, ApplicationId, "Reverted to Submitted.");

                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }


        public IActionResult BADocumentsList()
        {
            long? userid = _userManager.AbpSession.UserId;

            var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            int? branchId = currentuser.Result.BranchId;
            if (branchId == null)
            {
                branchId = 0;
            }
            var mobilizationList = _applicationAppService.GetApplicationList(ApplicationState.InProcess, branchId);
            var mobilizationListCreated = _applicationAppService.GetApplicationList(ApplicationState.Created, branchId);
            var mobilizationListSubmitted = _applicationAppService.GetApplicationList(ApplicationState.Submitted, branchId);

            mobilizationList.AddRange(mobilizationListCreated);
            mobilizationList.AddRange(mobilizationListSubmitted);

            return View(mobilizationList.OrderByDescending(x => x.AppDate).ToList());
        }

        [DisableValidation]
        public IActionResult ApplicationReport(int ApplicationId)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.Application = applicationDetail;
            var user = _userAppService.GetUserById(applicationDetail.CreatorUserId);
            ViewBag.SDEName = user.Result.FullName;
            ViewBag.appDate = applicationDetail.CreationTime.ToString("dd MMM yyyy");
            ViewBag.appTime = applicationDetail.CreationTime.ToString("hh:mm:ss tt");

            ViewBag.LRD = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
            ViewBag.PD = _personalDetailAppService.GetPersonalDetailByApplicationId(ApplicationId).Result;
            ViewBag.CD = _contactDetailAppService.GetContactDetailByApplicationId(ApplicationId).Result;
            ViewBag.BD = _businesDetailAppService.GetBusinessDetailByApplicationId(ApplicationId).Result;
            ViewBag.ColD = _collateralDetailAppService.GetCollateralDetailByApplicationId(ApplicationId).Result;
            ViewBag.ED = _exposureDetailAppService.GetExposureDetailByApplicationId(ApplicationId).Result;
            ViewBag.ALD = _AssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(ApplicationId).Result;
            ViewBag.BI = _businessIncomeAppService.GetBusinessIncomeByApplicationId(ApplicationId);
            ViewBag.AI = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(ApplicationId);
            ViewBag.NAI = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(ApplicationId);
            ViewBag.BE = _businessExpenseAppService.GetBusinessExpenseByApplicationId(ApplicationId).Result;
            ViewBag.HE = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(ApplicationId);
            ViewBag.LE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
            ViewBag.BAD = _bankAccountAppService.GetBankAccountDetailByApplicationId(ApplicationId).Result;
            ViewBag.RD = _preferenceAppService.GetPreferencesByApplicationId(ApplicationId).Result;
            ViewBag.SDE = _forSDEAppService.GetForSDEByApplicationId(ApplicationId).Result;

            var files = _FilesUploadAppService.GetFilesByApplicationId(ApplicationId);
            ViewBag.Files = files;

            if (files != null)
            {
                var ApplicantPic = files.Where(x => x.ScreenCode == "applicant_photo").LastOrDefault();
                if (ApplicantPic != null)
                {
                    ViewBag.ApplicantPicUrl = ApplicantPic.BaseUrl;
                }
                else
                {
                    ViewBag.ApplicantPicUrl = "/images/noPic.jpg";

                }
            }
            else
            {
                ViewBag.ApplicantPicUrl = "/images/noPic.jpg";
            }

                var gd = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(ApplicationId).Result;

                var guarantorPhotos = files.Where(x => x.ScreenCode == "guarantor_photo");

                foreach (var item in gd)
                {
                    var gPhotos = guarantorPhotos.Where(x => x.Fk_idForName == item.Id).FirstOrDefault();

                    if (gPhotos != null)
                    {
                        item.imageUrl = gPhotos.BaseUrl;
                        if (item.imageUrl == "" || item.imageUrl == null)
                        {
                            item.imageUrl = "/images/noPic.jpg";
                        }
                    }
                    else
                    {
                        item.imageUrl = "/images/noPic.jpg";
                    }

                }
                ViewBag.GD = gd;
                var cod = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(ApplicationId).Result;

                var coapplicantPhotos = files.Where(x => x.ScreenCode == "co_applicant_photo");

                foreach (var item in cod)
                {
                    var cPhotos = coapplicantPhotos.Where(x => x.Fk_idForName == item.Id).FirstOrDefault();
                    if (cPhotos != null)
                    {
                        item.imageUrl = cPhotos.BaseUrl;
                        if (item.imageUrl == "" || item.imageUrl == null)
                        {
                            item.imageUrl = "/images/noPic.jpg";
                        }
                    }
                    else
                    {
                        item.imageUrl = "/images/noPic.jpg";
                    }

                }

                ViewBag.COD = cod;



            return View();
        }

        [DisableValidation]
        public IActionResult ApplicationReportTds(int ApplicationId)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.Application = applicationDetail;
            var user = _userAppService.GetUserById(applicationDetail.CreatorUserId);
            ViewBag.SDEName = user.Result.FullName;
            ViewBag.appDate = applicationDetail.CreationTime.ToString("dd MMM yyyy");
            ViewBag.appTime = applicationDetail.CreationTime.ToString("hh:mm:ss tt");

            ViewBag.LRD = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
            ViewBag.PD = _personalDetailAppService.GetPersonalDetailByApplicationId(ApplicationId).Result;
            ViewBag.DED = _dependentEducationDetailsAppService.GetDependentEducationDetailByApplicationId(ApplicationId).Result;
            ViewBag.CD = _contactDetailAppService.GetContactDetailByApplicationId(ApplicationId).Result;
            ViewBag.BD = _businessDetailsTDSAppService.GetBusinessDetailTDSByApplicationId(ApplicationId).Result;
            ViewBag.ColD = _collateralDetailAppService.GetCollateralDetailByApplicationId(ApplicationId).Result;
            ViewBag.ED = _exposureDetailAppService.GetExposureDetailByApplicationId(ApplicationId).Result;
            ViewBag.ID = _tdsInventoryDetailAppService.GetTdsInventoryDetailDetailByApplicationId(ApplicationId).Result;
            ViewBag.ALD = _AssetLiabilityAppService.GetAssetLiabilityDetailByApplicationId(ApplicationId).Result;
            ViewBag.SD = _salesDetailAppService.GetSalesDetailByApplicationId(ApplicationId).Result;
            ViewBag.PurD = _purchaseDetailAppService.GetPurchaseDetailByApplicationId(ApplicationId).Result;
            ViewBag.NAI = _nonAssociatedIncomeAppService.GetNonAssociatedIncomeDetailByApplicationId(ApplicationId);
            //ViewBag.BI = _businessIncomeAppService.GetBusinessIncomeByApplicationId(ApplicationId);
            //ViewBag.AI = _associatedIncomeAppService.GetAssociatedIncomeDetailByApplicationId(ApplicationId);
            ViewBag.BE = _tDSBusinessExpenseAppService.GetTDSBusinessExpenseByApplicationId(ApplicationId).Result;
            ViewBag.HE = _householdIncomeAppService.GetHouseholdIncomeByApplicationId(ApplicationId);
            ViewBag.LE = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(ApplicationId).Result;
            ViewBag.BAD = _bankAccountAppService.GetBankAccountDetailByApplicationId(ApplicationId).Result;
            ViewBag.RD = _preferenceAppService.GetPreferencesByApplicationId(ApplicationId).Result;
            ViewBag.SDE = _forSDEAppService.GetForSDEByApplicationId(ApplicationId).Result;

            var files = _FilesUploadAppService.GetFilesByApplicationId(ApplicationId);
            ViewBag.Files = files;

            if (files != null)
            {
                var ApplicantPic = files.Where(x => x.ScreenCode == "applicant_photo").LastOrDefault();
                if (ApplicantPic != null)
                {
                    ViewBag.ApplicantPicUrl = ApplicantPic.BaseUrl;
                }
                else
                {
                    ViewBag.ApplicantPicUrl = "/images/noPic.jpg";

                }
            }
            else
            {
                ViewBag.ApplicantPicUrl = "/images/noPic.jpg";
            }

            var gd = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(ApplicationId).Result;

            var guarantorPhotos = files.Where(x => x.ScreenCode == "guarantor_photo");

            foreach (var item in gd)
            {
                var gPhotos = guarantorPhotos.Where(x => x.Fk_idForName == item.Id).FirstOrDefault();

                if (gPhotos != null)
                {
                    item.imageUrl = gPhotos.BaseUrl;
                    if (item.imageUrl == "" || item.imageUrl == null)
                    {
                        item.imageUrl = "/images/noPic.jpg";
                    }
                }
                else
                {
                    item.imageUrl = "/images/noPic.jpg";
                }

            }
            ViewBag.GD = gd;
            var cod = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(ApplicationId).Result;

            var coapplicantPhotos = files.Where(x => x.ScreenCode == "co_applicant_photo");

            foreach (var item in cod)
            {
                var cPhotos = coapplicantPhotos.Where(x => x.Fk_idForName == item.Id).FirstOrDefault();
                if (cPhotos != null)
                {
                    item.imageUrl = cPhotos.BaseUrl;
                    if (item.imageUrl == "" || item.imageUrl == null)
                    {
                        item.imageUrl = "/images/noPic.jpg";
                    }
                }
                else
                {
                    item.imageUrl = "/images/noPic.jpg";
                }

            }

            ViewBag.COD = cod;



            return View();
        }

        public IActionResult BADocumentUpload(int Id)
        {

            ViewBag.Applicationid = Id;

            List<string> personList = new List<string>();
            var application = _applicationAppService.GetApplicationById(Id);
            if (application != null)
            {
                personList.Add(application.ClientName + " (Applicant) ");
            }
            var guarantors = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(Id).Result;
            if (guarantors != null)
            {
                foreach (var guarantor in guarantors)
                {
                    personList.Add(guarantor.FullName + " (Guarantor) ");
                }
            }
            var coApplicants = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(Id).Result;
            if (coApplicants != null)
            {
                foreach (var coApplicant in coApplicants)
                {
                    personList.Add(coApplicant.FullName + " (Co-Applicant) ");
                }
            }

            ViewBag.PersonsList = new SelectList(personList);

            List<string> DocumentTypeList = new List<string>();

            DocumentTypeList.Add("ECIB");
            DocumentTypeList.Add("DATA CHECK");
            DocumentTypeList.Add("TASDEEQ");
            DocumentTypeList.Add("VERISYS");
            DocumentTypeList.Add("AML/CFT");

            ViewBag.DocumentList = new SelectList(DocumentTypeList);


            return View();
        }

        public IActionResult BADocumentsDetail(int Id)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(Id);
            return View(applicationDetail);
        }

        [HttpPost]
        public async Task<JsonResult> UploadDataCheckFile(int ApplicationId, IFormFile file, string DocumentType, string PersonName)
        {
            string response = "";
            try
            {
                var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");
                string rootPath = Path.Combine(Fileuploadpath, ApplicationId.ToString());
                string rootPath2 = Path.Combine(rootPath, "CreditBureau");
                string fileName = "CreditBureau_" + DocumentType.Replace("/","").Replace(" ", "") + "_" + PersonName.Replace(" ", "") + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string extension = System.IO.Path.GetExtension(file.FileName);
                //input.DecisionFile = "/uploads/" + input.ApplicationId.ToString() + "/" + fileName + extension;

                string uploadedFile = UploadDataCheckDocumentstoServer(file, rootPath2, fileName);


                CreateBADataCheckDto input = new CreateBADataCheckDto();

                input.ApplicationId = ApplicationId;
                input.BaseUrl = "..\\..\\uploads\\" + ApplicationId.ToString() + "\\CreditBureau\\" + fileName + extension;
                input.DocumentUrl = fileName + extension;
                input.Status = "Inprocessing";
                input.DocumentKey = DocumentType;
                input.DocumentName = PersonName;


                _IBADataCheckAppService.CreateBADocumentUpload(input);


                return Json("Document Uploaded Successfully!");

            }
            catch (Exception ex)
            {
                return Json("Document Upload Unsuccessful");
            }
        }

        [HttpPost]
        public async Task<JsonResult> getDataCheckFiles(int ApplicationId)
        {
            try
            {

                var files = _IBADataCheckAppService.GetBADocumentsByApplicationId(ApplicationId);

                //files.Result[0].CreationTime
                return Json(files);

            }
            catch (Exception ex)
            {
                return Json("Error");
            }
        }

        public IActionResult DeleteDataCheckFile(int id, int ApplicationId)
        {
            try
            {

                _IBADataCheckAppService.DeleteFile(id);


                return RedirectToAction("BADocumentUpload", new { id = ApplicationId });

            }
            catch (Exception ex)
            {
                return RedirectToAction("BADocumentUpload", new { id = ApplicationId });
            }
        }

        private string UploadDataCheckDocumentstoServer(IFormFile image, string rootPath, string DocumentName)
        {
            try
            {
                string extension = System.IO.Path.GetExtension(image.FileName);
                var filename = DocumentName;

                rootPath = Path.Combine(_env.WebRootPath, rootPath);

                var filePath = Path.Combine(rootPath, filename + extension);

                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                return filePath.ToString();

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        private void CalculateLoanaMortization()
        {


        }


        [HttpPost]
        public IActionResult BADocumentUpload([FromForm] DocumentUpload documentUpload)
        {
            string rootPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            string AppicationId = documentUpload.ApplicationId.ToString();

            var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");

            bool exists = System.IO.Directory.Exists(Fileuploadpath);
            if (!exists)
                System.IO.Directory.CreateDirectory(Fileuploadpath);


            var uploadApplication = Path.Combine(Fileuploadpath, AppicationId);
            bool existsApplication = System.IO.Directory.Exists(uploadApplication);
            if (!existsApplication)
                System.IO.Directory.CreateDirectory(uploadApplication);

            if (documentUpload.DataCheck_photo != null)
            {
                UploadImagestoServer(documentUpload.DataCheck_photo, uploadApplication, documentUpload.ApplicationId, rootPath, nameof(BADocumentsUploadString.DataCheck_photo));
            }

            if (documentUpload.ECIB_photo != null)
            {
                UploadImagestoServer(documentUpload.ECIB_photo, uploadApplication, documentUpload.ApplicationId, rootPath, nameof(BADocumentsUploadString.ECIB_photo));
            }

            if (documentUpload.Tasdeeq_photo != null)
            {
                UploadImagestoServer(documentUpload.Tasdeeq_photo, uploadApplication, documentUpload.ApplicationId, rootPath, nameof(BADocumentsUploadString.Tasdeeq_photo));
            }
            if (documentUpload.Verisys_photo != null)
            {
                UploadImagestoServer(documentUpload.Verisys_photo, uploadApplication, documentUpload.ApplicationId, rootPath, nameof(BADocumentsUploadString.Verisys_photo));
            }

            var appData = _applicationAppService.GetApplicationById(Int32.Parse(AppicationId));
            _notificationLogAppService.SendNotification((int)appData.CreatorUserId, "Documents have been uploaded against Application " + appData.ClientID, "Click to Open the Application.");

            return RedirectToAction("BADocumentsList");
        }

        private void UploadImagestoServer(IFormFile image, string uploadApplication, int applicationId, string rootPath, string DocumentKey)
        {
            try
            {

                string extension = System.IO.Path.GetExtension(image.FileName);
                var filename = "Test";
                if (image.FileName.Contains("."))
                {
                    filename = DocumentKey;
                }

                var filePath = Path.Combine(uploadApplication, filename + extension);

                if (!System.IO.File.Exists(filePath))
                {

                    CreateBADataCheckDto createdocumentUpload = new CreateBADataCheckDto();
                    createdocumentUpload.ApplicationId = applicationId;
                    createdocumentUpload.DocumentUrl = "uploads/" + applicationId + "/" + filename + extension;
                    createdocumentUpload.BaseUrl = rootPath + "/" + createdocumentUpload.DocumentUrl;
                    createdocumentUpload.Status = "Inprocessing";
                    createdocumentUpload.DocumentKey = DocumentKey;
                    _IBADataCheckAppService.CreateBADocumentUpload(createdocumentUpload);
                }
                else
                {
                    _IBADataCheckAppService.UpdateFile(applicationId, DocumentKey);
                }



                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }




            }
            catch (Exception ex)
            {

            }

        }

        private string GetIrrValue(string Tenure, string APR)
        {


            string filePath = "FormulaCalculation.xlsx";

            var Fileuploadpath = Path.Combine(_env.WebRootPath, "Formula");

            bool exists = System.IO.Directory.Exists(Fileuploadpath);
            if (!exists)
                System.IO.Directory.CreateDirectory(Fileuploadpath);


            var uploadApplication = Path.Combine(Fileuploadpath, filePath);


            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("FormulaCalculation");

            // Some formatting.
            var row = worksheet.Rows[0];
            row.Style.Font.Weight = ExcelFont.BoldWeight;

            var column = worksheet.Columns[0];
            column.SetWidth(250, LengthUnit.Pixel);
            column.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
            column = worksheet.Columns[1];
            column.SetWidth(250, LengthUnit.Pixel);
            column.Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;

            // Use first row for column headers.
            worksheet.Cells["A1"].Value = "Formula";
            worksheet.Cells["B1"].Value = "Calculated value";

            // Enter some Excel formulas as text in first column.
            worksheet.Cells["A2"].Value = "=RATE(" + Convert.ToDouble(Tenure) + ",(1+((1*" + Convert.ToDouble(APR) + "%)/12*" + Convert.ToDouble(Tenure) + "))/" + Convert.ToDouble(Tenure) + ",-1,0,0)*12*100";

            // Set text from first column as second row cell's formula.
            int rowIndex = 1;
            while (worksheet.Cells[rowIndex, 0].ValueType != CellValueType.Null)
                worksheet.Cells[rowIndex, 1].Formula = worksheet.Cells[rowIndex++, 0].StringValue;

            // GemBox.Spreadsheet supports single Excel cell calculation, ...
            worksheet.Cells["B2"].Calculate();
            var IRR = worksheet.Cells["B2"].Value;
            // ... Excel worksheet calculation,
            worksheet.Calculate();

            // ... and whole Excel file calculation.
            worksheet.Parent.Calculate();
            workbook.Save(uploadApplication);


            return IRR.ToString();

        }

        [HttpPost]
        public IActionResult ChangeDisbursmentStatus(string ApplicationId)
        {
            try
            {
                _applicationAppService.ChangeApplicationState(TFCLPortal.Applications.Dto.ApplicationState.Disbursed, Convert.ToInt32(ApplicationId), "");
            }
            catch (Exception ex)
            {

            }

            return Json("Application disburse successfully");

        }



        enum DueDate
        {
            EndOfPeriod = 0,
            BegOfPeriod = 1
        }
        [HttpPost]
        public IActionResult CreateMortization(string LoanAmount, string Tenure, string APR, string ApplicationId, string LoanDisbursementDate, string LoanStartDate)
        {


            var IRR = GetIrrValue(Tenure, APR);
            decimal irrRate = 0;


            var plan = _businessPlanAppService.GetBusinessPlanByApplicationId(Convert.ToInt32(ApplicationId));
            int periods = 0;
            decimal interestforbimonthly = 0;
            if (plan.Result != null)
            {
                var paymentFrequency = plan.Result.PaymentFrequency;

                if (paymentFrequency == 1)
                {
                    irrRate = Convert.ToDecimal(IRR) / 12;
                    periods = Convert.ToInt32(Tenure);
                    irrRate = irrRate / 100;
                }
                else if (paymentFrequency == 5 || paymentFrequency == 2 || paymentFrequency == 3 || paymentFrequency == 4)
                {
                    if (paymentFrequency == 5)
                    {
                        periods = Convert.ToInt32(Tenure) / 2;
                    }
                    else if (paymentFrequency == 2)
                    {
                        periods = Convert.ToInt32(Tenure) / 3;
                    }
                    else if (paymentFrequency == 3)
                    {
                        periods = Convert.ToInt32(Tenure) / 6;
                    }
                    else if (paymentFrequency == 4)
                    {
                        periods = Convert.ToInt32(Tenure) / 12;
                    }
                    irrRate = (Convert.ToDecimal(IRR) / periods);
                    irrRate = irrRate / 100;
                    var aprAmount1 = Convert.ToDouble(APR) / 100;
                    var tenureRate1 = Convert.ToDouble(Tenure) / 12;
                    var Totalinterest1 = Convert.ToDouble(LoanAmount) * (aprAmount1 * tenureRate1);
                    decimal balance1 = Convert.ToDecimal(LoanAmount);
                    var totalamountwithinterest1 = Convert.ToDouble(LoanAmount) + Totalinterest1;
                    var paymentInstallment1 = totalamountwithinterest1 / Convert.ToDouble(periods);

                    for (var i = 0; i < periods; i++)
                    {

                        decimal interestForMonth = 0;

                        interestForMonth = (Math.Round(balance1 * irrRate));

                        var principalForMonth = Math.Round(Convert.ToDecimal(paymentInstallment1) - interestForMonth, 2);
                        balance1 -= principalForMonth;

                        interestforbimonthly = interestforbimonthly + interestForMonth;


                    }

                }
            }


            var aprAmount = Convert.ToDouble(APR) / 100;
            var tenureRate = Convert.ToDouble(Tenure) / 12;
            var Totalinterest = Convert.ToDouble(LoanAmount) * (aprAmount * tenureRate);
            var paymentFrequency1 = plan.Result.PaymentFrequency;
            var totalamountwithinterest = 0.0;
            if (paymentFrequency1 == 1)
            {
                totalamountwithinterest = Convert.ToDouble(LoanAmount) + Totalinterest;
            }
            else if (paymentFrequency1 == 5 || paymentFrequency1 == 2 || paymentFrequency1 == 3 || paymentFrequency1 == 4)
            {
                totalamountwithinterest = Convert.ToDouble(LoanAmount) + Convert.ToDouble(interestforbimonthly);
            }
            var paymentInstallment = totalamountwithinterest / Convert.ToDouble(periods);
            var graceDay = 0.0;
            if (LoanDisbursementDate != "")
            {
                var loanDisbursDate = Convert.ToDateTime(LoanDisbursementDate);
                var loanStartDate = Convert.ToDateTime(LoanStartDate);
                graceDay = (loanStartDate - loanDisbursDate).Days;
            }

            var TotalinterestGrace = Totalinterest;
            double totaldaysInYear = 365 * tenureRate;
            var graceDayIntereset = Convert.ToDecimal((TotalinterestGrace / totaldaysInYear) * graceDay);


            List<CreateLoanAmortizationChildDto> listDisplay = new List<CreateLoanAmortizationChildDto>();
            CreateLoanAmortizationDto parent = new CreateLoanAmortizationDto();
            decimal balance = Convert.ToDecimal(LoanAmount); // for example

            var LoanDate = Convert.ToDateTime(LoanStartDate);
            LoanDate = LoanDate.AddMonths(1);
            int day = LoanDate.Day;
            try
            {
                for (var i = 0; i < periods; i++)
                {
                    CreateLoanAmortizationChildDto childDto = new CreateLoanAmortizationChildDto();
                    DateTime DuefinalDate = new DateTime();
                    decimal interestForMonth = 0;
                    decimal interestForFirstMonth = 0;
                    var startDate = new DateTime(LoanDate.Year, LoanDate.Month, day);
                    if (i == 0)
                    {
                        interestForMonth = Math.Round((balance * irrRate), 0);
                        interestForFirstMonth = Math.Round((balance * irrRate) + graceDayIntereset, 0);

                        DuefinalDate = startDate;

                    }
                    else
                    {
                        DuefinalDate = startDate.AddMonths(i);
                        interestForMonth = (Math.Round(balance * irrRate));


                    }


                    var principalForMonth = Math.Round(Convert.ToDecimal(paymentInstallment) - interestForMonth, 2);
                    balance -= principalForMonth;


                    if (i == 0)
                    {

                        childDto.InterestAmount = interestForFirstMonth;
                        childDto.TotalInstallment = Math.Round(interestForFirstMonth + principalForMonth, 0);

                    }
                    else
                    {
                        childDto.InterestAmount = interestForMonth;
                        childDto.TotalInstallment = Math.Round(interestForMonth + principalForMonth, 0);

                    }


                    if (balance < 9 && balance > -9)
                    {
                        balance = 0;
                    }
                    else
                    {
                        childDto.RemainingBalance = Math.Round(balance, 0);
                    }

                    childDto.PrincipalAmount = Math.Round(principalForMonth, 0);
                    childDto.InstallmentDueDate = DuefinalDate;
                    childDto.InstallmentSerial = i + 1;
                    childDto.TotalInstallmentCount = periods;


                    listDisplay.Add(childDto);
                }
            }
            catch (Exception ex)
            {

            }
            CreateLoanAmortizationDto createLoanAmortization = new CreateLoanAmortizationDto();
            try
            {

                createLoanAmortization.LoanAmortizationChilds = listDisplay;
            }
            catch (Exception ex)
            {

            }
            return PartialView("_loanmortizationlist", createLoanAmortization);

        }




        [HttpPost]
        public JsonResult SaveMortization(string LoanAmount, string Tenure, string APR, string ApplicationId, string LoanDisbursementDate, string LoanStartDate)
        {

            var IsExistRecord = _loanAmortizationAppService.GetLoanAmortizationByApplicationId(Convert.ToInt32(ApplicationId));
            if (IsExistRecord != null)
            {
                return Json("You have already save amortization to server");
            }

            var IRR = GetIrrValue(Tenure, APR);


            var plan = _businessPlanAppService.GetBusinessPlanByApplicationId(Convert.ToInt32(ApplicationId));
            int periods = 0;
            if (plan.Result != null)
            {
                var paymentFrequency = plan.Result.PaymentFrequency;

                if (paymentFrequency == 1)
                {
                    periods = Convert.ToInt32(Tenure);
                }
                else if (paymentFrequency == 5)
                {
                    periods = Convert.ToInt32(Tenure) / 2;
                }
            }

            var aprAmount = Convert.ToDouble(APR) / 100;
            var tenureRate = Convert.ToDouble(Tenure) / 12;
            var Totalinterest = Convert.ToDouble(LoanAmount) * (aprAmount * tenureRate);
            var totalamountwithinterest = Convert.ToDouble(LoanAmount) + Totalinterest;
            var paymentInstallment = totalamountwithinterest / Convert.ToDouble(periods);
            var graceDay = 0.0;
            if (LoanDisbursementDate != "")
            {
                var loanDisbursDate = Convert.ToDateTime(LoanDisbursementDate);
                var loanStartDate = Convert.ToDateTime(LoanStartDate);
                graceDay = (loanStartDate - loanDisbursDate).Days;
            }

            double totaldaysInYear = 365 * tenureRate;
            var graceDayIntereset = Convert.ToDecimal((Totalinterest / totaldaysInYear) * graceDay);
            var irrRate = Convert.ToDecimal(IRR) / 12;
            irrRate = irrRate / 100;
            //var irr=  this.Rate(Convert.ToDouble(Tenure), -paymentInstallment, Convert.ToDouble(LoanAmount), totalamountwithinterest, DueDate.EndOfPeriod);
            List<CreateLoanAmortizationChildDto> listDisplay = new List<CreateLoanAmortizationChildDto>();
            CreateLoanAmortizationDto parent = new CreateLoanAmortizationDto();
            decimal balance = Convert.ToDecimal(LoanAmount); // for example


            var LoanDate = Convert.ToDateTime(LoanStartDate);
            LoanDate = LoanDate.AddMonths(1);
            try
            {
                for (var i = 0; i < periods; i++)
                {
                    CreateLoanAmortizationChildDto childDto = new CreateLoanAmortizationChildDto();
                    DateTime DuefinalDate = new DateTime();
                    decimal interestForMonth = 0;
                    decimal interestForFirstMonth = 0;
                    var startDate = new DateTime(LoanDate.Year, LoanDate.Month, LoanDate.Day);
                    if (i == 0)
                    {
                        interestForMonth = Math.Round((balance * irrRate), 0);
                        interestForFirstMonth = Math.Round((balance * irrRate) + graceDayIntereset, 0);

                        DuefinalDate = startDate;

                    }
                    else
                    {
                        DuefinalDate = startDate.AddMonths(i);
                        interestForMonth = (Math.Round(balance * irrRate));


                    }


                    var principalForMonth = Math.Round(Convert.ToDecimal(paymentInstallment) - interestForMonth, 2);
                    balance -= principalForMonth;


                    if (i == 0)
                    {

                        childDto.InterestAmount = interestForFirstMonth;
                        childDto.TotalInstallment = Math.Round(interestForFirstMonth + principalForMonth, 0);

                    }
                    else
                    {
                        childDto.InterestAmount = interestForMonth;
                        childDto.TotalInstallment = Math.Round(interestForMonth + principalForMonth, 0);

                    }




                    childDto.PrincipalAmount = Math.Round(principalForMonth, 0);
                    if (balance < 9 && balance > -9)
                    {
                        balance = 0;
                    }
                    else
                    {
                        childDto.RemainingBalance = Math.Round(balance, 0);
                    }

                    childDto.InstallmentDueDate = DuefinalDate;
                    childDto.InstallmentSerial = i + 1;
                    childDto.TotalInstallmentCount = periods;


                    listDisplay.Add(childDto);
                }

                var app = _applicationAppService.GetApplicationById(Convert.ToInt32(ApplicationId));
                int prodId = 0;
                if (app != null && app.ProductType > 0)
                {
                    prodId = app.ProductType;
                }
                CreateLoanAmortizationDto createLoanAmortization = new CreateLoanAmortizationDto();

                createLoanAmortization.Tenure = Convert.ToInt32(periods);
                createLoanAmortization.APR = Math.Round(Convert.ToDecimal(APR), 2);
                createLoanAmortization.IntrestAmount = Math.Round(Convert.ToDecimal(Totalinterest), 0);
                createLoanAmortization.InstallmentPayment = Math.Round(Convert.ToDecimal(paymentInstallment), 0);
                createLoanAmortization.TotalInstallmentPayment = Math.Round(Convert.ToDecimal(totalamountwithinterest), 0);
                createLoanAmortization.IRR = Math.Round(Convert.ToDecimal(IRR), 2);
                createLoanAmortization.LoanAmount = Math.Round(Convert.ToDecimal(LoanAmount), 0);
                createLoanAmortization.ApplicationId = Convert.ToInt32(ApplicationId);
                createLoanAmortization.LoanDisbursementDate = Convert.ToDateTime(LoanDisbursementDate);
                createLoanAmortization.LoanStartDate = Convert.ToDateTime(LoanStartDate);
                createLoanAmortization.GraceDays = Convert.ToInt32(graceDay);
                createLoanAmortization.Fk_Product = prodId;
                createLoanAmortization.GraceDaysAmount = graceDayIntereset;
                createLoanAmortization.LoanAmortizationChilds = listDisplay;


                _loanAmortizationAppService.CreateLoanAmortization(createLoanAmortization);

            }
            catch (Exception ex)
            {

            }


            return Json("Amortization Save successfully to Server");

        }


        [HttpPost]
        public JsonResult IsAmortizationRecordExist(string ApplicationId)
        {
            try
            {
                var IsExistRecord = _loanAmortizationAppService.GetLoanAmortizationByApplicationId(Convert.ToInt32(ApplicationId));
                if (IsExistRecord != null)
                {
                    var Id = IsExistRecord.Id;
                    var AppId = IsExistRecord.ApplicationId;
                    return Json("" + Id);
                }
                else
                {
                    return Json("Please Save Amortization First");
                }

            }
            catch (Exception ex)
            {

            }


            return Json("Amortization Save successfully to Server");

        }



    }

}