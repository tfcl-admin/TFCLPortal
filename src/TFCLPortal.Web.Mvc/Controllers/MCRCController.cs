using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.BusinessPlans;
using TFCLPortal.CollateralDetails;
using TFCLPortal.Controllers;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.McrcDecisions;
using TFCLPortal.McrcDecisions.Dto;
using TFCLPortal.McrcRecords;
using TFCLPortal.McrcRecords.Dto;
using TFCLPortal.McrcStates;
using TFCLPortal.McrcStates.Dto;
using TFCLPortal.TDSLoanEligibilities;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.Web.Controllers
{
    public class MCRCController : TFCLPortalControllerBase
    {
        private readonly IUserAppService _userAppService;
        //private readonly IApplicationDescripantDeclineStateAppService _applicationDescripantDeclineStateAppService;
        //private readonly ICustomAppService _customAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IHostingEnvironment _env;

        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly ICollateralDetailAppService _collateralDetailAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;


        private readonly IApplicationAppService _applicationAppService;
        private readonly IMcrcDecisionAppService _McrcDecisionAppService;
        private readonly IRepository<McrcDecision, Int32> _McrcDecisionRepository;
        private readonly IRepository<McrcState, Int32> _McrcStateRepository;
        private readonly IMcrcRecordAppService _mcrcRecordAppService;
        private readonly IMcrcStateAppService _mcrcStateAppService;

        private readonly UserManager _userManager;

        public MCRCController(ITDSLoanEligibilityAppService tDSLoanEligibilityAppService, IHostingEnvironment env, IRepository<McrcDecision, Int32> McrcDecisionRepository, IRepository<McrcState, Int32> McrcStateRepository, IMcrcStateAppService mcrcStateAppService, IMcrcDecisionAppService McrcDecisionAppService, IMcrcRecordAppService mcrcRecordAppService, IUserAppService userAppService, IFinalWorkflowAppService finalWorkflowAppService, IBusinessPlanAppService businessPlanAppService, ICollateralDetailAppService collateralDetailAppService, ILoanEligibilityAppService loanEligibilityAppService, IApplicationAppService applicationAppService, UserManager userManager)
        {
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _userAppService = userAppService;
            _env = env;
            _mcrcRecordAppService = mcrcRecordAppService;
            _finalWorkflowAppService = finalWorkflowAppService;
            _McrcDecisionRepository = McrcDecisionRepository;
            _businessPlanAppService = businessPlanAppService;
            _collateralDetailAppService = collateralDetailAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
            _applicationAppService = applicationAppService;
            _userManager = userManager;
            _McrcDecisionAppService = McrcDecisionAppService;
            _mcrcStateAppService = mcrcStateAppService;
            _McrcStateRepository = McrcStateRepository;
        }
        public ActionResult Index()
        {
            var applications = _applicationAppService.GetShortApplicationList(ApplicationState.MCRCReview, Branchid());
            return View(applications);
        }

        public async Task<IActionResult> CreateMCRC(int Id)
        {
            ViewBag.AppId = Id;
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            //var users = _userAppService.GetAllUsers();
            List<UserDto> McrcUsers = new List<UserDto>();
            //long? userid = _userManager.AbpSession.UserId;

            //var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            //int? branchId = currentuser.Result.BranchId;
            //int? branchId = Branchid();
            bool IsAdmin = User.IsInRole("Admin");
            if (IsAdmin == false)
            {

                foreach (var user in users)
                {
                    if (user.RoleNames != null && user.RoleNames.Any(r => r == "MCRC"))
                    {

                        McrcUsers.Add(user);
                    }

                }
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.RoleNames != null && user.RoleNames.Any(r => r == "MCRC"))
                    {

                        McrcUsers.Add(user);
                    }

                }
            }



            ViewBag.McrcUserList = new SelectList(McrcUsers, "Id", "FullName");
            List<ApplicationDto> applicationLists = new List<ApplicationDto>();

            return View("CreateMCRC");
        }
        [HttpPost]
        [DisableValidation]
        public IActionResult CreateMcrc(CreateMcrcRecordDto createMcrcRecord)
        {
            try
            {
                var mcrc = _mcrcRecordAppService.GetMcrcRecordListByApplicationId(createMcrcRecord.ApplicationId);
                if (mcrc == null)
                {
                    var LastCreatedId = _mcrcRecordAppService.CreateMcrcRecordDetail(createMcrcRecord);

                    if (createMcrcRecord.User1Id != null && createMcrcRecord.User1Id != 0)
                    {
                        CreateMcrcStateDto createMcrcUser1Dto = new CreateMcrcStateDto();
                        createMcrcUser1Dto.ApplicationId = createMcrcRecord.ApplicationId;
                        createMcrcUser1Dto.Fk_McrcId = LastCreatedId;
                        createMcrcUser1Dto.Fk_UserId = (int)createMcrcRecord.User1Id;
                        createMcrcUser1Dto.Status = "Active";
                        _mcrcStateAppService.CreateMcrcStateDetail(createMcrcUser1Dto);
                    }

                    if (createMcrcRecord.User2Id != null && createMcrcRecord.User2Id != 0)
                    {
                        CreateMcrcStateDto createMcrcUser2Dto = new CreateMcrcStateDto();
                        createMcrcUser2Dto.ApplicationId = createMcrcRecord.ApplicationId;
                        createMcrcUser2Dto.Fk_McrcId = LastCreatedId;
                        createMcrcUser2Dto.Fk_UserId = (int)createMcrcRecord.User2Id;
                        createMcrcUser2Dto.Status = "Active";
                        _mcrcStateAppService.CreateMcrcStateDetail(createMcrcUser2Dto);
                    }
                    if (createMcrcRecord.User3Id != null && createMcrcRecord.User3Id != 0)
                    {
                        CreateMcrcStateDto createMcrcUser3Dto = new CreateMcrcStateDto();
                        createMcrcUser3Dto.ApplicationId = createMcrcRecord.ApplicationId;
                        createMcrcUser3Dto.Fk_McrcId = LastCreatedId;
                        createMcrcUser3Dto.Fk_UserId = (int)createMcrcRecord.User3Id;
                        createMcrcUser3Dto.Status = "Active";
                        _mcrcStateAppService.CreateMcrcStateDetail(createMcrcUser3Dto);
                    }
                    if (createMcrcRecord.User4Id != null && createMcrcRecord.User4Id != 0)
                    {
                        CreateMcrcStateDto createMcrcUser4Dto = new CreateMcrcStateDto();
                        createMcrcUser4Dto.ApplicationId = createMcrcRecord.ApplicationId;
                        createMcrcUser4Dto.Fk_McrcId = LastCreatedId;
                        createMcrcUser4Dto.Fk_UserId = (int)createMcrcRecord.User4Id;
                        createMcrcUser4Dto.Status = "Active";
                        _mcrcStateAppService.CreateMcrcStateDetail(createMcrcUser4Dto);
                    }
                    if (createMcrcRecord.User5Id != null && createMcrcRecord.User5Id != 0)
                    {
                        CreateMcrcStateDto createMcrcUser5Dto = new CreateMcrcStateDto();
                        createMcrcUser5Dto.ApplicationId = createMcrcRecord.ApplicationId;
                        createMcrcUser5Dto.Fk_McrcId = LastCreatedId;
                        createMcrcUser5Dto.Fk_UserId = (int)createMcrcRecord.User5Id;
                        createMcrcUser5Dto.Status = "Active";
                        _mcrcStateAppService.CreateMcrcStateDetail(createMcrcUser5Dto);
                    }

                    CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                    fWobj.ApplicationId = createMcrcRecord.ApplicationId;
                    fWobj.Action = "Under MCRC Review";
                    fWobj.ActionBy = (int)AbpSession.UserId;
                    fWobj.ApplicationState = ApplicationState.MCRCCreated;
                    fWobj.isActive = true;

                    _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                    _applicationAppService.ChangeApplicationState(ApplicationState.MCRCCreated, createMcrcRecord.ApplicationId, "Under MCRC Review");


                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("ApplicationId", "MCRC has already been created against this Application");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult UnderReview()
        {
            var applications = _applicationAppService.GetShortApplicationList(ApplicationState.MCRCCreated, Branchid());

            if (applications != null)
            {
                foreach (var app in applications)
                {
                    var getStates = _mcrcStateAppService.GetMcrcStateListByApplicationId(app.Id).Result.Where(x => x.Fk_UserId == (int)AbpSession.UserId && x.Status == "Active").LastOrDefault();
                    if (getStates != null)
                    {
                        app.Remarks = "Active";
                    }
                }
            }
            return View(applications);
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


        public async Task<ActionResult> DecisionPartial(int appid, int userid)
        {
            ViewBag.UserId = userid;
            ViewBag.AppId = appid;
            var appData = _applicationAppService.GetApplicationById(appid);

            ViewBag.ClientId = appData.ClientID;
            ViewBag.ApplicantName = appData.ClientName;
            ViewBag.SchoolName = appData.SchoolName;
            ViewBag.Cnic = appData.CNICNo;

            var Mcrc = _mcrcRecordAppService.GetMcrcRecordListByApplicationId(appid);
            var getStates = _mcrcStateAppService.GetMcrcStateListByApplicationId(appid).Result.ToList();
            var getUsers = _userAppService.GetAllUsers().ToList();

            ViewBag.McrcNo = "Mcrc-" + Mcrc.Id;
            ViewBag.UserId1 = Mcrc.User1Id;
            ViewBag.UserId2 = Mcrc.User2Id;
            ViewBag.UserId3 = Mcrc.User3Id;
            ViewBag.UserId4 = Mcrc.User4Id;
            ViewBag.UserId5 = Mcrc.User5Id;

            if (Mcrc.User1Id != 0)
            {

                ViewBag.McrcMember1Name = getUsers.Where(x => x.Id == Mcrc.User1Id).FirstOrDefault().FullName;
                ViewBag.McrcMember1Decision = getStates.Where(x => x.Fk_UserId == Mcrc.User1Id).LastOrDefault().Status;
                ViewBag.McrcMember1Reason = getStates.Where(x => x.Fk_UserId == Mcrc.User1Id).LastOrDefault().Reason;
            }
            if (Mcrc.User2Id != 0)
            {
                ViewBag.McrcMember2Name = getUsers.Where(x => x.Id == Mcrc.User2Id).FirstOrDefault().FullName;
                ViewBag.McrcMember2Decision = getStates.Where(x => x.Fk_UserId == Mcrc.User2Id).LastOrDefault().Status;
                ViewBag.McrcMember2Reason = getStates.Where(x => x.Fk_UserId == Mcrc.User2Id).LastOrDefault().Reason;
            }
            if (Mcrc.User3Id != 0)
            {

                ViewBag.McrcMember3Name = getUsers.Where(x => x.Id == Mcrc.User3Id).FirstOrDefault().FullName;
                ViewBag.McrcMember3Decision = getStates.Where(x => x.Fk_UserId == Mcrc.User3Id).LastOrDefault().Status;
                ViewBag.McrcMember3Reason = getStates.Where(x => x.Fk_UserId == Mcrc.User3Id).LastOrDefault().Reason;
            }
            if (Mcrc.User4Id != 0)
            {
                ViewBag.McrcMember4Name = getUsers.Where(x => x.Id == Mcrc.User4Id).FirstOrDefault().FullName;
                ViewBag.McrcMember4Decision = getStates.Where(x => x.Fk_UserId == Mcrc.User4Id).LastOrDefault().Status;
                ViewBag.McrcMember4Reason = getStates.Where(x => x.Fk_UserId == Mcrc.User4Id).LastOrDefault().Reason;
            }
            if (Mcrc.User5Id != 0)
            {
                ViewBag.McrcMember5Name = getUsers.Where(x => x.Id == Mcrc.User5Id).FirstOrDefault().FullName;
                ViewBag.McrcMember5Decision = getStates.Where(x => x.Fk_UserId == Mcrc.User5Id).LastOrDefault().Status;
                ViewBag.McrcMember5Reason = getStates.Where(x => x.Fk_UserId == Mcrc.User5Id).LastOrDefault().Reason;
            }

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


            return View("DecisionPartial");
        }

        [HttpPost]
        public async Task<JsonResult> CreateMcrcDecision(CreateMcrcDecisionDto input)
        {
            string response = "";
            try
            {
                var Fileuploadpath = Path.Combine(_env.WebRootPath, "uploads");
                string rootPath = Path.Combine(Fileuploadpath, input.ApplicationId.ToString());

                if (input.file != null)
                {
                    string fileName = "McrcDecision_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    string extension = System.IO.Path.GetExtension(input.file.FileName);
                    input.DecisionFile = "/uploads/" + input.ApplicationId.ToString() + "/" + fileName + extension;

                    UploadImagestoServer(input.file, rootPath, fileName);
                }

                await _McrcDecisionAppService.CreateMcrcDecision(input);

                if (input.McrcMember1UserId != 0)
                {
                    var state = _McrcStateRepository.GetAll().Where(x => x.Fk_UserId == input.McrcMember1UserId).LastOrDefault();
                    state.Status = input.McrcMember1Recommendation;
                    state.Reason = input.McrcMember1Reason;
                    _McrcStateRepository.Update(state);
                }
                if (input.McrcMember2UserId != 0)
                {
                    var state = _McrcStateRepository.GetAll().Where(x => x.Fk_UserId == input.McrcMember2UserId).LastOrDefault();
                    state.Status = input.McrcMember2Recommendation;
                    state.Reason = input.McrcMember2Reason;
                    _McrcStateRepository.Update(state);
                }
                if (input.McrcMember3UserId != 0)
                {
                    var state = _McrcStateRepository.GetAll().Where(x => x.Fk_UserId == input.McrcMember3UserId).LastOrDefault();
                    state.Status = input.McrcMember3Recommendation;
                    state.Reason = input.McrcMember3Reason;
                    _McrcStateRepository.Update(state);
                }
                if (input.McrcMember4UserId != 0)
                {
                    var state = _McrcStateRepository.GetAll().Where(x => x.Fk_UserId == input.McrcMember4UserId).LastOrDefault();
                    state.Status = input.McrcMember4Recommendation;
                    state.Reason = input.McrcMember4Reason;
                    _McrcStateRepository.Update(state);
                }
                if (input.McrcMember5UserId != 0)
                {
                    var state = _McrcStateRepository.GetAll().Where(x => x.Fk_UserId == input.McrcMember5UserId).LastOrDefault();
                    state.Status = input.McrcMember5Recommendation;
                    state.Reason = input.McrcMember5Reason;
                    _McrcStateRepository.Update(state);
                }

                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = input.ApplicationId;
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.isActive = true;

                if (input.Decision == "Decline")
                {
                    fWobj.Action = "Declined By Mcrc";
                    fWobj.ApplicationState = ApplicationState.MCRCReviewed;
                    _applicationAppService.ChangeApplicationState(ApplicationState.MCRCReviewed, input.ApplicationId, "Declined By Mcrc");
                }
                else if (input.Decision == "Discrepent")
                {
                    fWobj.Action = "Discrepented By Mcrc";
                    fWobj.ApplicationState = ApplicationState.MCRCReviewed;
                    _applicationAppService.ChangeApplicationState(ApplicationState.MCRCReviewed, input.ApplicationId, "Discrepented By Mcrc");
                }
                else if (input.Decision == "Approve")
                {
                    fWobj.Action = "Approved by Mcrc";
                    fWobj.ApplicationState = ApplicationState.MCRCReviewed;
                    _applicationAppService.ChangeApplicationState(ApplicationState.MCRCReviewed, input.ApplicationId, "Approved by Mcrc");
                }
                else if (input.Decision == "Discrepent & Represent")
                {
                    fWobj.Action = "Discrepent & Represent by Mcrc";
                    fWobj.ApplicationState = ApplicationState.MCRCReviewed;
                    _applicationAppService.ChangeApplicationState(ApplicationState.MCRCReviewed, input.ApplicationId, "Discrepent & Represent by Mcrc");
                }

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                response = "Mcrc Decision saved successfully!";


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

        public async Task<ActionResult> ApplyDecision(int id)
        {
            ViewBag.Id = id;
            var appData = _McrcDecisionAppService.GetMcrcDecisionById(id);

            ViewBag.Decision = appData.Decision;
            ViewBag.Reason = appData.Reason;
            ViewBag.AppId = appData.ApplicationId;

            return View("ApplyDecision");
        }

        [HttpPost]
        public async Task<JsonResult> SaveAppliedDecision(int ApplicationId, int Id)
        {
            string response = "";
            try
            {
                var appData = _McrcDecisionAppService.GetMcrcDecisionById(Id);

                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = ApplicationId;
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.isActive = true;

                if (appData.Decision == "Decline")
                {
                    fWobj.Action = "Declined By BM";
                    fWobj.ApplicationState = ApplicationState.Decline;
                    _applicationAppService.ChangeApplicationState(ApplicationState.Decline, ApplicationId, "Declined By BM");
                }
                else if (appData.Decision == "Discrepent")
                {
                    fWobj.Action = "Discrepented By Mcrc";
                    fWobj.ApplicationState = ApplicationState.Submitted;
                    _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, ApplicationId, "Discrepented By Mcrc");
                }
                else if (appData.Decision == "Approve")
                {
                    fWobj.Action = "Approved by Mcrc";
                    fWobj.ApplicationState = ApplicationState.BCC_Approved;
                    _applicationAppService.ChangeApplicationState(ApplicationState.BCC_Approved, ApplicationId, "Approved by Mcrc");
                }
                else if (appData.Decision == "Discrepent & Represent")
                {
                    fWobj.Action = "Discrepent & Represent by Mcrc";
                    fWobj.ApplicationState = ApplicationState.Submitted;
                    _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, ApplicationId, "Discrepent & Represent by Mcrc");
                }

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                response = "Mcrc Decision applied successfully!";

                var decision = _McrcDecisionRepository.Get(Id);
                decision.isApplied = true;
                var applied = _McrcDecisionRepository.Update(decision);

            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(response);

        }
    }
}
