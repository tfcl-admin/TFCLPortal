using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.NatureOfPayments;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(NatureOfPayment))]
    public class NatureOfPaymentListDto : Entity
    {
        public string Name { get; set; }

    }
}
