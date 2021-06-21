using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ProductMarkupRates
{
    [Table("Product")]
    public class Product : FullAuditedEntity<int>
    {
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int SlabMin { get; set; }
        public int SlabMax { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string Slabs { get; set; }
        public string ShortCode { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }
    }
}
