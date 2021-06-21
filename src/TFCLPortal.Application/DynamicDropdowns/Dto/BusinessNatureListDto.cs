using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessNatures;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(BusinessNature))]
    public class BusinessNatureListDto : Entity
    {
        public string Name { get; set; }

    }
}
