using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ScheduleInstallmentTemps;

namespace TFCLPortal.ScheduleTemps.Dto
{
    [AutoMapTo(typeof(ScheduleInstallmentTemp))]
    public class UpdateScheduleInstallmentTempDto : CreateScheduleTempDto
    {
        public int Id { get; set; }
    }
}
