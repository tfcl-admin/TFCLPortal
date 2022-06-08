using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.LoanStatuses;

namespace TFCLPortal.AllScreensGetByAppID.Dto
{
    [AutoMapTo(typeof(LoanStatus))]
    public class LoanStatusDto  : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public int Tenure { get; set; }

        public int LastLateDays { get; set; }
        public DateTime LastInstallmentDueDate { get; set; }
        public string LastInstallmentNo { get; set; }
        public decimal LastInstallmentPrincipal { get; set; }
        public decimal LastInstallmentMarkup { get; set; }
        public decimal LastInstallmentAmount { get; set; }
        public DateTime LastPaidDate { get; set; }
        public decimal LastPaidAmount { get; set; }
        public decimal LastExcessShort { get; set; }
        public decimal LastOutstandingPrincipal { get; set; }


        public int CurrentLateDays { get; set; }
        public string CurrentInstallmentNo { get; set; }
        public DateTime CurrentInstallmentDueDate { get; set; }
        public decimal CurrentInstallmentPrincipal { get; set; }
        public decimal CurrentInstallmentMarkup { get; set; }
        public decimal CurrentInstallmentAmount { get; set; }
        public decimal CurrentPaidAmount { get; set; }
        public decimal CurrentExcessShort { get; set; }
        public decimal CurrentOutstandingPrincipal { get; set; }
    }
}
