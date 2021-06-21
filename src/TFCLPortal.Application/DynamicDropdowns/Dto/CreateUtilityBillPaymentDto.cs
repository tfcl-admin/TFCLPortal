using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(UtilityBillPayment))]
    public class CreateUtilityBillPaymentDto
    {
        public string Name { get; set; }
    }
}
