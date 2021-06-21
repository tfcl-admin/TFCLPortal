using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.NatureOfPayments;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(NatureOfPayment))]
    public class CreateNatureOfPaymentDto
    {
        public string Name { get; set; }
    }
}
