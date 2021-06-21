using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(PaymentFrequency))]
    public class CreatePaymentFrequencyDto
    {
        public string Name { get; set; }
    }
}
