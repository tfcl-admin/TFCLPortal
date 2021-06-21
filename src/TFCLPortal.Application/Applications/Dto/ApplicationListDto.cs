using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Applications;
using TFCLPortal.Branches.Dto;
using TFCLPortal.BranchManagerActions.Dto;
using TFCLPortal.DescripentScreens.Dto;

namespace TFCLPortal.Applications.Dto
{
    [AutoMapFrom(typeof(Applicationz))]
    public class ApplicationListDto : FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public string ClientName { get; set; }
        public int ApplicantType { get; set; }
        public string MobileNo { get; set; }
        public string LandLineNo { get; set; }
        public string CNICNo { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public int MobilizationStatus { get; set; }
        public int ProductType { get; set; }
        public DateTime? NextMeeting { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string ProductTypeName { get; set; }
        public string MobilizationStatusName { get; set; }
        public long CreatorUserId { get; set; }
        public string ReportPdfUrl { get; set; }
        public string SDE_Name { get; set; }

        public int FK_branchid { get; set; }
        public BranchDetailList Brances { get; set; }

        public List<DiscrepentScreensListDto> DescripentScreens { get; set; }

        //added new field to dto

        public string Remarks { get; set; }
        public string AverageFee { get; set; }
        public string PrefixLable { get; set; }
        public string RespondantDesignation { get; set; }

        //------
        public string ApplicationType { get; set; }
        public string PersonNotInterested { get; set; }
        public string InterestOtherProvider { get; set; }
        public string MentionProviderInterest { get; set; }
        public string DecesionMonth { get; set; }
        public int NoOfStudent { get; set; }
        public int NoOfStaff { get; set; }
        public string BuildingStatus { get; set; }
        public int AreaOfSchoolMarla { get; set; }

        public int? ApplicationNumber { get; set; }
        public string ClientID { get; set; }
        public string LastScreen { get; set; }

        //in case of SDE tab Crash
        public int AcademicSession { get; set; } // New Dropdown2
        public string FranchiserName { get; set; }//New
        public bool isFranchise { get; set; }//New
        public string Longitude { get; set; } // New
        public string Latitude { get; set; } // New
        public int SchoolCategory { get; set; } // New Dropdown

    }
}
