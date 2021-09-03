using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Schedules.Dto
{
    [AutoMapFrom(typeof(ScheduleInstallment))]
    public class ScheduleInstallmenttListDto : EntityDto
    {
        public int FK_ScheduleId { get; set; }
        public string InstNumber { get; set; }
        public string BalInst { get; set; }
        public string InstallmentDueDate { get; set; }
        public string OsPrincipal_op { get; set; }
        public string AdditionalTranche { get; set; }
        public string OsPrincipal_Opening { get; set; }
        public string markup { get; set; }
        public string principal { get; set; }
        public string installmentAmount { get; set; }
        public string OsPrincipal_Closing { get; set; }
        public string PaidAmount { get; set; }
        public string ExcessShort { get; set; }
        public bool? isPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string BusinessName { get; set; }
        public int Applicationid { get; set; }

        public string SdeName { get; set; }
        public string BranchName { get; set; }

        public string Outstanding { get; set; }
        public string LoanAmount { get; set; }


    }
}
