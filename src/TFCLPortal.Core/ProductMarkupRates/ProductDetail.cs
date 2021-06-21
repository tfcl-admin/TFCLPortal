using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ProductMarkupRates
{
    [Table("ProductDetail")]
    public class ProductDetail : FullAuditedEntity<int>
    {
        public int Fk_ProductId { get; set; }

        [ForeignKey("Fk_ProductId")]
        public Product Products { get; set; }
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
