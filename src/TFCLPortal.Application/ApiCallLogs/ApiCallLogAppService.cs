using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlows;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.DescripentScreens;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;
using TFCLPortal.DynamicDropdowns.ProductTypes;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.Mobilizations;
using TFCLPortal.MobilizationsLogs;
using TFCLPortal.Mobilizations.Dto;
using TFCLPortal.MobilizationsLogs.Dto;
using TFCLPortal.TaleemSchoolAsasahs;
using TFCLPortal.TaleemSchoolAsasahs.Dto;
using TFCLPortal.TaleemSchoolSarmayas;
using TFCLPortal.TaleemSchoolSarmayas.Dto;
using TFCLPortal.Users;
using TFCLPortal.Users.Dto;
using TFCLPortal.ApiCallLogs.Dto;

namespace TFCLPortal.ApiCallLogs
{
    public class ApiCallLogAppService : TFCLPortalAppServiceBase, IApiCallLogAppService
    {
        private readonly IRepository<ApiCallLog, Int32> _ApiCallLogRepository;
       
        public ApiCallLogAppService(IRepository<ApiCallLog, Int32> ApiCallLogRepository)
        {
            _ApiCallLogRepository = ApiCallLogRepository;
        }

        public string CreateApplication(CreateApiCallLogDto input)
        {                      
            try
            {
                var logs = ObjectMapper.Map<ApiCallLog>(input);
                var callLogs = _ApiCallLogRepository.Insert(logs);
                return "success";
            }
            catch (Exception ex)
            {
                return "failure";
            }
        }

        public List<ApiCallLogListDto> GetAllList()
        {
            var CallList = _ApiCallLogRepository.GetAllList();
            return ObjectMapper.Map<List<ApiCallLogListDto>>(CallList);
        }
    }
}
