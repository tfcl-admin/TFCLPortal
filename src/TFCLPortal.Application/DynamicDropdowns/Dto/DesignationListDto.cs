using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Designations;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(Designation))]
    public class DesignationListDto : Entity
    {
        public string Name { get; set; }
    }
}
