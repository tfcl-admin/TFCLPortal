using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;
using TFCLPortal.ApplicationWorkFlows.BccStates;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees;
using TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Controllers;
using TFCLPortal.Customs;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.BccDecisions;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.BccDecisions.Dto;
using TFCLPortal.BusinessPlans;
using TFCLPortal.CollateralDetails;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.McrcDecisions;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TFCLPortal.FcmTokens.Dto;
using TFCLPortal.FcmTokens;
using TFCLPortal.NotificationLogs;
using TFCLPortal.TDSLoanEligibilities;

namespace TFCLPortal.Web.Mvc.Controllers
{
    public class BCCController : TFCLPortalControllerBase
    {
        private readonly IBranchCreditCommitteeAppService _branchCreditCommitteeAppService;
        private readonly IUserAppService _userAppService;
        private readonly IApplicationDescripantDeclineStateAppService _applicationDescripantDeclineStateAppService;
        private readonly ICustomAppService _customAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IFcmTokenAppService _fcmTokenAppService;
        private readonly IHostingEnvironment _env;

        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly ICollateralDetailAppService _collateralDetailAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly INotificationLogAppService _notificationLogAppService;


        private readonly IApplicationAppService _applicationAppService;
        private readonly IBccStateAppService _bccStateAppService;
        private readonly IBccDecisionAppService _bccDecisionAppService;
        private readonly UserManager _userManager;
        private readonly IMcrcDecisionAppService _McrcDecisionAppService;

        public BCCController(IHostingEnvironment env, ITDSLoanEligibilityAppService tDSLoanEligibilityAppService, IFcmTokenAppService fcmTokenAppService, INotificationLogAppService notificationLogAppService, IUserAppService userAppService, IMcrcDecisionAppService McrcDecisionAppService, ILoanEligibilityAppService loanEligibilityAppService, ICollateralDetailAppService collateralDetailAppService, IBusinessPlanAppService businessPlanAppService, IBccDecisionAppService bccDecisionAppService, IFinalWorkflowAppService finalWorkflowAppService, UserManager userManager)
        {
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _userManager = userManager;
            _branchCreditCommitteeAppService = IocManager.Instance.Resolve<IBranchCreditCommitteeAppService>();
            _userAppService = userAppService;
            _applicationAppService = IocManager.Instance.Resolve<IApplicationAppService>();
            _bccStateAppService = IocManager.Instance.Resolve<IBccStateAppService>();
            _applicationDescripantDeclineStateAppService = IocManager.Instance.Resolve<IApplicationDescripantDeclineStateAppService>();
            _customAppService = IocManager.Instance.Resolve<ICustomAppService>();
            _finalWorkflowAppService = finalWorkflowAppService;
            _bccDecisionAppService = bccDecisionAppService;
            _businessPlanAppService = businessPlanAppService;
            _collateralDetailAppService = collateralDetailAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
            _McrcDecisionAppService = McrcDecisionAppService;
            _fcmTokenAppService = fcmTokenAppService;
            _notificationLogAppService = notificationLogAppService;
            _env = env;
        }
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
        public IActionResult BccList()
        {
            var model = _branchCreditCommitteeAppService.GetBranchCreditCommitteeList();
            return View(model);
        }

        public ActionResult Index()
        {
            var applications = _applicationAppService.GetShortApplicationList(ApplicationState.Screened, Branchid());
            return View(applications);
        }

        public ActionResult BCCReviewedApplications()
        {
            //var applications = _applicationAppService.GetShortApplicationList(ApplicationState.BCCReviewed, Branchid());
            //var applications = _applicationAppService.GetAllApplicationsByUserId((int)AbpSession.UserId);
            var applications = _applicationAppService.GetAllBCCReviewedApplicationsByUserId((int)AbpSession.UserId);
            return View(applications);
        }

        public async Task<ActionResult> DecisionPartial(int appid, int userid)
        {
            ViewBag.UserId = userid;
            ViewBag.AppId = appid;
            var appData = _applicationAppService.GetApplicationById(appid);

            ViewBag.ClientId = appData.ClientID;
            ViewBag.ApplicantName = appData.ClientName;
            ViewBag.SchoolName = appData.SchoolName;
            ViewBag.Cnic = appData.CNICNo;

            var bcc = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListByApplicationId(appid);
            var getStates = _bccStateAppService.GetBccStateListByApplicationId(appid).Result.ToList();
            var getUsers = _userAppService.GetAllUsers().ToList();

            ViewBag.BCCNo = "BCC-" + bcc.Id;
            ViewBag.UserId1 = bcc.CreatorUserId;
            ViewBag.UserId2 = bcc.SDE1_UserId;
            ViewBag.UserId3 = bcc.SDE2_UserId;

            ViewBag.BCCMember1Name = getUsers.Where(x => x.Id == bcc.CreatorUserId).FirstOrDefault().FullName;
            ViewBag.BCCMember1Decision = getStates.Where(x => x.Fk_UserId == bcc.CreatorUserId).LastOrDefault().Status;
            ViewBag.BCCMember1Reason = getStates.Where(x => x.Fk_UserId == bcc.CreatorUserId).LastOrDefault().Reason;

            ViewBag.BCCMember2Name = getUsers.Where(x => x.Id == bcc.SDE1_UserId).FirstOrDefault().FullName;
            ViewBag.BCCMember2Decision = getStates.Where(x => x.Fk_UserId == bcc.SDE1_UserId).LastOrDefault().Status;
            ViewBag.BCCMember2Reason = getStates.Where(x => x.Fk_UserId == bcc.SDE1_UserId).LastOrDefault().Reason;

            ViewBag.BCCMember3Name = getUsers.Where(x => x.Id == bcc.SDE2_UserId).FirstOrDefault().FullName;
            ViewBag.BCCMember3Decision = getStates.Where(x => x.Fk_UserId == bcc.SDE2_UserId).LastOrDefault().Status;
            ViewBag.BCCMember3Reason = getStates.Where(x => x.Fk_UserId == bcc.SDE2_UserId).LastOrDefault().Reason;

            var getLRD = _businessPlanAppService.GetBusinessPlanByApplicationId(appid);
            var getColD = _collateralDetailAppService.GetCollateralDetailByApplicationId(appid);

            if (appData.ProductType == 1 || appData.ProductType == 2)
            {
                var getLE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(appid);
                if (getLE != null)
                {
                    ViewBag.Mark_Up = (getLE.Result.Mark_Up == null || getLE.Result.Mark_Up == "" ? "--" : getLE.Result.Mark_Up + " %");
                }
            }
            else if (appData.ProductType == 8 || appData.ProductType == 9)
            {
                var getLE = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(appid);
                if (getLE != null)
                {
                    ViewBag.Mark_Up = (getLE.Result.Mark_Up == null || getLE.Result.Mark_Up == "" ? "--" : getLE.Result.Mark_Up + " %");
                }
            }


            if (getLRD != null)
            {
                ViewBag.LoanAmount = (getLRD.Result.LoanAmountRecommended == null || getLRD.Result.LoanAmountRecommended == "" ? "--" : Convert.ToDecimal(getLRD.Result.LoanAmountRecommended).ToString("#,###"));
                ViewBag.LoanTenure = (getLRD.Result.LoanTenureRequestedName == null || getLRD.Result.LoanTenureRequestedName == "" ? "--" : getLRD.Result.LoanTenureRequestedName);
            }
            if (getColD != null)
            {
                ViewBag.CollateralAmount = (getColD.Result.AllCollateralMarketPrice == null || getColD.Result.AllCollateralMarketPrice == "" ? "--" : Convert.ToDecimal(getColD.Result.AllCollateralMarketPrice).ToString("#,###"));
                ViewBag.LTVPercentage = (getColD.Result.MaxFinancingAllowedLtvAllCollaterals == null || getColD.Result.MaxFinancingAllowedLtvAllCollaterals == "" ? "--" : Convert.ToDecimal(getColD.Result.MaxFinancingAllowedLtvAllCollaterals).ToString("#,###"));

                if (getColD.Result.isNA != true)
                {
                    ViewBag.cDate = string.Format("{0:dd MMM yyyy}", getColD.Result.CreationTime);
                }
                else
                {
                    ViewBag.cDate = "";
                }

            }


            var getMcrcDecision = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == appid).FirstOrDefault();
            if (getMcrcDecision != null)
            {
                ViewBag.McrcDecision = getMcrcDecision.Decision;
            }

            return View("DecisionPartial");
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
        public async Task<JsonResult> CreateBccDecision(CreateBccDecisionDto input)
        {
            string response = "";
            try
            {
                if (input.file != null)
                {
                    var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");
                    string rootPath = Path.Combine(Fileuploadpath, input.ApplicationId.ToString());
                    string fileName = "BccDecision_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    string extension = System.IO.Path.GetExtension(input.file.FileName);
                    input.DecisionFile = "/uploads/" + input.ApplicationId.ToString() + "/" + fileName + extension;

                    UploadImagestoServer(input.file, rootPath, fileName);
                }

                await _bccDecisionAppService.CreateBccDecision(input);


                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = input.ApplicationId;
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.isActive = true;

                if (input.Decision == "Decline")
                {
                    fWobj.Action = "Declined By BCC";
                    fWobj.ApplicationState = ApplicationState.Decline;
                    _applicationAppService.ChangeApplicationState(ApplicationState.Decline, input.ApplicationId, "Declined By BCC");
                }
                else if (input.Decision == "Discrepent")
                {
                    fWobj.Action = "Discrepented By BCC";
                    fWobj.ApplicationState = ApplicationState.Submitted;
                    _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, input.ApplicationId, "Discrepented By BCC");
                }
                else if (input.Decision == "Approve")
                {
                    fWobj.Action = "Approved by BCC";
                    fWobj.ApplicationState = ApplicationState.BCC_Approved;
                    _applicationAppService.ChangeApplicationState(ApplicationState.BCC_Approved, input.ApplicationId, "Approved by BCC");
                    var appData = _applicationAppService.GetApplicationById(input.ApplicationId);
                    if (appData != null)
                    {
                        await _notificationLogAppService.SendNotification(66, appData.ClientID + " is waiting for your approval", "Kindly view BCC Approved Applications.");
                    }
                }
                else if (input.Decision == "Under MCRC Review")
                {
                    fWobj.Action = "Under MCRC Review";
                    fWobj.ApplicationState = ApplicationState.MCRCReview;
                    _applicationAppService.ChangeApplicationState(ApplicationState.MCRCReview, input.ApplicationId, "Sent to MCRC");
                }

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                response = "BCC Decision saved successfully!";


            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(response);

        }

        private string UploadImagestoServer(IFormFile image, string rootPath, string DocumentName)
        {
            try
            {

                string extension = System.IO.Path.GetExtension(image.FileName);
                var filename = DocumentName;

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

        public async Task<ActionResult> RecommendationPartial(int appid, int userid)
        {
            ViewBag.UserId = userid;
            ViewBag.AppId = appid;
            var appData = _applicationAppService.GetApplicationById(appid);

            ViewBag.ClientId = appData.ClientID;
            ViewBag.ApplicantName = appData.ClientName;
            ViewBag.SchoolName = appData.SchoolName;
            ViewBag.Cnic = appData.CNICNo;

            return View("RecommendationPartial");
        }

        public ActionResult Recommendation(int appid, int userid)
        {
            ViewBag.UserId = userid;
            ViewBag.AppId = appid;
            var appData = _applicationAppService.GetApplicationById(appid);

            ViewBag.ClientId = appData.ClientID;
            ViewBag.ApplicantName = appData.ClientName;
            ViewBag.SchoolName = appData.SchoolName;
            ViewBag.Cnic = appData.CNICNo;

            return View();
        }

        public ActionResult UnderReview()
        {
            var applications = _applicationAppService.GetShortApplicationList(ApplicationState.BCCReview, Branchid());

            if (applications != null)
            {
                foreach (var app in applications)
                {
                    var getStates = _bccStateAppService.GetBccStateListByApplicationId(app.Id).Result.Where(x => x.Fk_UserId == (int)AbpSession.UserId && x.Status == "Active").LastOrDefault();
                    if (getStates != null)
                    {
                        app.Remarks = "Active";
                    }
                }
            }
            return View(applications);
        }
        //public ActionResult UnderReview()
        //{
        //    var getStates = _bccStateAppService.GetBccStateListByUserId((int)AbpSession.UserId).Result.ToList();

        //    if (getStates != null)
        //    {
        //        foreach (var app in applications)
        //        {
        //            var getStates = _bccStateAppService.GetBccStateListByApplicationId(app.Id).Result.ToList();
        //            if (getStates != null)
        //            {
        //                foreach (var state in getStates)
        //                {
        //                    if (state.Fk_UserId == (int)AbpSession.UserId && state.Status == "Active")
        //                    {
        //                        app.Remarks = state.Status;
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    return View(applications);
        //}
        public async Task<IActionResult> CreateBcc(int Id)
        {
            ViewBag.AppId = Id;

            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<UserDto> SdeUsers = new List<UserDto>();

            var appData = _applicationAppService.GetApplicationById(Id);
            if(appData!=null)
            {
                ViewBag.ClientId = appData.ClientID;
                ViewBag.applicantName = appData.ClientName;
                ViewBag.BusinessName = appData.SchoolName;
            }

            //long? userid = _userManager.AbpSession.UserId;

            //var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            //int? branchId = currentuser.Result.BranchId;
            int? branchId = Branchid();
            bool IsAdmin = User.IsInRole("Admin");
            if (IsAdmin == false)
            {

                foreach (var user in users)
                {
                    if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE") && user.BranchId == branchId)
                    {

                        SdeUsers.Add(user);
                    }

                }
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                    {

                        SdeUsers.Add(user);
                    }

                }
            }



            ViewBag.SDEUserList = new SelectList(SdeUsers, "Id", "FullName");

            return View("CreateBcc");
        }
        [HttpPost]
        public IActionResult CreateBcc(CreateBranchCreditCommitteeDto createBranchCredit)
        {
            try
            {
                var bcc = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListByApplicationId(createBranchCredit.ApplicationId);
                if (bcc == null)
                {
                    var LastCreatedId = _branchCreditCommitteeAppService.CreateBranchCreditCommitteeDetail(createBranchCredit);
                    CreateBccStateDto createBccUser1Dto = new CreateBccStateDto();
                    createBccUser1Dto.ApplicationId = createBranchCredit.ApplicationId;
                    createBccUser1Dto.Fk_BccId = LastCreatedId;
                    createBccUser1Dto.Fk_UserId = (int)createBranchCredit.SDE1_UserId;
                    createBccUser1Dto.Status = "Active";
                    _bccStateAppService.CreateBccStateDetail(createBccUser1Dto);

                    CreateBccStateDto createBccUser2Dto = new CreateBccStateDto();
                    createBccUser2Dto.ApplicationId = createBranchCredit.ApplicationId;
                    createBccUser2Dto.Fk_BccId = LastCreatedId;
                    createBccUser2Dto.Fk_UserId = (int)createBranchCredit.SDE2_UserId;
                    createBccUser2Dto.Status = "Active";

                    _bccStateAppService.CreateBccStateDetail(createBccUser2Dto);

                    CreateBccStateDto createBccBMDto = new CreateBccStateDto();

                    createBccBMDto.ApplicationId = createBranchCredit.ApplicationId;
                    createBccBMDto.Fk_BccId = LastCreatedId;
                    createBccBMDto.Fk_UserId = (int)AbpSession.UserId;
                    createBccBMDto.Status = "Active";
                    _bccStateAppService.CreateBccStateDetail(createBccBMDto);


                    CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                    fWobj.ApplicationId = createBranchCredit.ApplicationId;
                    fWobj.Action = "Under BCC Review";
                    fWobj.ActionBy = (int)AbpSession.UserId;
                    fWobj.ApplicationState = ApplicationState.BCCReview;
                    fWobj.isActive = true;

                    _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                    _applicationAppService.ChangeApplicationState(ApplicationState.BCCReview, createBranchCredit.ApplicationId, "Under BCC Review");


                    return RedirectToAction("Index");
                }
                else
                {

                    CreateBccStateDto createBccUser1Dto = new CreateBccStateDto();
                    createBccUser1Dto.ApplicationId = createBranchCredit.ApplicationId;
                    createBccUser1Dto.Fk_BccId = bcc.Id;
                    createBccUser1Dto.Fk_UserId = (int)createBranchCredit.SDE1_UserId;
                    createBccUser1Dto.Status = "Active";
                    _bccStateAppService.CreateBccStateDetail(createBccUser1Dto);

                    CreateBccStateDto createBccUser2Dto = new CreateBccStateDto();
                    createBccUser2Dto.ApplicationId = createBranchCredit.ApplicationId;
                    createBccUser2Dto.Fk_BccId = bcc.Id;
                    createBccUser2Dto.Fk_UserId = (int)createBranchCredit.SDE2_UserId;
                    createBccUser2Dto.Status = "Active";

                    _bccStateAppService.CreateBccStateDetail(createBccUser2Dto);

                    CreateBccStateDto createBccBMDto = new CreateBccStateDto();

                    createBccBMDto.ApplicationId = createBranchCredit.ApplicationId;
                    createBccBMDto.Fk_BccId = bcc.Id; 
                    createBccBMDto.Fk_UserId = (int)AbpSession.UserId;
                    createBccBMDto.Status = "Active";
                    _bccStateAppService.CreateBccStateDetail(createBccBMDto);


                    CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                    fWobj.ApplicationId = createBranchCredit.ApplicationId;
                    fWobj.Action = "Under BCC Review";
                    fWobj.ActionBy = (int)AbpSession.UserId;
                    fWobj.ApplicationState = ApplicationState.BCCReview;
                    fWobj.isActive = true;

                    _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                    _applicationAppService.ChangeApplicationState(ApplicationState.BCCReview, createBranchCredit.ApplicationId, "Under BCC Review");

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<JsonResult> AddReccomendationByUser(int ApplicationId, int Fk_UserId, string Status, string Reason)
        {
            String response = "";
            try
            {
                var getStates = _bccStateAppService.GetBccStateListByApplicationId(ApplicationId).Result.ToList();
                if (getStates.Count > 0)
                {
                    response = "Already Recommended!";


                    foreach (var item in getStates)
                    {
                        if (item.Fk_UserId == Fk_UserId)
                        {
                            UpdateBccStateDto obj = new UpdateBccStateDto();
                            obj.Id = item.Id;
                            obj.ApplicationId = item.ApplicationId;
                            obj.Fk_UserId = item.Fk_UserId;
                            obj.Fk_BccId = item.Fk_BccId;
                            obj.Status = Status;
                            obj.Reason = Reason;

                            var update = _bccStateAppService.UpdateBccState(obj);
                            response = "Application has been recommended " + Status + " Successfully!";

                        }
                    }

                    var getUpdatedStates = _bccStateAppService.GetBccStateListByApplicationId(ApplicationId).Result.ToList();
                    int activeCount = getUpdatedStates.Where(x => x.Status == "Active").Count();

                    if (activeCount == 0)
                    {
                        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                        fWobj.ApplicationId = ApplicationId;
                        fWobj.Action = "BCC Reviewed";
                        fWobj.ActionBy = Fk_UserId;
                        fWobj.ApplicationState = ApplicationState.BCCReviewed;
                        fWobj.isActive = true;

                        await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                        _applicationAppService.ChangeApplicationState(ApplicationState.BCCReviewed, ApplicationId, "Reviewed by All Members of BCC");

                    }

                    return Json(response);
                }
                else
                {
                    return Json("States Not Found. ApplicationId: " + ApplicationId + ", UserId: " + Fk_UserId + ", Recommendation: " + Status + ", Reason: " + Reason);
                }

            }
            catch (Exception ex)
            {
                response = "ApplicationId: " + ApplicationId + ", UserId: " + Fk_UserId + ", Recommendation: " + Status + ", Reason: " + Reason + " ,Error : " + ex.ToString();
            }


            return Json(response);
        }

        public async Task<IActionResult> UpdateBccAsync(string Id)
        {
            var bcc = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListDetailById(Convert.ToInt32(Id));
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<UserDto> SdeUsers = new List<UserDto>();
            //long? userid = _userManager.AbpSession.UserId;

            //var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            //int? branchId = currentuser.Result.BranchId;
            int? branchId = Branchid();
            bool IsAdmin = User.IsInRole("Admin");
            if (IsAdmin == false)
            {

                foreach (var user in users)
                {
                    if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE") && user.BranchId == branchId)
                    {

                        SdeUsers.Add(user);
                    }

                }
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                    {

                        SdeUsers.Add(user);
                    }

                }
            }



            ViewBag.SDEUserList = new SelectList(SdeUsers, "Id", "UserName");
            List<ApplicationDto> applicationLists = new List<ApplicationDto>();
            if (IsAdmin)
            {
                bool admin = true;
                applicationLists = _applicationAppService.GetApplicationList(ApplicationState.VO_Verified, branchId, false, admin);

            }
            else
            {
                applicationLists = _applicationAppService.GetApplicationList(ApplicationState.VO_Verified, branchId, false);

            }
            ViewBag.Application = new SelectList(applicationLists, "Id", "Id");
            return View(bcc);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBccAsync(BranchCreditCommitteeListDto branchCreditCommitteeList)
        {
            try
            {

                var bcc = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListByApplicationId(branchCreditCommitteeList.ApplicationId);
                if (bcc == null)
                {
                    UpdateBranchCreditCommitteeDto committeeDto = new UpdateBranchCreditCommitteeDto();
                    committeeDto.ApplicationId = branchCreditCommitteeList.ApplicationId;
                    committeeDto.Id = branchCreditCommitteeList.Id;
                    committeeDto.SDE1_UserId = branchCreditCommitteeList.SDE1_UserId;
                    committeeDto.SDE2_UserId = branchCreditCommitteeList.SDE2_UserId;
                    committeeDto.IsActive = branchCreditCommitteeList.IsActive;
                    committeeDto.Status = branchCreditCommitteeList.Status;
                    await _branchCreditCommitteeAppService.UpdateBranchCreditCommittee(committeeDto);
                    return RedirectToAction("BccList");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IActionResult BranchCreditCommitteeList()
        {
            string screenStatus = "";
            screenStatus = ApplicationState.BCC;
            int? branchId = Branchid();
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsAdmin)
            {

                admin = true;
            }

            var branchCreditCommitteeList = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListByScreenCode(screenStatus, branchId, true, admin);
            return View(branchCreditCommitteeList.Result);
        }

        public IActionResult BCCApprovedList()
        {
            string screenStatus = "";
            screenStatus = ApplicationState.BCC_Approved;
            int? branchId = Branchid();
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsAdmin)
            {

                admin = true;
            }

            var branchCreditCommitteeList = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListByScreenCode(screenStatus, branchId, true, admin);
            return View(branchCreditCommitteeList.Result);
        }

        public IActionResult BCCApplicationDetail(int Id)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(Id);
            return View(applicationDetail);
        }

        public IActionResult BCCApplication(int Id)
        {
            var applicationDetail = _applicationAppService.GetApplicationById(Id);
            return View(applicationDetail);
        }
        [HttpPost]
        public JsonResult BCCApplicationDescripant(string Id, string comment = null)
        {

            string status = string.Empty;
            var GetScreenstatus = _applicationAppService.GetApplicationById(Convert.ToInt32(Id));



            _applicationAppService.ChangeApplicationState(ApplicationState.BM_Descripent, Convert.ToInt32(Id), "");

            UpdateBccStateDto updateBcc = new UpdateBccStateDto();
            updateBcc.ApplicationId = Convert.ToInt32(Id);
            updateBcc.Fk_UserId = (int)AbpSession.UserId;
            updateBcc.Status = "Descripent";
            var result = _bccStateAppService.UpdateBccStateBySDE(updateBcc);
            _applicationAppService.ChangeApplicationState(ApplicationState.BCC_Descripent, updateBcc.ApplicationId, comment);

            var applicationObj = _applicationAppService.GetApplicationById(Convert.ToInt32(Id));

            var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

            CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
            declineStateDto.ApplicationId = Convert.ToInt32(Id);
            declineStateDto.Fk_UserId = (int)applicationObj.CreatorUserId;
            declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
            declineStateDto.IsActive = true;
            declineStateDto.Status = ApplicationState.BCC_Descripent;
            declineStateDto.State = WorkFlowState.SDE;
            declineStateDto.Fk_BccId = result.Fk_BccId;
            _applicationDescripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


            CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

            createWorkFlow.Fk_UserId = (int)applicationObj.CreatorUserId;
            createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
            createWorkFlow.ApplicationId = Convert.ToInt32(Id);
            createWorkFlow.IsActive = true;
            createWorkFlow.Status = ApplicationState.BCC_Decline;
            createWorkFlow.Fk_BccId = result.Fk_BccId;

            _applicationAppService.ChangeWorkFlowState(createWorkFlow);
            status = "Records Descripent Successfully";


            return Json(status);
        }

        [HttpPost]
        public JsonResult BCCApplicationDecline(string Id, string comment = null)
        {

            string status = string.Empty;

            UpdateBccStateDto updateBcc = new UpdateBccStateDto();
            updateBcc.ApplicationId = Convert.ToInt32(Id);
            updateBcc.Fk_UserId = (int)AbpSession.UserId;
            updateBcc.Status = "Decline";
            var result = _bccStateAppService.UpdateBccStateBySDE(updateBcc);
            _applicationAppService.ChangeApplicationState(TFCLPortal.Applications.Dto.ApplicationState.BCC_Decline, updateBcc.ApplicationId, comment);

            var applicationObj = _applicationAppService.GetApplicationById(Convert.ToInt32(Id));

            var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

            CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
            declineStateDto.ApplicationId = Convert.ToInt32(Id);
            declineStateDto.Fk_UserId = (int)applicationObj.CreatorUserId;
            declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
            declineStateDto.IsActive = true;
            declineStateDto.Status = ApplicationState.BCC_Decline;
            declineStateDto.State = WorkFlowState.SDE;
            declineStateDto.Fk_BccId = result.Fk_BccId;
            _applicationDescripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


            CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

            createWorkFlow.Fk_UserId = (int)applicationObj.CreatorUserId;
            createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
            createWorkFlow.ApplicationId = Convert.ToInt32(Id);
            createWorkFlow.IsActive = true;
            createWorkFlow.Status = ApplicationState.BCC_Decline;
            createWorkFlow.Fk_BccId = result.Fk_BccId;

            _applicationAppService.ChangeWorkFlowState(createWorkFlow);



            status = "Records Decline Successfully";
            return Json(status);
        }
        [HttpPost]
        public JsonResult BCCApplicationApproved(string Id)
        {
            string status = string.Empty;


            UpdateBccStateDto updateBcc = new UpdateBccStateDto();
            updateBcc.ApplicationId = Convert.ToInt32(Id);
            updateBcc.Fk_UserId = (int)AbpSession.UserId;
            updateBcc.Status = "Approved";

            var result = _bccStateAppService.UpdateBccStateBySDE(updateBcc);

            var IsApproved = _customAppService.GetBccApplicationApprovedStaus(Convert.ToInt32(Id));
            if (IsApproved.Result)
            {
                _applicationAppService.ChangeApplicationState(TFCLPortal.Applications.Dto.ApplicationState.BCC_Approved, Convert.ToInt32(Id), "");

                var appData = _applicationAppService.GetApplicationById(Convert.ToInt32(Id));
                if (appData != null)
                {
                    _notificationLogAppService.SendNotification(66, appData.ClientID + " is waiting for your approval", "Kindly view BCC Approved Applications.");
                }

                var workFlow = _applicationAppService.UserInRole(WorkFlowState.BA);
                CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                createWorkFlow.Fk_UserId = (int)workFlow.Result.UserId;
                createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                createWorkFlow.IsActive = true;
                createWorkFlow.Status = ApplicationState.BCC_Approved;
                createWorkFlow.Fk_BccId = result.Fk_BccId;
                _applicationAppService.ChangeWorkFlowState(createWorkFlow);
            }


            status = "Records Approved Successfully";
            return Json(status);
        }
    }
}