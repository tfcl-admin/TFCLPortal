using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ScheduleInstallmentTemps;

namespace TFCLPortal.ScheduleTemps.Dto
{
    [AutoMapFrom(typeof(ScheduleInstallmentTemp))]
    public class ScheduleInstallmenttTempListDto : EntityDto
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
        public bool? isPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
