using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Authorization.Users;
using TFCLPortal.BankAccountDetails;
using TFCLPortal.BccDecisions;
using TFCLPortal.Branches;
using TFCLPortal.BusinessPlans;
using TFCLPortal.Controllers;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.FinalWorkflows;
using TFCLPortal.LoanEligibilities;
using TFCLPortal.LoanSchedules.Dto;
using TFCLPortal.Users;
using Microsoft.VisualBasic;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.GuarantorDetails;
using Abp.Runtime.Validation;
using TFCLPortal.Schedules.Dto;
using TFCLPortal.Schedules;
using Abp.Domain.Repositories;
using TFCLPortal.FinalWorkflows.Dto;
using TFCLPortal.NotificationLogs;
using TFCLPortal.ScheduleTemps.Dto;
using TFCLPortal.ScheduleTemps;
using TFCLPortal.ApplicationWorkFlows.BADataChecks;
using TFCLPortal.CompanyBankAccounts;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFCLPortal.NatureOfPayments;
using TFCLPortal.InstallmentPayments;
using TFCLPortal.InstallmentPayments.Dto;
using TFCLPortal.Holidays;
using TFCLPortal.AuthorizeInstallmentPayments.Dto;
using TFCLPortal.AuthorizeInstallmentPayments;
using TFCLPortal.EarlySettlements.Dto;
using TFCLPortal.EarlySettlements;
using TFCLPortal.WriteOffs;
using TFCLPortal.WriteOffs.Dto;
using TFCLPortal.DeceasedSettlements;
using TFCLPortal.DeceasedSettlements.Dto;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using TFCLPortal.Web.Models.AMLCFT;
using TFCLPortal.TDSLoanEligibilities;

namespace TFCLPortal.Web.Controllers
{
    public class AccountantController : TFCLPortalControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IFinalWorkflowAppService _finalWorkflowAppService;
        private readonly IApplicationAppService _applicationAppService;
        private readonly UserManager _userManager;
        private readonly IBccDecisionAppService _bccDecisionAppService;
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IScheduleAppService _scheduleAppService;
        private readonly IScheduleTempAppService _scheduleTempAppService;
        private readonly IRepository<NatureOfPayment, int> _natureOfPaymentRepository;
        private readonly IRepository<CompanyBankAccount, int> _companyBankAccountRepository;
        private readonly IRepository<Schedule, int> _scheduleRepository;
        private readonly IRepository<ScheduleInstallment, int> _scheduleInstallmentRepository;
        private readonly IRepository<ScheduleTemp, int> _scheduleTempRepository;
        private readonly IBADataCheckAppService _IBADataCheckAppService;
        private readonly IInstallmentPaymentAppService _installmentPaymentAppService;
        private readonly IAuthorizeInstallmentPaymentAppService _authorizeInstallmentPaymentAppService;
        private readonly IEarlySettlementAppService _earlySettlementAppService;
        private readonly IRepository<EarlySettlement, int> _earlySettlementRepository;
        private readonly IWriteOffAppService _writeOffAppService;
        private readonly IRepository<WriteOff, int> _writeOffRepository;
        private readonly IDeceasedSettlementAppService _deceasedSettlementAppService;
        private readonly IRepository<DeceasedSettlement, int> _deceasedSettlementRepository;

        private readonly IRepository<Holiday, int> _holidayRepository;
        private readonly IRepository<GuarantorDetail, int> _GuarantorRepository;
        private readonly IRepository<CoApplicantDetail, int> _CoApplicantRepository;

        private readonly IRepository<Applicationz, Int32> _applicationRepository;

        private readonly IRepository<InstallmentPayment, int> _installmentPaymentRepository;
        private readonly IRepository<AuthorizeInstallmentPayment, int> _authorizeInstallmentPaymentRepository;

        private readonly INotificationLogAppService _notificationLogAppService;

        public AccountantController(ITDSLoanEligibilityAppService tDSLoanEligibilityAppService, IRepository<CoApplicantDetail, int> CoApplicantRepository, IRepository<GuarantorDetail, int> GuarantorRepository, IRepository<Applicationz, Int32> applicationRepository, IRepository<ScheduleTemp, int> scheduleTempRepository, IRepository<DeceasedSettlement, int> deceasedSettlementRepository, IDeceasedSettlementAppService deceasedSettlementAppService, IRepository<WriteOff, int> writeOffRepository, IWriteOffAppService writeOffAppService, IRepository<EarlySettlement, int> earlySettlementRepository, IEarlySettlementAppService earlySettlementAppService, IRepository<AuthorizeInstallmentPayment, int> authorizeInstallmentPaymentRepository, IAuthorizeInstallmentPaymentAppService authorizeInstallmentPaymentAppService, IRepository<InstallmentPayment, int> installmentPaymentRepository, IRepository<Holiday, int> holidayRepository, IRepository<ScheduleInstallment, int> scheduleInstallmentRepository, IInstallmentPaymentAppService installmentPaymentAppService, IRepository<NatureOfPayment, int> natureOfPaymentRepository, IRepository<CompanyBankAccount, int> companyBankAccountRepository, IBADataCheckAppService IBADataCheckAppService, INotificationLogAppService notificationLogAppService, IScheduleTempAppService scheduleTempAppService, UserManager userManager, IRepository<Schedule, int> scheduleRepository, IScheduleAppService scheduleAppService, ICoApplicantDetailAppService coApplicantDetailAppService, IGuarantorDetailAppService guarantorDetailAppService, IBranchDetailAppService branchDetailAppService, IBankAccountAppService bankAccountAppService, ILoanEligibilityAppService loanEligibilityAppService, IBusinessPlanAppService businessPlanAppService, IBccDecisionAppService bccDecisionAppService, IApplicationAppService applicationAppService, IUserAppService userAppService, IFinalWorkflowAppService finalWorkflowAppService)
        {
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _GuarantorRepository = GuarantorRepository;
            _CoApplicantRepository = CoApplicantRepository;
            _applicationRepository = applicationRepository;
            _applicationAppService = applicationAppService;
            _natureOfPaymentRepository = natureOfPaymentRepository;
            _notificationLogAppService = notificationLogAppService;
            _userAppService = userAppService;
            _finalWorkflowAppService = finalWorkflowAppService;
            _writeOffAppService = writeOffAppService;
            _deceasedSettlementAppService = deceasedSettlementAppService;
            _userManager = userManager;
            _bccDecisionAppService = bccDecisionAppService;
            _businessPlanAppService = businessPlanAppService;
            _loanEligibilityAppService = loanEligibilityAppService;
            _bankAccountAppService = bankAccountAppService;
            _deceasedSettlementRepository = deceasedSettlementRepository;
            _writeOffRepository = writeOffRepository;
            _branchDetailAppService = branchDetailAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;
            _scheduleTempAppService = scheduleTempAppService;
            _scheduleAppService = scheduleAppService;
            _scheduleRepository = scheduleRepository;
            _scheduleTempRepository = scheduleTempRepository;
            _scheduleInstallmentRepository = scheduleInstallmentRepository;
            _IBADataCheckAppService = IBADataCheckAppService;
            _companyBankAccountRepository = companyBankAccountRepository;
            _installmentPaymentAppService = installmentPaymentAppService;
            _holidayRepository = holidayRepository;
            _authorizeInstallmentPaymentAppService = authorizeInstallmentPaymentAppService;
            _installmentPaymentRepository = installmentPaymentRepository;
            _authorizeInstallmentPaymentRepository = authorizeInstallmentPaymentRepository;
            _earlySettlementRepository = earlySettlementRepository;
            _earlySettlementAppService = earlySettlementAppService;
        }

        public IActionResult Index()
        {
            var Applications = _applicationAppService.GetShortApplicationList(ApplicationState.MC_Authorized, Branchid());
            if (Applications != null)
            {
                foreach (var app in Applications)
                {
                    var getSchedule = _scheduleAppService.GetScheduleByApplicationId(app.Id).Result;
                    if (getSchedule != null)
                    {
                        if (getSchedule.isAuthorizedByBM == null)
                        {
                            app.Remarks = "Waiting";
                        }
                        else if (getSchedule.isAuthorizedByBM == true)
                        {
                            app.Remarks = "Authorized";
                        }
                        else if (getSchedule.isAuthorizedByBM == false)
                        {
                            app.Remarks = "Rejected";
                        }
                    }
                    else
                    {
                        app.Remarks = "OK";
                    }
                }

            }


            return View(Applications);
        }


        public ActionResult CheckAMLCFT()
        {
            ViewBag.JsonData = GetJson().Result;
            return View();
        }


        public ActionResult CheckAMLCFTByCNIC()
        {
            ViewBag.JsonData = GetJson().Result;
            return View();
        }

        public async Task<JsonResult> GetJson()
        {

            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("http://nfs.punjab.gov.pk/Home/GetJosn");

            //HttpContent content = response.Content;


            //JObject s = JObject.Parse(await content.ReadAsStringAsync());
            //string yourPrompt = (string)s["dialog"]["prompt"];

            string url = "http://nfs.punjab.gov.pk/Home/GetJosn";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;

            string yourPrompt = "test";
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                return Json(s);
            }
            else
            {
                return Json("Error");
            }

        }

        public async Task<JsonResult> GetApplicationsJson()
        {
            try
            {
                List<AmlCftModel> list = new List<AmlCftModel>();


                var applicationz = _applicationRepository.GetAllList();
                if (applicationz != null)
                {
                    foreach (var apps in applicationz)
                    {
                        AmlCftModel acm = new AmlCftModel();
                        acm.CNIC = apps.CNICNo;
                        acm.Type = "Applicant";
                        list.Add(acm);
                    }
                }

                var guarantors = _GuarantorRepository.GetAllList();
                if (guarantors != null)
                {
                    foreach (var apps in guarantors)
                    {
                        AmlCftModel acm = new AmlCftModel();
                        acm.CNIC = apps.CNICNumber;
                        acm.Type = "Guarantor";
                        list.Add(acm);
                    }
                }

                var coApplicants = _CoApplicantRepository.GetAllList();
                if (coApplicants != null)
                {
                    foreach (var apps in coApplicants)
                    {
                        AmlCftModel acm = new AmlCftModel();
                        acm.CNIC = apps.CNICNumber;
                        acm.Type = "Co-Applicant";
                        list.Add(acm);
                    }
                }


                return Json(list);
            }
            catch
            {
                return Json("Error");
            }
        }

        public IActionResult UploadedDocuments(int ApplicationId)
        {
            ViewBag.ApplicationId = ApplicationId;
            var list = _IBADataCheckAppService.GetBADocumentsByApplicationId(ApplicationId).Result;
            return View(list);
        }

        public IActionResult DisbursedApplications()
        {

            var Applications = _applicationAppService.GetShortApplicationList(ApplicationState.Disbursed, Branchid());
            return View(Applications);
        }


        public IActionResult ViewAuthorizations()
        {
            var schedules = _scheduleAppService.GetScheduleList().Result.Where(x => x.isAuthorizedByBM == null);

            List<ApplicationListDto> apps = new List<ApplicationListDto>();
            if (schedules != null)
            {
                foreach (var schedule in schedules)
                {
                    var app = _applicationAppService.GetApplicationById(schedule.ApplicationId);
                    apps.Add(app);
                }
            }
            return View(apps);
        }

        public IActionResult AuthorizationInstallmentPayment()
        {
            int branch = Branchid();
            List<AuthorizeInstallmentPaymentListDto> schedules;

            if (branch != 0)
            {
                schedules = _authorizeInstallmentPaymentAppService.GetAllAuthorizeInstallmentPayments().Result.Where(x => x.isAuthorized == null && x.branchId == branch).ToList();
            }
            else
            {
                schedules = _authorizeInstallmentPaymentAppService.GetAllAuthorizeInstallmentPayments().Result.Where(x => x.isAuthorized == null).ToList();
            }

            return View(schedules);
        }
        public IActionResult InstallmentPaymentList(int? filterType, int? branchFilter, int? day, int? month, int? year)
        {
            List<ScheduleInstallmenttListDto> scheduleInstallments = new List<ScheduleInstallmenttListDto>();


            decimal totalDue = 0;
            decimal totalPaid = 0;
            decimal totalUnPaid = 0;

            if (filterType == null)
            {
                filterType = 1;
            }
            //if (day == null)
            //{
            //    day = DateTime.Now.Day;
            //}
            if (month == null)
            {
                month = DateTime.Now.Month;
            }
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName((int)month);
            ViewBag.monthName = monthName;
            ViewBag.Month = month;
            ViewBag.Year = year;
            ViewBag.Day = day;
            ViewBag.filterType = filterType;

            int branch = 0;

            if (branchFilter == null)
            {
                branch = Branchid();
            }
            else
            {
                branch = (int)branchFilter;
            }

            var getDisbursedApplications = new List<Applicationz>();

            var users = _userAppService.GetAllUsers();


            if (branch != 0)
            {
                getDisbursedApplications = _applicationRepository.GetAllList(x => x.ScreenStatus == ApplicationState.Disbursed && (int)x.FK_branchid == branch).ToList();
            }
            else
            {
                getDisbursedApplications = _applicationRepository.GetAllList(x => x.ScreenStatus == ApplicationState.Disbursed).ToList();
            }

            if (getDisbursedApplications.Count > 0)
            {
                foreach (var app in getDisbursedApplications)
                {
                    var schedule = _scheduleAppService.GetScheduleByApplicationId(app.Id).Result;
                    if (schedule != null)
                    {
                        List<ScheduleInstallmenttListDto> installments = new List<ScheduleInstallmenttListDto>();

                        if (day != null)
                        {
                            if (filterType == 1)
                            {
                                installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && DateTime.Parse(x.InstallmentDueDate).Day == day && DateTime.Parse(x.InstallmentDueDate).Month == month && DateTime.Parse(x.InstallmentDueDate).Year == year).ToList();
                            }
                            else if (filterType == 2)
                            {
                                installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && x.isPaid == true && ((DateTime)x.PaymentDate).Day == day && ((DateTime)x.PaymentDate).Month == month && ((DateTime)x.PaymentDate).Year == year).ToList();
                            }
                            else if (filterType == 3)
                            {
                                installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && x.isPaid != true && DateTime.Parse(x.InstallmentDueDate).Day == day && DateTime.Parse(x.InstallmentDueDate).Month == month && DateTime.Parse(x.InstallmentDueDate).Year == year).ToList();
                            }
                        }
                        else
                        {
                            if (filterType == 1)
                            {
                                installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && DateTime.Parse(x.InstallmentDueDate).Month == month && DateTime.Parse(x.InstallmentDueDate).Year == year).ToList();
                            }
                            else if (filterType == 2)
                            {
                                installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && x.isPaid == true && ((DateTime)x.PaymentDate).Month == month && ((DateTime)x.PaymentDate).Year == year).ToList();
                            }
                            else if (filterType == 3)
                            {
                                installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && x.isPaid != true && DateTime.Parse(x.InstallmentDueDate).Month == month && DateTime.Parse(x.InstallmentDueDate).Year == year).ToList();
                            }
                        }


                        var paidInstallments = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(schedule.ApplicationId).Result;

                        if (paidInstallments != null)
                        {
                            foreach (var installment in installments)
                            {

                                if (installment.InstNumber != "0")
                                {
                                    var paidInstByInstNo = paidInstallments.Where(x => x.NoOfInstallment.ToString() == installment.InstNumber);

                                    decimal sumOfAmountsPerInstallment = 0;
                                    decimal excessShort = 0;
                                    foreach (var paidInstallment in paidInstByInstNo)
                                    {
                                        sumOfAmountsPerInstallment += paidInstallment.Amount;
                                        excessShort = paidInstallment.ExcessShortPayment;


                                    }
                                    installment.PaidAmount = sumOfAmountsPerInstallment.ToString();


                                    sumOfAmountsPerInstallment = 0;
                                }
                                else
                                {
                                    var AllDefferedInstallments = schedule.installmentList.Where(x => x.InstNumber == installment.InstNumber).ToList();
                                    var indexOfThisInstallment = AllDefferedInstallments.IndexOf(installment);

                                    var paidDeferredInstallments = paidInstallments.Where(x => x.NoOfInstallment.ToString() == "0").ToList();
                                    try
                                    {
                                        var paidDeferredInstallmentOnThisIndex = paidDeferredInstallments[indexOfThisInstallment];
                                        installment.PaidAmount = paidDeferredInstallmentOnThisIndex.Amount.ToString();
                                        installment.ExcessShort = paidDeferredInstallmentOnThisIndex.ExcessShortPayment.ToString();

                                    }
                                    catch
                                    {

                                    }

                                }
                            }
                        }



                        if (installments.Count > 0)
                        {
                            foreach (var inst in installments)
                            {
                                inst.ClientId = app.ClientID;
                                inst.ClientName = app.ClientName;
                                inst.BusinessName = app.SchoolName;
                                inst.Applicationid = app.Id;
                                inst.BranchName = app.BranchCode;
                                inst.LoanAmount = schedule.LoanAmount;
                                var sde = users.Where(x => x.Id == app.CreatorUserId).FirstOrDefault();
                                if (sde != null)
                                {
                                    inst.SdeName = sde.FullName;
                                }
                                scheduleInstallments.Add(inst);

                                totalDue += decimal.Parse(inst.installmentAmount.Replace(",", ""));

                                if (inst.isPaid == true)
                                {
                                    totalPaid += decimal.Parse(inst.PaidAmount.Replace(",", ""));
                                }
                                else
                                {
                                    totalUnPaid += decimal.Parse(inst.installmentAmount.Replace(",", ""));
                                }


                            }
                        }
                    }
                }
            }

            ViewBag.Due = totalDue;
            ViewBag.Paid = totalPaid;
            ViewBag.UnPaid = totalUnPaid;

            var branches = _branchDetailAppService.GetBranchListDetail();

            ViewBag.McrcUserList = new SelectList(branches, "Id", "BranchCode");

            return View(scheduleInstallments);
        }

        public IActionResult ViewInstallmentPayment(int Id)
        {
            ViewBag.Id = Id;
            var authorizeInstallment = _authorizeInstallmentPaymentAppService.GetAuthorizeInstallmentPaymentById(Id).Result;
            if (authorizeInstallment != null)
            {
                ViewBag.Applicationid = authorizeInstallment.ApplicationId;
                var app = _applicationAppService.GetApplicationById(authorizeInstallment.ApplicationId);
                ViewBag.ClientId = app.ClientID;
                ViewBag.ClientName = app.ClientName;
                var Banks = _companyBankAccountRepository.Get(authorizeInstallment.FK_CompanyBankId);
                if (Banks != null)
                {
                    ViewBag.BanksList = Banks.Name;
                }
                else
                {
                    ViewBag.BanksList = "";
                }
                var NatureOfPayments = _natureOfPaymentRepository.Get(authorizeInstallment.NatureOfPayment);
                if (NatureOfPayments != null)
                {
                    ViewBag.NatureOfPaymentsList = NatureOfPayments.Name;
                }
                else
                {
                    ViewBag.NatureOfPaymentsList = "";
                }
                ViewBag.InstallmentDueDate = authorizeInstallment.InstallmentDueDate;
                ViewBag.InstallmentAmount = authorizeInstallment.InstallmentAmount;
                ViewBag.InstallmentNumber = authorizeInstallment.NoOfInstallment;
                ViewBag.PreviousBalance = authorizeInstallment.PreviousBalance;
                ViewBag.DueAmount = authorizeInstallment.DueAmount;
                ViewBag.ModeOfPayment = authorizeInstallment.ModeOfPayment;
                ViewBag.Amount = authorizeInstallment.Amount;
                ViewBag.ExcessShortPayment = authorizeInstallment.ExcessShortPayment;
                ViewBag.AmountWords = authorizeInstallment.AmountWords;
                ViewBag.LateDays = authorizeInstallment.LateDays;
                ViewBag.LateDaysPenalty = authorizeInstallment.LateDaysPenalty;
                ViewBag.DepositDate = authorizeInstallment.DepositDate.ToString("yyyy-MM-dd hh:mm:ss tt");
                ViewBag.BankId = authorizeInstallment.FK_CompanyBankId;
                ViewBag.isLateDaysApplied = authorizeInstallment.isLateDaysApplied;
            }
            else
            {
                ViewBag.Applicationid = 0;
                ViewBag.ClientId = "";
                ViewBag.ClientName = "";
                ViewBag.BanksList = "";
                ViewBag.NatureOfPaymentsList = "";
                ViewBag.InstallmentDueDate = "";
                ViewBag.InstallmentAmount = "0";
                ViewBag.InstallmentNumber = "0";
                ViewBag.PreviousBalance = "0";
                ViewBag.DueAmount = "0";
                ViewBag.ModeOfPayment = "";
                ViewBag.Amount = "";
                ViewBag.ExcessShortPayment = "";
                ViewBag.AmountWords = "";
                ViewBag.isLateDaysApplied = 0;
                ViewBag.LateDays = "0";
                ViewBag.LateDaysPenalty = "0";
                ViewBag.DepositDate = "";
                ViewBag.BankId = 0;
            }

            return View();
        }

        public IActionResult ViewAuthorizationsReschedule()
        {
            var schedules = _scheduleTempAppService.GetScheduleTempList().Result.Where(x => x.isAuthorizedByBM == null);

            List<ApplicationListDto> apps = new List<ApplicationListDto>();
            if (schedules != null)
            {
                foreach (var schedule in schedules)
                {
                    var app = _applicationAppService.GetApplicationById(schedule.ApplicationId);
                    app.Comments = schedule.UpdationReason;
                    apps.Add(app);
                }
            }
            return View(apps);
        }

        public async Task<ActionResult> AuthorizationPartial(int appid)
        {
            ViewBag.AppId = appid;
            return View("AuthorizationPartial");
        }

        public async Task<ActionResult> AuthorizationInstallmentPaymentPartial(int id)
        {
            ViewBag.Id = id;
            ViewBag.IP = _installmentPaymentRepository.Get(id);
            return View("AuthorizationInstallmentPaymentPartial");
        }

        public async Task<ActionResult> AuthorizationPartialTemp(int appid)
        {
            ViewBag.AppId = appid;
            return View("AuthorizationPartialTemp");
        }

        [HttpPost]
        public async Task<JsonResult> AuthorizeByBM(int ApplicationId, bool Recommendation, string Reason)
        {
            String response = "";
            try
            {
                var getSchedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result;
                if (getSchedule != null)
                {
                    var schedule = _scheduleRepository.GetAllList(x => x.Id == getSchedule.Id).FirstOrDefault();
                    schedule.isAuthorizedByBM = Recommendation;
                    schedule.Reason = Reason;
                    _scheduleRepository.Update(schedule);
                    CurrentUnitOfWork.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> AuthorizeByBmReschedule(int ApplicationId, bool Recommendation, string Reason)
        {
            String response = "";
            try
            {
                var getSchedule = _scheduleTempAppService.GetScheduleTempByApplicationId(ApplicationId).Result;
                if (getSchedule != null)
                {
                    var schedule = _scheduleTempRepository.GetAllList(x => x.Id == getSchedule.Id).FirstOrDefault();
                    schedule.isAuthorizedByBM = Recommendation;
                    schedule.Reason = Reason;
                    _scheduleTempRepository.Update(schedule);
                    CurrentUnitOfWork.SaveChanges();

                    if (Recommendation == true)
                    {
                        CreateScheduleDto CreateSchedule = new CreateScheduleDto();
                        CreateSchedule.AccountTitle = getSchedule.AccountTitle;
                        CreateSchedule.ApplicationId = getSchedule.ApplicationId;
                        CreateSchedule.ClientId = getSchedule.ClientId;
                        CreateSchedule.ScheduleType = getSchedule.ScheduleType;
                        CreateSchedule.LoanAmount = getSchedule.LoanAmount;
                        CreateSchedule.Tenure = getSchedule.Tenure;
                        CreateSchedule.Markup = getSchedule.Markup;
                        CreateSchedule.DisbursmentDate = getSchedule.DisbursmentDate;
                        CreateSchedule.GraceDays = getSchedule.GraceDays;
                        CreateSchedule.Deferment = getSchedule.Deferment;
                        CreateSchedule.RepaymentACnumber = getSchedule.RepaymentACnumber;
                        CreateSchedule.BankBranchName = getSchedule.BankBranchName;
                        CreateSchedule.TFCL_Branch = getSchedule.TFCL_Branch;
                        CreateSchedule.BranchManager = getSchedule.BranchManager;
                        CreateSchedule.SDE = getSchedule.SDE;
                        CreateSchedule.DeffermentStartDate = getSchedule.DeffermentStartDate;
                        CreateSchedule.DeffermentEndDate = getSchedule.DeffermentEndDate;
                        CreateSchedule.IRR = getSchedule.IRR;
                        CreateSchedule.Installment = getSchedule.Installment;
                        CreateSchedule.LoanStartDate = getSchedule.LoanStartDate;
                        CreateSchedule.LastInstallmentDate = getSchedule.LastInstallmentDate;
                        CreateSchedule.YearlyMarkup = getSchedule.YearlyMarkup;
                        CreateSchedule.PerDayMarkup = getSchedule.PerDayMarkup;
                        CreateSchedule.isAuthorizedByBM = true;
                        CreateSchedule.Reason = getSchedule.Reason;

                        List<CreateScheduleInstallmentDto> listInstallments = new List<CreateScheduleInstallmentDto>();
                        foreach (var installment in getSchedule.installmentList)
                        {
                            CreateScheduleInstallmentDto installmentDto = new CreateScheduleInstallmentDto();
                            installmentDto.InstNumber = installment.InstNumber;
                            installmentDto.BalInst = installment.BalInst;
                            installmentDto.InstallmentDueDate = installment.InstallmentDueDate;
                            installmentDto.OsPrincipal_op = installment.OsPrincipal_op;
                            installmentDto.AdditionalTranche = installment.AdditionalTranche;
                            installmentDto.OsPrincipal_Opening = installment.OsPrincipal_Opening;
                            installmentDto.markup = installment.markup;
                            installmentDto.principal = installment.principal;
                            installmentDto.installmentAmount = installment.installmentAmount;
                            installmentDto.OsPrincipal_Closing = installment.OsPrincipal_Closing;
                            installmentDto.isPaid = installment.isPaid;
                            installmentDto.PaymentDate = installment.PaymentDate;

                            listInstallments.Add(installmentDto);

                        }

                        CreateSchedule.installmentList = listInstallments;


                        _scheduleAppService.CreateSchedule(CreateSchedule);

                    }



                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> RejectInstallmentPayment(int Id, string Reason)
        {
            String response = "";
            try
            {
                var getInstallmentPayment = _authorizeInstallmentPaymentRepository.Get(Id);
                if (getInstallmentPayment != null)
                {
                    getInstallmentPayment.isAuthorized = false;
                    getInstallmentPayment.RejectionReason = Reason;
                    _authorizeInstallmentPaymentRepository.Update(getInstallmentPayment);
                    CurrentUnitOfWork.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                response = "Error : " + ex.ToString();
            }


            return Json(response);
        }


        public void AuthorizeInstallmentPayment(int Id)
        {
            try
            {
                var getInstallmentPayment = _authorizeInstallmentPaymentRepository.Get(Id);
                if (getInstallmentPayment != null)
                {
                    getInstallmentPayment.isAuthorized = true;
                    _authorizeInstallmentPaymentRepository.Update(getInstallmentPayment);
                    CurrentUnitOfWork.SaveChanges();
                }

            }
            catch (Exception ex)
            {
            }

        }

        public IActionResult DisburseApplication(int ApplicationId)
        {
            CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
            fWobj.ApplicationId = ApplicationId;
            fWobj.Action = "Disbursed";
            fWobj.ActionBy = (int)AbpSession.UserId;
            fWobj.ApplicationState = ApplicationState.Disbursed;
            fWobj.isActive = true;

            _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

            _applicationAppService.ChangeApplicationState(ApplicationState.Disbursed, ApplicationId, "Disbursed");

            var appData = _applicationAppService.GetApplicationById(ApplicationId);
            _notificationLogAppService.SendNotification((int)appData.CreatorUserId, appData.ClientID + " has been Disbursed.", "Click to Open the Application.");


            return RedirectToAction("Applications", "Application");
        }

        public IActionResult ViewSchedule(int ApplicationId)
        {
            var getSchedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result;

            var Application = _applicationAppService.GetApplicationById(ApplicationId);
            if (Application != null)
            {
                ViewBag.ApplicantName = Application.ClientName;
                ViewBag.SchoolName = Application.SchoolName;
                ViewBag.ScreenStatus = Application.ScreenStatus;
                ViewBag.Product = Application.ProductTypeName;
                ViewBag.AppNo = Application.ClientID;
            }

            if (getSchedule != null)
            {
                ViewBag.DisbursmentDate = getSchedule.DisbursmentDate;
            }

            //var getDisbursedDate = _finalWorkflowAppService.GetFinalWorkflowByApplicationId(ApplicationId).Where(x => x.ApplicationState == ApplicationState.Disbursed).FirstOrDefault();
            //if (getDisbursedDate != null)
            //{
            //    ViewBag.DisbursmentDate = (getDisbursedDate.CreationTime == null ? "--" : string.Format("{0:dd MMM yyyy}", getDisbursedDate.CreationTime));
            //}



            var paidInstallments = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(ApplicationId).Result;

            if (paidInstallments != null)
            {
                foreach (var installment in getSchedule.installmentList)
                {
                    if (installment.InstNumber != "0")
                    {
                        var paidInstByInstNo = paidInstallments.Where(x => x.NoOfInstallment.ToString() == installment.InstNumber);

                        decimal sumOfAmountsPerInstallment = 0;
                        decimal excessShort = 0;
                        foreach (var paidInstallment in paidInstByInstNo)
                        {
                            sumOfAmountsPerInstallment += paidInstallment.Amount;
                            excessShort = paidInstallment.ExcessShortPayment;
                        }
                        installment.PaidAmount = sumOfAmountsPerInstallment.ToString();
                        installment.ExcessShort = excessShort.ToString();

                        sumOfAmountsPerInstallment = 0;
                    }
                    else
                    {
                        //Due To Ahsan Habib Display Issue
                        //var AllDefferedInstallments = getSchedule.installmentList.Where(x => x.InstNumber == installment.InstNumber).ToList();
                        //var indexOfThisInstallment = AllDefferedInstallments.IndexOf(installment);

                        //var paidDeferredInstallments = paidInstallments.Where(x => x.NoOfInstallment.ToString() == "0").ToList();

                        //try
                        //{
                        //    var paidDeferredInstallmentOnThisIndex = paidDeferredInstallments[indexOfThisInstallment];
                        //    installment.PaidAmount = paidDeferredInstallmentOnThisIndex.Amount.ToString();
                        //    installment.ExcessShort = paidDeferredInstallmentOnThisIndex.ExcessShortPayment.ToString();

                        //}
                        //catch
                        //{

                        //}

                        var AllDefferedInstallments = getSchedule.installmentList.Where(x => x.InstNumber == installment.InstNumber).ToList();
                        var indexOfThisInstallment = AllDefferedInstallments.IndexOf(installment);

                        var paidDeferredInstallments = paidInstallments.Where(x => x.NoOfInstallment.ToString() == "0" && x.InstallmentDueDate == DateTime.Parse(installment.InstallmentDueDate)).ToList();

                        try
                        {
                            if (paidDeferredInstallments.Count > 1)
                            {
                                foreach (var paidDeferment in paidDeferredInstallments)
                                {
                                    decimal a = 0;
                                    if (installment.PaidAmount != null && installment.PaidAmount != "")
                                    {
                                        a = Decimal.Parse(installment.PaidAmount);
                                    }

                                    decimal b = paidDeferment.Amount;

                                    installment.PaidAmount = (a + b).ToString();
                                    installment.ExcessShort = paidDeferment.ExcessShortPayment.ToString();
                                }

                            }
                            else
                            {
                                //var paidDeferredInstallmentOnThisIndex = paidDeferredInstallments[indexOfThisInstallment];
                                installment.PaidAmount = paidDeferredInstallments[0].Amount.ToString();
                                installment.ExcessShort = paidDeferredInstallments[0].ExcessShortPayment.ToString();

                            }

                        }
                        catch (Exception ex)
                        {
                            string a = ex.ToString();
                        }
                    }
                }
            }



            ViewBag.PrintDate = DateTime.Now.ToString("dd MMM yyyy");


            return View(getSchedule);
        }

        public IActionResult InstallmentPayment(int ApplicationId)
        {
            ViewBag.Applicationid = ApplicationId;

            var app = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.ClientId = app.ClientID;
            ViewBag.ClientName = app.ClientName;

            var Banks = _companyBankAccountRepository.GetAllList().Select(s => new { Id = s.Id, Selection = string.Format("{0} {1} ({2})", s.Name, s.Branch, s.AccountNumber) }).ToList();
            ViewBag.BanksList = new SelectList(Banks, "Id", "Selection");

            var NatureOfPayments = _natureOfPaymentRepository.GetAllList().ToList();
            ViewBag.NatureOfPaymentsList = new SelectList(NatureOfPayments, "Id", "Name");

            var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result ?? null;

            ScheduleInstallmenttListDto firstUnpaidInstallment = new ScheduleInstallmenttListDto();

            if (schedule != null)
            {
                firstUnpaidInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber != "G*").FirstOrDefault();
            }
            else
            {
                firstUnpaidInstallment = null;
            }


            if (firstUnpaidInstallment != null)
            {
                ViewBag.InstallmentDueDate = firstUnpaidInstallment.InstallmentDueDate;
                ViewBag.InstallmentAmount = (firstUnpaidInstallment.installmentAmount == "--" || firstUnpaidInstallment.installmentAmount == "" ? "0" : firstUnpaidInstallment.installmentAmount);
                ViewBag.InstallmentNumber = firstUnpaidInstallment.InstNumber;
                ViewBag.RemainingInstallments = firstUnpaidInstallment.BalInst;
            }
            else
            {
                ViewBag.InstallmentDueDate = "0";
                ViewBag.InstallmentAmount = "0";
                ViewBag.InstallmentNumber = "0";
                ViewBag.RemainingInstallments = schedule.installmentList.Where(x => x.InstNumber != "G*").Count();

            }

            var paidInstallments = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(ApplicationId);
            decimal previous;
            if (paidInstallments.Result.Count > 0)
            {
                var lastPaidInstallment = paidInstallments.Result.LastOrDefault();
                if (lastPaidInstallment.NoOfInstallment.ToString() != firstUnpaidInstallment.InstNumber)
                {
                    ViewBag.PreviousBalance = lastPaidInstallment.ExcessShortPayment;
                    previous = lastPaidInstallment.ExcessShortPayment;
                }
                else if (lastPaidInstallment.NoOfInstallment.ToString() == "0")
                {
                    //Changed due to Asif Iqbal's Previous Balance Issue
                    //var sameInstallmentPaymentsList = paidInstallments.Result.Where(x => x.InstallmentDueDate == DateTime.Parse(lastPaidInstallment.InstallmentDueDate));
                    var sameInstallmentPaymentsList = paidInstallments.Result.Where(x => x.InstallmentDueDate == DateTime.Parse(firstUnpaidInstallment.InstallmentDueDate));
                    decimal sumOfAllPaymentsForOneInstallment = 0;

                    int count = 0;
                    foreach (var payments in sameInstallmentPaymentsList)
                    {
                        if (count > 0)
                        {
                            sumOfAllPaymentsForOneInstallment += (payments.Amount);
                        }
                        else
                        {
                            sumOfAllPaymentsForOneInstallment += (payments.Amount + payments.PreviousBalance);
                        }

                        count++;
                    }

                    ViewBag.PreviousBalance = sumOfAllPaymentsForOneInstallment;
                    previous = sumOfAllPaymentsForOneInstallment;
                }
                else
                {
                    var sameInstallmentPaymentsList = paidInstallments.Result.Where(x => x.NoOfInstallment == lastPaidInstallment.NoOfInstallment);
                    decimal sumOfAllPaymentsForOneInstallment = 0;

                    int count = 0;
                    foreach (var payments in sameInstallmentPaymentsList)
                    {
                        if (count > 0)
                        {
                            sumOfAllPaymentsForOneInstallment += (payments.Amount);
                        }
                        else
                        {
                            sumOfAllPaymentsForOneInstallment += (payments.Amount + payments.PreviousBalance);
                        }

                        count++;
                    }

                    ViewBag.PreviousBalance = sumOfAllPaymentsForOneInstallment;
                    previous = sumOfAllPaymentsForOneInstallment;
                }
            }
            else
            {
                ViewBag.PreviousBalance = "0";
                previous = 0;
            }
            decimal Iamount = Decimal.Parse((ViewBag.InstallmentAmount).Replace(",", ""));
            ViewBag.DueAmount = Iamount - previous;

            return View();
        }



        [DisableValidation]
        [HttpPost]
        public IActionResult CreateAuthorizeInstallmentPayment(CreateAuthorizeInstallmentPayment payment)
        {
            _authorizeInstallmentPaymentAppService.Create(payment);

            //var schedule = _scheduleAppService.GetScheduleByApplicationId(payment.ApplicationId).Result;
            //var firstUnpaidInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber != "G*").FirstOrDefault();
            //var scheduleInstallment = _scheduleInstallmentRepository.Get(firstUnpaidInstallment.Id);

            //decimal paidAmount = payment.Amount;

            //var Exists = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(payment.ApplicationId);
            //if (Exists.Result != null || Exists.Result.Count >= 0)
            //{
            //    decimal existingAmountForSingleInstallment = 0;
            //    foreach (var existingPayment in Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber))
            //    {
            //        existingAmountForSingleInstallment += existingPayment.Amount;
            //    }
            //    paidAmount += existingAmountForSingleInstallment;

            //    var gracePeriodInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber == "G*").FirstOrDefault();
            //    if (gracePeriodInstallment != null)
            //    {
            //        var graceInstallment = _scheduleInstallmentRepository.Get(gracePeriodInstallment.Id);
            //        decimal gracePaidAmount = paidAmount;
            //        gracePaidAmount = paidAmount - Decimal.Parse(graceInstallment.markup);

            //        if (gracePaidAmount >= -100)
            //        {
            //            graceInstallment.isPaid = true;
            //            graceInstallment.PaymentDate = payment.DepositDate;
            //            _scheduleInstallmentRepository.Update(graceInstallment);
            //            CurrentUnitOfWork.SaveChanges();
            //        }
            //    }

            //    //if (Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber).ToList().Count <= 1)
            //    //{
            //    //    paidAmount += payment.PreviousBalance;
            //    //} commented on 29-03-2021
            //}

            //paidAmount -= Decimal.Parse(scheduleInstallment.installmentAmount);

            //_installmentPaymentAppService.Create(payment);

            //if (paidAmount >= -100)
            //{
            //    scheduleInstallment.isPaid = true;
            //    scheduleInstallment.PaymentDate = payment.DepositDate;
            //    _scheduleInstallmentRepository.Update(scheduleInstallment);
            //    CurrentUnitOfWork.SaveChanges();
            //}




            return RedirectToAction("InstallmentPayment", new { ApplicationId = payment.ApplicationId });
        }

        [DisableValidation]
        [HttpPost]
        public IActionResult CreateInstallmentPayment(CreateInstallmentPayment payment)
        {
            AuthorizeInstallmentPayment(payment.AuthorizationId);

            var schedule = _scheduleAppService.GetScheduleByApplicationId(payment.ApplicationId).Result;
            var firstUnpaidInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber != "G*").FirstOrDefault();
            var indexOfLastPaidInstallment = schedule.installmentList.IndexOf(firstUnpaidInstallment) - 1;

            ScheduleInstallmenttListDto lastPaidInstallment = new ScheduleInstallmenttListDto();

            if (indexOfLastPaidInstallment != -1)
            {
                lastPaidInstallment = schedule.installmentList[indexOfLastPaidInstallment];
            }

            var scheduleInstallment = _scheduleInstallmentRepository.Get(firstUnpaidInstallment.Id);

            decimal paidAmount = payment.Amount;

            var Exists = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(payment.ApplicationId);
            if (Exists.Result != null || Exists.Result.Count >= 0)
            {
                decimal existingAmountForSingleInstallment = 0;
                foreach (var existingPayment in Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber))
                {
                    existingAmountForSingleInstallment += (existingPayment.Amount);
                }


                //Before 2-8-2021
                //paidAmount += existingAmountForSingleInstallment;

                //After 2-8-2021 Start
                if (lastPaidInstallment != null)
                {
                    decimal excessShortForLastPaidInstallment = 0;
                    if (lastPaidInstallment.InstNumber != "G*")
                    {
                        var lastPaidinstallmentPayment = Exists.Result.Where(x => x.NoOfInstallment == Int32.Parse(lastPaidInstallment.InstNumber)).ToList();
                        if (lastPaidinstallmentPayment.Count == 1)
                        {
                            excessShortForLastPaidInstallment = lastPaidinstallmentPayment[0].ExcessShortPayment;
                        }
                        else if (lastPaidinstallmentPayment.Count > 1)
                        {
                            excessShortForLastPaidInstallment = lastPaidinstallmentPayment.LastOrDefault().ExcessShortPayment;
                        }
                    }
                    paidAmount += existingAmountForSingleInstallment + excessShortForLastPaidInstallment;
                }
                //After 2-8-2021 End



                var gracePeriodInstallment = schedule.installmentList.Where(x => (x.isPaid == false || x.isPaid == null) && x.InstNumber == "G*").FirstOrDefault();
                if (gracePeriodInstallment != null)
                {
                    var graceInstallment = _scheduleInstallmentRepository.Get(gracePeriodInstallment.Id);
                    decimal gracePaidAmount = paidAmount;
                    gracePaidAmount = paidAmount - Decimal.Parse(graceInstallment.markup);

                    if (gracePaidAmount >= -100)
                    {
                        graceInstallment.isPaid = true;
                        graceInstallment.PaymentDate = payment.DepositDate;
                        _scheduleInstallmentRepository.Update(graceInstallment);
                        CurrentUnitOfWork.SaveChanges();
                    }
                }

                //if (Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber).ToList().Count <= 1)
                //{
                //    paidAmount += payment.PreviousBalance;
                //} commented on 29-03-2021
            }

            paidAmount -= Decimal.Parse(scheduleInstallment.installmentAmount);

            payment.isAuthorized = true;
            _installmentPaymentAppService.Create(payment);

            if (paidAmount >= -100)
            {
                scheduleInstallment.isPaid = true;
                scheduleInstallment.PaymentDate = payment.DepositDate;
                _scheduleInstallmentRepository.Update(scheduleInstallment);
                CurrentUnitOfWork.SaveChanges();
            }
            return RedirectToAction("AuthorizationInstallmentPayment");
        }


        public IActionResult ViewReSchedule(int ApplicationId)
        {
            var getScheduleTemp = _scheduleTempAppService.GetScheduleTempByApplicationId(ApplicationId).Result;

            var Application = _applicationAppService.GetApplicationById(ApplicationId);
            if (Application != null)
            {
                ViewBag.ApplicantName = Application.ClientName;
                ViewBag.SchoolName = Application.SchoolName;
                ViewBag.ScreenStatus = Application.ScreenStatus;
                ViewBag.Product = Application.ProductTypeName;
                ViewBag.AppNo = Application.ClientID;
            }

            var getDisbursedDate = _finalWorkflowAppService.GetFinalWorkflowByApplicationId(ApplicationId).Where(x => x.ApplicationState == ApplicationState.Disbursed).FirstOrDefault();
            if (getDisbursedDate != null)
            {
                ViewBag.DisbursmentDate = (getDisbursedDate.CreationTime == null ? "--" : string.Format("{0:dd MMM yyyy}", getDisbursedDate.CreationTime));
            }

            return View(getScheduleTemp);
        }

        public IActionResult Schedule(int ApplicationId)
        {
            ViewBag.ApplicationId = ApplicationId;
            double markup = 0.00;
            int tenure = 0;
            int LoanAmount = 0;
            var application = _applicationAppService.GetApplicationById(ApplicationId);
            if (application != null)
            {
                var getLRD = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result;
                if (getLRD != null)
                {
                    ViewBag.LoanRequisitionDetails = getLRD;
                    tenure = Int32.Parse(getLRD.LoanTenureRequestedName);
                    LoanAmount = Int32.Parse(getLRD.LoanAmountRecommended.Replace(",", ""));
                }
                var getBranch = _branchDetailAppService.GetBranchDetailById(application.FK_branchid);
                if (getLRD != null)
                {
                    ViewBag.Branch = getBranch;
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

                //var getLE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(ApplicationId).Result;
                //if (getLE != null)
                //{
                //    ViewBag.LoanEligibility = getLE;
                //    markup = double.Parse(getLE.Mark_Up);
                //}
                //var getBA = _bankAccountAppService.GetBankAccountDetailByApplicationId(ApplicationId).Result.FirstOrDefault();
                //if (getBA != null)
                //{
                //    ViewBag.BankAccount = getBA;
                //}
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

        public IActionResult Reschedule(int ApplicationId)
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
                //foreach (var item in schedule.listForTranches)
                //{

                //    //Calculation of Tenure
                //    int tranchTenure = 0;

                //    if (item.tranchId == '1') { tranchTenure = Installments; }
                //    else
                //    {
                //        DateTime a = item.StartDate;
                //        DateTime b = Schedule.listForTranches[0].StartDate;

                //        tranchTenure = Installments - MonthDifference(a, b);
                //    }
                //    tranchTenure += Schedule.DefermentMonths;
                //    item.tranchTenure = tranchTenure;

                //    sumOfAmounts += Int32.Parse(item.Amount);

                //    item.Irr = (Rate(tranchTenure, (1 + ((1 * markup) / 12 * tranchTenure)) / tranchTenure, -1, 0, 0) * 12) * 100;

                //    item.tranchInstallment = -PMT(item.Irr / 1200, tranchTenure, sumOfAmounts, 0, 0);

                //    item.DailyMarkup = Int32.Parse(item.Amount) * markup / 365;

                //}
            }



            ViewBag.Input = schedule;

            return View();
        }




        [HttpPost]
        public JsonResult getInstallments(int ApplicationId)
        {
            try
            {
                var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId);
                if (schedule != null)
                {
                    var installments = schedule.Result.installmentList;
                    return Json(installments);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.ToString());
            }
        }

        [HttpPost]
        public JsonResult getAuthorizeInstallmentPayment(int ApplicationId)
        {
            try
            {
                var schedule = _authorizeInstallmentPaymentAppService.GetAllAuthorizeInstallmentPaymentByApplicationId(ApplicationId);
                var installments = schedule.Result;
                return Json(installments);
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.ToString());
            }
        }


        [HttpPost]
        public JsonResult getHolidays()
        {
            try
            {
                var holidays = _holidayRepository.GetAllList();
                return Json(holidays);
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.ToString());
            }
        }




        [DisableValidation]
        [HttpPost]
        public IActionResult ScheduleResult(GetFromFormDto Schedule)
        {

            List<signatories> listForSignatories = new List<signatories>();

            ViewBag.ApplicationId = Schedule.ApplicationId;

            var application = _applicationAppService.GetApplicationById(Schedule.ApplicationId);
            if (application != null)
            {
                ViewBag.Application = application;
                ViewBag.BMName = _userAppService.GetUserById(Schedule.BranchManagerId).Result.FullName;
                ViewBag.SDEName = _userAppService.GetUserById(Schedule.SdeId).Result.FullName;

                signatories applicant = new signatories();
                applicant.Name = application.ClientName;
                applicant.Detail = "(Applicant)";
                listForSignatories.Add(applicant);

                signatories bm = new signatories();
                bm.Name = ViewBag.BMName;
                bm.Detail = "(Branch Manager)";
                listForSignatories.Add(bm);

                var getCoApplicants = _coApplicantDetailAppService.GetCoApplicantDetailByApplicationId(Schedule.ApplicationId).Result.ToList();
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

                var getGuarantors = _guarantorDetailAppService.GetGuarantorDetailByApplicationId(Schedule.ApplicationId).Result.ToList();
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


            if (Schedule.ScheduleType == "Tranches")
            {
                int LoanAmount = 0;
                int Installments = 0;
                double markup = 0;

                var getLRD = _businessPlanAppService.GetBusinessPlanByApplicationId(Schedule.ApplicationId).Result;
                if (getLRD != null)
                {
                    ViewBag.LoanRequisitionDetails = getLRD;
                    Installments = Int32.Parse(getLRD.LoanTenureRequestedName);
                }

                var getLE = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(Schedule.ApplicationId).Result;
                if (getLE != null)
                {
                    ViewBag.LoanEligibility = getLE;
                    markup = double.Parse(getLE.Mark_Up);
                }



                markup = markup / 100;

                int sumOfAmounts = 0;
                foreach (var item in Schedule.listForTranches)
                {

                    //Calculation of Tenure
                    int tranchTenure = 0;

                    if (item.tranchId == 1) { tranchTenure = Installments; }
                    else
                    {
                        //DateTime a = item.StartDate;
                        DateTime a = item.StartDate;
                        DateTime b = Schedule.LoanStartDate;
                        //DateTime b = Schedule.LoanStartDate.AddMonths(1);
                        //DateTime b = Schedule.listForTranches[0].StartDate;

                        tranchTenure = Installments - MonthDifference(a, b);
                    }
                    //tranchTenure += Schedule.DefermentMonths;
                    item.tranchTenure = tranchTenure;

                    sumOfAmounts += Int32.Parse(item.Amount);

                    item.Irr = (Rate(tranchTenure, (1 + ((1 * markup) / 12 * tranchTenure)) / tranchTenure, -1, 0, 0) * 12) * 100;

                    item.tranchInstallment = -PMT(item.Irr / 1200, tranchTenure, sumOfAmounts, 0, 0);

                    item.DailyMarkup = Int32.Parse(item.Amount) * markup / 365;

                }
            }



            ViewBag.Input = Schedule;
            var branch = _branchDetailAppService.GetBranchListDetail().Where(x => x.BranchName.Contains(Schedule.BranchName)).FirstOrDefault();
            if (branch != null)
            {
                ViewBag.BranchCode = branch.BranchCode;
            }
            return View();
        }


        [HttpPost]
        public JsonResult SaveSchedule(CreateScheduleDto Schedule)
        {
            try
            {
                _scheduleAppService.CreateSchedule(Schedule);
                return Json("Schedule saved successfully");
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.ToString());
            }
        }

        [HttpPost]
        public JsonResult SaveScheduleTemp(CreateScheduleTempDto Schedule)
        {
            try
            {
                _scheduleTempAppService.CreateScheduleTemp(Schedule);
                return Json("Schedule saved successfully");
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.ToString());
            }
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

        public static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }

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

        private const double cnL_IT_STEP = 0.00001;
        private const double cnL_IT_EPSILON = 0.0000001;

        enum DueDate
        {
            EndOfPeriod = 0,
            BegOfPeriod = 1
        }

        //public static double PMT(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
        //{
        //    var rate = (double)yearlyInterestRate / 100 / 12;
        //    var denominator = Math.Pow((1 + rate), totalNumberOfMonths) - 1;
        //    return (rate + (rate / denominator)) * loanAmount;
        //}

        public static double PMT(double RATE, int NPER, int PV, long FV, int TYPE)
        {
            return -RATE * (FV + PV * Math.Pow(1 + RATE, NPER)) / ((Math.Pow(1 + RATE, NPER) - 1) * (1 + RATE * TYPE));
        }


        public IActionResult ActiveSchedules()
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

        //Early Settlement Module Start
        public IActionResult EarlySettlement(int ApplicationId)
        {
            ViewBag.Applicationid = ApplicationId;

            var app = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.ClientId = app.ClientID;
            ViewBag.ClientName = app.ClientName;

            var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result;
            if (schedule != null)
            {
                ViewBag.LoanAmount = schedule.LoanAmount;
                ViewBag.Markup = schedule.Markup;


                var lastPaidInstallment = schedule.installmentList.Where(x => x.isPaid == true).LastOrDefault();
                if (lastPaidInstallment != null)
                {
                    ViewBag.OsPrincipalAmount = lastPaidInstallment.OsPrincipal_Closing;
                    ViewBag.PaymentDate = string.Format("{0:yyyy-MM-dd}", lastPaidInstallment.InstallmentDueDate);

                    var paymentDetails = _installmentPaymentAppService.GetAllInstallmentPaymentByApplicationId(ApplicationId).Result;
                    var excess_short = paymentDetails.Where(x => x.NoOfInstallment.ToString() == lastPaidInstallment.InstNumber).LastOrDefault().ExcessShortPayment;
                    ViewBag.PreviousBalance = string.Format("{0:#,##0}", excess_short);
                }
                else
                {
                    ViewBag.OsPrincipalAmount = schedule.LoanAmount;
                    ViewBag.PreviousBalance = 0;
                    ViewBag.PaymentDate = null;
                }
                try
                {
                    ViewBag.PerDay = string.Format("{0:#,##0.##}", (Decimal.Parse((ViewBag.OsPrincipalAmount).ToString().Replace(",", "")) * (Decimal.Parse(schedule.Markup) / 100)) / 365);
                }
                catch
                {
                    ViewBag.PerDay = "";
                }

                if (ViewBag.PaymentDate == null)
                {
                    ViewBag.PaymentDate = string.Format("{0:yyyy-MM-dd}", schedule.DisbursmentDate.Substring(0, 11));
                }

                //OutstandingMarkup
                decimal OsMarkupAmount = 0;
                foreach (var item in schedule.installmentList.Where(x => x.isPaid != true))
                {
                    OsMarkupAmount += Decimal.Parse(item.markup.Replace(",", ""));
                }
                ViewBag.OsMarkupAmount = string.Format("{0:#,##0}", OsMarkupAmount);

                //Early Settlement Charges
                if (ViewBag.OsPrincipalAmount != null)
                {
                    var esc = Int32.Parse(ViewBag.OsPrincipalAmount.Replace(",", "")) * 0.03;
                    ViewBag.ESC = string.Format("{0:#,##0}", esc);

                    var FEDonESC = Int32.Parse(ViewBag.ESC.Replace(",", "")) * 0.16;
                    ViewBag.FEDonESC = string.Format("{0:#,##0}", FEDonESC);
                }
                else
                {
                    ViewBag.ESC = 0;
                    ViewBag.FEDonESC = 0;
                }

            }


            return View();
        }

        [HttpPost]
        public JsonResult AuthorizeEarlySettlement(int Id, string Decision, string Reason)
        {
            var entry = _earlySettlementRepository.Get(Id);

            if (Decision == "Authorize")
            {
                entry.isAuthorized = true;
                entry.rejectionReason = Reason;

                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = entry.ApplicationId;
                fWobj.Action = "Early Settled By BM";
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.ApplicationState = ApplicationState.EarlySettled;
                fWobj.isActive = true;

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                _applicationAppService.ChangeApplicationState(ApplicationState.EarlySettled, entry.ApplicationId, "Early Settled By BM");

            }
            else if (Decision == "Reject")
            {
                entry.isAuthorized = false;
                entry.rejectionReason = Reason;
            }

            _earlySettlementRepository.Update(entry);
            CurrentUnitOfWork.SaveChanges();

            return Json("");
        }

        [HttpPost]
        [DisableValidation]
        public IActionResult CreateEarlySettlement(CreateEarlySettlement input)
        {
            _earlySettlementAppService.Create(input);

            return RedirectToAction("Success", "About", new { Message = "Early Settlement Entry Sent to BM for Authorization!" });
        }

        public IActionResult EarlySettlementAuthorizationList(int ApplicationId)
        {
            var list = _earlySettlementAppService.GetAllEarlySettlements().Result.Where(x => x.isAuthorized == null).ToList();

            List<EarlySettlementListDto> returnList = new List<EarlySettlementListDto>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    var app = _applicationAppService.GetApplicationById(item.ApplicationId);
                    if (app != null)
                    {
                        if (app.FK_branchid == Branchid() || Branchid() == 0)
                        {
                            item.ClientID = app.ClientID;
                            item.ClientName = app.ClientName;
                            item.SchoolName = app.SchoolName;
                            item.CNIC = app.CNICNo;

                            returnList.Add(item);
                        }
                    }
                }
            }

            return View(returnList);
        }

        public IActionResult EarlySettlementAuthorization(int Id)
        {
            var earlySettlement = _earlySettlementAppService.GetEarlySettlementById(Id).Result;
            return View(earlySettlement);
        }
        //Early Settlement Module End
        //Write Off Module Start
        public IActionResult WriteOff(int ApplicationId)
        {
            ViewBag.Applicationid = ApplicationId;

            var app = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.ClientId = app.ClientID;
            ViewBag.ClientName = app.ClientName;

            var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result;
            if (schedule != null)
            {

                var lastPaidInstallment = schedule.installmentList.Where(x => x.isPaid == true).LastOrDefault();
                if (lastPaidInstallment != null)
                {
                    ViewBag.OsPrincipalAmount = lastPaidInstallment.OsPrincipal_Closing;
                }
                else
                {
                    ViewBag.OsPrincipalAmount = schedule.LoanAmount;
                }

                //OutstandingMarkup
                decimal OsMarkupAmount = 0;
                foreach (var item in schedule.installmentList.Where(x => x.isPaid != true))
                {
                    OsMarkupAmount += Decimal.Parse(item.markup.Replace(",", ""));
                }
                ViewBag.OsMarkupAmount = string.Format("{0:#,##0}", OsMarkupAmount);

                ViewBag.TotalPayable = decimal.Parse(ViewBag.OsPrincipalAmount.Replace(",", "")) + OsMarkupAmount;

            }


            return View();
        }

        [HttpPost]
        public IActionResult CreateWriteOff(CreateWriteOff input)
        {
            _writeOffAppService.Create(input);

            return RedirectToAction("Success", "About", new { Message = "Write-Off Entry Sent to BM for Authorization!" });
        }

        public IActionResult WriteOffAuthorizationList(int ApplicationId)
        {
            var list = _writeOffAppService.GetAllWriteOffs().Result.Where(x => x.isAuthorized == null).ToList();

            List<WriteOffListDto> returnList = new List<WriteOffListDto>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    var app = _applicationAppService.GetApplicationById(item.ApplicationId);
                    if (app != null)
                    {
                        if (app.FK_branchid == Branchid() || Branchid() == 0)
                        {
                            item.ClientID = app.ClientID;
                            item.ClientName = app.ClientName;
                            item.SchoolName = app.SchoolName;
                            item.CNIC = app.CNICNo;

                            returnList.Add(item);
                        }
                    }
                }
            }

            return View(returnList);
        }

        public IActionResult WriteOffAuthorization(int Id)
        {
            var writeOff = _writeOffAppService.GetWriteOffById(Id).Result;
            return View(writeOff);
        }


        [HttpPost]
        public JsonResult AuthorizeWriteOff(int Id, string Decision, string Reason)
        {
            var entry = _writeOffRepository.Get(Id);

            if (Decision == "Authorize")
            {
                entry.isAuthorized = true;
                entry.RejectionReason = Reason;
            }
            else if (Decision == "Reject")
            {
                entry.isAuthorized = false;
                entry.RejectionReason = Reason;
            }

            _writeOffRepository.Update(entry);
            CurrentUnitOfWork.SaveChanges();

            return Json("");
        }
        //Write Off Module End

        //Deceased Settlement Module Start

        public IActionResult DeceasedSettlement(int ApplicationId)
        {
            ViewBag.Applicationid = ApplicationId;

            var app = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.ClientId = app.ClientID;
            ViewBag.ClientName = app.ClientName;

            var schedule = _scheduleAppService.GetScheduleByApplicationId(ApplicationId).Result;
            if (schedule != null)
            {

                var lastPaidInstallment = schedule.installmentList.Where(x => x.isPaid == true).LastOrDefault();
                if (lastPaidInstallment != null)
                {
                    ViewBag.OsPrincipalAmount = lastPaidInstallment.OsPrincipal_Closing;
                }
                else
                {
                    ViewBag.OsPrincipalAmount = schedule.LoanAmount;
                }

                //OutstandingMarkup
                decimal OsMarkupAmount = 0;
                foreach (var item in schedule.installmentList.Where(x => x.isPaid != true))
                {
                    OsMarkupAmount += Decimal.Parse(item.markup.Replace(",", ""));
                }
                ViewBag.OsMarkupAmount = string.Format("{0:#,##0}", OsMarkupAmount);

                ViewBag.TotalPayable = decimal.Parse(ViewBag.OsPrincipalAmount.Replace(",", "")) + OsMarkupAmount;

            }


            return View();
        }

        [HttpPost]
        public IActionResult CreateDeceasedSettlement(CreateDeceasedSettlement input)
        {
            _deceasedSettlementAppService.Create(input);

            return RedirectToAction("Success", "About", new { Message = "Deceased Applicant Settlement Entry Sent to BM for Authorization!" });
        }

        public IActionResult DeceasedSettlementAuthorizationList(int ApplicationId)
        {
            var list = _deceasedSettlementAppService.GetAllDeceasedSettlements().Result.Where(x => x.isAuthorized == null).ToList();

            List<DeceasedSettlementListDto> returnList = new List<DeceasedSettlementListDto>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    var app = _applicationAppService.GetApplicationById(item.ApplicationId);
                    if (app != null)
                    {
                        if (app.FK_branchid == Branchid() || Branchid() == 0)
                        {
                            item.ClientID = app.ClientID;
                            item.ClientName = app.ClientName;
                            item.SchoolName = app.SchoolName;
                            item.CNIC = app.CNICNo;

                            returnList.Add(item);
                        }
                    }
                }
            }

            return View(returnList);
        }

        public IActionResult DeceasedSettlementAuthorization(int Id)
        {
            var deceasedSettlement = _deceasedSettlementAppService.GetDeceasedSettlementById(Id).Result;
            return View(deceasedSettlement);
        }


        [HttpPost]
        public JsonResult AuthorizeDeceasedSettlement(int Id, string Decision, string Reason)
        {
            var entry = _deceasedSettlementRepository.Get(Id);

            if (Decision == "Authorize")
            {
                entry.isAuthorized = true;
                entry.RejectionReason = Reason;
            }
            else if (Decision == "Reject")
            {
                entry.isAuthorized = false;
                entry.RejectionReason = Reason;
            }

            _deceasedSettlementRepository.Update(entry);
            CurrentUnitOfWork.SaveChanges();

            return Json("");
        }

        //Deceased Settlement Module End

    }
}
