using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LoansPurpose;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(LoanPurpose))]
    public class LoanPurposeListDto : Entity
    {
        public string Name { get; set; }
    }
}
