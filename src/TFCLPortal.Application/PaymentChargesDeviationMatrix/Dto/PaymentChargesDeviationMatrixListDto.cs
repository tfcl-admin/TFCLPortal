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


    public class PaymentChargesValues
    {
        public double EarlierProcessingCharges { get; set; }
        public double EarlierFEDonPC { get; set; }
        public double EarlierNetDisbursement { get; set; }

        public double ProcessingCharges { get; set; }
        public double FEDonPC{ get; set; }
        public double NetDisbursement{ get; set; }

        public double TotalProcessingCharges { get; set; }
        public double TotalFEDonPC { get; set; }
        public double TotalNetDisbursement { get; set; }

    }
}
