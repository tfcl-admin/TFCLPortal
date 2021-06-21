using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.CreditCommettees;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(CreditCommettee))]
    public class CreateCreditCommetteeDto
    {
        public string Name { get; set; }
    }
}
