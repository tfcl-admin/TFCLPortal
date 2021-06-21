using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LoanTenureRequireds;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(LoanTenureRequired))]
    public class CreateLoanTenureRequiredDto
    {
        public string Name { get; set; }
    }
}
