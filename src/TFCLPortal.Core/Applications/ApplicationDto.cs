using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Applications
{
    public class ApplicationDto
    {
        public int AppNumber { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicationNumber { get; set; }
        public string ClientID { get; set; }
        public string BranchName { get; set; }
        public string SchoolName { get; set; }
        public string Product { get; set; }
        public string MobilizationStatus { get; set; }
        public string SDEName { get; set; }
        public string AppStatus { get; set; }
        public string CNICNo { get; set; }
        public int Id { get; set; }
        public int TAT { get; set; }
        public string ShortCode { get; set; }
        public string Comments { get; set; }
        public string LastScreen { get; set; }
        public string Transferred { get; set; }
        public int branchId { get; set; }
        public DateTime AppDate { get; set; }
        public bool isDeceased { get; set; }//New

        public int FundingSource { get; set; } // New Dropdown
        public string FundingSourceName { get; set; }
    }
}
