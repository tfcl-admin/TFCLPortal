using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Controllers;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates;
using TFCLPortal.ApplicationWorkFlows.ApplicationDescripantDeclineStates.Dto;
using TFCLPortal.ApplicationWorkFlows.BranchCreditCommittees;
using TFCLPortal.Authorization.Users;
using TFCLPortal.BranchManagerActions;
using TFCLPortal.Users;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Users.Dto;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.Branches;

namespace TFCLPortal.Web.Mvc.Controllers
{
    [AbpMvcAuthorize]
    public class ApplicationController : TFCLPortalControllerBase
    {
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApplicationDescripantDeclineStateAppService _applicationDescripantDeclineStateAppService;
        private readonly IBranchCreditCommitteeAppService _branchCreditCommitteeAppService;
        private readonly IBranchManagerActionAppService _branchManagerActionAppService;
        private readonly IProductTypeAppService _productTypeAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;
        public ApplicationController(UserManager userManager, IBranchDetailAppService branchDetailAppService, IProductTypeAppService productTypeAppService, IUserAppService userAppService, IBranchManagerActionAppService branchManagerActionAppService)
        {
            _userAppService = userAppService;
            _branchDetailAppService = branchDetailAppService;
            _productTypeAppService = productTypeAppService;
            _branchManagerActionAppService = branchManagerActionAppService;
            _userManager = userManager;
            _applicationAppService = IocManager.Instance.Resolve<IApplicationAppService>();
            _applicationDescripantDeclineStateAppService = IocManager.Instance.Resolve<IApplicationDescripantDeclineStateAppService>();
            _branchCreditCommitteeAppService = IocManager.Instance.Resolve<IBranchCreditCommitteeAppService>();
        }
        public IActionResult ApplicationDashboard()
        {
            return View();
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

        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> Applications(DateTime? startdate, DateTime? enddate, string screenText, string sdeText)
        {
            return RedirectToAction("Applications", "Application", new { screen = screenText, startDate = startdate, endDate = enddate, sde=sdeText });
        }


        public List<string> getApplicationStateList()
        {
            List<string> StrList = new List<string>();

            StrList.Add(ApplicationState.Created);
            StrList.Add(ApplicationState.InProcess);
            StrList.Add(ApplicationState.Submitted);
            StrList.Add(ApplicationState.Decline);
            StrList.Add(ApplicationState.Screened);
            StrList.Add(ApplicationState.Discrepent);
            StrList.Add(ApplicationState.BCCReview);
            StrList.Add(ApplicationState.BCCReviewed);
            StrList.Add(ApplicationState.MCRCReview);
            StrList.Add(ApplicationState.MCRCReviewed);
            StrList.Add(ApplicationState.MCRCReviewed);
            StrList.Add(ApplicationState.BCC_Approved);
            StrList.Add(ApplicationState.MC_Authorized);
            StrList.Add(ApplicationState.Disbursed);

            return StrList;
        }

       
        public IActionResult Applications(string screen,string sde, DateTime? startDate, DateTime? endDate)
        {
            if (screen == null) { screen = ""; }
            string screenStatus = screen;
            
            if (screen == "") { ViewBag.ScreenTitle = "Track Loan Application"; } else { ViewBag.ScreenTitle = screen + " Applications"; }
            
            var IsVo = User.IsInRole("VO");
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;

            ViewBag.ApplicationStateList = new SelectList(getApplicationStateList());
            

            if (IsVo)
            {
                //screenStatus = ApplicationState.Submitted;
            }
            else if (IsBm)
            {
                //screenStatus = ApplicationState.Submitted;
            }
            else if (IsAdmin)
            {
                //screenStatus = ApplicationState.Submitted;
                admin = true;
            }


            var sdesList = getSDEs();

            ViewBag.SDEUserList = new SelectList(sdesList,"FullName", "FullName");


            int? branchId = Branchid();

            List<ApplicationDto> mobilizationList = new List<ApplicationDto>();


            if(screenStatus=="Enhancement")
            {
                mobilizationList = _applicationAppService.GetApplicationList("", branchId, true, admin,true);
            }
            else
            {
                mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            }



            List<ApplicationDto> returnList = new List<ApplicationDto>();
            if (startDate != null && endDate != null)
            {
                ViewBag.StartDate = startDate;
                ViewBag.EndDate = endDate;
                returnList=mobilizationList.Where(x => x.AppDate >= startDate && x.AppDate <= endDate).ToList();
            }
            if (startDate != null)
            {
                ViewBag.StartDate = startDate;
                returnList = mobilizationList.Where(x => x.AppDate >= startDate).ToList();
            }
            if (endDate != null)
            {
                ViewBag.EndDate = endDate;
                returnList = mobilizationList.Where(x => x.AppDate <= endDate).ToList();
            }
            else
            {
                returnList = mobilizationList.ToList();
            }

            if (sde != "" && sde != null)
            {
                returnList = returnList.Where(x => x.SDEName == sde || x.Transferred==sde).ToList();
            }


            return View(returnList);

        }

        public List<UserDto> getSDEs()
        {
            var users = (_userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Result.Items;
            List<UserDto> SdeUsers = new List<UserDto>();
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

            return SdeUsers;
        }

        public IActionResult CreateApplications()
        {
            string screenStatus = "";
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsBm)
            {

                screenStatus = ApplicationState.Created;
            }
            else if (IsAdmin)
            {
                screenStatus = ApplicationState.Created;
                admin = true;
            }
            int? branchId = Branchid();
            var mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            return View(mobilizationList);
        }

        public IActionResult InprocessApplications()
        {
            string screenStatus = "";
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsBm)
            {

                screenStatus = ApplicationState.InProcess;
            }
            else if (IsAdmin)
            {
                screenStatus = ApplicationState.InProcess;
                admin = true;
            }
            int? branchId = Branchid();
            var mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            return View(mobilizationList);
        }

        public IActionResult VerifiedApplications()
        {
            string screenStatus = "";
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsBm)
            {

                screenStatus = ApplicationState.VO_Verified;
            }
            else if (IsAdmin)
            {
                screenStatus = ApplicationState.VO_Verified;
                admin = true;
            }
            int? branchId = Branchid();
            var mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            return View(mobilizationList);
        }


        public IActionResult UnderVerificationApplications()
        {
            string screenStatus = "";
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsBm)
            {

                screenStatus = ApplicationState.Verification;
            }
            else if (IsAdmin)
            {
                screenStatus = ApplicationState.Verification;
                admin = true;
            }
            int? branchId = Branchid();
            var mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            return View(mobilizationList);
        }

        public IActionResult ScreeningApplications()
        {
            string screenStatus = "";
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsBm)
            {

                screenStatus = ApplicationState.Screening;
            }
            else if (IsAdmin)
            {
                screenStatus = ApplicationState.Screening;
                admin = true;
            }
            int? branchId = Branchid();
            var mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            return View(mobilizationList);
        }

        public IActionResult ScreenedApplications()
        {
            string screenStatus = "";
            var IsVo = User.IsInRole("VO");
            var IsBm = User.IsInRole("BM");
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsVo)
            {
                screenStatus = ApplicationState.VO_Verified;

            }
            else if (IsBm)
            {

                screenStatus = ApplicationState.BM_Verified;
            }
            else if (IsAdmin)
            {
                screenStatus = ApplicationState.BM_Verified;
                admin = true;
            }
            int? branchId = Branchid();
            var mobilizationList = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            return View(mobilizationList);
        }

        public IActionResult ApplicationDiscrepencies(int Id)
        {
            ViewBag.Applicationid = Id;
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

            var detail = _branchManagerActionAppService.GetBranchManagerActionByApplicationId(Id);
            return View(detail);
        }

        public IActionResult ApplicationDetail(int Id)
        {
            var mobilizationDetail = _applicationAppService.GetApplicationById(Id);
            return View(mobilizationDetail);
        }
        public IActionResult ApplicationDeclineDetail()
        {
            int? branchId = Branchid();
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsAdmin)
            {

                admin = true;
            }
            var mobilizationDetail = _applicationAppService.GetApplicationList("Decline", branchId, true, admin);
            return View(mobilizationDetail);
        }

        public IActionResult ApplicationDescripantDetail()
        {
            int? branchId = Branchid();
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsAdmin)
            {

                admin = true;
            }
            var mobilizationDetail = _applicationAppService.GetApplicationList("Descripent", branchId, true, admin);
            return View(mobilizationDetail);
        }

        public IActionResult DisbursedFiles()
        {
            int? branchId = Branchid();
            var IsAdmin = User.IsInRole("Admin");
            bool admin = false;
            if (IsAdmin)
            {

                admin = true;
            }
            var mobilizationDetail = _applicationAppService.GetApplicationList(ApplicationState.Disbursed, branchId, true, admin);
            return View(mobilizationDetail);
        }

        [HttpPost]
        public JsonResult ApplicationScreenApprovedDescripant(string Id, string comment)
        {
            var result = _applicationAppService.GetApplicationById(Convert.ToInt32(Id));
            string status = string.Empty;
            if (result != null)
            {

                var IsVo = User.IsInRole("VO");
                var IsBm = User.IsInRole("BM");

                if (!string.IsNullOrEmpty(comment))
                {
                    result.Comments = comment;
                    // result.Result.ScreenStatus = "discrepant";
                    status = "Records discrepant Successfully";


                    if (IsVo)
                    {
                        ///change application state to  vo discrepent
                        _applicationAppService.ChangeApplicationState(ApplicationState.VO_Descripent, Convert.ToInt32(Id), "");

                        var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

                        CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
                        declineStateDto.ApplicationId = Convert.ToInt32(Id);
                        declineStateDto.Fk_UserId = (int)result.CreatorUserId;
                        declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        declineStateDto.IsActive = true;
                        declineStateDto.Status = ApplicationState.VO_Descripent;
                        declineStateDto.State = WorkFlowState.SDE;
                        _applicationDescripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = (int)result.CreatorUserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = ApplicationState.VO_Descripent;

                        _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                    }

                    else if (IsBm)
                    {
                        ///change application state to  vo discrepent
                        _applicationAppService.ChangeApplicationState(ApplicationState.BM_Descripent, Convert.ToInt32(Id), "");

                        var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

                        CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
                        declineStateDto.ApplicationId = Convert.ToInt32(Id);
                        declineStateDto.Fk_UserId = (int)result.CreatorUserId;
                        declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        declineStateDto.IsActive = true;
                        declineStateDto.Status = ApplicationState.BM_Descripent;
                        declineStateDto.State = WorkFlowState.SDE;
                        _applicationDescripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = (int)result.CreatorUserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = ApplicationState.BM_Descripent;

                        _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                    }
                }
                else
                {
                    // result.Result.ScreenStatus = "Approved";
                    status = "Records Approved Successfully";


                    if (IsVo)
                    {
                        ///change application state to  vo discrepent
                        _applicationAppService.ChangeApplicationState(ApplicationState.VO_Verified, Convert.ToInt32(Id), "");

                        var workFlow = _applicationAppService.UserInRole(WorkFlowState.BM);

                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = ApplicationState.VO_Verified;

                        _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                    }

                    else if (IsBm)
                    {
                        ///change application state to  vo discrepent
                        ///
                        //check here before given approved to application create bcc first check
                        var branchCreditCommettee = _branchCreditCommitteeAppService.GetBranchCreditCommitteeListByApplicationId(Convert.ToInt32(Id));
                        if (branchCreditCommettee == null)
                        {
                            status = "Please Create Bcc against this Application Number " + Id + " Before Approving this Application ";
                            return Json(status);

                        }


                        _applicationAppService.ChangeApplicationState(ApplicationState.BM_Verified, Convert.ToInt32(Id), "");
                        _applicationAppService.ChangeApplicationState(ApplicationState.BCC, Convert.ToInt32(Id), "");

                        var workFlow = _applicationAppService.UserInRole(WorkFlowState.BCC);

                        CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                        createWorkFlow.Fk_UserId = workFlow.Result.UserId;
                        createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                        createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                        createWorkFlow.IsActive = true;
                        createWorkFlow.Status = ApplicationState.BM_Verified;

                        _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                        return Json(status);
                    }
                }
            }
            return Json(status);
        }

        [HttpPost]
        public JsonResult ApplicationScreenDecline(string Id, string comment = null)
        {
            var result = _applicationAppService.GetApplicationById(Convert.ToInt32(Id));
            string status = string.Empty;
            if (result != null)
            {
                if (!string.IsNullOrEmpty(comment))
                {
                    result.Comments = comment;
                    // result.Result.ScreenStatus = "Decline";
                    status = "Records Decline Successfully";
                }
                UpdateApplicationDto updateApplication = new UpdateApplicationDto();

                var IsVo = User.IsInRole("VO");
                var IsBm = User.IsInRole("BM");
                if (IsVo)
                {
                    ///change application state to  vo discrepent
                    _applicationAppService.ChangeApplicationState(ApplicationState.VO_Decline, Convert.ToInt32(Id), "");

                    var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

                    CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
                    declineStateDto.ApplicationId = Convert.ToInt32(Id);
                    declineStateDto.Fk_UserId = (int)result.CreatorUserId;
                    declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                    declineStateDto.IsActive = true;
                    declineStateDto.Status = ApplicationState.VO_Decline;
                    declineStateDto.State = WorkFlowState.SDE;
                    _applicationDescripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


                    CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                    createWorkFlow.Fk_UserId = (int)result.CreatorUserId;
                    createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                    createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                    createWorkFlow.IsActive = true;
                    createWorkFlow.Status = ApplicationState.VO_Decline;

                    _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                }

                else if (IsBm)
                {
                    ///change application state to  vo discrepent
                    _applicationAppService.ChangeApplicationState(ApplicationState.BM_Decline, Convert.ToInt32(Id), "");

                    var workFlow = _applicationAppService.UserInRole(WorkFlowState.SDE);

                    CreateApplicationDescripantDeclineStateDto declineStateDto = new CreateApplicationDescripantDeclineStateDto();
                    declineStateDto.ApplicationId = Convert.ToInt32(Id);
                    declineStateDto.Fk_UserId = (int)result.CreatorUserId;
                    declineStateDto.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                    declineStateDto.IsActive = true;
                    declineStateDto.Status = ApplicationState.BM_Decline;
                    declineStateDto.State = WorkFlowState.SDE;
                    _applicationDescripantDeclineStateAppService.CreateApplicationDescripantDecline(declineStateDto);


                    CreateWorkFlowApplicationStateDto createWorkFlow = new CreateWorkFlowApplicationStateDto();

                    createWorkFlow.Fk_UserId = (int)result.CreatorUserId;
                    createWorkFlow.Fk_WorkFlowId = workFlow.Result.WorkFlowId;
                    createWorkFlow.ApplicationId = Convert.ToInt32(Id);
                    createWorkFlow.IsActive = true;
                    createWorkFlow.Status = ApplicationState.BM_Decline;

                    _applicationAppService.ChangeWorkFlowState(createWorkFlow);
                }

                //updateApplication.Id = result.Result.Id;
                //updateApplication.ClientName = result.Result.ClientName;
                //updateApplication.MobileNo = result.Result.MobileNo;
                //updateApplication.LandLineNo = result.Result.LandLineNo;
                //updateApplication.CNICNo = result.Result.CNICNo;
                //updateApplication.Address = result.Result.Address;
                //updateApplication.SchoolName = result.Result.SchoolName;
                //updateApplication.MobilizationStatus = result.Result.MobilizationStatus;
                //updateApplication.ProductType = result.Result.ProductType;
                //updateApplication.NextMeeting = result.Result.NextMeeting;
                //updateApplication.ScreenStatus = result.Result.ScreenStatus;
                //updateApplication.Comments = result.Result.Comments;

                // _applicationAppService.UpdateApplication(updateApplication);

            }
            return Json(status);
        }

        public IActionResult ApplicationWorkFlow()
        {
            return View();
        }
    }
}