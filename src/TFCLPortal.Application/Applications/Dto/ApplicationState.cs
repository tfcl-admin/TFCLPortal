using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Applications.Dto
{
    public static class ApplicationState
    {
       
        public static string Verification = "In Verification";
        public static string VO_Verified = "VO Verified";
        public static string VO_Descripent = "VO Descripent";
        public static string VO_Decline = "VO Decline";
        public static string Screening = "Screening";
        public static string BM_Verified = "BM Verified";
        public static string BM_Descripent = "BM Descripent";
        public static string BM_Decline = "BM Decline";
        public static string BCC = "BCC";
        public static string BCC_Descripent = "BCC Descripent";
        public static string BCC_Decline = "BCC Decline";
        public static string Disbursed = "Disbursed";
        public static string Closed = "Closed";
        public static string ForceDecline = "Force Decline";
        public static string Discrepent = "Discrepent";

        //using Now
        public static string Created = "Created";
        public static string InProcess = "In Process";
        public static string Submitted = "Submitted";
        public static string Screened = "Screened";
        public static string Decline = "decline";
        public static string BCCReview = "BCC Review";
        public static string BCCReviewed = "BCC Reviewed";
        public static string MCRCReview = "MCRC Review";
        public static string MCRCCreated = "MCRC Created";
        public static string MCRCReviewed = "MCRC Reviewed";
        public static string BCC_Approved = "BCC Approved";
        public static string MC_Authorized = "MC Authorized";
        public static string EarlySettled = "Early Settled";
        public static string Settled = "Settled";
        public static string Deceased = "Deceased";
        public static string Enhanced = "Enhanced";


    }


    public static class WorkFlowState
    {
        public static string VO = "VO";
        public static string SDE = "SDE";
        public static string BM = "BM";
        public static string BCC = "BCC";
        public static string BA = "BA";
        public static string BA_DataCheck = "BA DATACHECK";

    }
}
