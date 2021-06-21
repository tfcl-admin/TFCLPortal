using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Provinces;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(Province))]
    public class CreateProvinceDto
    {
        public string Name { get; set; }
    }
}
