using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ProductMarkupRates.Dto
{
    [AutoMapFrom(typeof(Product))]
    public class ProductListDto : EntityDto
    {
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int SlabMin { get; set; }
        public int SlabMax { get; set; }
        public string Slabs { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string ShortCode { get; set; }

        public List<ProductDetailListDto> ProductDetails { get; set; }
    }
}
