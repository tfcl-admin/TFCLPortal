using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.CollateralTDRs
{
    [Table("CollateralTDR")]
    public class CollateralTDR : FullAuditedEntity<Int32>
    {
        public int Fk_ColateralID { get; set; }
        public int CollateralOwnership { get; set; }
        public string TDRNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string AmountTDR { get; set; }

        //New
        public DateTime? DateOfEvaluation { get; set; }
        public string TDrOwnerName { get; set; }
        public string RelationWithApplicant { get; set; }


        //NEW
        public string AppliedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }
        public int? BankRating { get; set; }
        public string BankRatingName { get; set; }

    }
}
