using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ColatteralGolds
{
    [Table("CollateralGold")]
    public class CollateralGold : FullAuditedEntity<Int32>
    {
        public int Fk_ColateralID { get; set; }
        public int CollateralOwnership { get; set; }
        public string NoOFItemGold { get; set; }
        public string ItemDescriptionGold { get; set; }
        public string TotalGrossWeightGold { get; set; }
        public string TotalNetWeightGold { get; set; }
        public string MarketValueInGram { get; set; }
        public string MarketValueTotalGold { get; set; }
        public string GoldEvaluatorName { get; set; }

        //New
        public DateTime? DateOfEvaluation { get; set; }
        public string GoldOwnerName { get; set; }
        public string RelationWithApplicant { get; set; }

        //NEW
        public string AppliedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }

    }
}
