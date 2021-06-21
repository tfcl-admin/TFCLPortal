using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Districts;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(District))]
    public class CreateDistrictDto
    {
        public string Name { get; set; }
        public int Fk_ProvinceId { get; set; }
    }
}
