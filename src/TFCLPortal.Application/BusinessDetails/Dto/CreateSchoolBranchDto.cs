using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessDetails
{
    [AutoMapTo(typeof(School_Branch))]
    public class CreateSchoolBranchDto
    {
        public string SchoolAddress { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Tehsil { get; set; }
        public string UC_NO { get; set; }
        public string Moza_Town { get; set; }
        public string NearestLandmark { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int SchoolPlaceOwnership { get; set; }
        public int Fk_BusinessDetailID { get; set; }
        public string TeachingStaffRooms { get; set; }
        public string AreaOfSchool { get; set; }
        public string NonTeachingStaffRooms { get; set; }

        //New Fields
        public string SchoolName { get; set; }
        public int? ClientBusinessClassification { get; set; }
        public bool? isFranchise { get; set; }
        public string FranchiserName { get; set; }
        public int? RentAgreementSignatory { get; set; }
        public int? MonthlyRent { get; set; }
        public decimal? MonthlyRentSharing { get; set; }
        public DateTime? RentAgreementExpiryDate { get; set; }
        public int? SchoolBranchBusinessNature { get; set; }
        public DateTime? EstablishedSince { get; set; }
        public DateTime? CurrentAddressSince { get; set; }
        public string BusinessAge { get; set; }
        public string TimeAtCurrentAddress { get; set; }
        public int? AcademicSession { get; set; }
        public int? Category { get; set; }
        public int ClassRooms { get; set; }
        public int NoOfBranchAccount { get; set; }
        public int AdministrativeRooms { get; set; }
        public int WashRooms { get; set; }
        public int ComputerLabs { get; set; }
        public int ScienceLabs { get; set; }
        public int Libraries { get; set; }
        public int Playgrounds { get; set; }
        public int Canteens { get; set; }
        public int Auditoriums { get; set; }
        public int PaidTeachingStaffMale { get; set; }
        public int PaidTeachingStaffFemale { get; set; }
        public int PaidTeachingStaffTotal { get; set; }
        public int UnPaidTeachingStaffMale { get; set; }
        public int UnPaidTeachingStaffFemale { get; set; }
        public int UnPaidTeachingStaffTotal { get; set; }
        public int TotalTeachingStaffMale { get; set; }
        public int TotalTeachingStaffFemale { get; set; }
        public int TotalTeachingStaffTotal { get; set; }
        public int NonTeachingStaffMale { get; set; }
        public int NonTeachingStaffFemale { get; set; }
        public int NonTeachingStaffTotal { get; set; }

        public int SectionsActiveClasses { get; set; }
        public int AreaOfSchoolSqFt { get; set; }
        public string SchoolContactNo { get; set; }
        public string PersonalEmail { get; set; }
        public string OfficialEmail { get; set; }
        public string FaxNo { get; set; }
        public string ContactPreferences { get; set; }

        public int? BusinessType { get; set; }
        public int? SchoolLevel { get; set; }
        public int? LegalStatus { get; set; }
        public int NoOfPartnersInvestorsDirectors { get; set; }
        public decimal? percentageOfProfitShare { get; set; }

        public bool? isBoardAffiliation { get; set; }
        public DateTime? AffiliationSince { get; set; }
        public string AffiliationRegistrationNumber { get; set; }
        public string AffiliatedBoardName { get; set; }
        public DateTime? AffiliationRegistrationExpiry { get; set; }
        public string AffiliationReasonNotRegistered { get; set; }

        public string RegistrationStatus { get; set; }
        public DateTime? RegisteredSince { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationAuthority { get; set; }
        public DateTime? RegistrationExpiry { get; set; }
        public string ReasonForNotRegistered { get; set; }
        public bool? isAcademy { get; set; }
        public string AcademyName { get; set; }

        public decimal? MonthlyShare { get; set; }
        public string BusinessTypeOthers { get; set; }
        public string LegalStatusOthers { get; set; }

        public string otherBusinessNature { get; set; }
        public string rentAgreementSignatoryOthers { get; set; }
        public int noOfPrograms { get; set; }


        //--------------------------------------------------
        public int noOfElectricityConnections { get; set; }
        public int noOfWaterGasConnections { get; set; }
        public int noOfLandlineConnections { get; set; }

        public int TotalStaffMale { get; set; }
        public int TotalStaffFemale { get; set; }
        public int TotalStaffTotal { get; set; }
        public string BusinessProfitConsidered { get; set; }
        public string NameOfPartnerInvestorDirector { get; set; }
    }
}
