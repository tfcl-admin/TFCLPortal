using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BusinessDetails.Dto
{
    [AutoMapTo(typeof(BusinessDetail))]
    public class CreateBusinessDetailDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public string SchoolName { get; set; }
        public int SchoolType { get; set; }
        public string IsAnyFracnchiseOfSchoolNetwork { get; set; }
        public string NameOfFracnchiseSchoolNetwork { get; set; }
        public int LegalStatus { get; set; }
        public DateTime? EstablishedSince { get; set; }
        public string IsSchoolRegistered { get; set; }
        public DateTime? SchoolRegisterSince { get; set; }
        public string RegisterAuthority { get; set; }
        public string IfNoRegisteredWhy { get; set; }
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
        public int NumberOfSchoolBranches { get; set; }
        public int GenderOfTheStudent { get; set; }
        public string TotalExperienceInEducationIndustry { get; set; }
        public string PreviousExperience { get; set; }
        public string EmailAddress { get; set; }
        public string SchoolLandLine { get; set; }
        public DateTime? CurrentAddressSince { get; set; }
        public int NoofClassRoom { get; set; }
        public int NoofStaffRoom { get; set; }
        public int NoofWashRoom { get; set; }
        public int Canteen { get; set; }
        public int ComputerLab { get; set; }
        public int PlayGround { get; set; }
        public int Library { get; set; }
        public string SELECT_ANY_OTHER_SCHOOL { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string RentAmount { get; set; }
        public List<CreateSchoolBranchDto> school_Branches { get; set; }

        //New Fields
        public string SchoolNtn { get; set; }
        public bool? isActiveTaxPayer { get; set; }
        public bool? isOtherCampus { get; set; }
    }
}
