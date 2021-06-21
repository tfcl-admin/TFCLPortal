using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ProductMarkupRates.Dto
{
    [AutoMapTo(typeof(ProductDetail))]
    public class CreateProductDetailDto : Entity<int>
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
