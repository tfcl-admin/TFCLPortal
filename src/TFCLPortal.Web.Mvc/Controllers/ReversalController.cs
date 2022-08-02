using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Abp.AspNetCore.Mvc.Controllers;
using TFCLPortal.FilesUploads;
using TFCLPortal.FileTypes;
using TFCLPortal.Web.Models.UploadFiles;
using Microsoft.AspNetCore.Http;
using TFCLPortal.FilesUploads.Dto;
using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.CoApplicantDetails;
using System.Collections.Generic;
using TFCLPortal.LoanSchedules.Dto;
using TFCLPortal.BusinessPlans;
using TFCLPortal.Schedules;
using TFCLPortal.Applications;
using TFCLPortal.LoanEligibilities;
using System.Linq;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Users;
using Microsoft.AspNetCore.Identity;
using TFCLPortal.Authorization.Users;
using TFCLPortal.TDSLoanEligibilities;
using TFCLPortal.BccDecisions;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.Reversals;
using TFCLPortal.Reversals.Dto;

namespace TFCLPortal.Web.Controllers
{
    public class ReversalController : AbpController
    {
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IScheduleAppService _scheduleAppService;
        private readonly ICustomerAccountAppService _customerAccountAppAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IBccDecisionAppService _bccDecisionAppService;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;
        private readonly IReversalAppService _reversalAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        public ReversalController(
            IScheduleAppService scheduleAppService,
            IBusinessPlanAppService businessPlanAppService,
            IApplicationAppService applicationAppService,
            ILoanEligibilityAppService loanEligibilityAppService,
            ICustomerAccountAppService customerAccountAppAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService,
            IReversalAppService reversalAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
            IBccDecisionAppService bccDecisionAppService,
            ITDSLoanEligibilityAppService tDSLoanEligibilityAppService,
            IUserAppService userAppService,
            UserManager userManager
            )
        {
            _customerAccountAppAppService = customerAccountAppAppService;
            _bccDecisionAppService = bccDecisionAppService;
            _reversalAppService = reversalAppService;
            _userManager = userManager;
            _bccDecisionAppService = bccDecisionAppService;
            _businessPlanAppService = businessPlanAppService;
            _scheduleAppService = scheduleAppService;
            _applicationAppService = applicationAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            long? userid = _userManager.AbpSession.UserId;

            var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            int? branchId = currentuser.Result.BranchId;
            if (branchId == null)
            {
                branchId = 0;
            }
            var mobilizationList = _applicationAppService.GetApplicationList(ApplicationState.Disbursed, branchId, true);

            return View(mobilizationList);
        }

        public ActionResult Reschedule(int ApplicationId)
        {
          

            return View();
        }

        [HttpPost]
        public JsonResult getCustomerTransactions(string cnic)
        {
            var customerAccount = _customerAccountAppAppService.GetCustomerAccountByCNICwithTransactions(cnic);
            return Json(customerAccount);
        }

        public ActionResult CreateReversal(int TransactionId, string Reason)
        {
            CreateReversalDto reversalDto = new CreateReversalDto();

            long? userid = _userManager.AbpSession.UserId;
            reversalDto.TransactionId = TransactionId;
            reversalDto.InitiatedBy = (int)userid;
            reversalDto.Details = Reason;

            string create= _reversalAppService.CreateReversal(reversalDto).Result;

            if(create== "Success")
            {
                ViewBag.Success = 1;
            }
            else
            {
                ViewBag.Success = 0;
            }
            

            return View();
        }

        public ActionResult List()
        {
            var reversals = _reversalAppService.GetReversals();
            return View(reversals);
        }

        public ActionResult AuthList()
        {
            var reversals = _reversalAppService.GetReversals();
            return View(reversals);
        }

        public ActionResult ViewAuth(int id)
        {
            var reversals = _reversalAppService.GetReversalDetailsById(id);
            return View(reversals);
        }

        [HttpPost]
        public JsonResult Authorize(int Id,string Decision,string Reason)
        {
            var reversals = _reversalAppService.ReversalAuthorization(Id,Decision,Reason);
            return Json(reversals);
        }

        public int Branchid()
        {
            long? userid = _userManager.AbpSession.UserId;

            var currentuser = _userAppService.GetUserById(Convert.ToInt64(userid));
            int branchId = (int)(currentuser.Result.BranchId == null ? 0 : currentuser.Result.BranchId);
            if (branchId == null)
            {
                branchId = 0;
            }
            return branchId;
        }

    }
}
