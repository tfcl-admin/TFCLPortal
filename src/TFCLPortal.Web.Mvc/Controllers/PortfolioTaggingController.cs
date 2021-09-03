using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Controllers;
using TFCLPortal.NotificationLogs;
using TFCLPortal.TaggedPortfolios;
using TFCLPortal.TaggedPortfolios.Dto;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.Web.Models.Portfolio;

namespace TFCLPortal.Web.Controllers
{
    public class PortfolioTaggingController : TFCLPortalControllerBase
    {
        private readonly INotificationLogAppService _notificationLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<Applicationz> _applicationRepository;
        private readonly IRepository<TaggedPortfolio> _taggedPortfolioRepository;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;
        private readonly ITaggedPortfolioAppService _taggedPortfolioAppService;

        public PortfolioTaggingController(ITaggedPortfolioAppService taggedPortfolioAppService,IRepository<TaggedPortfolio> taggedPortfolioRepository,IRepository<Applicationz> applicationRepository, IUserAppService userAppService, INotificationLogAppService notificationLogAppService, IApplicationAppService applicationAppService, UserManager userManager)
        {
            _applicationRepository = applicationRepository;
            _taggedPortfolioAppService = taggedPortfolioAppService;
            _userAppService = userAppService;
            _userManager = userManager;
            _notificationLogAppService = notificationLogAppService;
            _applicationAppService = applicationAppService;
            _taggedPortfolioRepository = taggedPortfolioRepository;
        }

        public ActionResult Index()
        {
            var branch = Branchid();


            List<Applicationz> applications = new List<Applicationz>();
            List<UserDto> users = new List<UserDto>();
            List<TaggedPortfolio> tagged = new List<TaggedPortfolio>();

            tagged = _taggedPortfolioRepository.GetAllList();

            if (branch == 0 || branch == null)
            {
                applications = _applicationRepository.GetAllList();
                users = _userAppService.GetAllUsers();
            }
            else
            {
                applications = _applicationRepository.GetAllList(x => x.FK_branchid == branch);
                users = _userAppService.GetAllUsers().Where(x => x.BranchId == branch).ToList();
            }

            foreach (var user in users)
            {
                var userApps = applications.Where(x => x.CreatorUserId == user.Id).Count();
                user.applicationsCount = userApps;

                var taggedApps = tagged.Where(x => x.NewUserId == user.Id&&x.isApproved==true).Count();
                user.taggedApplicationsCount = taggedApps;
            }



            return View(users);
        }

        public async Task<ActionResult> UserApplications(int userid)
        {
            var applications = _applicationAppService.GetAllApplicationsByUserId(userid);
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;

            var SelectedUser = users.Where(x => x.Id == (long)userid).FirstOrDefault();
            ViewBag.ScreenTitle = SelectedUser.FullName + "'s Applications";

            var taggedToApps = _taggedPortfolioRepository.GetAllList(x => x.NewUserId == userid && x.isApproved==true).ToList();
            var taggedFromApps = _taggedPortfolioRepository.GetAllList(x => x.OldUserId == userid && x.isApproved == true).ToList();

            foreach (var app in applications)
            {
                var tagged = taggedFromApps.Where(x => x.ApplicationId == app.Id && x.OldUserId == userid).ToList();
                if (tagged.Count>0)
                {
                    app.Comments = "@ Transferred to " + users.Where(x => x.Id == (long)tagged.FirstOrDefault().NewUserId).FirstOrDefault().FullName;
                }
            }

            List<ApplicationListDto> taggedApps = new List<ApplicationListDto>();
            foreach (var app in taggedToApps)
            {
                var tagged = _applicationAppService.GetApplicationById(app.ApplicationId);
                tagged.Comments = users.Where(x => x.Id == (long)app.OldUserId).FirstOrDefault().FullName;
                taggedApps.Add(tagged);
            }

            ViewBag.ScreenTaggedTitle = "Applications Transferred to " + SelectedUser.FullName;

            List<UserDto> listToSend = new List<UserDto>();

            var branch = Branchid();
            if (branch != 0 && branch != null)
            {
                foreach (var user in users.Where(x => x.BranchId == branch).ToList())
                {
                    if (user.Id != userid)
                    {
                        if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                        {
                            listToSend.Add(user);
                        }
                    }

                }
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.Id != userid)
                    {
                        if (user.RoleNames != null && user.RoleNames.Any(r => r == "SDE"))
                        {
                            listToSend.Add(user);
                        }
                    }
                }
            }


            ViewBag.UsersList = listToSend;

            PortfolioByUserModel model = new PortfolioByUserModel();
            model.UserApplications = applications;
            model.UserTaggedApplications = taggedApps;


            return View(model);
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

        [HttpPost]
        public JsonResult TransferPortfolio(CreateTaggedPortfolioDto input)
        {

            string response = "";
            try
            {
                _taggedPortfolioAppService.CreateTaggedPortfolio(input);
                _notificationLogAppService.SendNotification(66, "Transfered Portfolio is waiting for your approval", "Kindly view Portfolio Transfer > Authorization.");
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error";
            }
            return Json(response);
        }
        public async Task<ActionResult> Authorization()
        {
            var taggedApplications = _taggedPortfolioAppService.GetAllTaggedPortfolio().Where(x => x.isApproved == null).ToList();
            var applications = _applicationRepository.GetAllList();
            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;

            foreach (var app in taggedApplications)
            {
                var appDetails = applications.Where(x => x.Id == app.ApplicationId).FirstOrDefault();
                app.ClientId = appDetails.ClientID;
                app.ClientName = appDetails.ClientName;
                app.SchoolName = appDetails.SchoolName;
                app.OldUserName= users.Where(x => x.Id == (long)app.OldUserId).FirstOrDefault().FullName;
                app.NewUserName= users.Where(x => x.Id == (long)app.NewUserId).FirstOrDefault().FullName;
            }

            return View(taggedApplications);
        }

        public async Task<ActionResult> Authorize(int id,bool authorize)
        {
            var taggedApplications = _taggedPortfolioRepository.Get(id);
            taggedApplications.isApproved = authorize;
            _taggedPortfolioRepository.Update(taggedApplications);
            CurrentUnitOfWork.SaveChanges();
            return RedirectToAction("Authorization");
        }

    }
}
