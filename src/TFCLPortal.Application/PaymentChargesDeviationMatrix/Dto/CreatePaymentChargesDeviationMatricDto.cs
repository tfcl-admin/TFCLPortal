using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.PaymentChargesDeviationMatrix;

namespace TFCLPortal.PaymentChargesDeviationMatrix.Dto
{
    [AutoMapTo(typeof(PaymentChargesDeviationMatric))]
    public class CreatePaymentChargesDeviationMatricDto
    {
        public string Type { get; set; }
        public decimal  MaxAmount { get; set; }
        public decimal Percentage { get; set; }
    }
}
