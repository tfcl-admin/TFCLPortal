using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.CollateralDetails
{
    [Table("CollateralDetail")]
    public class CollateralDetail: FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public int CollateralType { get; set; }
        public int CollateralCount { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public bool isNA { get; set; }
        public string CollateralTypeOthers { get; set; }

        public string AllCollateralMarketPrice { get; set; }
        public string MaxFinancingAllowedLtvAllCollaterals { get; set; }
    }
}
