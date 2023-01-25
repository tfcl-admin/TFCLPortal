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
using TFCLPortal.BusinessPlans;
using TFCLPortal.Controllers;
using TFCLPortal.DynamicDropdowns.BusinessTypes;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.ManagmentCommitteeDecisions;
using TFCLPortal.ManagmentCommitteeDecisions.Dto;
using TFCLPortal.McrcDecisions;
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
        private readonly IMcrcDecisionAppService _McrcDecisionAppService;
        private readonly IBusinessPlanAppService _BusinessPlanAppServices;

        public ManagmentCommitteeDecisionsController(IUserAppService userAppService, INotificationLogAppService notificationLogAppService, IFinalWorkflowAppService finalWorkflowAppService, UserManager userManager, IRepository<ManagmentCommitteeDecision, int> managmentCommitteeDecisionRepository, IApplicationAppService applicationAppService,
            IManagmentCommitteeDecisionAppService managmentCommitteeDecisionAppService, IMcrcDecisionAppService McrcDecisionAppService, IBusinessPlanAppService BusinessPlanAppServices)
        {
            _userAppService = userAppService;
            _notificationLogAppService = notificationLogAppService;
            _applicationAppService = applicationAppService;
            _managmentCommitteeDecisionAppService = managmentCommitteeDecisionAppService;
            _managmentCommitteeDecisionRepository = managmentCommitteeDecisionRepository;
            _McrcDecisionAppService = McrcDecisionAppService;
            _userManager = userManager;
            _finalWorkflowAppService = finalWorkflowAppService;
            _BusinessPlanAppServices = BusinessPlanAppServices;
        }

        // GET: ManagmentCommitteeDecisions
        public IActionResult Index()
        {
            int userid = (int)_userManager.AbpSession.UserId;
            var applications = _applicationAppService.GetShortApplicationListMC(ApplicationState.BCC_Approved);

            List<ApplicationDto> returnList = new List<ApplicationDto>();


            if (userid != 0)
            {
                if (userid == 66) //Manager (OPS)
                {
                    foreach (var app in applications)
                    {
                        var decision = _managmentCommitteeDecisionRepository.GetAllList(x => x.ApplicationId == app.Id && x.fk_userid == userid);
                        //var getMcrcDecision = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == app.Id).FirstOrDefault();
                        var BP= _BusinessPlanAppServices.GetBusinessPlanByApplicationId(app.Id).Result;
                        ViewBag.LoanAmount = BP.LoanAmountRecommended;
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
                        //var getMcrcDecision = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == app.Id).FirstOrDefault();
                        var BP = _BusinessPlanAppServices.GetBusinessPlanByApplicationId(app.Id).Result;
                        ViewBag.LoanAmount = BP.LoanAmountRecommended;
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
                        //var getMcrcDecision = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == app.Id).FirstOrDefault();
                        var BP = _BusinessPlanAppServices.GetBusinessPlanByApplicationId(app.Id).Result;
                        ViewBag.LoanAmount = BP.LoanAmountRecommended;
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
                        //var getMcrcDecision = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == app.Id).FirstOrDefault();
                        var BP = _BusinessPlanAppServices.GetBusinessPlanByApplicationId(app.Id).Result;
                        app.LoanAmount = BP.LoanAmountRecommended;
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

        public async Task<IActionResult> CreateMCdecline(int Id,string Reason)
        {
            var app = _applicationAppService.GetApplicationById(Id);

            if(app!=null)
            {
                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = app.Id;
                fWobj.Action = "Decline";
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.ApplicationState = ApplicationState.Decline;
                fWobj.isActive = true;

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                _applicationAppService.ChangeApplicationState(ApplicationState.Decline, app.Id, Reason);
            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateDiscrepancy(int Id, string Reason)
        {
            var app = _applicationAppService.GetApplicationById(Id);

            if (app != null)
            {
                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = app.Id;
                fWobj.Action = "Sent to Submitted. Reason : "+Reason;
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.ApplicationState = ApplicationState.Submitted;
                fWobj.isActive = true;

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                _applicationAppService.ChangeApplicationState(ApplicationState.Submitted, app.Id, Reason);
            }


            return RedirectToAction("Index");
        }


    }
}
