using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Districts;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(District))]
    public class DistrictListDto : Entity
    {
        public string Name { get; set; }
        public int Fk_ProvinceId { get; set; }
    }
}
