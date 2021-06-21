using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.NatureOfEmployments;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(NatureOfEmployment))]
    public class CreateNatureOfEmploymentDto
    {
        public string Name { get; set; }
    }
}
