using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BranchManagerActions.Dto
{
    public class DiscrepentScreensListDto
    {
        public string ScreenName { get; set; }
        public string Reason { get; set; }
        public DateTime DateOfDiscrepency { get; set; }
    }
}
