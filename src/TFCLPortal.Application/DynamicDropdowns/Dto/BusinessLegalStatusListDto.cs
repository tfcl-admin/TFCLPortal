using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.BusinessLegalStatuses;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(BusinessLegalStatus))]
    public class BusinessLegalStatusListDto : Entity
    {
        public string Name { get; set; }
    }
}
