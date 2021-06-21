using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.CreditCommettees;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(CreditCommettee))]
    public class CreditCommetteeListDto : Entity
    {
        public string Name { get; set; }
    }
}
