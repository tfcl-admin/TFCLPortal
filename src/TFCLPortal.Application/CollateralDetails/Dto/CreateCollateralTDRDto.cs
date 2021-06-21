using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.CollateralTDRs;

namespace TFCLPortal.CollateralDetails.Dto
{
    [AutoMapTo(typeof(CollateralTDR))]
    public class CreateCollateralTDRDto
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
