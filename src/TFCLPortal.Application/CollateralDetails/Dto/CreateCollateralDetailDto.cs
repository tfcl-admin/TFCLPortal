using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CollateralDetails.Dto
{
    [AutoMapTo(typeof(CollateralDetail))]
    public class CreateCollateralDetailDto
    {
        public int ApplicationId { get; set; }
        public int CollateralType { get; set; }
        public int CollateralCount { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public bool isNA { get; set; }
        public string CollateralTypeOthers { get; set; }

        public List<CreateCollateralLandBuildingDto> createCollateralLandBuilding { get; set; }
        public List<CreateCollateralTDRDto> createCollateralTDR { get; set; }
        public List<CreateCollateralVehicleDto> createCollateralVehicle { get; set; }
        public List<CreateCollateralGoldDto> createCollateralGold { get; set; }
        public List<CreateCollateralFranchiseDto> createCollateralFranchise { get; set; }

        public string AllCollateralMarketPrice { get; set; }
        public string MaxFinancingAllowedLtvAllCollaterals { get; set; }
    }
}
