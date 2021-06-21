using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LoanPurposeClassifications;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(LoanPurposeClassification))]
    public class LoanPurposeClassificationListDto : Entity
    {
        public string Name { get; set; }
    }
}
