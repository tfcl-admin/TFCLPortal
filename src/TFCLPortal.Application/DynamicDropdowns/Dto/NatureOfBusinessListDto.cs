using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.NatureOfBusinesses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(NatureOfBusiness))]
    public class NatureOfBusinessListDto
    {
        public string Name { get; set; }
    }
}
