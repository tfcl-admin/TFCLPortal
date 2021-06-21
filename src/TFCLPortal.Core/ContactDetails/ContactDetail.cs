using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.ContactDetails
{
    [Table("ContactDetail")]
    public class ContactDetail : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string PresentAddress { get; set; }
        public int PresentProvince { get; set; }
        public int PresentDistrict { get; set; }
        public string PresentTehsil { get; set; }
        public string PresentUCNo { get; set; }
        public string PresentMouzaTown { get; set; }
        public string PresentNearestLandMark { get; set; }
        public int OwnershipStatus { get; set; }
        public DateTime? CurrentAddressSince { get; set; }
        public bool IsSamePermanent { get; set; }
        public string permanentAddress { get; set; }
        public int permanentProvince { get; set; }
        public int permanentDistrict { get; set; }
        public string permanentTehsil { get; set; }
        public string permanentUCNo { get; set; }
        public string permanentMouzaTown { get; set; }
        public string permanentNearestLandMark { get; set; }
        public string MobileNo { get; set; }
        public string LandlineNo { get; set; }
        public string AlternateMobileNo { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string RentAmount { get; set; }


        //New
        public int? RentAgreementSignatory { get; set; }
        public string RentAgreementSignatoryOthers { get; set; }
        public decimal? MonthlyRentSharingPercentage { get; set; }
        public decimal? MonthlyShare { get; set; }
        public decimal? AreaOfResidenceSqFt { get; set; }
        public string AlternateMobileNoSelf { get; set; }
        public string FaxNo { get; set; }
        public string AlternateMobileNoName { get; set; }

        public DateTime? RentAgreementExpiryDate { get; set; }

    }
}
