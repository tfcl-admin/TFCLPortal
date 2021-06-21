using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.MobilizationsLogs.Dto
{
    [AutoMapFrom(typeof(MobilizationsLog))]
    public class MobilizationsLogListDto
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
        public int MobilizationTableID { get; set; }

        public string ProductTypeName { get; set; }
        public string MobStatusName { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public string Remarks { get; set; }
        public string AverageFee { get; set; }
        public string PrefixLable { get; set; }
        public string RespondantDesignation { get; set; }

        public long CreatorUserId { get; set; }
        public string SDE_Name { get; set; }

        //-----
        public string ApplicantSource { get; set; }//Name Change
        public string PersonNotInterested { get; set; }
        public string PrefferedProduct { get; set; } //Name Change
        public string PrefferedProvider { get; set; } //New
        public string MentionProviderInterest { get; set; }
        public string DecesionMonth { get; set; }
        public int NoOfStudent { get; set; }
        public int NoOfStaff { get; set; }
        public string BuildingStatus { get; set; }
        public int AreaOfSchoolMarla { get; set; }
        public int ApplicationId { get; set; }

        public string RespondantDesignationOthers { get; set; } //New
        public int InteractionNumber { get; set; }//New
        public string FranchiserName { get; set; }//New
        public bool isFranchise { get; set; }//New

        public int OtherSourceIncome { get; set; } // New Dropdown
        public string OtherSourceIncomeOthers { get; set; } // New
        public bool AnyOtherBusiness { get; set; } // New
        public bool isAvailedLoan { get; set; } // New
        public int SchoolCategory { get; set; } // New Dropdown
        public string Longitude { get; set; } // New
        public string Latitude { get; set; } // New
        public int AcademicSession { get; set; } // New Dropdown

    }
}
