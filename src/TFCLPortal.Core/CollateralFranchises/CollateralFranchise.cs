using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.CollateralFranchises
{
    [Table("CollateralFranchise")]
    public class CollateralFranchise : FullAuditedEntity<Int32>
    {
        public int Fk_ColateralID { get; set; }
        public int CollateralOwnership { get; set; }

        public string FranchiserName { get; set; }
        public string FranchiserAddress { get; set; }
        public string FranchiseBranchCampusName { get; set; }
        public string FranchiseBranchCampusAddress { get; set; }
        public string AmountOfFranchiseAgreement { get; set; }

        public DateTime? DateOfEvaluation { get; set; }
        public string FranchiseOwnerName { get; set; }
        public string RelationWithApplicant { get; set; }

        //NEW
        public string AppliedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }


    }
}
