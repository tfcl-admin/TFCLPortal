using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.BusinessPlans;
using TFCLPortal.DynamicDropdowns.FundSources;
using TFCLPortal.DynamicDropdowns.Occupations;
using TFCLPortal.Schedules.Dto;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.Applications.Dto;
using TFCLPortal.InstallmentPayments;
using TFCLPortal.Users;
using System.Globalization;
using TFCLPortal.InstallmentPayments.Dto;

namespace TFCLPortal.Schedules
{
    public class ScheduleAppService : TFCLPortalAppServiceBase, IScheduleAppService
    {
        private readonly IRepository<Schedule, Int32> _ScheduleRepository;
        private readonly IRepository<ScheduleInstallment, Int32> _childRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IInstallmentPaymentAppService _installmentPaymentAppService;
        private readonly IUserAppService _userAppService;

        private string Schedules = "Schedules";
        public ScheduleAppService(IRepository<Schedule, Int32> ScheduleRepository,
            IRepository<GuarantorDetail, Int32> guarantorDetailAppService,
            IApplicationAppService applicationAppService,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<BusinessPlan, Int32> BusinessPlanAppService,
            IInstallmentPaymentAppService installmentPaymentAppService,
            IUserAppService userAppService,
            IRepository<Applicationz, Int32> applicationRepository,
            IRepository<ScheduleInstallment, Int32> childRepository)
        {
            _userAppService = userAppService;
            _applicationRepository = applicationRepository;
            _ScheduleRepository = ScheduleRepository;
            _childRepository = childRepository;
            _installmentPaymentAppService = installmentPaymentAppService;
            _applicationAppService = applicationAppService;
            _apiCallLogAppService = apiCallLogAppService;
        }

        public async Task<string> CreateSchedule(CreateScheduleDto input)
        {
            CreateApiCallLogDto callLog = new CreateApiCallLogDto();
            callLog.FunctionName = "CreateSchedule";
            callLog.Input = JsonConvert.SerializeObject(input);
            var returnStr = _apiCallLogAppService.CreateApplication(callLog);

            string response = "Success";
            var IsScheduleExist = _ScheduleRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();
            try
            {
                if (IsScheduleExist != null)
                {
                    var IsScheduleInstallmentExist = _childRepository.GetAllList().Where(x => x.FK_ScheduleId == IsScheduleExist.Id).ToList();

                    var Schedule1 = ObjectMapper.Map<Schedule>(IsScheduleExist);
                    await _ScheduleRepository.DeleteAsync(Schedule1);

                    var Schedule = ObjectMapper.Map<Schedule>(input);
                    var result = await _ScheduleRepository.InsertAsync(Schedule);
                    CurrentUnitOfWork.SaveChanges();

                    if (IsScheduleInstallmentExist.Count > 0)
                    {
                        foreach (var child in IsScheduleInstallmentExist)
                        {
                            child.FK_ScheduleId = result.Id;
                            var installment = ObjectMapper.Map<ScheduleInstallment>(child);
                            await _childRepository.DeleteAsync(installment);
                            CurrentUnitOfWork.SaveChanges();
                        }

                        List<CreateScheduleInstallmentDto> ScheduleAddDtos = input.installmentList;
                        foreach (var ScheduleAddDto in ScheduleAddDtos)
                        {
                            ScheduleAddDto.FK_ScheduleId = result.Id;
                            var ScheduleInstallment = ObjectMapper.Map<ScheduleInstallment>(ScheduleAddDto);
                            await _childRepository.InsertAsync(ScheduleInstallment);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                    else
                    {
                        List<CreateScheduleInstallmentDto> ScheduleAddDtos = input.installmentList;
                        foreach (var ScheduleAddDto in ScheduleAddDtos)
                        {
                            ScheduleAddDto.FK_ScheduleId = result.Id;
                            var ScheduleInstallment = ObjectMapper.Map<ScheduleInstallment>(ScheduleAddDto);
                            await _childRepository.InsertAsync(ScheduleInstallment);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }

                }
                else
                {
                    var Schedule = ObjectMapper.Map<Schedule>(input);

                    var result = await _ScheduleRepository.InsertAsync(Schedule);
                    CurrentUnitOfWork.SaveChanges();
                    if (input.installmentList.Count > 0)
                    {
                        List<CreateScheduleInstallmentDto> ScheduleAddDtos = input.installmentList;
                        foreach (var ScheduleAddDto in ScheduleAddDtos)
                        {
                            ScheduleAddDto.FK_ScheduleId = result.Id;
                            var ScheduleInstallment = ObjectMapper.Map<ScheduleInstallment>(ScheduleAddDto);
                            await _childRepository.InsertAsync(ScheduleInstallment);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.ToString();
                throw new UserFriendlyException(L("CreateMethodError{0}", Schedules));

            }


        }
        public async Task<ScheduleListDto> GetScheduleById(int Id)
        {
            try
            {
                var Schedule = await _ScheduleRepository.GetAsync(Id);
                var result = ObjectMapper.Map<ScheduleListDto>(Schedule);
                if (result != null)
                {
                    var ScheduleInstallment = _childRepository.GetAllList(i => i.FK_ScheduleId == Id);
                    var MapScheduleAddDto = ObjectMapper.Map<List<ScheduleInstallmenttListDto>>(ScheduleInstallment);
                    result.installmentList = MapScheduleAddDto;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }
        public async Task<string> UpdateSchedule(UpdateScheduleDto input)
        {
            string ResponseString = "";
            try
            {
                var Schedule = _ScheduleRepository.Get(input.Id);
                if (Schedule != null && Schedule.Id > 0)
                {
                    ObjectMapper.Map(input, Schedule);
                    await _ScheduleRepository.UpdateAsync(Schedule);
                    CurrentUnitOfWork.SaveChanges();

                    if (input.installmentList.Count > 0)
                    {
                        foreach (var child in input.installmentList)
                        {
                            var detailChild = _childRepository.Get(child.Id);
                            ObjectMapper.Map(child, detailChild);
                            await _childRepository.UpdateAsync(detailChild);
                            CurrentUnitOfWork.SaveChanges();

                        }
                    }
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", Schedules));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", Schedules));
            }
        }
        public async Task<ScheduleListDto> GetScheduleByApplicationId(int ApplicationId)
        {
            try
            {
                
                var Schedule = _ScheduleRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                var result = ObjectMapper.Map<ScheduleListDto>(Schedule);
                if (result != null)
                {
                    var ScheduleInstallment = _childRepository.GetAllList(i => i.FK_ScheduleId == result.Id).OrderBy(x => x.Id);
                    var MapScheduleAddDto = ObjectMapper.Map<List<ScheduleInstallmenttListDto>>(ScheduleInstallment);
                    result.installmentList = MapScheduleAddDto;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }

        public async Task<List<ScheduleListDto>> GetScheduleList()
        {
            try
            {
                var Schedule = _ScheduleRepository.GetAllList().ToList();

                var result = ObjectMapper.Map<List<ScheduleListDto>>(Schedule);

                foreach (var item in result)
                {
                    if (result != null)
                    {
                        var ScheduleInstallment = _childRepository.GetAllList(i => i.FK_ScheduleId == item.Id).OrderBy(x => x.Id);
                        var MapScheduleAddDto = ObjectMapper.Map<List<ScheduleInstallmenttListDto>>(ScheduleInstallment);
                        item.installmentList = MapScheduleAddDto;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }

        public bool CheckScheduleByApplicationId(int ApplicationId)
        {
            try
            {
                var Schedule = _ScheduleRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (Schedule != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }

        public async Task<List<ScheduleInstallmenttListDto>> GetInstallmentPaymentsByUserId(int UserId)
        {
            try
            {
                List<ScheduleInstallmenttListDto> scheduleInstallments = new List<ScheduleInstallmenttListDto>();

                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;



                var getDisbursedApplications = _applicationRepository.GetAllList(x => x.ScreenStatus == ApplicationState.Disbursed && x.CreatorUserId == UserId).ToList();
                if (getDisbursedApplications.Count > 0)
                {
                    foreach (var app in getDisbursedApplications)
                    {
                        var schedule = GetScheduleByApplicationId(app.Id).Result;
                        if (schedule != null)
                        {
                            List<ScheduleInstallmenttListDto> installments = new List<ScheduleInstallmenttListDto>();

                            installments = schedule.installmentList.Where(x => x.InstNumber != "G*" && DateTime.Parse(x.InstallmentDueDate).Month == month && DateTime.Parse(x.InstallmentDueDate).Year == year).ToList();

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


                                    scheduleInstallments.Add(inst);
                                }
                            }
                        }
                    }
                }

                return scheduleInstallments;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }

        public List<ScheduleInstallmenttListDto> GetInstallmentPaymentsList(int? filterType, int? branchFilter, int? day, int? month, int? year)
        {
            try
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
                //ViewBag.monthName = monthName;
                //ViewBag.Month = month;
                //ViewBag.Year = year;
                //ViewBag.Day = day;
                //ViewBag.filterType = filterType;

                int branch = 0;

                if (branchFilter != null)
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

                var schedules = GetScheduleList();
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

                //ViewBag.Due = totalDue;
                //ViewBag.Paid = totalPaid;
                //ViewBag.UnPaid = totalUnPaid;
                //ViewBag.DefCount = DefCount;
                //ViewBag.DefAmount = DefAmount;



                return scheduleInstallments;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }

        public bool SetPaid(int InstId, string Type,DateTime paymentDate)
        {
            try
            {
                var schedule = _childRepository.GetAllList(x=>x.Id==InstId).FirstOrDefault();
                if(schedule!=null)
                {
                    if (Type == "Markup")
                    {
                        schedule.isMarkupPaid = true;
                        _childRepository.Update(schedule);
                        CurrentUnitOfWork.SaveChanges();

                        return true;
                    }
                    else if (Type == "Principal")
                    {
                        schedule.isPrincipalPaid = true;
                        _childRepository.Update(schedule);
                        CurrentUnitOfWork.SaveChanges();

                        return true;
                    }
                    else if (Type == "Installment")
                    {
                        schedule.isMarkupPaid = true;
                        schedule.isPrincipalPaid = true;
                        schedule.isPaid = true;
                        schedule.PaymentDate = paymentDate;
                        _childRepository.Update(schedule);
                        CurrentUnitOfWork.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Schedules));
            }
        }
    }
}
