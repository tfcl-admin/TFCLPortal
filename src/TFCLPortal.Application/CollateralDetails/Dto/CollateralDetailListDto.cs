using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CollateralDetails.Dto
{
    [AutoMapFrom(typeof(CollateralDetail))]
    public class CollateralDetailListDto : FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public int CollateralType { get; set; }
        public int CollateralCount { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string CollateralTypeName { get; set; }

        public bool isNA { get; set; }
        public string CollateralTypeOthers { get; set; }

        public List<CollateralLandBuildingListDto> createCollateralLandBuilding { get; set; }
        public List<CollateralTDRListDto> createCollateralTDR { get; set; }
        public List<CollateralVehicleListDto> createCollateralVehicle { get; set; }
        public List<CollateralGoldListDto> createCollateralGold { get; set; }
        public List<CollateralFranchiseListDto> createCollateralFranchise { get; set; }
        public string AllCollateralMarketPrice { get; set; }
        public string MaxFinancingAllowedLtvAllCollaterals { get; set; }

    }
}
