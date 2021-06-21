using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.CollateralLandBuildings;

namespace TFCLPortal.CollateralDetails.Dto
{
    [AutoMapTo(typeof(CollateralLandBuilding))]
    public class CreateCollateralLandBuildingDto
    {
        public int Fk_ColateralID { get; set; }
        public int PropertyType { get; set; }
        public int CollateralOwnership { get; set; }
        public DateTime? BuildSince { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string PropertyAddress { get; set; }
        public string TotalArea { get; set; }
        public string CoveredArea { get; set; }
        public string PurchasePrice { get; set; }
        public string LandBuildingMarketPrice { get; set; }
        public string GovtEstimatedValue { get; set; }


        //New 
        public DateTime? DateOfEvaluation { get; set; }
        public string PropertyOwnerName { get; set; }

        public string DealerOneName { get; set; }
        public string RelationWithApplicant { get; set; }
        public string DealerOneContactNumber { get; set; }
        public string DealerOneBusinessName { get; set; }

        public string DealerTwoName { get; set; }
        public string DealerTwoContactNumber { get; set; }
        public string DealerTwoBusinessName { get; set; }

        //NEW
        public string AppliedLtvPercentage { get; set; }
        public string MaxFinancingAllowedLTV { get; set; }


    }
}
