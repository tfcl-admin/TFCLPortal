using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Occupations;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(Occupation))]
    public class CreateOccupationDto
    {
        public string Name { get; set; }
    }
}
