using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.AssetLiabilityDetails
{
    [Table("AssetLiabilityDetail")]
    public class AssetLiabilityDetail : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public decimal AssetLandBuliding { get; set; }
        public decimal AssetFurnitureFixture { get; set; }
        public decimal AssetAccountReceivable { get; set; }
        public decimal AssetCashInHandAtBank { get; set; }
        public decimal AssetVehicle { get; set; }
        public decimal AssetEquipment { get; set; }
        public decimal AssetCommittee { get; set; }
        public decimal OtherAssets { get; set; }
        public decimal TotalBusinessAsset { get; set; }
        public decimal AssetBusinessNetWorth { get; set; }
        public decimal TotalHouseholdAsset { get; set; }
        public decimal AssetHouseholdNetWorth { get; set; }
        public decimal LiablityLoanPayebleBank { get; set; }
        public decimal LiablityAdvanceReceived { get; set; }
        public decimal LiablityAccountPayable { get; set; }
        public decimal LiablityCommittee { get; set; }
        public decimal OtherLiablity { get; set; }
        public decimal TotalBusinessLiability { get; set; }
        public decimal TotalHouseholdLiability { get; set; }
        public decimal BorrowerNetWorthLiability { get; set; }
        public string ScreenStatus { get; set; }
        public bool isNew { get; set; }
        public string Comments { get; set; }
        public string qtyMachinery { get; set; }
        public string detailsMachinery { get; set; }
        //NEW
        public decimal AssetStockInHand { get; set; }
        public decimal AssetFranchiseFee { get; set; }
        public decimal AssetGirviAmount { get; set; }
        public decimal AssetAirConditioners { get; set; }
        public decimal AssetComputers { get; set; }
        public decimal AssetGeneratorUps { get; set; }
        public decimal AssetSolar { get; set; }

        public string qtyAssetCashInHandAtBank { get; set; }
        public string qtyAssetStockInHand { get; set; }
        public string qtyAssetAccountReceivable { get; set; }
        public string qtyAssetFranchiseFee { get; set; }
        public string qtyAssetCommittee { get; set; }
        public string qtyAssetGirviAmount { get; set; }
        public string qtyAssetFurnitureFixture { get; set; }
        public string qtyAssetVehicle { get; set; }
        public string qtyAssetAirConditioners { get; set; }
        public string qtyAssetComputers { get; set; }
        public string qtyAssetGeneratorUps { get; set; }
        public string qtyAssetSolar { get; set; }
        public string qtyAssetEquipment { get; set; }
        public string qtyAssetLandBuliding { get; set; }
        public string qtyOtherAssets { get; set; }


        public string detailsLoanPayableBank { get; set; }
        public string detailsStudentSecurityDeposit { get; set; }
        public string detailsAdvanceReceived { get; set; }
        public string detailsAccountPayable { get; set; }
        public string detailsCommittee { get; set; }
        public string detailsOtherLiabilities { get; set; }

        public string AccountRecievable { get; set; }
        public string qtyAccountRecievable { get; set; }
        public string detailsPreciousItems { get; set; }
        public string qtyPreciousItems { get; set; }
        public string detailsProvidentFund { get; set; }
        public string qtyProvidentFund { get; set; }

        public decimal LiablityStudentSecurityDeposit { get; set; }
        public DateTime AssetLiabilityAsOn { get; set; }

        //----------------------------Addition Due to CAT--------------------------------//
        public string qtyCurrAccountRecievable { get; set; }
        public string detailsCurrAccountRecievable { get; set; }
        public string qtyCurrCommittee { get; set; }
        public string detailsCurrCommittee { get; set; }
        public string CurrTotalCurrentAssets { get; set; }
        public string qtyCurrLoanPayableBanks { get; set; }
        public string detailsCurrLoanPayableBanks { get; set; }
        public string qtyCurrAccountPayable { get; set; }
        public string detailsCurrAccountPayable { get; set; }
        public string qtyCurrCommitteeLiabilities { get; set; }
        public string detailsCurrCommitteeLiabilities { get; set; }
        public string qtyCurrAdvanceReceived { get; set; }
        public string detailsCurrAdvanceReceived { get; set; }
        public string CurrTotalCurrentLiabilities { get; set; }

        public string TotalFixedAssets { get; set; }
        public string TotalLongTermLiabilities { get; set; }
    }
}
