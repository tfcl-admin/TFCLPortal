using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.BusinessTypes;
using TFCLPortal.TDSBusinessNatures;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(BusinessType))]
    public class BusinessTypeListDto : Entity
    {
        public string Name { get; set; }

    }
}
