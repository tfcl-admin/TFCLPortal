using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CollateralDetails.Dto
{
    public class UpdateCollateralDetailDto : CreateCollateralDetailDto
    {
        public int Id { get; set; }
        public List<UpdateCollateralLandBuildingDto> updateCollateralLandBuilding { get; set; }
        public List<UpdateCollateralTDRDto> updateCollateralTDR { get; set; }
        public List<UpdateCollateralVehicleDto> updateCollateralVehicle { get; set; }
        public List<UpdateCollateralGoldDto> updateCollateralGold { get; set; }
    }
}
