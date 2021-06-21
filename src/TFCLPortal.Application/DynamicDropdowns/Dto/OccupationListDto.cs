using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Occupations;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(Occupation))]
    public class OccupationListDto : Entity
    {
        public string Name { get; set; }
    }
}
