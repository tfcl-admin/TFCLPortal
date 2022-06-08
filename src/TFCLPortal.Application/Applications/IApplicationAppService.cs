using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications.Dto;
using TFCLPortal.ApplicationWorkFlows.WorkFlowApplicationStates.Dto;
using TFCLPortal.Mobilizations.Dto;

namespace TFCLPortal.Applications
{
    public interface IApplicationAppService : IApplicationService
    {
        ApplicationListDto GetApplicationById(int Id);
        Task<ApplicationResponse> CreateApplication(CreateApplicationDto input);
        Task<ApplicationResponse> MigrateEnhancementApplication(int OldApplicationId);
        Task<string> UpdateApplication(UpdateApplicationDto input);
        ApplicationListDto GetApplicationByApplicationId(int ApplicationId);
        List<ApplicationDto> GetApplicationList(string applicationState, int? branchId, bool showAll = false,bool IsAdmin=false, bool IsEnhanced = false);
        List<ApplicationListDto> GetAllApplicationsList();
        List<ApplicationListCrsDto> GetAllApplicationsListForCRS();
        List<ApplicationListCrsDto> GetAllApplicationsListforcrsTSSTSA();
        Task<DashboardDataDto> GetTFCLDashboardCountingData(int branchId);
        Task<List<HighChartWeeklyDto>> GetHighChartWeekData();
        Task<List<BranchPortfolioGraphDto>> GetBranchPortfolioGraphData();
        Task<List<MonthWiseGraphDto>> GetMonthlyGraphData();
        Task<ApplicationListDto> GetApplicationByIdAsync(int Id);
        Task<List<ProductwiseDto>> GetProductWiseAmount();
        string ChangeApplicationState(string state, int ApplicationId, string comments);
        string UpdateApplicationLastScreen(string LastScreen, int ApplicationId);
        Task<WorkFlowReturnDto> UserInRole(string name);
        List<Applicationz> GetShortApplicationList(string applicationState, int? branchId);
        Task ChangeWorkFlowState(CreateWorkFlowApplicationStateDto createWorkFlow);
        List<ApplicationListDto> GetDeclineApplicationbyUserId(int UserId);
        List<ApplicationListDto> GetDescripentApplicationbyUserId(int UserId);
        ApplicationListDto GetDescripentApplicationbyApplicationId(int ApplicationId);
        List<MobilizationSyncDto> GetMobilizationDataBySDEId(int SDEId);

        List<ApplicationListDto> GetStateWiseApplicationbyUserId(int UserId, string state);
        string setMobilizationRecordId(List<setMobilizationRecordIdDto> records);

        DateTime getLastWorkFlowStateDate(int ApplicationId, string State);
        List<Applicationz> GetBCCShortApplicationList(int userid);
        Task<CnicCheckResponse> CheckCNIC(string cnic);
        List<Applicationz> GetAllApplicationsByUserId(int userid);
        List<Applicationz> GetAllBCCReviewedApplicationsByUserId(int userid);
        Task<string> ChangeApplicationStateAsync(string state, int ApplicationId, string comments);
    }
}
