using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.ProductMarkupRates.Dto
{
    [AutoMapTo(typeof(Product))]
    public class CreateProductDto : Entity<int>
    {
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int SlabMin { get; set; }
        public int SlabMax { get; set; }
        public string Slabs { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string ShortCode { get; set; }
    }
}
