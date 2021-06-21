using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.BusinessLegalStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(BusinessLegalStatus))]
    public class CreateBusinessLegalStatusDto
    {
        public string Name { get; set; }
    }
}
