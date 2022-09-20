using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BaloonPayments.Dto
{
    [AutoMapTo(typeof(BaloonPayment))]
    public class CreateBaloonPaymentDto
    {
        public int ApplicationId { get; set; }
        public int Fk_ScheduleTempId { get; set; }
        public decimal BaloonPaymentAmount { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal BpcAmount { get; set; }
        public decimal FEDonBPC { get; set; }
        public decimal TotalPayableBP { get; set; }
        public decimal AccountBalance { get; set; }

    }
}
