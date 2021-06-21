using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ExposureDetailChilds;

namespace TFCLPortal.Schedules.Dto
{
    [AutoMapTo(typeof(Schedule))]
    public class UpdateScheduleDto : CreateScheduleDto
    {
        public int Id { get; set; }
    }
}
