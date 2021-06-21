using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFCLPortal.Applications;
using TFCLPortal.McrcDecisions;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.Users;
using TFCLPortal.McrcDecisions.Dto;

namespace TFCLPortal.Web.Controllers
{
    public class McrcDecisionsController : AbpController
    {
        private readonly IRepository<McrcDecision, int> _context;
        private readonly IMcrcDecisionAppService _McrcDecisionAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IUserAppService _userAppService;


        public McrcDecisionsController(IRepository<McrcDecision, int> context, IUserAppService userAppService,IApplicationAppService applicationAppService,IMcrcDecisionAppService McrcDecisionAppService)
        {
            _context = context;
            _McrcDecisionAppService = McrcDecisionAppService;
            _applicationAppService = applicationAppService;
            _userAppService = userAppService;
        }

        // GET: McrcDecisions
        public async Task<IActionResult> Index(int? ApplicationId)
        {
            List<McrcDecisionListDto> McrcDecisions = new List<McrcDecisionListDto>();

            if (ApplicationId==null || ApplicationId == 0)
            {
               McrcDecisions = _McrcDecisionAppService.GetMcrcDecisionList();
            }
            else
            {
                McrcDecisions = _McrcDecisionAppService.GetMcrcDecisionList().Where(x => x.ApplicationId == (int)ApplicationId).ToList();
            }

            if (McrcDecisions != null)
            {
                foreach (var decision in McrcDecisions)
                {
                    var application = _applicationAppService.GetApplicationById(decision.ApplicationId);
                    decision.ApplicantName = application.ClientName;
                    decision.SchoolName = application.SchoolName;
                    decision.ClientId = application.ClientID;
                }
            }

            return View(McrcDecisions);
        }

        // GET: McrcDecisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var McrcDecision = _McrcDecisionAppService.GetMcrcDecisionById((int)id);
            if (McrcDecision == null)
            {
                return NotFound();
            }
            else
            {
                var application = _applicationAppService.GetApplicationById(McrcDecision.ApplicationId);
                McrcDecision.ApplicantName = application.ClientName;
                McrcDecision.SchoolName = application.SchoolName;
                McrcDecision.ClientId = application.ClientID;
                McrcDecision.CNIC = application.CNICNo;

                if(McrcDecision.McrcMember1UserId!=0)
                {
                    var user1 = _userAppService.GetUserById(McrcDecision.McrcMember1UserId);
                    McrcDecision.McrcMember1UserName = user1.Result.FullName;
                }

                if (McrcDecision.McrcMember2UserId != 0)
                {
                    var user2 = _userAppService.GetUserById(McrcDecision.McrcMember2UserId);
                    McrcDecision.McrcMember2UserName = user2.Result.FullName;
                }
                if (McrcDecision.McrcMember3UserId != 0)
                {
                    var user3 = _userAppService.GetUserById(McrcDecision.McrcMember3UserId);
                    McrcDecision.McrcMember3UserName = user3.Result.FullName;
                }
                if (McrcDecision.McrcMember4UserId != 0)
                {
                    var user4 = _userAppService.GetUserById(McrcDecision.McrcMember4UserId);
                    McrcDecision.McrcMember4UserName = user4.Result.FullName;
                }
                if (McrcDecision.McrcMember5UserId != 0)
                {
                    var user5 = _userAppService.GetUserById(McrcDecision.McrcMember5UserId);
                    McrcDecision.McrcMember5UserName = user5.Result.FullName;
                }
                McrcDecision.SchoolName = application.SchoolName;
                McrcDecision.ClientId = application.ClientID;
            }

            return View(McrcDecision);
        }
    }
}
