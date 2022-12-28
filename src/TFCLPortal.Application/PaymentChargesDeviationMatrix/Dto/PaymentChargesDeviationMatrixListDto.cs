using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.PaymentChargesDeviationMatrix.Dto
{
    [AutoMapFrom(typeof(PaymentChargesDeviationMatric))]
    public class PaymentChargesDeviationMatrixListDto
    {
        public string Type { get; set; }
        public decimal MaxAmount { get; set; }

        public decimal Percentage { get; set; }
    }
}
