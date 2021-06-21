using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.CreditBureauChecks;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(CreditBureauCheck))]
    public class CreditBureauCheckListDto : Entity
    {
        public string Name { get; set; }
    }
}
