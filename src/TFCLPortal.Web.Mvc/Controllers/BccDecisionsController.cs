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
using TFCLPortal.BccDecisions;
using TFCLPortal.BccDecisions.Dto;
using TFCLPortal.EntityFrameworkCore;
using TFCLPortal.Users;

namespace TFCLPortal.Web.Controllers
{
    public class BccDecisionsController : AbpController
    {
        private readonly IRepository<BccDecision, int> _context;
        private readonly IBccDecisionAppService _bccDecisionAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IUserAppService _userAppService;


        public BccDecisionsController(IRepository<BccDecision, int> context, IUserAppService userAppService,IApplicationAppService applicationAppService,IBccDecisionAppService bccDecisionAppService)
        {
            _context = context;
            _bccDecisionAppService = bccDecisionAppService;
            _applicationAppService = applicationAppService;
            _userAppService = userAppService;
        }

        // GET: BccDecisions
        public async Task<IActionResult> Index(int? ApplicationId)
        {

            List<BccDecisionListDto> BccDecisions = new List<BccDecisionListDto>();

            if (ApplicationId == null || ApplicationId == 0)
            {
                BccDecisions = _bccDecisionAppService.GetBccDecisionList();
            }
            else
            {
                BccDecisions = _bccDecisionAppService.GetBccDecisionList().Where(x => x.ApplicationId == (int)ApplicationId).ToList();
            }



            if (BccDecisions != null)
            {
                foreach (var decision in BccDecisions)
                {
                    var application = _applicationAppService.GetApplicationById(decision.ApplicationId);
                    decision.ApplicantName = application.ClientName;
                    decision.SchoolName = application.SchoolName;
                    decision.ClientId = application.ClientID;
                }
            }

            return View(BccDecisions);
        }

        // GET: BccDecisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bccDecision = _bccDecisionAppService.GetBccDecisionById((int)id);
            if (bccDecision == null)
            {
                return NotFound();
            }
            else
            {
                var application = _applicationAppService.GetApplicationById(bccDecision.ApplicationId);
                bccDecision.ApplicantName = application.ClientName;
                bccDecision.SchoolName = application.SchoolName;
                bccDecision.ClientId = application.ClientID;
                bccDecision.CNIC = application.CNICNo;

                var user1 = _userAppService.GetUserById(bccDecision.BccMember1UserId);
                bccDecision.BccMember1UserName = user1.Result.FullName;

                var user2 = _userAppService.GetUserById(bccDecision.BccMember2UserId);
                bccDecision.BccMember2UserName = user2.Result.FullName;

                var user3 = _userAppService.GetUserById(bccDecision.BccMember3UserId);
                bccDecision.BccMember3UserName = user3.Result.FullName;


                bccDecision.SchoolName = application.SchoolName;
                bccDecision.ClientId = application.ClientID;
            }

            return View(bccDecision);
        }
    }
}
