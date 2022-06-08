using Abp.Data;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Mobilizations;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.EntityFrameworkCore.Repositories
{
    public class CustomRepository : TFCLPortalRepositoryBase<BccState, int>, ICustomRepository
    {


        private readonly IActiveTransactionProvider _transactionProvider;

        public CustomRepository(IDbContextProvider<TFCLPortalDbContext> dbContextProvider,
                              IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }


        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }


        private async Task EnsureConnectionOpenAsync()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
            {
                {"ContextType", typeof(TFCLPortalDbContext) },
                {"MultiTenancySide", MultiTenancySide }
            });
        }

        public List<GetMobilizationListDto> GetMobilizationsByMaxInteractionNumber()
        {
            try
            {
                List<GetMobilizationListDto> obj = new List<GetMobilizationListDto>();
                EnsureConnectionOpen();



                using (var command = CreateCommand("SP_GetMobilizationsListByMaxIntNo", CommandType.StoredProcedure))
                {

                    using (var dataReader = command.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            GetMobilizationListDto mbo = new GetMobilizationListDto();

                            mbo.Id = Convert.ToInt32(dataReader["Id"]);
                            mbo.ClientName = Convert.ToString(dataReader["ClientName"]);
                            mbo.MobileNo = Convert.ToString(dataReader["MobileNo"]);
                            mbo.LandLineNo = Convert.ToString(dataReader["LandLineNo"]);
                            mbo.CNICNo = Convert.ToString(dataReader["CNICNo"]);
                            mbo.Address = Convert.ToString(dataReader["Address"]);
                            mbo.SchoolName = Convert.ToString(dataReader["SchoolName"]);
                            mbo.MobilizationStatus = Convert.ToInt32(dataReader["MobilizationStatus"]);
                            mbo.ProductType = Convert.ToInt32(dataReader["ProductType"]);
                            if (dataReader["NextMeeting"] != System.DBNull.Value)
                            {
                                mbo.NextMeeting = Convert.ToDateTime(dataReader["NextMeeting"]);
                                mbo.NextMeetingstr = (Convert.ToDateTime(dataReader["NextMeeting"])).ToString("dd MMM yyyy");
                            }
                            else
                            {
                                //mbo.NextMeeting = null;
                                mbo.NextMeetingstr = null;

                            }
                            mbo.ScreenStatus = Convert.ToString(dataReader["ScreenStatus"]);
                            mbo.Comments = Convert.ToString(dataReader["Comments"]);
                            mbo.Latitude = Convert.ToString(dataReader["Latitude"]);
                            mbo.Longitude = Convert.ToString(dataReader["Longitude"]);

                            mbo.ProductTypeName = Convert.ToString(dataReader["ProductTypeName"]);
                            //mbo.ProductTypeName = Convert.ToString(dataReader["ProductTypeName"]);
                            mbo.MobStatusName = Convert.ToString(dataReader["MobStatusName"]);
                            mbo.CreationTime = Convert.ToDateTime(dataReader["CreationTime"]);

                            mbo.Remarks = Convert.ToString(dataReader["Remarks"]);
                            mbo.AverageFee = Convert.ToString(dataReader["AverageFee"]);
                            mbo.PrefixLable = Convert.ToString(dataReader["PrefixLable"]);
                            mbo.RespondantDesignation = Convert.ToString(dataReader["RespondantDesignation"]);
                            mbo.OtherSourceIncome = Convert.ToString(dataReader["OtherSourceIncome"]);
                            mbo.OtherSourceIncomeOthers = Convert.ToString(dataReader["OtherSourceIncomeOthers"]);

                            mbo.CreatorUserId = Convert.ToInt32(dataReader["CreatorUserId"]);
                            mbo.SDE_Name = Convert.ToString(dataReader["SDE_Name"]);

                            mbo.ApplicantSource = Convert.ToString(dataReader["ApplicantSource"]);
                            mbo.otherApplicantSource = Convert.ToString(dataReader["otherApplicantSource"]);
                            mbo.PersonNotInterested = Convert.ToString(dataReader["PersonNotInterested"]);
                            mbo.InteractionNumber = Convert.ToInt32(dataReader["InteractionNumber"]);
                            mbo.MentionProviderInterest = Convert.ToString(dataReader["MentionProviderInterest"]);
                            mbo.DecesionMonth = Convert.ToString(dataReader["DecesionMonth"]);
                            mbo.NoOfStudent = Convert.ToInt32(dataReader["NoOfStudent"]);
                            mbo.NoOfStaff = Convert.ToInt32(dataReader["NoOfStaff"]);
                            mbo.BuildingStatus = Convert.ToString(dataReader["BuildingStatus"]);
                            mbo.Fk_BranchId = Convert.ToInt32(dataReader["Fk_BranchID"]);
                            //mbo.SchoolCategory = Convert.ToString(dataReader["SchoolCategory"]);
                            //mbo.AcademicSession = Convert.ToString(dataReader["AcademicSession"]);
                            mbo.AreaOfSchoolMarla = Convert.ToInt32(dataReader["AreaOfSchoolMarla"]);
                            //mbo.TDSBusinessNatureName = Convert.ToString(dataReader["TDSBusinessNature"]);

                            mbo.SchoolCategory = Convert.ToInt32(dataReader["SchoolCategory"]);
                            mbo.SchoolCategoryName = Convert.ToString(dataReader["SchoolCategoryName"]);
                            mbo.AcademicSession = Convert.ToInt32(dataReader["AcademicSession"]);
                            mbo.AcademicSessionName = Convert.ToString(dataReader["AcademicSessionName"]);
                            mbo.TDSBusinessNature = Convert.ToInt32(dataReader["TDSBusinessNature"]);
                            mbo.TDSBusinessNatureName = Convert.ToString(dataReader["TDSBusinessNatureName"]);
                            mbo.ContactSourceName = Convert.ToString(dataReader["ContactSourceName"]);

                            obj.Add(mbo);
                        }

                        return obj;
                    }
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public List<GetMobilizationListDto> GetMobilizationsByMaxInteractionNumberBySdeId(int SdeId)
        {
            try
            {
                List<GetMobilizationListDto> obj = new List<GetMobilizationListDto>();
                EnsureConnectionOpen();

                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter();
                parameter[0].SqlDbType = SqlDbType.Int;
                parameter[0].ParameterName = "@userid";
                parameter[0].Value = SdeId;

                using (var command = CreateCommand("SP_GetMobilizationsListByMaxIntNoByUserId", CommandType.StoredProcedure, parameter))
                {
                    using (var dataReader = command.ExecuteReader())
                    {

                        while (dataReader.Read())
                        {
                            GetMobilizationListDto mbo = new GetMobilizationListDto();

                            mbo.Id = dataReader["Id"] == DBNull.Value || dataReader["Id"] == "" ? 0 : Convert.ToInt32(dataReader["Id"]);
                            mbo.ClientName = dataReader["ClientName"] == DBNull.Value || dataReader["ClientName"] == "" ? "" : Convert.ToString(dataReader["ClientName"]);
                            mbo.MobileNo = dataReader["MobileNo"] == DBNull.Value || dataReader["MobileNo"] == "" ? "" : Convert.ToString(dataReader["MobileNo"]);
                            mbo.LandLineNo = dataReader["LandLineNo"] == DBNull.Value || dataReader["LandLineNo"] == "" ? "" : Convert.ToString(dataReader["LandLineNo"]);
                            mbo.CNICNo = dataReader["CNICNo"] == DBNull.Value || dataReader["CNICNo"] == "" ? "" : Convert.ToString(dataReader["CNICNo"]);
                            mbo.Address = dataReader["Address"] == DBNull.Value || dataReader["Address"] == "" ? "" : Convert.ToString(dataReader["Address"]);
                            mbo.SchoolName = dataReader["SchoolName"] == DBNull.Value || dataReader["SchoolName"] == "" ? "" : Convert.ToString(dataReader["SchoolName"]);
                            mbo.MobilizationStatus = dataReader["MobilizationStatus"] == DBNull.Value || dataReader["MobilizationStatus"] == "" ? 0 : Convert.ToInt32(dataReader["MobilizationStatus"]);
                            mbo.ProductType = dataReader["ProductType"] == DBNull.Value || dataReader["ProductType"] == "" ? 0 : Convert.ToInt32(dataReader["ProductType"]);
                            if (dataReader["NextMeeting"] != DBNull.Value)
                            {
                                mbo.NextMeeting = Convert.ToDateTime(dataReader["NextMeeting"]);
                                mbo.NextMeetingstr = dataReader["NextMeeting"] == DBNull.Value || dataReader["NextMeeting"] == "" ? "" : (Convert.ToDateTime(dataReader["NextMeeting"])).ToString("dd MMM yyyy");
                            }
                            mbo.ScreenStatus = dataReader["ScreenStatus"] == DBNull.Value || dataReader["ScreenStatus"] == "" ? "" : Convert.ToString(dataReader["ScreenStatus"]);
                            mbo.Comments = dataReader["Comments"] == DBNull.Value || dataReader["Comments"] == "" ? "" : Convert.ToString(dataReader["Comments"]);
                            mbo.Latitude = dataReader["Latitude"] == DBNull.Value || dataReader["Latitude"] == "" ? "" : Convert.ToString(dataReader["Latitude"]);
                            mbo.Longitude = dataReader["Longitude"] == DBNull.Value || dataReader["Longitude"] == "" ? "" : Convert.ToString(dataReader["Longitude"]);

                            mbo.ProductTypeName = dataReader["ProductTypeName"] == DBNull.Value || dataReader["ProductTypeName"] == "" ? "" : Convert.ToString(dataReader["ProductTypeName"]);
                            mbo.MobStatusName = dataReader["MobStatusName"] == DBNull.Value || dataReader["MobStatusName"] == "" ? "" : Convert.ToString(dataReader["MobStatusName"]);
                            mbo.CreationTime = Convert.ToDateTime(dataReader["CreationTime"]);

                            mbo.Remarks = dataReader["Remarks"] == DBNull.Value || dataReader["Remarks"] == "" ? "" : Convert.ToString(dataReader["Remarks"]);
                            mbo.AverageFee = dataReader["AverageFee"] == DBNull.Value || dataReader["AverageFee"] == "" ? "" : Convert.ToString(dataReader["AverageFee"]);
                            mbo.PrefixLable = dataReader["PrefixLable"] == DBNull.Value || dataReader["PrefixLable"] == "" ? "" : Convert.ToString(dataReader["PrefixLable"]);
                            mbo.RespondantDesignation = dataReader["RespondantDesignation"] == DBNull.Value || dataReader["RespondantDesignation"] == "" ? "" : Convert.ToString(dataReader["RespondantDesignation"]);
                            mbo.OtherSourceIncome = dataReader["OtherSourceIncome"] == DBNull.Value || dataReader["OtherSourceIncome"] == "" ? "" : Convert.ToString(dataReader["OtherSourceIncome"]);
                            mbo.OtherSourceIncomeOthers = dataReader["OtherSourceIncomeOthers"] == DBNull.Value || dataReader["OtherSourceIncomeOthers"] == "" ? "" : Convert.ToString(dataReader["OtherSourceIncomeOthers"]);

                            mbo.CreatorUserId = dataReader["CreatorUserId"] == DBNull.Value || dataReader["CreatorUserId"] == "" ? 0 : Convert.ToInt32(dataReader["CreatorUserId"]);
                            mbo.SDE_Name = dataReader["SDE_Name"] == DBNull.Value || dataReader["SDE_Name"] == "" ? "" : Convert.ToString(dataReader["SDE_Name"]);

                            mbo.ApplicantSource = dataReader["ApplicantSource"] == DBNull.Value || dataReader["ApplicantSource"] == "" ? "" : Convert.ToString(dataReader["ApplicantSource"]);
                            mbo.otherApplicantSource = dataReader["otherApplicantSource"] == DBNull.Value || dataReader["otherApplicantSource"] == "" ? "" : Convert.ToString(dataReader["otherApplicantSource"]);
                            mbo.PersonNotInterested = dataReader["PersonNotInterested"] == DBNull.Value || dataReader["PersonNotInterested"] == "" ? "" : Convert.ToString(dataReader["PersonNotInterested"]);
                            mbo.InteractionNumber = dataReader["InteractionNumber"] == DBNull.Value || dataReader["InteractionNumber"] == "" ? 0 : Convert.ToInt32(dataReader["InteractionNumber"]);
                            mbo.MentionProviderInterest = dataReader["MentionProviderInterest"] == DBNull.Value || dataReader["MentionProviderInterest"] == "" ? "" : Convert.ToString(dataReader["MentionProviderInterest"]);
                            mbo.DecesionMonth = dataReader["DecesionMonth"] == DBNull.Value || dataReader["DecesionMonth"] == "" ? "" : Convert.ToString(dataReader["DecesionMonth"]);
                            mbo.NoOfStudent = dataReader["NoOfStudent"] == DBNull.Value || dataReader["NoOfStudent"] == "" ? 0 : Convert.ToInt32(dataReader["NoOfStudent"]);
                            mbo.NoOfStaff = dataReader["NoOfStaff"] == DBNull.Value || dataReader["NoOfStaff"] == "" ? 0 : Convert.ToInt32(dataReader["NoOfStaff"]);
                            mbo.BuildingStatus = dataReader["BuildingStatus"] == DBNull.Value || dataReader["BuildingStatus"] == "" ? "" : Convert.ToString(dataReader["BuildingStatus"]);

                            mbo.SchoolCategory = dataReader["SchoolCategory"] == DBNull.Value || dataReader["SchoolCategory"] == "" ? 0 : Convert.ToInt32(dataReader["SchoolCategory"]);
                            mbo.SchoolCategoryName = dataReader["SchoolCategoryName"] == DBNull.Value || dataReader["SchoolCategoryName"] == "" ? "" : Convert.ToString(dataReader["SchoolCategoryName"]);
                            mbo.AcademicSession = dataReader["AcademicSession"] == DBNull.Value || dataReader["AcademicSession"] == "" ? 0 : Convert.ToInt32(dataReader["AcademicSession"]);
                            mbo.AcademicSessionName = dataReader["AcademicSessionName"] == DBNull.Value || dataReader["AcademicSessionName"] == "" ? "" : Convert.ToString(dataReader["AcademicSessionName"]);
                            mbo.TDSBusinessNature = dataReader["TDSBusinessNature"] == DBNull.Value || dataReader["TDSBusinessNature"] == "" ? 0 : Convert.ToInt32(dataReader["TDSBusinessNature"]);
                            mbo.TDSBusinessNatureName = dataReader["TDSBusinessNatureName"] == DBNull.Value || dataReader["TDSBusinessNatureName"] == "" ? "" : Convert.ToString(dataReader["TDSBusinessNatureName"]);
                            mbo.MobilizationRecordId = dataReader["mobilizationrecordid"] == DBNull.Value || dataReader["mobilizationrecordid"] == "" ? "" : Convert.ToString(dataReader["mobilizationrecordid"]);

                            mbo.AreaOfSchoolMarla = dataReader["AreaOfSchoolMarla"] == DBNull.Value || dataReader["AreaOfSchoolMarla"] == "" ? 0 : Convert.ToInt32(dataReader["AreaOfSchoolMarla"]);

                            obj.Add(mbo);
                        }

                        return obj;
                    }
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public async Task<bool> GetBccApplicationApprovedStaus(int applicationId)
        {
            EnsureConnectionOpen();
            bool IsApproved = false;
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter();
            parameter[0].SqlDbType = SqlDbType.Int;
            parameter[0].ParameterName = "@ApplicationId";
            parameter[0].Value = applicationId;

            using (var command = CreateCommand("SP_GetBCCApplicationApprovedStatus", CommandType.StoredProcedure, parameter))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {


                    while (dataReader.Read())
                    {
                        IsApproved = Convert.ToBoolean(dataReader["IsApproved"]);
                    }

                    return IsApproved;
                }
            }
        }

        public List<ApplicationDto> GetAllApplicationList(string applicationState, int branchId, bool showAll = false, bool IsAdmin = false, bool IsEnhancement = false)
        {
            List<ApplicationDto> AppList = new List<ApplicationDto>();
            EnsureConnectionOpen();
            // bool IsApproved = false;
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter();
            parameter[0].SqlDbType = SqlDbType.VarChar;
            parameter[0].ParameterName = "@ApplicationState";
            parameter[0].Value = applicationState;

            parameter[1] = new SqlParameter();
            parameter[1].SqlDbType = SqlDbType.Bit;
            parameter[1].ParameterName = "@showAll";
            parameter[1].Value = showAll;

            parameter[2] = new SqlParameter();
            parameter[2].SqlDbType = SqlDbType.Int;
            parameter[2].ParameterName = "@BranchId";
            parameter[2].Value = branchId;

            parameter[3] = new SqlParameter();
            parameter[3].SqlDbType = SqlDbType.Bit;
            parameter[3].ParameterName = "@IsAdmin";
            parameter[3].Value = IsAdmin;

            parameter[4] = new SqlParameter();
            parameter[4].SqlDbType = SqlDbType.Bit;
            parameter[4].ParameterName = "@IsEnhancement";
            parameter[4].Value = IsEnhancement;

            using (var command = CreateCommand("SP_GetAllApplications", CommandType.StoredProcedure, parameter))
            {
                using (var dataReader = command.ExecuteReader())
                {
                    try
                    {
                        while (dataReader.Read())
                        {
                            ApplicationDto obj = new ApplicationDto();
                            obj.ApplicantName = dataReader["ClientName"].ToString();
                            obj.AppStatus = dataReader["AppStatus"].ToString();
                            obj.MobilizationStatus = dataReader["MobilizationStatus"].ToString();
                            obj.SchoolName = dataReader["SchoolName"].ToString();
                            obj.SDEName = dataReader["SDEName"].ToString();
                            obj.AppNumber = Convert.ToInt32(dataReader["ApplicationId"]);
                            obj.Product = dataReader["Product"].ToString();
                            obj.BranchName = Convert.ToString(dataReader["BranchName"]);
                            obj.CNICNo = Convert.ToString(dataReader["CNICNo"]);
                            obj.ApplicationNumber = Convert.ToString(dataReader["ApplicationNumber"]);
                            obj.ClientID = Convert.ToString(dataReader["ClientID"]);
                            obj.ShortCode = Convert.ToString(dataReader["ShortCode"]);
                            obj.AppDate = Convert.ToDateTime(dataReader["CreationTime"]);
                            obj.Id = Convert.ToInt32(dataReader["AppzId"]);
                            obj.TAT = Convert.ToInt32(dataReader["TAT"]);
                            obj.branchId = Convert.ToInt32(dataReader["branchId"]);
                            obj.FundingSource = Convert.ToInt32(dataReader["FundingSource"]);
                            obj.FundingSourceName = dataReader["FundingSourceName"].ToString();
                            obj.Comments = dataReader["Comments"].ToString();
                            obj.LastScreen = Convert.ToString(dataReader["LastScreen"]);
                            obj.Transferred = Convert.ToString(dataReader["transferred"]);
                            AppList.Add(obj);

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    return AppList;
                }
            }
        }



        public async Task<DashboardDataDto> GetTFCLDashboardCountingData(int branchId)
        {
            DashboardDataDto dashboard = new DashboardDataDto();
            EnsureConnectionOpen();
            // bool IsApproved = false;
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter();
            parameter[0].SqlDbType = SqlDbType.Int;
            parameter[0].ParameterName = "@BranchId";
            parameter[0].Value = branchId;


            using (var command = CreateCommand("SP_GetTFCLDashboardCountingData", CommandType.StoredProcedure, parameter))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {

                    while (dataReader.Read())
                    {

                        dashboard.MobilizationCount = Convert.ToInt32(dataReader["MobilizationCount"]);
                        dashboard.InprocessfileCount = Convert.ToInt32(dataReader["InprocessfileCount"]);
                        dashboard.SubmittedfileCount = Convert.ToInt32(dataReader["SubmittedfileCount"]);
                        dashboard.BCCapprovedfileCoun = Convert.ToInt32(dataReader["BCCapprovedfileCount"]);
                        dashboard.DisbursedfileCount = Convert.ToInt32(dataReader["DisbursedfileCount"]);
                        dashboard.DeclinefileCount = Convert.ToInt32(dataReader["DeclinefileCount"]);
                        dashboard.LendingAmountCount = Convert.ToDecimal(dataReader["LendingAmountCount"]);

                        dashboard.CreatedfileCount = Convert.ToInt32(dataReader["CreatedfileCount"]);
                        dashboard.ScreenedfileCount = Convert.ToInt32(dataReader["ScreenedfileCount"]);
                        dashboard.DiscrepentedfileCount = Convert.ToInt32(dataReader["DiscrepentedfileCount"]);
                        dashboard.UnderBccReviewfileCount = Convert.ToInt32(dataReader["UnderBccReviewfileCount"]);
                        dashboard.BccReviewedfileCount = Convert.ToInt32(dataReader["BccReviewedfileCount"]);
                        dashboard.UnderMcrcReviewfileCount = Convert.ToInt32(dataReader["UnderMcrcReviewfileCount"]);
                        dashboard.McrcReviewedfileCount = Convert.ToInt32(dataReader["McrcReviewedfileCount"]);
                        dashboard.TotalfileCount = Convert.ToInt32(dataReader["TotalfileCount"]);
                        dashboard.UnderMCRCreviewCount = Convert.ToInt32(dataReader["McrcReviewfileCount"]);
                        dashboard.ManagementApprovedCount = Convert.ToInt32(dataReader["ManagementApprovedCount"]);
                        
                        dashboard.SettledfileCount = Convert.ToInt32(dataReader["SettledfileCount"]);
                        dashboard.SettledfileAmount = Convert.ToInt32(dataReader["SettledfileAmount"]);
                        dashboard.EarlySettledfileCount = Convert.ToInt32(dataReader["EarlySettledfileCount"]);
                        dashboard.EarlySettledfileAmount = Convert.ToInt32(dataReader["EarlySettledfileAmount"]);

                        dashboard.DeceasedfileAmount = Convert.ToInt32(dataReader["DeceasedfileAmount"]);
                        dashboard.DeceasedfileCount = Convert.ToInt32(dataReader["DeceasedfileCount"]);
                        dashboard.EnhancementfileCount = Convert.ToInt32(dataReader["EnhancementfileCount"]);
                        dashboard.EnhancedfileCount = Convert.ToInt32(dataReader["EnhancedfileCount"]);



                    }

                    return dashboard;
                }
            }
        }


        public async Task<List<HighChartWeeklyDto>> GetHighChartWeeklyData()
        {
            try
            {
                List<HighChartWeeklyDto> obj = new List<HighChartWeeklyDto>();
                EnsureConnectionOpen();

                using (var command = CreateCommand("SP_GetWeeklyGraphData", CommandType.StoredProcedure))
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {

                        while (dataReader.Read())
                        {
                            HighChartWeeklyDto dashboard = new HighChartWeeklyDto();
                            dashboard.TotalRecord = Convert.ToInt32(dataReader["TotalRecord"]);
                            dashboard.WeekNumber = Convert.ToInt32(dataReader["WeekNumber"]);
                            dashboard.BranchName = Convert.ToString(dataReader["BranchName"]);
                            obj.Add(dashboard);
                        }

                        return obj;
                    }
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public async Task<List<MonthWiseGraphDto>> GetMonthlyGraphData()
        {
            try
            {
                List<MonthWiseGraphDto> obj = new List<MonthWiseGraphDto>();
                EnsureConnectionOpen();

                using (var command = CreateCommand("SP_GetMonthlyGraphData", CommandType.StoredProcedure))
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {

                        while (dataReader.Read())
                        {
                            MonthWiseGraphDto dashboard = new MonthWiseGraphDto();
                            dashboard.Record = Convert.ToInt32(dataReader["Records"]);
                            dashboard.Months = Convert.ToString(dataReader["Months"]);
                            dashboard.BranchName = Convert.ToString(dataReader["BranchName"]);
                            obj.Add(dashboard);
                        }

                        return obj;
                    }
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }



        public async Task<List<ProductwiseDto>> GetProductWiseAmount()
        {
            try
            {
                List<ProductwiseDto> obj = new List<ProductwiseDto>();
                EnsureConnectionOpen();

                using (var command = CreateCommand("SP_GetProductWiseAmount", CommandType.StoredProcedure))
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {

                        while (dataReader.Read())
                        {
                            ProductwiseDto dashboard = new ProductwiseDto();
                            dashboard.Name = Convert.ToString(dataReader["Name"]);
                            dashboard.Id = Convert.ToInt32(dataReader["Id"]);
                            dashboard.LoanAmount = Convert.ToString(dataReader["LoanAmount"]);
                            obj.Add(dashboard);
                        }

                        return obj;
                    }
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public async Task<List<BranchPortfolioGraphDto>> GetBranchPortfolioGraphData()
        {
            try
            {
                List<BranchPortfolioGraphDto> obj = new List<BranchPortfolioGraphDto>();
                EnsureConnectionOpen();
                // bool IsApproved = false;
                // SqlParameter[] parameter = new SqlParameter[0];

                using (var command = CreateCommand("SP_GetBranchPortfolioGraphData", CommandType.StoredProcedure))
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {

                        while (dataReader.Read())
                        {
                            BranchPortfolioGraphDto dashboard = new BranchPortfolioGraphDto();
                            dashboard.TotalRecord = Convert.ToInt32(dataReader["TotalRecord"]);
                            dashboard.BranchName = Convert.ToString(dataReader["BranchName"]);
                            obj.Add(dashboard);
                        }

                        return obj;
                    }
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }


        public async Task<double> GetIRR(int nper, double pmt, double pv, double fv, bool type)
        {

            double IrrValue = 0.0;
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter();
            parameter[0].SqlDbType = SqlDbType.Int;
            parameter[0].ParameterName = "@nper";
            parameter[0].Value = nper;
            //
            parameter[1] = new SqlParameter();
            parameter[1].SqlDbType = SqlDbType.Float;
            parameter[1].ParameterName = "@pmt";
            parameter[1].Value = -pmt;
            //
            parameter[2] = new SqlParameter();
            parameter[2].SqlDbType = SqlDbType.Float;
            parameter[2].ParameterName = "@pv";
            parameter[2].Value = pv;
            //
            parameter[3] = new SqlParameter();
            parameter[3].SqlDbType = SqlDbType.Float;
            parameter[3].ParameterName = "@fv";
            parameter[3].Value = fv;
            //
            parameter[4] = new SqlParameter();
            parameter[4].SqlDbType = SqlDbType.Bit;
            parameter[4].ParameterName = "@type";
            parameter[4].Value = type;


            await EnsureConnectionOpenAsync();
            using (var command = CreateCommand("SELECT dbo.uf_Financial_RATE( @nper, @pmt, @pv, @fv, @type)", CommandType.Text, parameter))
            {
                var Irr = (await command.ExecuteScalarAsync()).ToString();
                IrrValue = Convert.ToDouble(Irr);
                return IrrValue;
            }
        }


    }
}
