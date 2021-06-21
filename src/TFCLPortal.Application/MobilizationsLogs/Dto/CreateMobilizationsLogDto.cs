using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.MobilizationsLogs.Dto
{
    [AutoMapTo(typeof(MobilizationsLog))]
    public class CreateMobilizationsLogDto
    {
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string LandLineNo { get; set; }
        public string CNICNo { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public int MobilizationStatus { get; set; }
        public int MobilizationTableID { get; set; }
        public int ProductType { get; set; }
        public DateTime NextMeeting { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string BranchCode { get; set; }
        public long CreatorUserId { get; set; }
        public string Remarks { get; set; }
        public string AverageFee { get; set; }
        public string PrefixLable { get; set; }
        public string RespondantDesignation { get; set; }//New Field                                   

        //-----
        public string ApplicantSource { get; set; }
        public string PersonNotInterested { get; set; }
        public string PrefferedProduct { get; set; }
        public string PrefferedProvider { get; set; }
        public string MentionProviderInterest { get; set; }
        public string DecesionMonth { get; set; }
        public int NoOfStudent { get; set; }
        public int NoOfStaff { get; set; }
        public string BuildingStatus { get; set; }
        public int AreaOfSchoolMarla { get; set; }

        public string RespondantDesignationOthers { get; set; } //New
        public int InteractionNumber { get; set; }//New
        public string FranchiserName { get; set; }//New
        public bool isFranchise { get; set; }//New

        public string OtherSourceIncome { get; set; } // New Dropdown
        public string OtherSourceIncomeOthers { get; set; } // New
        public bool AnyOtherBusiness { get; set; } // New
        public bool isAvailedLoan { get; set; } // New
        public int SchoolCategory { get; set; } // New Dropdown
        public string Longitude { get; set; } // New
        public string Latitude { get; set; } // New
        public int AcademicSession { get; set; } // New Dropdown

        public int? TDSBusinessNature { get; set; }// New Dropdown
        public string otherApplicantSource { get; set; }//new
        public string otherNotbeingIntersted { get; set; }//new
        public string otherSchoolBuildingStatus { get; set; }//new

    }
}
