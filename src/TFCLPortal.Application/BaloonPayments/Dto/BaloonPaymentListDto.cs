using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFCLPortal.BaloonPayments.Dto
{
    [AutoMapFrom(typeof(BaloonPayment))]
    public class BaloonPaymentListDto : EntityDto
    {

        public int ApplicationId { get; set; }
        public int Fk_ScheduleTempId { get; set; }
        public decimal BaloonPaymentAmount { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal BpcAmount { get; set; }
        public decimal FEDonBPC { get; set; }
        public decimal TotalPayableBP { get; set; }
        public decimal AccountBalance { get; set; }
        public bool isPaid { get; set; }


    }
}
