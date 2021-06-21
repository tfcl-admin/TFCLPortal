using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessDetailsTDS.Dto
{
    [AutoMapTo(typeof(BusinessDetailTDS))]
    public class CreateBusinessDetailTDSDto
    {
        public int ApplicationId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string BusinessTypeOthers { get; set; }
        public string BusinessAddress { get; set; }
        public string MouzaTown { get; set; }
        public string UnionCouncil { get; set; }
        public string Tehsil { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string NearestLandMark { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int LegalStatus { get; set; }
        public string LegalStatusOthers { get; set; }
        public int NoOfPartnersInvestorsDirectors { get; set; }
        public string NameOfPartnerInvestorDirector { get; set; }
        public string PercentageOfProfitConsidered { get; set; }
        public string PercentageOfProfitSharedApplicant { get; set; }
        public string BusinessNature { get; set; }
        public int NatureOfBusiness { get; set; }
        public string NatureOfBusinessOthers { get; set; }
        public DateTime EstablishedSince { get; set; }
        public int BusinessPlaceOwnership { get; set; }
        public int? RentAgreementSignatory { get; set; }
        public string rentAgreementSignatoryOthers { get; set; }
        public string MonthlyRent { get; set; }
        public string MonthlyRentSharingPercentage { get; set; }
        public string MonthlyShare { get; set; }
        public DateTime? RentAgreementExpiryDate { get; set; }
        public DateTime? CurrentAddressSince { get; set; }
        public string BusinessAge { get; set; }
        public string BusinessPhoneNumber { get; set; }

        public string Email { get; set; }
        public string NtnNo { get; set; }
        public string SalesTaxNo { get; set; }
        public bool isAnyOtherBusiness { get; set; }
        public string NumberofBusiness { get; set; }

    }
}
