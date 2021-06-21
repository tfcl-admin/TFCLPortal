using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.PaymentsFrequency;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(PaymentFrequency))]
    public class PaymentFrequencyListDto : Entity
    {
        public string Name { get; set; }
    }
}
