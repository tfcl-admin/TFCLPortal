
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ApplicantTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(ApplicantType))]
    public class CreateApplicantTypeDto
    {
        public string Name { get; set; }
    }
}
