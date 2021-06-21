using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Abp.Data;
using Abp.Dependency;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.Applications;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Controllers;
using TFCLPortal.Customs;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.Mobilizations;
using TFCLPortal.Mobilizations.Dto;
using TFCLPortal.ProductMarkupRates;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.Web.Models.MobilizationSearch;

namespace TFCLPortal.Web.Mvc.Controllers
{
    public class MobilizationController : TFCLPortalControllerBase
    {
        private readonly IMobilizationAppService _mobilizationAppService;
        private readonly ICustomAppService _customAppService;
        private readonly IMobilizationStatusAppService _mobilizationAppServiceStatus;
        private readonly IProductTypeAppService _productAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;
        public MobilizationController(IUserAppService userAppService, IApplicationAppService applicationAppService, UserManager userManager, ICustomAppService customAppService)
        {
            _userManager = userManager;
            _mobilizationAppService = IocManager.Instance.Resolve<IMobilizationAppService>();
            _productAppService = IocManager.Instance.Resolve<IProductTypeAppService>();
            _customAppService = customAppService;
            _mobilizationAppServiceStatus = IocManager.Instance.Resolve<IMobilizationStatusAppService>();
            _userAppService = userAppService;
            _applicationAppService = applicationAppService;
        }
        public IActionResult Index()
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
        [HttpGet]
        public async Task<IActionResult> Mobilizations(int? page)
        {



            // return View(await _context.Sermon.OrderByDescending(x => x.SermonDate).ToListAsync());

            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<UserDto> SdeUsers = new List<UserDto>();
            //long? userid = _userManager.AbpSession.UserId;

            //var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            //int? branchId = currentuser.Result.BranchId;
            bool IsAdmin = User.IsInRole("Admin");
            if (IsAdmin == false)
            {
                int? branch = Branchid();

                if (branch != null && branch != 0)
                {
                    foreach (var user in users)
                    {
                        if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE") && user.BranchId == branch)
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


            var productList = _productAppService.GetAllList();
            var mobilizationStatusList = _mobilizationAppServiceStatus.GetAllList();
            ViewBag.ApplicationStatuslist = new SelectList(mobilizationStatusList, "Id", "Name");
            ViewBag.SDEUserList = new SelectList(SdeUsers, "Id", "FullName");
            ViewBag.ProductList = new SelectList(productList, "Id", "Name");


            string screenStatus = "";
            var IsVo = User.IsInRole("VO");
            var IsBm = User.IsInRole("BM");
            bool admin = false;
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
            int? branchId = Branchid();
            var applications = _applicationAppService.GetApplicationList(screenStatus, branchId, true, admin);
            var mobilizationList = _mobilizationAppService.GetMobilizationList();
            if (branchId != null && branchId != 0)
            {
                mobilizationList = mobilizationList.Where(x => x.Fk_BranchId == (int)branchId).ToList();
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


            var pager = new Pager(returnList.Count(), page);

            MobilizationSearchViewModel searchViewModel = new MobilizationSearchViewModel();
            //searchViewModel.MobilizationList = mobilizationList.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            searchViewModel.MobilizationList = returnList;
            searchViewModel.Pager = pager;
            return View(searchViewModel);
        }
        private readonly IActiveTransactionProvider _transactionProvider;



        [HttpPost]
        public async Task<IActionResult> Mobilizations(string startdate, string enddate, string nextmeeting, string ProductId, string MobilizationStatusId, string SDEUserId, int? page)
        {
            //List<GetMobilizationListDto> mobilizationList = new List<GetMobilizationListDto>();
            long sdeId = 0;
            long productId = 0;
            long statusId = 0;

            if (SDEUserId != null)
            {
                sdeId = Convert.ToInt64(SDEUserId);
            }
            if (ProductId != null)
            {
                productId = Convert.ToInt64(ProductId);
            }
            if (MobilizationStatusId != null)
            {
                statusId = Convert.ToInt64(MobilizationStatusId);
            }

            //long? userid = _userManager.AbpSession.UserId;

            //var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            //int? branch = currentuser.Result.BranchId;
            bool IsAdmin = User.IsInRole("Admin");


            var applications = _applicationAppService.GetApplicationList("", Branchid(), true, IsAdmin);
            var mobilizationList = _mobilizationAppService.GetMobilizationList();
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


            if (startdate != null)
            {
                returnList = returnList.FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate));
            }
            if (enddate != null)
            {
                returnList = returnList.FindAll(x => x.CreationTime <= Convert.ToDateTime(enddate));
            }
            if (nextmeeting != null)
            {
                returnList = returnList.FindAll(x => x.NextMeeting == Convert.ToDateTime(nextmeeting));
            }
            if (productId != null && productId != 0)
            {
                returnList = returnList.FindAll(x => x.ProductType == productId);
            }
            if (statusId != null && statusId != 0)
            {
                returnList = returnList.FindAll(x => x.MobilizationStatus == statusId);
            }
            if (sdeId != null && sdeId != 0)
            {
                returnList = returnList.FindAll(x => x.CreatorUserId == sdeId);
            }

            //if (startdate != null && enddate != null && nextmeeting != null && ProductId != null && MobilizationStatusId != null && SDEUserId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.NextMeeting == Convert.ToDateTime(nextmeeting) && x.CreatorUserId == sdeId && x.MobilizationStatus == statusId && x.ProductType == productId);
            //}
            //else if (startdate != null && enddate != null && nextmeeting != null && ProductId != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.NextMeeting == Convert.ToDateTime(nextmeeting) && x.MobilizationStatus == statusId && x.ProductType == productId);

            //}
            //else if (startdate != null && enddate != null && nextmeeting != null && SDEUserId != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.NextMeeting == Convert.ToDateTime(nextmeeting) && x.CreatorUserId == sdeId && x.MobilizationStatus == statusId);

            //}
            //else if (startdate != null && enddate != null && nextmeeting != null && ProductId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.NextMeeting == Convert.ToDateTime(nextmeeting) && x.ProductType == productId);

            //}
            //else if (startdate != null && enddate != null && ProductId != null && MobilizationStatusId != null && SDEUserId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.CreatorUserId == sdeId && x.MobilizationStatus == statusId && x.ProductType == productId);
            //}
            //else if (startdate != null && enddate != null && ProductId != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.MobilizationStatus == statusId && x.ProductType == productId);

            //}
            //else if (startdate != null && enddate != null && nextmeeting != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate) && x.NextMeeting == Convert.ToDateTime(nextmeeting));
            //}
            //else if (startdate != null && enddate != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate));
            //}
            //else if (startdate != null && enddate != null && SDEUserId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate)).Where(x => x.CreatorUserId == sdeId).ToList();
            //}
            //else if (startdate != null && enddate != null && ProductId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate)).Where(x => x.ProductType == productId).ToList();
            //}
            //else if (startdate != null && enddate != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreationTime >= Convert.ToDateTime(startdate) && x.CreationTime <= Convert.ToDateTime(enddate)).Where(x => x.MobilizationStatus == statusId).ToList();
            //}
            //else if (SDEUserId != null && ProductId != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.ProductType == productId && x.MobilizationStatus == statusId && x.CreatorUserId == sdeId).ToList();
            //}
            //else if (ProductId != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.ProductType == productId && x.MobilizationStatus == statusId).ToList();
            //}
            //else if (SDEUserId != null && MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreatorUserId == sdeId && x.MobilizationStatus == statusId).ToList();
            //}
            //else if (SDEUserId != null && ProductId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.CreatorUserId == sdeId && x.ProductType == productId).ToList();
            //}
            //else if (nextmeeting != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().FindAll(x => x.NextMeeting >= Convert.ToDateTime(nextmeeting));
            //}
            //else if (SDEUserId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().Where(x => x.CreatorUserId == sdeId).ToList();
            //}
            //else if (ProductId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().Where(x => x.ProductType == productId).ToList();
            //}
            //else if (MobilizationStatusId != null)
            //{
            //    mobilizationList = _mobilizationAppService.GetMobilizationList().Where(x => x.MobilizationStatus == statusId).ToList();
            //}


            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<UserDto> SdeUsers = new List<UserDto>();

            if (IsAdmin == false)
            {
                int? branchId = Branchid();
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



            //var ApplicationStatuslist = new List<SelectListItem>
            //{
            //    new SelectListItem{ Text="Created", Value = "Created" },
            //    new SelectListItem{ Text="In Process", Value = "In Process" },
            //    new SelectListItem{ Text="Submitted", Value = "Submitted" },
            //    new SelectListItem{ Text="In Verification", Value = "In Verification" },
            //    new SelectListItem{ Text="VO Verified", Value = "VO Verified" },
            //    new SelectListItem{ Text="VO Descripent", Value = "VO Descripent" },
            //    new SelectListItem{ Text="VO Decline", Value = "VO Decline" },
            //    new SelectListItem{ Text="Screening", Value = "Screening" },
            //    new SelectListItem{ Text="BM Verified", Value = "BM Verified" },
            //    new SelectListItem{ Text="BM Descripent", Value = "BM Descripent" },
            //    new SelectListItem{ Text="BM Decline", Value = "BM Decline" },
            //    new SelectListItem{ Text="BCC", Value = "BCC" },
            //    new SelectListItem{ Text="BCC Approved", Value = "BCC Approved" },
            //    new SelectListItem{ Text="BCC Descripent", Value = "BCC Descripent" },
            //    new SelectListItem{ Text="BCC Decline", Value = "BCC Decline" },
            //    new SelectListItem{ Text="Disbursed", Value = "Disbursed" },
            //    new SelectListItem{ Text="Closed", Value = "Closed" },
            //    new SelectListItem{ Text="Force Decline", Value = "Force Decline" },
            //    new SelectListItem{ Text="Select Application State", Value = "Select", Selected = true }
            //};

            //ViewBag.ApplicationStatuslist = ApplicationStatuslist;


            var productList = _productAppService.GetAllList();
            var mobilizationStatusList = _mobilizationAppServiceStatus.GetAllList();
            ViewBag.ApplicationStatuslist = new SelectList(mobilizationStatusList, "Id", "Name");
            ViewBag.SDEUserList = new SelectList(SdeUsers, "Id", "UserName");
            ViewBag.ProductList = new SelectList(productList, "Id", "Name");

            var pager = new Pager(returnList.Count(), page);
            //var mobilizationLists = _mobilizationAppService.GetMobilizationList();
            //// return View(await _context.Sermon.OrderByDescending(x => x.SermonDate).ToListAsync());
            //return View(mobilizationList);
            MobilizationSearchViewModel searchViewModel = new MobilizationSearchViewModel();
            searchViewModel.MobilizationList = returnList;
            searchViewModel.mobilizationSearch.startdate = startdate;
            searchViewModel.mobilizationSearch.enddate = enddate;
            searchViewModel.Pager = pager;
            searchViewModel.mobilizationSearch.nextmeeting = nextmeeting;
            return View("Mobilizations", searchViewModel);
        }


        public JsonResult MobilizationDetailNew(int Id)
        {
            var mobilizationDetail = _mobilizationAppService.GetMobilizationById(Id);
            return Json(mobilizationDetail);
        }

        public ActionResult MobilizationDetail(int Id)
        {
            var mobilizationDetail = _mobilizationAppService.GetMobilizationById(Id);
            return View(mobilizationDetail);
        }
        public IActionResult report()
        {
            return View();
        }
    }
}