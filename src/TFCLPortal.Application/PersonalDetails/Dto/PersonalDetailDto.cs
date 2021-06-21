using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.PersonalDetails.Dto
{
    [AutoMapFrom(typeof(PersonalDetail))]
    public class PersonalDetailDto:Entity<int>
    {

        public int ApplicationId { get; set; }
        public string ApplicantName { get; set; }
        public string ParentName { get; set; }
        public string CNIC { get; set; }
        public DateTime? CNICExpiry { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Gender { get; set; }
        public string AllowedMinAge { get; set; }
        public string AllowedMaxAge { get; set; }
        public string Age { get; set; }
        public string CalculatedAge { get; set; }
        public string CalculatedAgeDisbursement { get; set; }
        
        public string LoanMatureDate { get; set; }
        public int MaritalStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public int Qualification { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string OtherGenderDD { get; set; }
        public string OtherQualificationDD { get; set; }

        public string Specialization { get; set; }
        //dropdowns names
        public string GenderName { get; set; }
        public string MaritalStatusName { get; set; }
        public string QualificationName { get; set; }

        //New
        public int? NumberOfDependants { get; set; }
        public int? SpouseStatus { get; set; }
        public string SpouseStatusName { get; set; }
        public int? SchoolGoingDependants { get; set; }
        public string Nationality { get; set; }
        public string OtherNationality { get; set; }
        public string MotherMaidenName { get; set; }
        public string PersonalNTN { get; set; }
        public string SalesTaxNumber { get; set; }
        public bool? isActiveTaxPayer { get; set; }
        public bool? AgeApprovalTaken { get; set; }

    }
}
