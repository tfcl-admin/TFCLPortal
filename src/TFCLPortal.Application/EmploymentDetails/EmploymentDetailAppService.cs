using Abp.Application.Services.Dto;
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
using TFCLPortal.Applications.Dto;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.DynamicDropdowns.CompanyTypes;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;
using TFCLPortal.EmploymentDetails.Dto;
using TFCLPortal.IApplicationWiseDeviationVariableAppServices;

namespace TFCLPortal.EmploymentDetails
{
    public class EmploymentDetailAppService : TFCLPortalAppServiceBase, IEmploymentDetailAppService
    {
        #region Properties
        private readonly IRepository<EmploymentDetail, int> _EmploymentDetailRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;
        private readonly IApplicationAppService _applicationAppService;
        private readonly IRepository<NatureOfEmployment> _NatureOfEmploymentAppService;
        private readonly IRepository<CompanyType> _CompanyTypeRepository;
        private readonly IApplicationWiseDeviationVariableAppService _applicationWiseDeviationVariableAppService;
        private readonly IApiCallLogAppService _apiCallLogAppService;
        #endregion
        #region Constructor 
        public EmploymentDetailAppService(IRepository<EmploymentDetail> EmploymentDetailRepository,
               IRepository<Applicationz, Int32> applicationRepository,
            IApplicationAppService applicationAppService,
            IRepository<CompanyType> CompanyTypeRepository,
            IApiCallLogAppService apiCallLogAppService,
            IRepository<NatureOfEmployment> NatureOfEmploymentAppService,
            IApplicationWiseDeviationVariableAppService applicationWiseDeviationVariableAppService)
        {
            _EmploymentDetailRepository = EmploymentDetailRepository;
            _applicationRepository = applicationRepository;
            _NatureOfEmploymentAppService = NatureOfEmploymentAppService;
            _applicationAppService = applicationAppService;
            _apiCallLogAppService = apiCallLogAppService;
            _CompanyTypeRepository = CompanyTypeRepository;
            _applicationWiseDeviationVariableAppService = applicationWiseDeviationVariableAppService;
        }
        #endregion
        #region Methods
        public async Task<string> Create(CreateEmploymentDetailInput createEmploymentDetailInput, int applicationId)
        {
            string response = "";
            try
            {
                CreateApiCallLogDto callLog = new CreateApiCallLogDto();
                callLog.FunctionName = "CreateEmploymentDetail";
                callLog.Input = JsonConvert.SerializeObject(createEmploymentDetailInput);
                var returnStr = _apiCallLogAppService.CreateApplication(callLog);


                var IsExist = _EmploymentDetailRepository.GetAllList().Where(x => x.ApplicationId == applicationId).ToList();
                if (IsExist.Count > 0)
                {
                    foreach (var Employment in IsExist)
                    {
                        var Employments = ObjectMapper.Map<EmploymentDetail>(Employment);
                        await _EmploymentDetailRepository.DeleteAsync(Employments);
                        CurrentUnitOfWork.SaveChanges();
                    }
                    foreach (var Employment in createEmploymentDetailInput.CreateEmploymentInput)
                    {
                     
                        //Employment.ApplicationId = applicationId;
                        var Employments = ObjectMapper.Map<EmploymentDetail>(Employment);
                        await _EmploymentDetailRepository.InsertAsync(Employments);
                    }
                }
                else
                {
                    foreach (EditEmploymentDetailinput Employment in createEmploymentDetailInput.CreateEmploymentInput)
                    {

                        //Employment.ApplicationId = applicationId;
                        var Employments = ObjectMapper.Map<EmploymentDetail>(Employment);
                        await _EmploymentDetailRepository.InsertAsync(Employments);

                    }
                }

                _applicationAppService.UpdateApplicationLastScreen("Employment Detail", applicationId);



                if (response != "")
                {
                    return response;
                }
                else
                {
                    return "Success";
                }
            }

            catch (Exception)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Employment Detail"));
            }
        }

        public async Task<List<EmploymentDetailListDto>> GetEmploymentDetailById(int Id)
        {
            try
            {

                var Employment = await _EmploymentDetailRepository.GetAllListAsync(x => x.Id == Id);

                return ObjectMapper.Map<List<EmploymentDetailListDto>>(Employment);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Employment Detail"));
            }
        }

        public async Task<string> Update(UpdateEmploymentDtoList editEmploymentDetailinput)
        {


            string ResponseString = "";
            try
            {

                foreach (EditEmploymentDetailinput EmploymentDto in editEmploymentDetailinput.EmploymentInput)
                {
                    var Employmentobj = _EmploymentDetailRepository.Get(EmploymentDto.Id);
                    if (Employmentobj != null && Employmentobj.Id > 0)
                    {


                        ObjectMapper.Map(EmploymentDto, Employmentobj);

                        await _EmploymentDetailRepository.UpdateAsync(Employmentobj);

                        CurrentUnitOfWork.SaveChanges();
                        ResponseString = "Records Updated Successfully";
                    }
                    else
                    {
                        throw new UserFriendlyException(L("UpdateMethodError{0}", "Employment Detail"));

                    }
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Employment Detail"));
            }
            return ResponseString;

        }

        public async Task<List<EmploymentDetailListDto>> GetEmploymentDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var forSDE = _EmploymentDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                var EmploymentDetailMapped = ObjectMapper.Map<List<EmploymentDetailListDto>>(forSDE);
                if (EmploymentDetailMapped.Count > 0)
                {
                    foreach (var Employment in EmploymentDetailMapped)
                    {
                        if (Employment.CompanyType != 0 )
                        {
                            var result = _CompanyTypeRepository.Get((int)Employment.CompanyType);
                            Employment.CompanyTypeName = result.Name;
                        }
                        if (Employment.NatureOfEmployment != 0)
                        {
                            var result = _NatureOfEmploymentAppService.Get((int)Employment.NatureOfEmployment);
                            Employment.NatureOfEmploymentName = result.Name;
                        }
                    }
                }

                return EmploymentDetailMapped;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Employment Detail"));
            }
        }

        public bool CheckEmploymentDetailByApplicationId(int ApplicationId)
        {
            try
            {
                var EmploymentDetails = _EmploymentDetailRepository.GetAllList(x => x.ApplicationId == ApplicationId).ToList();
                if (EmploymentDetails.Count > 0)
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
                throw new UserFriendlyException(L("GetMethodError{0}", "Employment Detail"));
            }
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

        #endregion
    }
}
