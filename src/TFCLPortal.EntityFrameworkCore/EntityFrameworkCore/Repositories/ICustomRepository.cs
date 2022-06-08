using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Mobilizations;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.EntityFrameworkCore.Repositories
{
    public interface ICustomRepository : IRepository<BccState, int>
    {
        Task<bool> GetBccApplicationApprovedStaus(int applicationId);
        Task<double> GetIRR(int nper, double pmt, double pv, double fv, bool type);
        List<ApplicationDto> GetAllApplicationList(string applicationState, int branchId, bool showAll = false, bool IsAdmin = false,bool IsEnhancement = false);
        Task<DashboardDataDto> GetTFCLDashboardCountingData(int branchId);
        Task<List<HighChartWeeklyDto>> GetHighChartWeeklyData();
        Task<List<BranchPortfolioGraphDto>> GetBranchPortfolioGraphData();
        Task<List<MonthWiseGraphDto>> GetMonthlyGraphData();
        Task<List<ProductwiseDto>> GetProductWiseAmount();
        List<GetMobilizationListDto> GetMobilizationsByMaxInteractionNumberBySdeId(int SdeId);
        List<GetMobilizationListDto> GetMobilizationsByMaxInteractionNumber();
    }
}
