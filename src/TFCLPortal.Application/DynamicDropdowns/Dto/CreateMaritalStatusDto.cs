using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.MaritalStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(MaritalStatus))]
    public class CreateMaritalStatusDto
    {
        public string Name { get; set; }
    }
}
