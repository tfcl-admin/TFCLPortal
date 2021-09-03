using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ScheduleTemps.Dto
{
    [AutoMapFrom(typeof(ScheduleTemp))]
    public class ScheduleTempListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string ClientId { get; set; }
        public string ScheduleType { get; set; }
        public string LoanAmount { get; set; }
        public string Tenure { get; set; }
        public string Markup { get; set; }
        public string DisbursmentDate { get; set; }
        public string GraceDays { get; set; }
        public string Deferment { get; set; }
        public string AccountTitle { get; set; }
        public string RepaymentACnumber { get; set; }
        public string BankBranchName { get; set; }
        public string TFCL_Branch { get; set; }
        public string BranchManager { get; set; }
        public string SDE { get; set; }
        public string DeffermentStartDate { get; set; }
        public string DeffermentEndDate { get; set; }
        public string IRR { get; set; }
        public string Installment { get; set; }
        public string LoanStartDate { get; set; }
        public string LastInstallmentDate { get; set; }
        public string YearlyMarkup { get; set; }
        public string PerDayMarkup { get; set; }
        public string UpdationReason { get; set; }
        public bool? isAuthorizedByBM { get; set; }
        public string Reason { get; set; }

        public List<ScheduleInstallmenttTempListDto> installmentList { get; set; }


    }
}
