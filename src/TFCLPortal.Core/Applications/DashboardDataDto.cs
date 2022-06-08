using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Applications
{
    public class DashboardDataDto
    {
        public int MobilizationCount { get; set; }
        public int InprocessfileCount { get; set; }
        public int SubmittedfileCount { get; set; }
        public int DeclinefileCount { get; set; }
        public decimal LendingAmountCount { get; set; }
        public int DisbursedfileCount { get; set; }
        public int BCCapprovedfileCoun { get; set; }
        
        public int ManagementApprovedCount { get; set; }
        public int UnderMCRCreviewCount { get; set; }



        public int CreatedfileCount { get; set; }
        public int ScreenedfileCount { get; set; }
        public int DiscrepentedfileCount { get; set; }
        public int UnderBccReviewfileCount { get; set; }
        public int BccReviewedfileCount { get; set; }
        public int UnderMcrcReviewfileCount { get; set; }
        public int McrcReviewedfileCount { get; set; }
        public int TotalfileCount { get; set; }

        public int TodayApplications { get; set; }
        public int TodayMobilizations { get; set; }
        public int TodayMeetingWithClients { get; set; }

        public int SettledfileCount { get; set; }
        public int SettledfileAmount { get; set; }
        public int EarlySettledfileCount { get; set; }
        public int EarlySettledfileAmount { get; set; }
        public int DeceasedfileCount { get; set; }
        public int DeceasedfileAmount { get; set; }
        public int EnhancementfileCount { get; set; }
        public int EnhancedfileCount { get; set; }


    }


    public class HighChartWeeklyDto
    {
        public int TotalRecord { get; set; }
        public int WeekNumber { get; set; }
        public string BranchName { get; set; }
        
    }

    public class BranchPortfolioGraphDto
    {
        public int TotalRecord { get; set; }
        public string BranchName { get; set; }

    }

    public class MonthWiseGraphDto
    {
        public int Record { get; set; }
        public string BranchName { get; set; }
        public string Months { get; set; }

    }

    public class ProductwiseDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string LoanAmount { get; set; }

    }

    public class MobilizationListDto
    {
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string LandLineNo { get; set; }
        public string CNICNo { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public int MobilizationStatus { get; set; }
        public int ProductType { get; set; }
        public DateTime NextMeeting { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        public string ProductTypeName { get; set; }
        public string MobStatusName { get; set; }
        public DateTime CreationTime { get; set; }

        public string Remarks { get; set; }
        public string AverageFee { get; set; }
        public string PrefixLable { get; set; }
        public string RespondantDesignation { get; set; }

        public long CreatorUserId { get; set; }
        public string SDE_Name { get; set; }

        //-----
        public string ApplicantSource { get; set; }
        public string PersonNotInterested { get; set; }
        public string InterestOtherProvider { get; set; }
        public string MentionProviderInterest { get; set; }
        public string DecesionMonth { get; set; }
        public int NoOfStudent { get; set; }
        public int NoOfStaff { get; set; }
        public string BuildingStatus { get; set; }
        public int AreaOfSchoolMarla { get; set; }
    }
}
