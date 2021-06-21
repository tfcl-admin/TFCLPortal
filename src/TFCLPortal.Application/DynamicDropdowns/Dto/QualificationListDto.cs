using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.Qualifications;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(Qualification))]
    public class QualificationListDto:Entity
    {
        public string Name { get; set; }
    }
}
