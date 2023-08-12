using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.TFSLoanTenureRequireds;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(TFSLoanTenureRequired))]
    public class CreateTFSLoanTenureRequiredDto
    {
        public string Name { get; set; }
    }
}
