using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.ExposureDetailChilds;
using TFCLPortal.ScheduleTemps;

namespace TFCLPortal.ScheduleTemps.Dto
{
    [AutoMapTo(typeof(ScheduleTemp))]
    public class UpdateScheduleTempDto : CreateScheduleTempDto
    {
        public int Id { get; set; }
    }
}
