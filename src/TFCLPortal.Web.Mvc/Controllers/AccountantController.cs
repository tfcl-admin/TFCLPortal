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
using TFCLPortal.DeceasedAuthorizations;
using TFCLPortal.DeceasedAuthorizations.Dto;
using Microsoft.AspNetCore.Http;
using System.IO;
using TFCLPortal.Customs;
using TFCLPortal.FundingSources;
using TFCLPortal.EnhancementRequests;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.Transactions;

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
        private readonly IEnhancementRequestAppService _enhancementRequestAppService;
        private readonly ILoanEligibilityAppService _loanEligibilityAppService;
        private readonly ITDSLoanEligibilityAppService _tDSLoanEligibilityAppService;
        private readonly IBankAccountAppService _bankAccountAppService;
        private readonly IBranchDetailAppService _branchDetailAppService;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IScheduleAppService _scheduleAppService;
        private readonly IScheduleTempAppService _scheduleTempAppService;
        private readonly IRepository<NatureOfPayment, int> _natureOfPaymentRepository;
        private readonly IRepository<EnhancementRequest, int> _enhancementRequestRepository;
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
        private readonly IDeceasedAuthorizationAppService _deceasedAuthorizationAppService;
        private readonly ICustomerAccountAppService _customerAccountAppAppService;
        private readonly IRepository<DeceasedAuthorization, int> _deceasedAuthorizationRepository;
        private readonly ICustomAppService _customAppService;

        private readonly IRepository<Transaction, int> _transactionRepository;
        private readonly IRepository<Holiday, int> _holidayRepository;
        private readonly IRepository<FundingSource, int> _fundingSourceRepository;
        private readonly IRepository<GuarantorDetail, int> _GuarantorRepository;
        private readonly IRepository<CoApplicantDetail, int> _CoApplicantRepository;

        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IRepository<InstallmentPayment, int> _installmentPaymentRepository;
        private readonly IRepository<AuthorizeInstallmentPayment, int> _authorizeInstallmentPaymentRepository;

        private readonly INotificationLogAppService _notificationLogAppService;

        public AccountantController(IRepository<Transaction, int> transactionRepository, ICustomerAccountAppService customerAccountAppAppService, IRepository<EnhancementRequest, int> enhancementRequestRepository, IEnhancementRequestAppService enhancementRequestAppService, IRepository<FundingSource, int> fundingSourceRepository, IRepository<DeceasedAuthorization, int> deceasedAuthorizationRepository, ICustomAppService customAppService, IDeceasedAuthorizationAppService deceasedAuthorizationAppService, ITDSLoanEligibilityAppService tDSLoanEligibilityAppService, IRepository<CoApplicantDetail, int> CoApplicantRepository, IRepository<GuarantorDetail, int> GuarantorRepository, IRepository<Applicationz, Int32> applicationRepository, IRepository<ScheduleTemp, int> scheduleTempRepository, IRepository<DeceasedSettlement, int> deceasedSettlementRepository, IDeceasedSettlementAppService deceasedSettlementAppService, IRepository<WriteOff, int> writeOffRepository, IWriteOffAppService writeOffAppService, IRepository<EarlySettlement, int> earlySettlementRepository, IEarlySettlementAppService earlySettlementAppService, IRepository<AuthorizeInstallmentPayment, int> authorizeInstallmentPaymentRepository, IAuthorizeInstallmentPaymentAppService authorizeInstallmentPaymentAppService, IRepository<InstallmentPayment, int> installmentPaymentRepository, IRepository<Holiday, int> holidayRepository, IRepository<ScheduleInstallment, int> scheduleInstallmentRepository, IInstallmentPaymentAppService installmentPaymentAppService, IRepository<NatureOfPayment, int> natureOfPaymentRepository, IRepository<CompanyBankAccount, int> companyBankAccountRepository, IBADataCheckAppService IBADataCheckAppService, INotificationLogAppService notificationLogAppService, IScheduleTempAppService scheduleTempAppService, UserManager userManager, IRepository<Schedule, int> scheduleRepository, IScheduleAppService scheduleAppService, ICoApplicantDetailAppService coApplicantDetailAppService, IGuarantorDetailAppService guarantorDetailAppService, IBranchDetailAppService branchDetailAppService, IBankAccountAppService bankAccountAppService, ILoanEligibilityAppService loanEligibilityAppService, IBusinessPlanAppService businessPlanAppService, IBccDecisionAppService bccDecisionAppService, IApplicationAppService applicationAppService, IUserAppService userAppService, IFinalWorkflowAppService finalWorkflowAppService)
        {
            _transactionRepository = transactionRepository;
            _customerAccountAppAppService = customerAccountAppAppService;
            _enhancementRequestRepository = enhancementRequestRepository;
            _fundingSourceRepository = fundingSourceRepository;
            _customAppService = customAppService;
            _deceasedAuthorizationRepository = deceasedAuthorizationRepository;
            _deceasedAuthorizationAppService = deceasedAuthorizationAppService;
            _tDSLoanEligibilityAppService = tDSLoanEligibilityAppService;
            _GuarantorRepository = GuarantorRepository;
            _CoApplicantRepository = CoApplicantRepository;
            _applicationRepository = applicationRepository;
            _enhancementRequestAppService = enhancementRequestAppService;
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

        public IActionResult cnics()
        {
            var Applications = _applicationRepository.GetAllList();
            List<CnicByApp> cniclist = new List<CnicByApp>();

            if (Applications != null)
            {
                var guarantors = _GuarantorRepository.GetAllList();
                var coApplicants = _CoApplicantRepository.GetAllList();

                foreach (var app in Applications)
                {
                    CnicByApp cnic = new CnicByApp();

                    cnic.ClientId = app.ClientID;
                    cnic.ClientName = app.ClientName;
                    cnic.BusinessName = app.SchoolName;
                    cnic.ClientCNIC = app.CNICNo;
                    cnic.Screenstatus = app.ScreenStatus;

                    var guarantor = guarantors.Where(x => x.ApplicationId == app.Id).ToList();
                    if (guarantor.Count > 0)
                    {
                        cnic.Guarantor1Cnic = guarantor[0].CNICNumber;
                        cnic.Guarantor1Name = guarantor[0].FullName;
                        if (guarantor.Count > 1)
                        {
                            cnic.Guarantor2Cnic = guarantor[1].CNICNumber;
                            cnic.Guarantor2Name = guarantor[1].FullName;
                        }
                    }

                    var coApplicant = coApplicants.Where(x => x.ApplicationId == app.Id).ToList();
                    if (coApplicant.Count > 0)
                    {
                        cnic.CoApplicant1Cnic = coApplicant[0].CNICNumber;
                        cnic.CoApplicant1Name = coApplicant[0].FullName;
                        if (coApplicant.Count > 1)
                        {
                            cnic.CoApplicant2Cnic = coApplicant[1].CNICNumber;
                            cnic.CoApplicant2Name = coApplicant[1].FullName;
                        }
                    }

                    cniclist.Add(cnic);

                }

            }


            return View(cniclist);
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
            //ViewBag.JsonData = GetJson().Result;
            ViewBag.JsonData = _customAppService.getProscribedPersonList();
            return View();
        }

        public ActionResult CheckAMLCFTByCNIC()
        {
            //ViewBag.JsonData = GetJson().Result;
            ViewBag.JsonData = _customAppService.getProscribedPersonList();

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



        public IActionResult EnhancementRequestList()
        {
            var reqs = _enhancementRequestAppService.GetAllEnhancementRequests().Result;
            return View(reqs);
        }
        [HttpGet]
        [DisableValidation]
        public ActionResult ApproveEnhancement(int id, bool approve)
        {
            var req = _enhancementRequestRepository.Get(id);
            if (approve)
            {
                req.RequestState = 1;
            }
            else
            {
                req.RequestState = 2;
            }
            _enhancementRequestRepository.Update(req);



            return RedirectToAction("EnhancementRequestList", "Accountant");
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

        public IActionResult getEarlySettlement(int ApplicationId)
        {

            var earlysettlements = _earlySettlementRepository.GetAllList(x => x.ApplicationId == ApplicationId && x.isAuthorized == true);

            if (earlysettlements != null)
            {
                int eid = earlysettlements.FirstOrDefault().Id;
                return RedirectToAction("earlysettlementauthorization", "Accountant", new { id = eid });
            }

            else
            {
                return RedirectToAction("earlysettlementauthorization", "Accountant", new { id = 0 });
            }

        }


        public IActionResult InstallmentPaymentList(int? filterType, int? branchFilter, int? day, int? month, int? year)
        {
            List<ScheduleInstallmenttListDto> scheduleInstallments = new List<ScheduleInstallmenttListDto>();


            decimal totalDue = 0;
            decimal totalPaid = 0;
            decimal totalUnPaid = 0;
            decimal DefCount = 0;
            decimal DefAmount = 0;

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

            var schedules = _scheduleAppService.GetScheduleList();
            var paidInstallmentsList = _installmentPaymentAppService.GetAllInstallmentPayments();


            if (getDisbursedApplications.Count > 0)
            {
                foreach (var app in getDisbursedApplications)
                {
                    var schedule = schedules.Result.Where(x => x.ApplicationId == app.Id).FirstOrDefault();
                    if (schedule != null)
                    {
                        List<ScheduleInstallmenttListDto> installments = new List<ScheduleInstallmenttListDto>();

                        if (filterType != 3)
                        {
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

                            }


                            var paidInstallments = paidInstallmentsList.Result.Where(x => x.ApplicationId == schedule.ApplicationId && x.isAuthorized == true);

                            if (paidInstallments != null)
                            {
                                foreach (var installment in installments)
                                {
                                    if (installment.InstNumber != "0")
                                    {
                                        var paidInstByInstNo = paidInstallments.Where(x => x.NoOfInstallment.ToString() == installment.InstNumber);

                                        decimal sumOfAmountsPerInstallment = 0;
                                        decimal excessShort = 0;

                                        if (paidInstByInstNo.Count() > 0)
                                        {
                                            foreach (var paidInstallment in paidInstByInstNo)
                                            {
                                                sumOfAmountsPerInstallment += paidInstallment.Amount;
                                                excessShort = paidInstallment.ExcessShortPayment;
                                                installment.LastPaymentDate = paidInstallment.DepositDate;
                                            }
                                        }
                                        else
                                        {
                                            var getLastPaidInstallment = paidInstallments.Where(x => x.ApplicationId == schedule.ApplicationId).FirstOrDefault();
                                            if (getLastPaidInstallment != null)
                                            {
                                                excessShort = getLastPaidInstallment.ExcessShortPayment;
                                                installment.LastPaymentDate = getLastPaidInstallment.DepositDate;
                                            }
                                        }


                                        installment.PaidAmount = sumOfAmountsPerInstallment.ToString();
                                        installment.ExcessShort = excessShort.ToString();


                                        sumOfAmountsPerInstallment = 0;
                                    }
                                    else
                                    {

                                        var AllDefferedInstallments = schedule.installmentList.Where(x => x.InstNumber == installment.InstNumber).ToList();
                                        var indexOfThisInstallment = AllDefferedInstallments.IndexOf(installment);

                                        var paidDeferredInstallments = paidInstallments.Where(x => x.NoOfInstallment.ToString() == "0").ToList();
                                        try
                                        {
                                            IGrouping<DateTime, InstallmentPaymentListDto> lastInstallmentDate;
                                            if (month != DateTime.Now.Month)
                                            {
                                                lastInstallmentDate = paidInstallments.Where(x => x.isAuthorized == true && x.InstallmentDueDate.Month == month && x.InstallmentDueDate.Year == year).GroupBy(x => x.InstallmentDueDate).OrderBy(x => x.Key).LastOrDefault();
                                            }
                                            else
                                            {
                                                lastInstallmentDate = paidInstallments.Where(x => x.isAuthorized == true).GroupBy(x => x.InstallmentDueDate).OrderBy(x => x.Key).LastOrDefault();
                                            }

                                            if (lastInstallmentDate != null)
                                            {
                                                var requiredPayments = paidInstallments.Where(x => x.InstallmentDueDate == lastInstallmentDate.Key).ToList();

                                                decimal sumOfAmountsPerInstallment = 0;
                                                decimal excessShort = 0;

                                                int appid = schedule.ApplicationId;

                                                foreach (var payment in requiredPayments)
                                                {
                                                    if (installment.isPaid == true)
                                                    {
                                                        sumOfAmountsPerInstallment += payment.Amount;
                                                        excessShort += payment.ExcessShortPayment;
                                                    }
                                                    else
                                                    {
                                                        excessShort = payment.ExcessShortPayment;

                                                    }
                                                    installment.LastPaymentDate = payment.DepositDate;
                                                }

                                                installment.PaidAmount = sumOfAmountsPerInstallment.ToString();
                                                installment.ExcessShort = excessShort.ToString();
                                            }

                                            //var paidDeferredInstallmentOnThisIndex = paidDeferredInstallments[indexOfThisInstallment];
                                            //installment.PaidAmount = paidDeferredInstallmentOnThisIndex.Amount.ToString();
                                            //installment.ExcessShort = paidDeferredInstallmentOnThisIndex.ExcessShortPayment.ToString();

                                        }
                                        catch
                                        {

                                        }

                                    }
                                }
                            }

                        }
                        else
                        {
                            var installment = schedule.installmentList.Where(x => x.InstNumber != "G*" && x.isPaid != true).FirstOrDefault();

                            var paidInstallments = paidInstallmentsList.Result.Where(x => x.ApplicationId == schedule.ApplicationId && x.isAuthorized == true).LastOrDefault();
                            if (paidInstallments != null)
                            {
                                installment.LastPaymentDate = paidInstallments.DepositDate;
                            }

                            if ((DateTime.Parse(installment.InstallmentDueDate)) <= DateTime.Now.AddDays(-1))
                            {
                                installments.Add(installment);
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
                                    inst.DPD = (int)(DateTime.Now - DateTime.Parse(inst.InstallmentDueDate)).TotalDays;

                                    totalUnPaid += decimal.Parse(inst.installmentAmount.Replace(",", ""));
                                }

                                if (inst.InstNumber == "0")
                                {
                                    DefCount++;
                                    DefAmount += decimal.Parse(inst.installmentAmount.Replace(",", ""));
                                }


                            }
                        }
                    }


                }
            }

            ViewBag.Due = totalDue;
            ViewBag.Paid = totalPaid;
            ViewBag.UnPaid = totalUnPaid;
            ViewBag.DefCount = DefCount;
            ViewBag.DefAmount = DefAmount;

            var branches = _branchDetailAppService.GetBranchListDetail();

            ViewBag.McrcUserList = new SelectList(branches, "Id", "BranchCode");

            return View(scheduleInstallments);
        }

        public async Task<IActionResult> CreateAccdecline(int Id, string Reason)
        {
            var app = _applicationAppService.GetApplicationById(Id);

            if (app != null)
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
                var app = _applicationAppService.GetApplicationById(ApplicationId);
                if (app != null)
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

                            decimal baloonPayment = 0;

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

                                if (installment.AdditionalTranche != "" && installment.AdditionalTranche != "--")
                                {
                                    baloonPayment = Decimal.Parse(installment.AdditionalTranche.Replace(",", ""));
                                }

                            }

                            CreateSchedule.installmentList = listInstallments;

                            baloonPayment = (baloonPayment * -1);


                            _scheduleAppService.CreateSchedule(CreateSchedule);

                            var custAcc = _customerAccountAppAppService.GetCustomerAccountByCNIC(app.CNICNo).Result;
                            var transactions = new Transaction();
                            transactions.Type = "Debit";
                            transactions.Details = "Baloon Payment";
                            transactions.isAuthorized = true;
                            transactions.Fk_AccountId = custAcc.Id;
                            transactions.ApplicationId = ApplicationId;
                            transactions.BalBefore = custAcc.Balance;
                            transactions.Amount = baloonPayment;
                            transactions.AmountWords = NumberToWords((int)baloonPayment);
                            transactions.BalAfter = (transactions.BalBefore - baloonPayment);
                            var ts = _transactionRepository.Insert(transactions);
                            var cs = _customerAccountAppAppService.UpdateAccountBalance(custAcc.Id, transactions.BalAfter);



                        }

                        if (app.isEnhancementApplication)
                        {
                            var oldApp = _applicationAppService.GetApplicationById(app.PrevApplicationId);

                            _applicationAppService.ChangeApplicationState(ApplicationState.Enhanced, oldApp.Id, "Application Enhanced");

                            CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                            fWobj.ApplicationId = oldApp.Id;
                            fWobj.Action = "Application Enhanced";
                            fWobj.ActionBy = (int)AbpSession.UserId;
                            fWobj.ApplicationState = ApplicationState.Enhanced;
                            fWobj.isActive = true;

                            _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

                            var currApp = _applicationRepository.Get(ApplicationId);
                            currApp.isEnhancementApplication = false;
                            _applicationRepository.Update(currApp);
                        }


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
                ViewBag.LoanCycles = _applicationRepository.GetAllListAsync().Result.FindAll(x => x.CNICNo == Application.CNICNo && (x.ScreenStatus != "decline")).Count;


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

                if (paidInstallments.Count == 0)
                {
                    paidInstallments = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(Application.PrevApplicationId).Result;
                }

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

            var Acc = _customerAccountAppAppService.GetCustomerAccountByCNIC(app.CNICNo).Result;
            if (Acc != null)
            {
                ViewBag.Payment = Acc.Balance;
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
                    if (sameInstallmentPaymentsList.Count() > 0)
                    {

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

                    }
                    else
                    {
                        sumOfAllPaymentsForOneInstallment = lastPaidInstallment.ExcessShortPayment;
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
            decimal actualPayment = 0;
            decimal paidAmount = payment.Amount;
            decimal excessShortForLastPaidInstallment = 0;
            var Exists = _installmentPaymentAppService.GetInstallmentPaymentByApplicationId(payment.ApplicationId);
            if (Exists.Result != null || Exists.Result.Count >= 0)
            {
                decimal existingAmountForSingleInstallment = 0;
                foreach (var existingPayment in Exists.Result.Where(x => x.NoOfInstallment.ToString() == scheduleInstallment.InstNumber && x.isAuthorized == true))
                {
                    existingAmountForSingleInstallment += (existingPayment.Amount);
                }

                if (lastPaidInstallment != null)
                {
                    if (lastPaidInstallment.InstNumber != "G*" && lastPaidInstallment.InstNumber != null && lastPaidInstallment.InstNumber != "")
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

                actualPayment = paidAmount;

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
            decimal totalPaidForThisInst = paidAmount;
            paidAmount -= Decimal.Parse(scheduleInstallment.installmentAmount);

            payment.isAuthorized = true;
            _installmentPaymentAppService.Create(payment);

            var acc = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

            //Transaction transaction = new Transaction();
            //transaction.Amount = payment.Amount;
            //transaction.AmountWords = payment.AmountWords;
            //transaction.Type = "Debit";
            //transaction.Details = "Collection Inst No : " + scheduleInstallment.InstNumber;
            //transaction.ModeOfPayment = payment.ModeOfPayment;
            //transaction.isAuthorized = true;
            //transaction.Fk_AccountId = acc.Id;
            //transaction.BalBefore = acc.Balance;
            //transaction.BalAfter = (transaction.BalBefore-payment.Amount);
            //var t = _transactionRepository.Insert(transaction);
            //CurrentUnitOfWork.SaveChanges();
            //actualPayment = payment.Amount;
            decimal markupForThisInstallment = decimal.Parse(scheduleInstallment.markup == "--" ? "0" : scheduleInstallment.markup.Replace(",", ""));

            if (scheduleInstallment.isMarkupPaid == false)
            {
                if (actualPayment >= markupForThisInstallment)
                {
                    markupForThisInstallment -= (totalPaidForThisInst - payment.Amount);

                    if (excessShortForLastPaidInstallment > 0)
                    {
                        Transaction transaction1 = new Transaction();
                        transaction1.AmountWords = NumberToWords((int)excessShortForLastPaidInstallment);
                        transaction1.Type = "Debit";
                        transaction1.Details = "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                        transaction1.ModeOfPayment = payment.ModeOfPayment;
                        transaction1.isAuthorized = true;
                        transaction1.Fk_AccountId = acc.Id;
                        transaction1.ApplicationId = payment.ApplicationId;
                        transaction1.BalBefore = acc.Balance;
                        transaction1.Amount = excessShortForLastPaidInstallment;
                        transaction1.BalAfter = acc.Balance;
                        var t1 = _transactionRepository.Insert(transaction1);
                        var c1 = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction1.BalAfter);
                        CurrentUnitOfWork.SaveChanges();

                    }

                    if (excessShortForLastPaidInstallment < 0)
                    {
                        excessShortForLastPaidInstallment *= -1;

                        Transaction transaction1 = new Transaction();
                        transaction1.AmountWords = NumberToWords((int)excessShortForLastPaidInstallment);
                        transaction1.Type = "Debit";
                        transaction1.Details = "Previous Installment Deduction";
                        transaction1.ModeOfPayment = payment.ModeOfPayment;
                        transaction1.isAuthorized = true;
                        transaction1.Fk_AccountId = acc.Id;
                        transaction1.ApplicationId = payment.ApplicationId;
                        transaction1.BalBefore = acc.Balance;
                        transaction1.Amount = excessShortForLastPaidInstallment;
                        transaction1.BalAfter = acc.Balance - excessShortForLastPaidInstallment;
                        var t1 = _transactionRepository.Insert(transaction1);
                        var c1 = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction1.BalAfter);
                        CurrentUnitOfWork.SaveChanges();
                    }

                    acc = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                    Transaction transaction = new Transaction();
                    transaction.AmountWords = NumberToWords((int)markupForThisInstallment);
                    transaction.Type = "Debit";
                    transaction.Details = "Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                    transaction.ModeOfPayment = payment.ModeOfPayment;
                    transaction.isAuthorized = true;
                    transaction.Fk_AccountId = acc.Id;
                    transaction.ApplicationId = payment.ApplicationId;
                    transaction.BalBefore = acc.Balance;
                    transaction.Amount = markupForThisInstallment;
                    transaction.BalAfter = (transaction.BalBefore - markupForThisInstallment);
                    scheduleInstallment.isMarkupPaid = true;
                    var t = _transactionRepository.Insert(transaction);
                    var c = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction.BalAfter);
                    var si = _scheduleInstallmentRepository.Update(scheduleInstallment);
                    actualPayment -= (markupForThisInstallment + (totalPaidForThisInst - acc.Balance));
                    CurrentUnitOfWork.SaveChanges();

                    decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                    var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                    if (actualPayment > 0)
                    {
                        if (actualPayment >= principalForThisInstallment)
                        {
                            //decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                            //var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                            if (Exists.Result.Where(x => x.NoOfInstallment == Int32.Parse(scheduleInstallment.InstNumber)).Count() > 1)
                            {
                                principalForThisInstallment -= (totalPaidForThisInst - payment.Amount - markupForThisInstallment);
                            }

                            //principalForThisInstallment -= (totalPaidForThisInst - markupForThisInstallment);

                            transaction = new Transaction();
                            transaction.BalBefore = accupdate.Balance;
                            transaction.Type = "Debit";
                            transaction.ModeOfPayment = payment.ModeOfPayment;
                            transaction.ApplicationId = payment.ApplicationId;
                            transaction.isAuthorized = true;
                            transaction.Fk_AccountId = accupdate.Id;

                            if (actualPayment >= principalForThisInstallment)
                            {
                                transaction.Details = "Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                transaction.Amount = principalForThisInstallment;
                                transaction.BalAfter = (transaction.BalBefore - principalForThisInstallment);
                                scheduleInstallment.isPrincipalPaid = true;
                                var sis = _scheduleInstallmentRepository.Update(scheduleInstallment);
                                transaction.AmountWords = NumberToWords((int)principalForThisInstallment);
                                actualPayment -= principalForThisInstallment;
                            }
                            else
                            {
                                transaction.Details = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                                transaction.Amount = actualPayment;
                                transaction.BalAfter = (transaction.BalBefore - actualPayment);
                                transaction.AmountWords = NumberToWords((int)actualPayment);
                                actualPayment = 0;
                            }


                            t = _transactionRepository.Insert(transaction);
                            c = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction.BalAfter);
                            //actualPayment -= principalForThisInstallment;
                            CurrentUnitOfWork.SaveChanges();

                            if (scheduleInstallment.isPrincipalPaid = true)
                            {
                                if (actualPayment > 0 && (principalForThisInstallment + markupForThisInstallment) < Decimal.Parse(scheduleInstallment.installmentAmount))
                                {
                                    decimal amountToDeduct = Decimal.Parse(scheduleInstallment.installmentAmount) - (principalForThisInstallment + markupForThisInstallment);
                                    var accupdate2 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                                    if (scheduleInstallment.InstNumber == "1")
                                    {
                                        var transactions = new Transaction();
                                        transactions.AmountWords = NumberToWords((int)amountToDeduct);
                                        transactions.Type = "Debit";
                                        transactions.Details = "Grace Days Markup Collection";
                                        transactions.ModeOfPayment = payment.ModeOfPayment;
                                        transactions.isAuthorized = true;
                                        transactions.ApplicationId = payment.ApplicationId;
                                        transactions.Fk_AccountId = accupdate2.Id;
                                        transactions.BalBefore = accupdate2.Balance;
                                        transactions.Amount = amountToDeduct;
                                        transactions.BalAfter = (transactions.BalBefore - amountToDeduct);
                                        t = _transactionRepository.Insert(transactions);
                                        c = _customerAccountAppAppService.UpdateAccountBalance(accupdate2.Id, transactions.BalAfter);
                                        actualPayment -= amountToDeduct;
                                        CurrentUnitOfWork.SaveChanges();
                                    }


                                    //if(actualPayment>0)
                                    //{
                                    //    var accupdate3 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);
                                    //    var transactions = new Transaction();
                                    //    transactions.AmountWords = NumberToWords((int)amountToDeduct);
                                    //    transactions.Type = "Debit";
                                    //    transactions.Details = "Collection Inst No # " + scheduleInstallment.InstNumber;
                                    //    transactions.ModeOfPayment = payment.ModeOfPayment;
                                    //    transactions.isAuthorized = true;
                                    //    transactions.ApplicationId = payment.ApplicationId;
                                    //    transactions.Fk_AccountId = accupdate3.Id;
                                    //    transactions.BalBefore = accupdate3.Balance;
                                    //    transactions.Amount = actualPayment;
                                    //    transactions.BalAfter = (transactions.BalBefore - actualPayment);
                                    //    t = _transactionRepository.Insert(transactions);
                                    //    c = _customerAccountAppAppService.UpdateAccountBalance(accupdate3.Id, transactions.BalAfter);
                                    //    actualPayment -= actualPayment;
                                    //    CurrentUnitOfWork.SaveChanges();
                                    //}

                                }
                            }
                        }
                        else
                        {
                            //decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                            var accupdate2 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                            transaction = new Transaction();

                            transaction.Details = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                            transaction.BalBefore = accupdate2.Balance;
                            transaction.Amount = actualPayment;
                            transaction.BalAfter = (transaction.BalBefore - actualPayment);
                            transaction.AmountWords = NumberToWords((int)actualPayment);
                            transaction.ApplicationId = payment.ApplicationId;
                            transaction.Type = "Debit";
                            transaction.ModeOfPayment = payment.ModeOfPayment;
                            transaction.isAuthorized = true;
                            transaction.Fk_AccountId = accupdate2.Id;

                            t = _transactionRepository.Insert(transaction);
                            c = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction.BalAfter);
                            actualPayment -= principalForThisInstallment;
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                }
                else
                {

                    if (excessShortForLastPaidInstallment > 0)
                    {
                        Transaction transaction1 = new Transaction();
                        transaction1.AmountWords = NumberToWords((int)excessShortForLastPaidInstallment);
                        transaction1.Type = "Debit";
                        transaction1.Details = "Markup Collection from Previous Balance Inst No # " + scheduleInstallment.InstNumber;
                        transaction1.ModeOfPayment = payment.ModeOfPayment;
                        transaction1.isAuthorized = true;
                        transaction1.Fk_AccountId = acc.Id;
                        transaction1.ApplicationId = payment.ApplicationId;
                        transaction1.BalBefore = acc.Balance;
                        transaction1.Amount = excessShortForLastPaidInstallment;
                        transaction1.BalAfter = acc.Balance;
                        var t1 = _transactionRepository.Insert(transaction1);
                        var c1 = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction1.BalAfter);
                        CurrentUnitOfWork.SaveChanges();
                    }

                    if (excessShortForLastPaidInstallment < 0)
                    {
                        excessShortForLastPaidInstallment *= -1;

                        Transaction transaction1 = new Transaction();
                        transaction1.AmountWords = NumberToWords((int)excessShortForLastPaidInstallment);
                        transaction1.Type = "Debit";
                        transaction1.Details = "Previous Installment Deduction";
                        transaction1.ModeOfPayment = payment.ModeOfPayment;
                        transaction1.isAuthorized = true;
                        transaction1.Fk_AccountId = acc.Id;
                        transaction1.ApplicationId = payment.ApplicationId;
                        transaction1.BalBefore = acc.Balance;
                        transaction1.Amount = excessShortForLastPaidInstallment;
                        transaction1.BalAfter = acc.Balance - excessShortForLastPaidInstallment;
                        var t1 = _transactionRepository.Insert(transaction1);
                        var c1 = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction1.BalAfter);
                        CurrentUnitOfWork.SaveChanges();

                        payment.Amount-=excessShortForLastPaidInstallment;
                    }

                    acc = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);
                    Transaction transaction = new Transaction();
                    transaction.AmountWords = NumberToWords((int)payment.Amount);
                    transaction.Type = "Debit";
                    transaction.Details = "Partial Markup Collection Inst No # " + scheduleInstallment.InstNumber;
                    transaction.ModeOfPayment = payment.ModeOfPayment;
                    transaction.ApplicationId = payment.ApplicationId;
                    transaction.isAuthorized = true;
                    transaction.Fk_AccountId = acc.Id;
                    transaction.BalBefore = acc.Balance;
                    transaction.Amount = payment.Amount;
                    transaction.BalAfter = (transaction.BalBefore - payment.Amount);
                    var t = _transactionRepository.Insert(transaction);
                    var c = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction.BalAfter);
                    actualPayment -= markupForThisInstallment;
                    CurrentUnitOfWork.SaveChanges();
                }
            }
            else if (scheduleInstallment.isMarkupPaid == true)
            {
                actualPayment -= markupForThisInstallment;

                if (actualPayment > 0)
                {
                    if (scheduleInstallment.isPrincipalPaid == false)
                    {
                        decimal principalForThisInstallment = decimal.Parse(scheduleInstallment.principal == "--" ? "0" : scheduleInstallment.principal.Replace(",", ""));
                        var accupdate = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);

                        Transaction transaction = new Transaction();
                        transaction.Type = "Debit";
                        transaction.ModeOfPayment = payment.ModeOfPayment;
                        transaction.isAuthorized = true;
                        transaction.Fk_AccountId = accupdate.Id;
                        transaction.BalBefore = accupdate.Balance;
                        transaction.ApplicationId = payment.ApplicationId;

                        if (actualPayment >= (principalForThisInstallment - 100))
                        {
                            //principalForThisInstallment -= (totalPaidForThisInst - acc.Balance - markupForThisInstallment);

                            transaction.Details = "Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                            transaction.Amount = payment.Amount;
                            transaction.AmountWords = NumberToWords((int)payment.Amount);
                            transaction.BalAfter = (transaction.BalBefore - payment.Amount);
                            scheduleInstallment.isPrincipalPaid = true;
                            scheduleInstallment.isPaid = true;
                            scheduleInstallment.PaymentDate = payment.DepositDate;
                            var si = _scheduleInstallmentRepository.Update(scheduleInstallment);

                            actualPayment -= principalForThisInstallment;

                            if (scheduleInstallment.isPrincipalPaid = true)
                            {
                                if (actualPayment > 0 && (principalForThisInstallment + markupForThisInstallment) < Decimal.Parse(scheduleInstallment.installmentAmount))
                                {
                                    decimal amountToDeduct = Decimal.Parse(scheduleInstallment.installmentAmount) - (principalForThisInstallment + markupForThisInstallment);
                                    var accupdate2 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(payment.ApplicationId);
                                    var transactions = new Transaction();
                                    transactions.AmountWords = NumberToWords((int)amountToDeduct);
                                    transactions.Type = "Debit";
                                    transactions.Details = "Collection Inst No # " + scheduleInstallment.InstNumber;
                                    transactions.ModeOfPayment = payment.ModeOfPayment;
                                    transactions.isAuthorized = true;
                                    transaction.ApplicationId = payment.ApplicationId;
                                    transactions.Fk_AccountId = accupdate2.Id;
                                    transactions.BalBefore = accupdate2.Balance;
                                    transactions.Amount = amountToDeduct;
                                    transactions.BalAfter = (transactions.BalBefore - amountToDeduct);
                                    var ts = _transactionRepository.Insert(transactions);
                                    var cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate2.Id, transactions.BalAfter);
                                    actualPayment -= amountToDeduct;
                                    CurrentUnitOfWork.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            transaction.Details = "Partial Principal Collection Inst No # " + scheduleInstallment.InstNumber;
                            transaction.Amount = payment.Amount;
                            transaction.BalAfter = (transaction.BalBefore - payment.Amount);
                        }


                        var t = _transactionRepository.Insert(transaction);
                        var c = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction.BalAfter);
                        actualPayment -= principalForThisInstallment;
                        CurrentUnitOfWork.SaveChanges();
                    }
                }
            }
            else
            {
                Transaction transaction = new Transaction();
                transaction.AmountWords = NumberToWords((int)payment.Amount);
                transaction.Type = "Debit";
                transaction.Details = "Collection Inst No # " + scheduleInstallment.InstNumber;
                transaction.ModeOfPayment = payment.ModeOfPayment;
                transaction.isAuthorized = true;
                transaction.ApplicationId = payment.ApplicationId;
                transaction.Fk_AccountId = acc.Id;
                transaction.BalBefore = acc.Balance;
                transaction.Amount = payment.Amount;
                transaction.BalAfter = (transaction.BalBefore - payment.Amount);
                scheduleInstallment.isMarkupPaid = true;
                var t = _transactionRepository.Insert(transaction);
                var c = _customerAccountAppAppService.UpdateAccountBalance(acc.Id, transaction.BalAfter);
                var si = _scheduleInstallmentRepository.Update(scheduleInstallment);
                CurrentUnitOfWork.SaveChanges();
            }




            if (paidAmount >= -100)
            {
                scheduleInstallment.isPaid = true;
                scheduleInstallment.PaymentDate = payment.DepositDate;
                _scheduleInstallmentRepository.Update(scheduleInstallment);
                CurrentUnitOfWork.SaveChanges();


                var allUnpaidInstallments = _scheduleInstallmentRepository.GetAllList(x => x.FK_ScheduleId == schedule.Id && (x.isPaid == false || x.isPaid == null));
                if (allUnpaidInstallments.Count < 1)
                {
                    _applicationAppService.ChangeApplicationState(ApplicationState.Settled, payment.ApplicationId, "All Installments Paid");

                    CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                    fWobj.ApplicationId = payment.ApplicationId;
                    fWobj.Action = "All Installments Paid";
                    fWobj.ActionBy = (int)AbpSession.UserId;
                    fWobj.ApplicationState = ApplicationState.Settled;
                    fWobj.isActive = true;

                    _finalWorkflowAppService.CreateFinalWorkflow(fWobj);
                }
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

                var branch = _branchDetailAppService.GetBranchDetailById(application.FK_branchid);

                ViewBag.BranchManager = branch.ContactPerson; // _userAppService.GetUserById((long)decision.CreatorUserId).Result.FullName;
                ViewBag.BranchManagerId = (long)branch.FK_BMid;
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

        public IActionResult ScheduleEnhancement(int ApplicationId)
        {
            ViewBag.ApplicationId = ApplicationId;
            double markup = 0.00;
            int tenure = 0;
            int LoanAmount = 0;
            var application = _applicationAppService.GetApplicationById(ApplicationId);
            if (application != null)
            {
                ViewBag.OldApplicationId = application.PrevApplicationId;
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

                    var getLEold = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(application.PrevApplicationId).Result;
                    if (getLEold != null)
                    {
                        ViewBag.LoanEligibilityOld = getLEold;
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
                    var getLEold = _tDSLoanEligibilityAppService.GetTDSLoanEligibilityListByApplicationId(application.PrevApplicationId).Result;
                    if (getLEold != null)
                    {
                        ViewBag.LoanEligibilityOld = getLEold;
                    }
                }
                var getLRDold = _businessPlanAppService.GetBusinessPlanByApplicationId(application.PrevApplicationId).Result;
                if (getLRDold != null)
                {
                    ViewBag.LoanRequisitionDetailsOld = getLRDold;
                }

                var getUnpaidIstallmentLastSchedule = _scheduleAppService.GetScheduleByApplicationId(application.PrevApplicationId);
                if (getUnpaidIstallmentLastSchedule != null)
                {
                    var unpaidInstallment = getUnpaidIstallmentLastSchedule.Result.installmentList.Where(x => x.isPaid != true && x.InstNumber != "G*").FirstOrDefault();
                    if (unpaidInstallment != null)
                    {
                        ViewBag.UnpaidInstallment = unpaidInstallment;
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

                var branch = _branchDetailAppService.GetBranchDetailById(application.FK_branchid);

                ViewBag.BranchManager = branch.ContactPerson; // _userAppService.GetUserById((long)decision.CreatorUserId).Result.FullName;
                ViewBag.BranchManagerId = (long)branch.FK_BMid;
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



        [DisableValidation]
        [HttpPost]
        public IActionResult ScheduleEnhancementResult(GetFromFormDto Schedule)
        {

            List<signatories> listForSignatories = new List<signatories>();
            ViewBag.ApplicationId = Schedule.ApplicationId;
            ViewBag.PrevApplicationId = Schedule.PrevApplicationId;
            ViewBag.newEnhancedAmount = Schedule.newEnhancedAmount;
            ViewBag.newEnhancedTenure = Schedule.newEnhancedTenure;
            ViewBag.newLoanAmountDiff = Schedule.newLoanAmountDiff;

            var schedule = _scheduleAppService.GetScheduleByApplicationId(Schedule.PrevApplicationId);
            if (schedule.Result != null)
            {
                var paidInstallments = schedule.Result.installmentList.Where(x => x.isPaid == true).ToList();
                Schedule.PaidInstallmentList = paidInstallments;
                Schedule.OldSchedule = schedule.Result;
            }

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
                var getLRDold = _businessPlanAppService.GetBusinessPlanByApplicationId(application.PrevApplicationId).Result;
                if (getLRDold != null)
                {
                    ViewBag.LoanRequisitionDetailsOld = getLRDold;
                }
                var getLEold = _loanEligibilityAppService.GetLoanEligibilityListByApplicationId(application.PrevApplicationId).Result;
                if (getLEold != null)
                {
                    ViewBag.LoanEligibilityOld = getLEold;
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

        [HttpPost]
        public JsonResult SaveScheduleTempEnhancement(CreateScheduleTempDto Schedule)
        {
            try
            {
                Schedule.UpdationReason = "Enhancement";
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

        public ActionResult FundingSource()
        {

            var sources = _fundingSourceRepository.GetAllList();

            ViewBag.sourcesList = new SelectList(sources, "Id", "Name");

            var mobilizationList = _applicationAppService.GetApplicationList(ApplicationState.Disbursed, 0, true);
            return View(mobilizationList);
        }
        [HttpPost]
        public async Task<JsonResult> SaveFundingSource(int ApplicationId, int fsource)
        {
            string response = "";
            try
            {
                var appData = _applicationRepository.Get(ApplicationId);
                appData.FundingSource = fsource;
                _applicationRepository.Update(appData);
                CurrentUnitOfWork.SaveChanges();

                response = "Funding Source Updated";
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(response);

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
                var Acc = _customerAccountAppAppService.GetCustomerAccountByCNIC(app.CNICNo).Result;
                if (Acc != null)
                {
                    ViewBag.Payment = Acc.Balance;
                }
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

            decimal amountToDeduct = entry.amountDeposited;

            var accupdate1 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(entry.ApplicationId);
            var transactions = new Transaction();
            transactions.Type = "Debit";
            transactions.Details = "Early Settlement Charges";
            transactions.isAuthorized = true;
            transactions.ApplicationId = entry.ApplicationId;
            transactions.Fk_AccountId = accupdate1.Id;
            transactions.BalBefore = accupdate1.Balance;
            transactions.Amount = entry.EarlySettlmentCharges;
            transactions.AmountWords = NumberToWords((int)entry.EarlySettlmentCharges);
            transactions.BalAfter = (transactions.BalBefore - entry.EarlySettlmentCharges);
            var ts = _transactionRepository.Insert(transactions);
            var cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate1.Id, transactions.BalAfter);
            amountToDeduct -= entry.EarlySettlmentCharges;

            var accupdate2 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(entry.ApplicationId);
            transactions = new Transaction();
            transactions.Type = "Debit";
            transactions.Details = "FED on Early Settlement Charges";
            transactions.isAuthorized = true;
            transactions.ApplicationId = entry.ApplicationId;
            transactions.Fk_AccountId = accupdate2.Id;
            transactions.BalBefore = accupdate2.Balance;
            transactions.Amount = entry.FEDonESC;
            transactions.AmountWords = NumberToWords((int)entry.FEDonESC);
            transactions.BalAfter = (transactions.BalBefore - entry.FEDonESC);
            ts = _transactionRepository.Insert(transactions);
            cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate1.Id, transactions.BalAfter);
            amountToDeduct -= entry.FEDonESC;


            var accupdate3 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(entry.ApplicationId);
            transactions = new Transaction();
            transactions.Type = "Debit";
            transactions.Details = "Late Payment Charges";
            transactions.isAuthorized = true;
            transactions.Fk_AccountId = accupdate3.Id;
            transactions.ApplicationId = entry.ApplicationId;
            transactions.BalBefore = accupdate3.Balance;
            transactions.Amount = entry.LatePaymentCharges;
            transactions.AmountWords = NumberToWords((int)entry.LatePaymentCharges);
            transactions.BalAfter = (transactions.BalBefore - entry.LatePaymentCharges);
            ts = _transactionRepository.Insert(transactions);
            cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate3.Id, transactions.BalAfter);
            amountToDeduct -= entry.LatePaymentCharges;

            var accupdate4 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(entry.ApplicationId);
            transactions = new Transaction();
            transactions.Type = "Debit";
            transactions.Details = "FED on Late Payment Charges";
            transactions.isAuthorized = true;
            transactions.ApplicationId = entry.ApplicationId;
            transactions.Fk_AccountId = accupdate4.Id;
            transactions.BalBefore = accupdate4.Balance;
            transactions.Amount = entry.FEDonLPC;
            transactions.AmountWords = NumberToWords((int)entry.FEDonLPC);
            transactions.BalAfter = (transactions.BalBefore - entry.FEDonLPC);
            ts = _transactionRepository.Insert(transactions);
            cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate4.Id, transactions.BalAfter);
            amountToDeduct -= entry.FEDonLPC;

            var accupdate5 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(entry.ApplicationId);
            transactions = new Transaction();
            transactions.Type = "Debit";
            transactions.Details = "Markup";
            transactions.isAuthorized = true;
            transactions.ApplicationId = entry.ApplicationId;
            transactions.Fk_AccountId = accupdate5.Id;
            transactions.BalBefore = accupdate5.Balance;
            transactions.Amount = entry.MarkupPayable;
            transactions.AmountWords = NumberToWords((int)entry.MarkupPayable);
            transactions.BalAfter = (transactions.BalBefore - entry.MarkupPayable);
            ts = _transactionRepository.Insert(transactions);
            cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate5.Id, transactions.BalAfter);
            amountToDeduct -= entry.MarkupPayable;

            var accupdate6 = _customerAccountAppAppService.GetCustomerAccountByApplicationId(entry.ApplicationId);
            transactions = new Transaction();
            transactions.Type = "Debit";
            transactions.Details = "Principal";
            transactions.isAuthorized = true;
            transactions.Fk_AccountId = accupdate6.Id;
            transactions.ApplicationId = entry.ApplicationId;
            transactions.BalBefore = accupdate6.Balance;
            transactions.Amount = entry.PrincipalPayable;
            transactions.AmountWords = NumberToWords((int)entry.PrincipalPayable);
            transactions.BalAfter = (transactions.BalBefore - entry.PrincipalPayable);
            ts = _transactionRepository.Insert(transactions);
            cs = _customerAccountAppAppService.UpdateAccountBalance(accupdate6.Id, transactions.BalAfter);
            amountToDeduct -= entry.PrincipalPayable;



            CurrentUnitOfWork.SaveChanges();

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

            if (!app.isDeceased)
            {
                ViewBag.Deceased = "No";
            }
            else
            {
                ViewBag.Deceased = "Yes";
            }

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

        public IActionResult MarkDeceased(int ApplicationId)
        {
            ViewBag.Applicationid = ApplicationId;

            var app = _applicationAppService.GetApplicationById(ApplicationId);
            ViewBag.ClientId = app.ClientID;
            ViewBag.ClientName = app.ClientName;
            ViewBag.CNIC = app.CNICNo;

            return View();
        }

        public IActionResult declineMarkingDeceased(int Id, string Reason)
        {
            var app = _deceasedAuthorizationRepository.Get(Id);
            app.isAuthorized = false;
            app.RejectionReason = Reason;
            _deceasedAuthorizationRepository.Update(app);

            return RedirectToAction("DeceasedAuthorizationList", "Accountant");
        }

        public IActionResult MarkApplicantDeceased(string cnic, int appid)
        {
            var apps = _applicationRepository.GetAllList(x => x.CNICNo == cnic).ToList();

            foreach (var app in apps)
            {
                app.isDeceased = true;
                _applicationRepository.Update(app);
                CurrentUnitOfWork.SaveChanges();
            }

            var auth = _deceasedAuthorizationRepository.Get(appid);
            auth.isAuthorized = true;
            _deceasedAuthorizationRepository.Update(auth);

            return RedirectToAction("DeceasedAuthorizationList", "Accountant");
        }


        [HttpPost]
        public IActionResult CreateDeceasedSettlement(CreateDeceasedSettlement input)
        {
            string uploadFileResult = UploadImagestoServer(input.file, "wwwroot/uploads/DeceasedFiles/" + input.ApplicationId + "/");
            if (uploadFileResult != "Error")
            {
                input.ProofUrl = uploadFileResult;
            }

            _deceasedSettlementAppService.Create(input);
            _notificationLogAppService.SendNotification(69, "Deceased Applicant Settlement Entry has been recieved.", "Go to Deceased Applicant Settlement Authorization list to authorize/reject entry.");

            return RedirectToAction("Success", "About", new { Message = "Deceased Applicant Settlement Entry Sent to Finance Department for Authorization!" });
        }

        [HttpPost]
        public IActionResult CreateDeceasedAuthorization(CreateDeceasedAuthorization input)
        {
            string uploadFileResult = UploadImagestoServer(input.file, "wwwroot/uploads/DeceasedFiles/" + input.ApplicationId + "/");
            if (uploadFileResult != "Error")
            {
                input.ProofUrl = uploadFileResult;
            }

            _deceasedAuthorizationAppService.Create(input);
            return RedirectToAction("Success", "About", new { Message = "Deceased Applicant Marking Entry Sent to BM for Authorization!" });
        }
        private string UploadImagestoServer(IFormFile document, string path)
        {
            try
            {
                Directory.CreateDirectory(path);

                string extension = System.IO.Path.GetExtension(document.FileName);
                string filePath = Path.Combine(path, document.FileName + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + extension);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    document.CopyTo(fileStream);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        public IActionResult DeceasedAuthorizationList(int ApplicationId)
        {
            var list = _deceasedAuthorizationAppService.GetAllDeceasedAuthorizations().Result.Where(x => x.isAuthorized == null).ToList();

            List<DeceasedAuthorizationListDto> returnList = new List<DeceasedAuthorizationListDto>();

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
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
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

                var app = _applicationRepository.Get(entry.ApplicationId);
                _applicationAppService.ChangeApplicationState(ApplicationState.Deceased, entry.ApplicationId, "Deceased Applicant");

                CreateFinalWorkflowDto fWobj = new CreateFinalWorkflowDto();
                fWobj.ApplicationId = entry.ApplicationId;
                fWobj.Action = "Application Submitted";
                fWobj.ActionBy = (int)AbpSession.UserId;
                fWobj.ApplicationState = ApplicationState.Submitted;
                fWobj.isActive = true;

                _finalWorkflowAppService.CreateFinalWorkflow(fWobj);

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
