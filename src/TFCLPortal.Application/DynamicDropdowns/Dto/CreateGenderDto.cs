using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Genders;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(Gender))]
    public class CreateGenderDto
    {
        public string Name { get; set; }
    }
}
