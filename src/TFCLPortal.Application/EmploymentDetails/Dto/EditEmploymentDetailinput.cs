using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.EmploymentDetails.Dto
{
    [AutoMapTo(typeof(EmploymentDetail))]
    public class EditEmploymentDetailinput:Entity<int>
    {
        public int ApplicationId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyType { get; set; }
        public string CompanyTypeOthers { get; set; }
        public string CompanyAddress { get; set; }
        public string MouzaTown { get; set; }
        public string UnionCouncil { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Tehsil { get; set; }
        public DateTime CompanySince { get; set; }
        public string CompanyBusinessDetails { get; set; }
        public string ClientDesignation { get; set; }
        public string ConcernedDepartment { get; set; }
        public int NatureOfEmployment { get; set; }
        public string NatureOfEmploymentOthers { get; set; }
        public string TenureOfEmploymentDesignation { get; set; }
        public string TenureOfEmploymentCompany { get; set; }
        public string TenureOfEmploymentOverall { get; set; }
        public string Email { get; set; }
        public string Landline { get; set; }
        public string CompanyNTN { get; set; }
    }
}
