using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LoanNatures;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(LoanNature))]
    public class LoanNatureListDto : Entity
    {
        public string Name { get; set; }
    }
}
