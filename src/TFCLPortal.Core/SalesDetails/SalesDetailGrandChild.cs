using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.SalesDetails
{
    [Table("SalesDetailGrandChild")]
    public class SalesDetailGrandChild : FullAuditedEntity<Int32>
    {
        public int Fk_SalesDetailChildId { get; set; }

        public string SrNo { get; set; }
        public string ItemName { get; set; }
        public string PerUnitSalePrice { get; set; }
        public string MonthlySaleUnit { get; set; }
        public string TotalSale { get; set; }

    }
}
