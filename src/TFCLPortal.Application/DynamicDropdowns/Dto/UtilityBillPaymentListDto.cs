using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.UtilityBillPayments;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(UtilityBillPayment))]
    public class UtilityBillPaymentListDto : Entity
    {
        public string Name { get; set; }
    }
}
