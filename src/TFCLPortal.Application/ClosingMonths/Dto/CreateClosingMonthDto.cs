using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ClosingMonths.Dto
{
    [AutoMapTo(typeof(ClosingMonth))]
    public class CreateClosingMonthDto
    {
        public DateTime closingDate { get; set; }
        public int Month { get; set; }
        public int BranchId { get; set; }
        public int Year { get; set; }
    }
}
