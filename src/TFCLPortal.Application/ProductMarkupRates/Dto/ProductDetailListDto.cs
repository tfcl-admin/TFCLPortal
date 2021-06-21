using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ProductMarkupRates.Dto
{
    [AutoMapFrom(typeof(ProductDetail))]
    public class ProductDetailListDto : EntityDto
    {
       
        public int Fk_ProductId { get; set; }
        public string Tenure { get; set; }
        public int SlabMin { get; set; }
        public int SlabMax { get; set; }
        public string Slabs { get; set; }
        public decimal FreshClientSecureMarkupRate { get; set; }
        public decimal FreshClientUnSecureMarkupRate { get; set; }
        public decimal RepeatClientUnSecureMarkupRate { get; set; }
        public decimal RepeatClientSecureMarkupRate { get; set; }
        public bool IsActive { get; set; }
        //public string FreshClientLoanStatus { get; set; }
        //public string RepeatClientLoanStatus { get; set; }
    }
}
