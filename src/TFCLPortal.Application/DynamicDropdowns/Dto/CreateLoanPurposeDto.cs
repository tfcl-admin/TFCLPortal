using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.LoansPurpose;

namespace TFCLPortal.DynamicDropdowns.Dto
{
   
    [AutoMapTo(typeof(LoanPurpose))]
    public class CreateLoanPurposeDto
    {

        public string Name { get; set; }
    }
}
