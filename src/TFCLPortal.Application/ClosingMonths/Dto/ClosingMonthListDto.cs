using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ClosingMonths.Dto
{
    [AutoMapFrom(typeof(ClosingMonth))]
    public class ClosingMonthListDto : FullAuditedEntityDto
    {
        public DateTime closingDate { get; set; }
        public int Month { get; set; }
        public int BranchId { get; set; }
        public int Year { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string MonthName { get; set; }
    }
}
