using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ReferenceChecks;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(ReferenceCheck))]
    public class CreateReferenceCheckDto
    {
        public string Name { get; set; }
    }
}
