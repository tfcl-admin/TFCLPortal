using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.ApplicantTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(ApplicantType))]
    public class ApplicantTypeListDto : Entity
    {
        public string Name { get; set; }
    }
}
