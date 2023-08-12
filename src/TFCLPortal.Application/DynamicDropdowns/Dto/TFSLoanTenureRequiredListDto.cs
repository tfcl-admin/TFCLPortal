using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.TFSLoanTenureRequireds;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(TFSLoanTenureRequired))]
    public class TFSLoanTenureRequiredListDto : Entity
    {
        public string Name { get; set; }
    }
}
