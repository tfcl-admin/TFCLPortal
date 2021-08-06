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

namespace TFCLPortal.Web.Controllers
{
    public class RescheduleApplicationController : AbpController
    {
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IScheduleAppService _scheduleAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly UserManager _userManager;
        private readonly IUserAppService _userAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        public RescheduleApplicationController(
            IScheduleAppService scheduleAppService,
            IBusinessPlanAppService businessPlanAppService,
            IApplicationAppService applicationAppService,
            ILoanEligibilityAppService loanEligibilityAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
            IUserAppService userAppService,
            UserManager userManager
            )
        {
            _userManager = userManager;
            _businessPlanAppService = businessPlanAppService;
            _scheduleAppService = scheduleAppService;
            _applicationAppService = applicationAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            var Applications = _applicationAppService.GetShortApplicationList(ApplicationState.Disbursed, Branchid());


            return View(Applications);
        }

        public ActionResult Reschedule(int ApplicationId)
        {
            List<signatories> listForSignatories = new List<signatories>();

            ViewBag.ApplicationId = ApplicationId;
            var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result;
            ViewBag.BMName = schedule.BranchManager;
            ViewBag.SDEName = schedule.SDE;

            var application = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.Application = application;
            if (application != null)
            {
                signatories applicant = new signatories();
                applicant.Name = application.ClientName;
                applicant.Detail = "(Applicant)";
                listForSignatories.Add(applicant);

                signatories bm = new signatories();
                bm.Name = ViewBag.BMName;
                bm.Detail = "(Branch Manager)";
                listForSignatories.Add(bm);

                var getCoApplicants = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(ApplicationId).Result.ToList();
                if (getCoApplicants != null)
                {
                    foreach (var coapplicant in getCoApplicants)
                    {
                        signatories CoApplicant = new signatories();
                        CoApplicant.Name = coapplicant.FullName;
                        CoApplicant.Detail = "(Co-Applicant)";
                        listForSignatories.Add(CoApplicant);
                    }
                }

                var getGuarantors = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(ApplicationId).Result.ToList();
                if (getGuarantors != null)
                {
                    foreach (var Guarantor in getGuarantors)
                    {
                        signatories GuarantorObj = new signatories();
                        GuarantorObj.Name = Guarantor.FullName;
                        GuarantorObj.Detail = "(Guarantor)";
                        listForSignatories.Add(GuarantorObj);
                    }
                }


            }
            ViewBag.Signatories = listForSignatories;


            if (schedule.ScheduleType == "Tranches")
            {
                int LoanAmount = 0;
                int Installments = 0;
                double markup = 0;

                var getLRD = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                if (getLRD != null)
                {
                    ViewBag.LoanRequisitionDetails = getLRD;
                    Installments = Int32.Parse(getLRD.LoanTenureRequestedName);
                }

                var getLE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
                if (getLE != null)
                {
                    ViewBag.LoanEligibility = getLE;
                    markup = double.Parse(getLE.Mark_Up);
                }

                markup = markup / 100;

                int sumOfAmounts = 0;
       
            }



            ViewBag.Input = schedule;

            return View();
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
