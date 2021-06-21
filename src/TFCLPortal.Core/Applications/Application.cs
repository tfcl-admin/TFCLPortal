using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Branches;
using TFCLPortal.DescripentScreens;

namespace TFCLPortal.Applications
{
    [Table("Applicationz")]
    public class Applicationz : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string BranchCode { get; set; }
        public string ProductCode { get; set; }
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string LandLineNo { get; set; }
        public string CNICNo { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public int MobilizationStatus { get; set; }
        public int ProductType { get; set; }
        public int ApplicantType { get; set; }
        public DateTime? NextMeeting { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        public int? FK_branchid { get; set; }

        [ForeignKey("FK_branchid")]
        public Branch Brances { get; set; }

        public List<DescripentScreen> DescripentScreens { get; set; }

        //new field added to dto

        public string Remarks { get; set; }
        public string AverageFee { get; set; }
        public string PrefixLable { get; set; }
        public string RespondantDesignation { get; set; }
        public string ApplicantSource { get; set; }
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
