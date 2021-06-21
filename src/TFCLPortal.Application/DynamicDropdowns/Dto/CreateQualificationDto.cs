using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Qualifications;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(Qualification))]
   public class CreateQualificationDto
    {

        public string Name { get; set; }
    }
}
