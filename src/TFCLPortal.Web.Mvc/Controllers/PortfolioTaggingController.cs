using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Applications;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Controllers;
using TFCLPortal.NotificationLogs;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.Web.Controllers
{
    public class PortfolioTaggingController : TFCLPortalControllerBase
    {
        private readonly INotificationLogAppService _notificationLogAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<Applicationz> _applicationRepository;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;

        public PortfolioTaggingController(IRepository<Applicationz> applicationRepository, IUserAppService userAppService, INotificationLogAppService notificationLogAppService, IApplicationAppService applicationAppService, UserManager userManager)
        {
            _applicationRepository = applicationRepository;
            _userAppService = userAppService;
            _userManager = userManager;
            _notificationLogAppService = notificationLogAppService;
            _applicationAppService = applicationAppService;
        }

        public ActionResult Index()
        {
            var branch = Branchid();


            List<Applicationz> applications = new List<Applicationz>();
            List<UserDto> users = new List<UserDto>();


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
            }



            return View(users);
        }

        public async Task<ActionResult> UserApplications(int userid)
        {
            var applications = _applicationAppService.GetAllApplicationsByUserId(userid);

            var users = (await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            List<UserDto> listToSend = new List<UserDto>();

            var branch = Branchid();
            if (branch!=0 && branch!=null)
            {
                foreach (var user in users.Where(x => x.BranchId == branch).ToList())
                {
                    if(user.Id!=userid)
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
            var SelectedUser = users.Where(x => x.Id == (long)userid).FirstOrDefault();
            ViewBag.ScreenTitle = SelectedUser.FullName + "'s Applications";
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
    }
}
