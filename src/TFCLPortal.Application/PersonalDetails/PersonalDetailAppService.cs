using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.ApiCallLogs.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.BusinessPlans;
using TFCLPortal.DynamicDropdowns.Genders;
using TFCLPortal.DynamicDropdowns.MaritalStatuses;
using TFCLPortal.DynamicDropdowns.Qualifications;
using TFCLPortal.DynamicDropdowns.SpouseStatuses;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.PersonalDetails
{
    public class PersonalDetailAppService : TFCLPortalAppServiceBase, IPersonalDetailAppService
    {
        private readonly IRepository<PersonalDetail, Int32> _personalDetailRepository;
        private readonly IRepository<MaritalStatus> _maritalStatusesRepository;
        private readonly IRepository<Gender> _genderrepository;
        private readonly IRepository<Qualification> _qualificationRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IRepository<SpouseStatus> _spouseStatuseRepository;
        private string personalDetail = "Personal Detail";

        public PersonalDetailAppService(IRepository<PersonalDetail, Int32> repository,
            IRepository<MaritalStatus> maritalStatusesRepository,
            IRepository<Gender> genderrepository,
            IRepository<SpouseStatus> spouseStatuseRepository,
            IApiCallLogAppService apiCallLogAppService,
            IApplicationAppService applicationAppService,
            IBusinessPlanAppService businessPlanAppService,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService,
            IRepository<Qualification> qualificationRepository
            )
        {
            _personalDetailRepository = repository;
            _maritalStatusesRepository = maritalStatusesRepository;
            _genderrepository = genderrepository;
            _qualificationRepository = qualificationRepository;
            _spouseStatuseRepository = spouseStatuseRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
            _businessPlanAppService = businessPlanAppService;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }

        public PersonalDetailDto GetPersonalDetailById(int Id)
        {
            try
            {
                var personalDetails = _personalDetailRepository.Get(Id);
                return ObjectMapper.Map<PersonalDetailDto>(personalDetails);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", personalDetail));
            }
        }


        public async Task<string> CreatePersonalDetail(CreatePersonalDetailDto input)
        {
            string ResponseString = "";

            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreatePersonalDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _personalDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsExist != null && IsExist.ApplicationId > 0)
                {
                    var personalDetail = _personalDetailRepository.Get(IsExist.Id);
                    personalDetail.Id = IsExist.Id;
                    personalDetail.ApplicationId = input.ApplicationId;
                    personalDetail.Name = input.Name;
                    personalDetail.ApplicantName = input.ApplicantName;
                    personalDetail.ParentName = input.ParentName;
                    personalDetail.CNIC = input.CNIC;
                    personalDetail.CNICExpiry = input.CNICExpiry;
                    personalDetail.BirthDate = input.BirthDate;
                    personalDetail.Gender = input.Gender;
                    personalDetail.Age = input.Age;
                    personalDetail.MaritalStatus = input.MaritalStatus;
                    personalDetail.NumberOfDependents = input.NumberOfDependents;
                    personalDetail.Qualification = input.Qualification;
                    personalDetail.ScreenStatus = input.ScreenStatus;
                    personalDetail.Comments = input.Comments;
                    personalDetail.OtherGenderDD = input.OtherGenderDD;
                    personalDetail.OtherQualificationDD = input.OtherQualificationDD;
                    personalDetail.Specialization = input.Specialization;
                    personalDetail.NumberOfDependants = input.NumberOfDependants;
                    personalDetail.SpouseStatus = input.SpouseStatus;
                    personalDetail.SchoolGoingDependants = input.SchoolGoingDependants;
                    personalDetail.Nationality = input.Nationality;
                    personalDetail.OtherNationality = input.OtherNationality;
                    personalDetail.MotherMaidenName = input.MotherMaidenName;
                    personalDetail.PersonalNTN = input.PersonalNTN;
                    personalDetail.SalesTaxNumber = input.SalesTaxNumber;
                    personalDetail.isActiveTaxPayer = input.isActiveTaxPayer;

                    await _personalDetailRepository.UpdateAsync(personalDetail);
                }
                else
                {
                    var personalDetailcreate = ObjectMapper.Map<PersonalDetail>(input);
                    await _personalDetailRepository.InsertAsync(personalDetailcreate);
                    _applicationAppService.UpdateApplicationLastScreen("PERSONAL DETAILS", input.ApplicationId);

                }
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();

                throw new UserFriendlyException(L("CreateMethodError{0}", personalDetail));

            }

        }

        public async Task<string> UpdatePersonalDetail(UpdatePersonalDetailDto input)
        {
            // CheckUpdatePermission();
            string ResponseString = "";
            try
            {


                var personalDetails = _personalDetailRepository.Get(input.Id);
                if (personalDetails != null && personalDetails.Id > 0)
                {
                    ObjectMapper.Map(input, personalDetails);

                    await _personalDetailRepository.UpdateAsync(personalDetails);

                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", personalDetail));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", personalDetail));
            }
            return ResponseString;

        }

        public async Task<PersonalDetailDto> GetPersonalDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var personalDetails = _personalDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                var obj = ObjectMapper.Map<PersonalDetailDto>(personalDetails);

                if (obj != null && obj.ApplicationId > 0)
                {

                    if (personalDetails.Gender != 0)
                    {
                        var gender = _genderrepository.Get(personalDetails.Gender);
                        obj.GenderName = gender.Name;
                    }

                    if (personalDetails.MaritalStatus != 0)
                    {
                        var marital = _maritalStatusesRepository.Get(personalDetails.MaritalStatus);
                        obj.MaritalStatusName = marital.Name;
                    }

                    if (personalDetails.Qualification != 0)
                    {
                        var qualification = _qualificationRepository.Get(personalDetails.Qualification);
                        obj.QualificationName = qualification.Name;
                    }

                    if (personalDetails.SpouseStatus != null && personalDetails.SpouseStatus != 0)
                    {
                        var spouseStatus = _spouseStatuseRepository.Get((int)personalDetails.SpouseStatus);
                        obj.SpouseStatusName = spouseStatus.Name;
                    }

                    if (personalDetails.BirthDate != null)
                    {
                        //var appDetails = _applicationAppService.GetApplicationById(ApplicationId);
                        //if (appDetails != null)
                        //{
                        //    if (appDetails.ScreenStatus == ApplicationState.Disbursed || appDetails.ScreenStatus == ApplicationState.ForceDecline || appDetails.ScreenStatus == ApplicationState.BCC_Decline || appDetails.ScreenStatus == ApplicationState.VO_Decline || appDetails.ScreenStatus == ApplicationState.BM_Decline)
                        //    {
                        //        obj.CalculatedAge= getDuration(Convert.ToDateTime(personalDetails.BirthDate), Convert.ToDateTime(appDetails.LastModificationTime)) + " (Last Update)";
                        //    }
                        //}
                        //if(obj.CalculatedAge==null)
                        //{
                        //    obj.CalculatedAge = getDuration(Convert.ToDateTime(personalDetails.BirthDate), DateTime.Now);
                        //}

                        DateTime SubmittedDate = _applicationAppService.getLastWorkFlowStateDate(ApplicationId, ApplicationState.Submitted);
                        
                        if (SubmittedDate!=new DateTime())
                        {
                            obj.CalculatedAge = getDuration(Convert.ToDateTime(personalDetails.BirthDate), SubmittedDate);

                        }
                        else
                        {
                            obj.CalculatedAge = "--";
                        }

                        DateTime DisbursementDate = _applicationAppService.getLastWorkFlowStateDate(ApplicationId, ApplicationState.Disbursed);

                        if (DisbursementDate != new DateTime())
                        {
                            obj.CalculatedAgeDisbursement = getDuration(Convert.ToDateTime(personalDetails.BirthDate), DisbursementDate);

                        }
                        else
                        {
                            obj.CalculatedAgeDisbursement = "--";
                        }


                        if (DisbursementDate != new DateTime())
                        {
                            var tenure = _businessPlanAppService.GetBusinessPlanByApplicationId(ApplicationId).Result.LoanTenureRequestedName;
                            var IntTenure = int.Parse(tenure);


                            obj.LoanMatureDate = getDurationWithTenure(Convert.ToDateTime(personalDetails.BirthDate), DisbursementDate, IntTenure);
                            //Change When disbursed date is available
                            //else show on submitted date.

                        }
                        else
                        {
                            obj.LoanMatureDate = "--";
                        }

                        var deviation = _applicationWiseDeviationVariableAppService.GetApplicationWiseDeviationVariableDetailByApplicationId(ApplicationId);
                       if(deviation!=null)
                        {
                            obj.AllowedMinAge = deviation.ApplicantMinAge;
                            obj.AllowedMaxAge = deviation.ApplicantMaxAge;
                        }

                    }

                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", personalDetail));
            }
        }

        private string getDurationWithTenure(DateTime BirthDate, DateTime submittedDate, int intTenure)
        {


            DateTime startDate = BirthDate;
            DateTime endDate = submittedDate;
            int days = 0;
            int months = 0;
            int years = 0;
            //calculate days
            if (endDate.Day >= startDate.Day)
            {
                days = endDate.Day - startDate.Day;
            }
            else
            {
                var tempDate = endDate.AddMonths(-1);
                int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
                days = daysInMonth - (startDate.Day - endDate.Day);
                months--;
            }
            //calculate months
            if (endDate.Month >= startDate.Month)
            {
                months += endDate.Month - startDate.Month;
            }
            else
            {
                months += 12 - (startDate.Month - endDate.Month);
                years--;
            }
            //calculate years
            years += endDate.Year - startDate.Year;

            var totalDaysAge = Convert.ToInt32(days + (months * 30.436875) + (years * 365.2425));
            var totalDaysTenure = Convert.ToInt32(intTenure * 30.436875);

            var totalDays = totalDaysAge + totalDaysTenure;

            TimeSpan ts = new TimeSpan(totalDays);

            var totalYears = Math.Truncate(Convert.ToDecimal(totalDays / 365.2425));
            var totalMonths = Math.Truncate(Convert.ToDecimal((totalDays % 365.2425) / 30.436875));
            var remainingDays = Math.Truncate(Convert.ToDecimal((totalDays % 365.2425) % 30.436875));

            return string.Format("{0} years, {1} months, {2} days", totalYears, totalMonths, remainingDays);
        }

        public string getDuration(DateTime dStart, DateTime dEnd)
        {
            DateTime startDate = dStart;
            DateTime endDate = dEnd;
            int days = 0;
            int months = 0;
            int years = 0;
            //calculate days
            if (endDate.Day >= startDate.Day)
            {
                days = endDate.Day - startDate.Day;
            }
            else
            {
                var tempDate = endDate.AddMonths(-1);
                int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
                days = daysInMonth - (startDate.Day - endDate.Day);
                months--;
            }
            //calculate months
            if (endDate.Month >= startDate.Month)
            {
                months += endDate.Month - startDate.Month;
            }
            else
            {
                months += 12 - (startDate.Month - endDate.Month);
                years--;
            }
            //calculate years
            years += endDate.Year - startDate.Year;

          
            return string.Format("{0} years, {1} months, {2} days", years, months, days);
        }

        public bool CheckPersonalDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var personalDetails = _personalDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
                if (personalDetails != null)
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
                throw new UserFriendlyException(L("GetMethodError{0}", personalDetail));
            }
        }
    }
}

