using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Genders;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(Gender))]
    public class GenderListDto : Entity
    {
        public string Name { get; set; }
    }
}
