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
using TFCLPortal.StudentDetails.Dto;
using TFCLPortal.Users.Dto;

namespace TFCLPortal.StudentDetails
{
    public class StudentDetailAppService : TFCLPortalAppServiceBase, IStudentDetailAppService
    {
        private readonly IRepository<StudentDetail, Int32> _studentDetailRepository;
        private readonly IRepository<MaritalStatus> _maritalStatusesRepository;
        private readonly IRepository<Gender> _genderrepository;
        private readonly IRepository<Qualification> _qualificationRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        private readonly IBusinessPlanAppService _businessPlanAppService;
        private readonly IRepository<SpouseStatus> _spouseStatuseRepository;
        private string studentDetail = "Student Detail";

        public StudentDetailAppService(IRepository<StudentDetail, Int32> repository,
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
            _studentDetailRepository = repository;
            _maritalStatusesRepository = maritalStatusesRepository;
            _genderrepository = genderrepository;
            _qualificationRepository = qualificationRepository;
            _spouseStatuseRepository = spouseStatuseRepository;
            _apiCallLogAppService = apiCallLogAppService;
            _applicationAppService = applicationAppService;
            _businessPlanAppService = businessPlanAppService;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }

        public StudentDetailDto GetStudentDetailById(int Id)
        {
            try
            {
                var studentDetails = _studentDetailRepository.Get(Id);
                return ObjectMapper.Map<StudentDetailDto>(studentDetails);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", studentDetail));
            }
        }


        public async Task<string> CreateStudentDetail(CreateStudentDetailDto input)
        {
            string ResponseString = "";

            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateStudentDetail";
                callLog.Input = JsonConvert.SerializeObject(input);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);

                var IsExist = _studentDetailRepository.GetAllList().Where(x => x.ApplicationId == input.ApplicationId).FirstOrDefault();

                if (IsExist != null && IsExist.ApplicationId > 0)
                {
                    var studentDetail = _studentDetailRepository.Get(IsExist.Id);
                    studentDetail.Id = IsExist.Id;
                    studentDetail.ApplicationId = input.ApplicationId;
                    studentDetail.StudentName = input.StudentName;
                    studentDetail.ParentName = input.ParentName;
                    studentDetail.CNIC = input.CNIC;
                    studentDetail.CNICExpiry = input.CNICExpiry;
                    studentDetail.BirthDate = input.BirthDate;
                    studentDetail.Gender = input.Gender;
                    studentDetail.Age = input.Age;
                    studentDetail.RelationWithClient = input.RelationWithClient;
                    studentDetail.MaritalStatus = input.MaritalStatus;
                    studentDetail.NumberOfDependents = input.NumberOfDependents;
                    studentDetail.EIName = input.EIName;
                    studentDetail.StudentID = input.StudentID;
                    studentDetail.EnrolledDegree = input.EnrolledDegree;
                    studentDetail.Others = input.Others;
                    studentDetail.FinalSemester = input.FinalSemester;
                    studentDetail.LastSemester = input.LastSemester;
                    studentDetail.FeeRequiredForSemesterNo = input.FeeRequiredForSemesterNo;
                    studentDetail.PhoneNumber = input.PhoneNumber;

                    await _studentDetailRepository.UpdateAsync(studentDetail);
                }
                else
                {
                    var studentDetailcreate = ObjectMapper.Map<StudentDetail>(input);
                    await _studentDetailRepository.InsertAsync(studentDetailcreate);
                    _applicationAppService.UpdateApplicationLastScreen("STUDENT DETAILS", input.ApplicationId);

                }
                CurrentUnitOfWork.SaveChanges();
                return ResponseString = "Success";
            }
            catch (Exception ex)
            {
                return ResponseString = "Error : " + ex.ToString();

                throw new UserFriendlyException(L("CreateMethodError{0}", studentDetail));

            }

        }

        public async Task<string> UpdateStudentDetail(UpdateStudentDetailDto input)
        {
            // CheckUpdatePermission();
            string ResponseString = "";
            try
            {


                var studentDetails = _studentDetailRepository.Get(input.Id);
                if (studentDetails != null && studentDetails.Id > 0)
                {
                    ObjectMapper.Map(input, studentDetails);

                    await _studentDetailRepository.UpdateAsync(studentDetails);

                    CurrentUnitOfWork.SaveChanges();
                    ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", studentDetail));

                }


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", studentDetail));
            }
            return ResponseString;

        }

        public async Task<StudentDetailDto> GetStudentDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var studentDetails = _studentDetailRepository.FirstOrDefault(x => x.ApplicationId == ApplicationId);

                var obj = ObjectMapper.Map<StudentDetailDto>(studentDetails);

                if (obj != null && obj.ApplicationId > 0)
                {

                    if (studentDetails.Gender != 0)
                    {
                        var gender = _genderrepository.Get(studentDetails.Gender);
                        obj.GenderName = gender.Name;
                    }

                    if (studentDetails.MaritalStatus != 0)
                    {
                        var marital = _maritalStatusesRepository.Get(studentDetails.MaritalStatus);
                        obj.MaritalStatusName = marital.Name;
                    }

    

                    if (studentDetails.BirthDate != null)
                    {
  
                        DateTime SubmittedDate = _applicationAppService.getLastWorkFlowStateDate(ApplicationId, ApplicationState.Submitted);

                        if (SubmittedDate != new DateTime())
                        {
                            obj.Age = getDuration(Convert.ToDateTime(studentDetails.BirthDate), SubmittedDate);

                        }
                        else
                        {
                            obj.Age = "--";
                        }

   

                    }

                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", studentDetail));
            }
        }

        //private string getDurationWithTenure(DateTime BirthDate, DateTime submittedDate, int intTenure)
        //{


        //    DateTime startDate = BirthDate;
        //    DateTime endDate = submittedDate;
        //    int days = 0;
        //    int months = 0;
        //    int years = 0;
        //    //calculate days
        //    if (endDate.Day >= startDate.Day)
        //    {
        //        days = endDate.Day - startDate.Day;
        //    }
        //    else
        //    {
        //        var tempDate = endDate.AddMonths(-1);
        //        int daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
        //        days = daysInMonth - (startDate.Day - endDate.Day);
        //        months--;
        //    }
        //    //calculate months
        //    if (endDate.Month >= startDate.Month)
        //    {
        //        months += endDate.Month - startDate.Month;
        //    }
        //    else
        //    {
        //        months += 12 - (startDate.Month - endDate.Month);
        //        years--;
        //    }
        //    //calculate years
        //    years += endDate.Year - startDate.Year;

        //    var totalDaysAge = Convert.ToInt32(days + (months * 30.436875) + (years * 365.2425));
        //    var totalDaysTenure = Convert.ToInt32(intTenure * 30.436875);

        //    var totalDays = totalDaysAge + totalDaysTenure;

        //    TimeSpan ts = new TimeSpan(totalDays);

        //    var totalYears = Math.Truncate(Convert.ToDecimal(totalDays / 365.2425));
        //    var totalMonths = Math.Truncate(Convert.ToDecimal((totalDays % 365.2425) / 30.436875));
        //    var remainingDays = Math.Truncate(Convert.ToDecimal((totalDays % 365.2425) % 30.436875));

        //    return string.Format("{0} years, {1} months, {2} days", totalYears, totalMonths, remainingDays);
        //}

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

        //public bool CheckPersonalDetailByApplicationId(int ApplicationId)
        //{
        //    try
        //    {
        //        var personalDetails = _studentDetailRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).FirstOrDefault();
        //        if (personalDetails != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException(L("GetMethodError{0}", studentDetail));
        //    }
        //}
    }
}

