using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(LoanTenureRequired))]
    public class LoanTenureRequiredListDto : Entity
    {
        public string Name { get; set; }
    }
}
