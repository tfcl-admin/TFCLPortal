using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.LoanSchedules.Dto
{
    [AutoMapFrom(typeof(LoanSchedule))]
    public class LoanScheduleListDto : FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public string ScheduleNo { get; set; }
        public string RevisionNo { get; set; }
        public DateTime RevisionDate { get; set; }
        public string ScheduleType { get; set; }
        public DateTime DisbursmentDate { get; set; }
        public DateTime LoanStartDate { get; set; }
        public DateTime LastInstallmentDate { get; set; }
        public int GraceDays { get; set; }
        public decimal IRR { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal YearlyMarkup { get; set; }
        public decimal PerDayMarkup { get; set; }

    }
}
