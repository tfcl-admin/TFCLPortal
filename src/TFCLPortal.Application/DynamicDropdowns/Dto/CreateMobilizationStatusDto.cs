using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.MobilizationStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(MobilizationStatus))]
    public class CreateMobilizationStatusDto
    {
        public string Name { get; set; }
    }
}
