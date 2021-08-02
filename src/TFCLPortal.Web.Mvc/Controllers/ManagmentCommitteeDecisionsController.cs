using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Controllers;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.ManagmentCommitteeDecisions;
using TFCLPortal.ManagmentCommitteeDecisions.Dto;
using TFCLPortal.NotificationLogs;
using TFCLPortal.Users;
using TFCLPortal.Web.Models.McModels;

namespace TFCLPortal.Web.Controllers
{
    public class ManagmentCommitteeDecisionsController : TFCLPortalControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IManagmentCommitteeDecisionAppService _managmentCommitteeDecisionAppService;
        private readonly IRepository<ManagmentCommitteeDecision, int> _managmentCommitteeDecisionRepository;
        private readonly UserManager _userManager;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly INotificationLogAppService _notificationLogAppService;


        public ManagmentCommitteeDecisionsController(IUserAppService userAppService, INotificationLogAppService notificationLogAppService, IFinalWorkflowAppService finalWorkflowAppService, UserManager userManager, IRepository<ManagmentCommitteeDecision, int> managmentCommitteeDecisionRepository, IApplicationAppService applicationAppService, IManagmentCommitteeDecisionAppService managmentCommitteeDecisionAppService)
        {
            _userAppService = userAppService;
            _notificationLogAppService = notificationLogAppService;
            _applicationAppService = applicationAppService;
            _managmentCommitteeDecisionAppService = managmentCommitteeDecisionAppService;
            _managmentCommitteeDecisionRepository = managmentCommitteeDecisionRepository;
            _userManager = userManager;
            _finalWorkflowAppService = finalWorkflowAppService;
        }

        // GET: ManagmentCommitteeDecisions
        public IActionResult Index()
        {
            int userid = (int)_userManager.AbpSession.UserId;
            var applications = _applicationAppService.GetShortApplicationList(ApplicationState.BCC_Approved, 0);

            List<Applicationz> returnList = new List<Applicationz>();


            if (userid != 0)
            {
                if (userid == 66) //Manager (OPS)
                {
                    foreach (var app in applications)
                    {
                        var decision = _managmentCommitteeDecisionRepository.GetAllList(x => x.ApplicationId == app.Id && x.fk_userid == userid);
                        if (decision.Count == 0)
                        {
                            returnList.Add(app);
                        }
                    }
                }
                else if (userid == 69) //Manager (F&A)
                {
                    foreach (var app in applications)
                    {
                        var decision = _managmentCommitteeDecisionRepository.GetAllList(x => x.ApplicationId == app.Id);
                        if (decision.Count > 0)
                        {
                            if (!decision.Where(x => x.fk_userid == userid).Any())
                            {
                                if (decision.Where(x => x.fk_userid == 66 && x.Decision == "Authorized").Any())
                                {
                                    returnList.Add(app);
                                }
                            }
                        }
                    }
                }
                else if (userid == 67) //CEO
                {
                    foreach (var app in applications)
                    {
                        var decision = _managmentCommitteeDecisionRepository.GetAllList(x => x.ApplicationId == app.Id);
                        if (decision.Count > 0)
                        {
                            if (!decision.Where(x => x.fk_userid == userid).Any())
                            {
                                if (decision.Where(x => x.fk_userid == 66 && x.Decision == "Authorized").Any() && decision.Where(x => x.fk_userid == 69 && x.Decision == "Authorized").Any())
                                {
                                    returnList.Add(app);
                                }
                            }
                        }
                    }
                }
                else if (userid == 2) //Admin
                {
                    foreach (var app in applications)
                    {
                        returnList.Add(app);
                    }
                }
            }
            else
            {

            }




            var mcs = _managmentCommitteeDecisionAppService.GetManagmentCommitteeDecisionList();

            McModel mc = new McModel();
            mc.applications = returnList;
            mc.decisions = mcs;

            return View(mc);
        }
        public async Task<IActionResult> CreateMC(int Id)
        {
            int userid = (int)_userManager.AbpSession.UserId;

            if (userid != 0)
            {
                ManagmentCommitteeDecision decision = new ManagmentCommitteeDecision();
                decision.ApplicationId = Id;
                decision.fk_userid = userid;
                decision.Decision = "Authorized";

                _managmentCommitteeDecisionRepository.Insert(decision);
                CurrentUnitOfWork.SaveChanges();

                var appData = _applicationAppService.GetApplicationById(Id);
                if (appData != null)
                {
                    if (userid == 66)
                    {
                        await _notificationLogAppService.SendNotification(69, appData.ClientID + " is waiting for your approval", "Kindly view BCC Approved Applications.");
                    }
                    else if (userid == 69)
                    {
                        await _notificationLogAppService.SendNotification(67, appData.ClientID + " is waiting for your approval", "Kindly view BCC Approved Applications. ");
                    }
                }
            }

            var list = _managmentCommitteeDecisionRepository.GetAllList(x => x.ApplicationId == Id && x.Decision == "Authorized");

            if (list.Where(x => x.fk_userid == 66).Any())
            {
                if (list.Where(x => x.fk_userid == 69).Any())
                {
                    if (list.Where(x => x.fk_userid == 67).Any())
                    {
                        _applicationAppService.ChangeApplicationState(ApplicationState.MC_Authorized, Id, "");

                        CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                        fWobj.ApplicationId = Id;
                        fWobj.Action = "Application Authorized By Management Committee";
                        fWobj.ActionBy = userid;
                        fWobj.ApplicationState = ApplicationState.MC_Authorized;
                        fWobj.isActive = true;

                        await _finalWorkflowAppService.CreateFinalWorkflow(fWobj);
                    }
                }
            }


            return RedirectToAction("Index");
        }

    }
}
