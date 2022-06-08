using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Applications;

namespace TFCLPortal.Applications.Dto
{
    [AutoMapTo(typeof(Applicationz))]
    public class CreateApplicationDto
    {
        public int ApplicationId { get; set; }
        public string ClientName { get; set; }
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
        public string BranchCode { get; set; }
        public long CreatorUserId { get; set; }
        public int FK_branchid { get; set; }

        // new field added to dto

        public string Remarks { get; set; }
        public string AverageFee { get; set; }
        public string PrefixLable { get; set; }
        public string RespondantDesignation { get; set; }//Name Change
        public string ApplicationSource { get; set; } //Name Change
        public string PersonNotInterested { get; set; }
        public string PrefferedProduct { get; set; }//Name Change
        public string MentionProviderInterest { get; set; } //NOT BEING INTERESTED
        public string MentionProviderInterestOthers { get; set; }
        public string DecesionMonth { get; set; }
        public int NoOfStudent { get; set; }
        public int NoOfStaff { get; set; }
        public string BuildingStatus { get; set; }
        public int AreaOfSchoolMarla { get; set; }
        public string MobilizationRecordId { get; set; }

        public string RespondantDesignationOthers { get; set; } //New
        public int InteractionNumber { get; set; }//New
        public int MobilizationTableID { get; set; }//new
        public string otherApplicantSource { get; set; }//new
        public string otherNotbeingIntersted { get; set; }//new
        public string otherSchoolBuildingStatus { get; set; }//new
      
        public string OtherSourceIncome { get; set; } // New Dropdown
        public string OtherSourceIncomeOthers { get; set; } // New
        public bool AnyOtherBusiness { get; set; } // New
        public bool isAvailedLoan { get; set; } // New
        

        public int? TDSBusinessNature { get; set; }// New Dropdown

        public int UpdateRecordId { get; set; } //New


        //in case of SDE tab Crash
        public int AcademicSession { get; set; } // New Dropdown2
        public string FranchiserName { get; set; }//New
        public bool isFranchise { get; set; }//New
        public string Longitude { get; set; } // New
        public string Latitude { get; set; } // New
        public int SchoolCategory { get; set; } // New Dropdown

        //Update In Mobilizations Due to TDS,TJS,TTS.
        public int ContactSource { get; set; }
        public int ApplicantType { get; set; }
        public string FiName { get; set; }
        public string Designation { get; set; }
        public string MonthlySalary { get; set; }
        public string JobTenure { get; set; }
        public int SchoolGoingDependants { get; set; }

    }

}
