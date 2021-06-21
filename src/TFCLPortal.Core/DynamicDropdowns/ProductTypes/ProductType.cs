using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.ProductTypes
{
    [Table("ProductType")]
    public class ProductType : AuditedEntity<Int32>
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
    }
}
