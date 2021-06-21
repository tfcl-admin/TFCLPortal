using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Applications.Dto
{
    public class ChangeApplicationState
    {
        public static string Created { get; set; }
        public static string InProcess { get; set; }
        public static string Submitted { get; set; }
        public static string Verification { get; set; }
        public static string VO_Verified { get; set; }
        public static string VO_Descripent { get; set; }
        public static string VO_Decline { get; set; }
        public static string Screening { get; set; }
        public static string BM_Verified { get; set; }
        public static string BM_Descripent { get; set; }
        public static string BM_Decline { get; set; }
        public static string BCC { get; set; }
        public static string BCC_Approved { get; set; }
        public static string BCC_Descripent { get; set; }
        public static string BCC_Decline { get; set; }
        public static string Disbursed { get; set; }
        public static string Closed { get; set; }
    }
}
