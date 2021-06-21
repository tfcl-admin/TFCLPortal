using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Schedules.Dto
{
    [AutoMapTo(typeof(ScheduleInstallment))]
    public class UpdateScheduleInstallmentDto : CreateScheduleDto
    {
        public int Id { get; set; }
    }
}
