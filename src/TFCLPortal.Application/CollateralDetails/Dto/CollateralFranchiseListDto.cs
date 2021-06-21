using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.CollateralFranchises;

namespace TFCLPortal.CollateralDetails.Dto
{
    [AutoMapFrom(typeof(CollateralFranchise))]
    public class CollateralFranchiseListDto : EntityDto
    {
        public int Fk_ColateralID { get; set; }
        public int CollateralOwnership { get; set; }

        public string FranchiserName { get; set; }
        public string OwnershipName { get; set; }
        public string FranchiserAddress { get; set; }
        public string FranchiseBranchCampusName { get; set; }
        public string FranchiseBranchCampusAddress { get; set; }
        public string AmountOfFranchiseAgreement { get; set; }

        public DateTime? DateOfEvaluation { get; set; }
        public string FranchiseOwnerName { get; set; }
        public string RelationWithApplicant { get; set; }
        public string RelationWithApplicantName { get; set; }


        //NEW
        public string AppliedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }


    }
}
