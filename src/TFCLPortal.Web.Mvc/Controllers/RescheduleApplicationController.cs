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

namespace TFCLPortal.Web.Controllers
{
    public class RescheduleApplicationController : AbpController
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
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        public RescheduleApplicationController(
            IScheduleAppService scheduleAppService,
            IBusinessPlanAppService businessPlanAppService,
            IApplicationAppService applicationAppService,
            ILoanEligibilityAppService loanEligibilityAppService,
            ICustomerAccountAppService customerAccountAppAppService,
            ICoApplicantDetailAppService coApplicantDetailAppService,
            IGuarantorDetailAppService guarantorDetailAppService,
            IBccDecisionAppService bccDecisionAppService,
            ITDSLoanEligibilityAppService tDSLoanEligibilityAppService,
            IUserAppService userAppService,
            UserManager userManager
            )
        {
            _customerAccountAppAppService = customerAccountAppAppService;
            _bccDecisionAppService = bccDecisionAppService;
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

                var customerAcc = _customerAccountAppAppService.GetCustomerAccountByCNIC(application.CNICNo);
                ViewBag.customerAcc = customerAcc;

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
                int LoanAmountT = 0;
                int Installments = 0;
                double markupT = 0;

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
                    markupT = double.Parse(getLE.Mark_Up);
                }

                markupT = markupT / 100;

                int sumOfAmounts = 0;
       
            }



            ViewBag.Input = schedule;


            int tenure = 0;
            double markup = 0.00;
            int LoanAmount = 0;
            if (application != null)
            {
                var getLRD = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                if (getLRD != null)
                {
                    ViewBag.LoanRequisitionDetails = getLRD;
                    tenure = Int32.Parse(getLRD.LoanTenureRequestedName);
                    LoanAmount = Int32.Parse(getLRD.LoanAmountRecommended.Replace(",", ""));
                }
                if (application.ProductType == 1 || application.ProductType == 2)
                {
                    var getLE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId);
                    if (getLE != null)
                    {
                        ViewBag.LoanEligibility = getLE.Result;
                        markup = double.Parse(getLE.Result.Mark_Up);
                    }
                }
                else if (application.ProductType == 8 || application.ProductType == 9)
                {
                    var getLE = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(ApplicationId);
                    if (getLE != null)
                    {
                        ViewBag.LoanEligibility = getLE.Result;
                        markup = double.Parse(getLE.Result.Mark_Up);
                    }
                }
                var decision = _bccDecisionAppService.GetBccDecisionList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (decision != null)
                {
                    decision.ApplicantName = application.ClientName;
                    decision.ClientId = application.ClientID;
                    decision.SchoolName = application.SchoolName;
                    decision.CNIC = application.CNICNo;
                    ViewBag.Decision = decision;
                }

                ViewBag.BranchManager = _userAppService.GetUserById((long)decision.CreatorUserId).Result.FullName;
                ViewBag.BranchManagerId = (long)decision.CreatorUserId;
                ViewBag.SdeName = _userAppService.GetUserById((long)application.CreatorUserId).Result.FullName;
                ViewBag.SdeId = (long)application.CreatorUserId;
            }

            //Calculating IRR
            double markupPercentage = markup / 100;
            double IRR = (Rate(tenure, (1 + ((1 * markupPercentage) / 12 * tenure)) / tenure, -1, 0, 0) * 12);
            ViewBag.IRR = Math.Round(IRR * 100, 2);
            ViewBag.IRR_full = IRR * 100;

            //Calculating installment Amount
            double installmentAmount = -PMT(IRR / 12, tenure, LoanAmount, 0, 0);
            ViewBag.InstallmentAmount = Math.Round(installmentAmount, 2);

            //Calculating Yearly Markup Amount
            double yearlyMarkup = LoanAmount * markupPercentage;
            ViewBag.YearlyMarkup = yearlyMarkup;

            //Calculating Daily Markup Amount
            double dailyMarkup = yearlyMarkup / 365;
            ViewBag.DailyMarkup = dailyMarkup;

            ViewBag.Application = application;


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


        enum DueDate
        {
            EndOfPeriod = 0,
            BegOfPeriod = 1
        }

        private const double cnL_IT_STEP = 0.00001;
        private const double cnL_IT_EPSILON = 0.0000001;

        private double Rate(double NPer, double Pmt, double PV, double FV = 0, DueDate Due = DueDate.EndOfPeriod, double Guess = 0.1)
        {
            double dTemp;
            double dRate0;
            double dRate1;
            double dY0;
            double dY1;
            int I;

            // Check for error condition
            if (NPer <= 0.0)
                throw new ArgumentException("NPer must by greater than zero");

            dRate0 = Guess;
            dY0 = LEvalRate(dRate0, NPer, Pmt, PV, FV, Due);
            if (dY0 > 0)
                dRate1 = (dRate0 / 2);
            else
                dRate1 = (dRate0 * 2);

            dY1 = LEvalRate(dRate1, NPer, Pmt, PV, FV, Due);

            for (I = 0; I <= 39; I++)
            {
                if (dY1 == dY0)
                {
                    if (dRate1 > dRate0)
                        dRate0 = dRate0 - cnL_IT_STEP;
                    else
                        dRate0 = dRate0 - cnL_IT_STEP * (-1);
                    dY0 = LEvalRate(dRate0, NPer, Pmt, PV, FV, Due);
                    if (dY1 == dY0)
                        throw new ArgumentException("Divide by zero");
                }

                dRate0 = dRate1 - (dRate1 - dRate0) * dY1 / (dY1 - dY0);

                // Secant method of generating next approximation
                dY0 = LEvalRate(dRate0, NPer, Pmt, PV, FV, Due);
                if (Math.Abs(dY0) < cnL_IT_EPSILON)
                    return dRate0;

                dTemp = dY0;
                dY0 = dY1;
                dY1 = dTemp;
                dTemp = dRate0;
                dRate0 = dRate1;
                dRate1 = dTemp;
            }

            throw new ArgumentException("Can not calculate rate");
        }

        private double LEvalRate(double Rate, double NPer, double Pmt, double PV, double dFv, DueDate Due)
        {
            double dTemp1;
            double dTemp2;
            double dTemp3;

            if (Rate == 0.0)
                return (PV + Pmt * NPer + dFv);
            else
            {
                dTemp3 = Rate + 1.0;
                // WARSI Using the exponent operator for pow(..) in C code of LEvalRate. Still got
                // to make sure that they (pow and ^) are same for all conditions
                dTemp1 = Math.Pow(dTemp3, NPer);

                if (Due != 0)
                    dTemp2 = 1 + Rate;
                else
                    dTemp2 = 1.0;
                return (PV * dTemp1 + Pmt * dTemp2 * (dTemp1 - 1) / Rate + dFv);
            }
        }

        public static double PMT(double RATE, int NPER, int PV, long FV, int TYPE)
        {
            return -RATE * (FV + PV * Math.Pow(1 + RATE, NPER)) / ((Math.Pow(1 + RATE, NPER) - 1) * (1 + RATE * TYPE));
        }
    }
}
