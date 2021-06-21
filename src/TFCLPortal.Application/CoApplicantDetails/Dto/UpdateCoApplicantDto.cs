using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CoApplicantDetails.Dto
{
    [AutoMapTo(typeof(CoApplicantDetail))]
    public class UpdateCoApplicantDto : Entity<int>
    {
        public string FullName { get; set; }
        public string SDW { get; set; }
        public string CNICNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PresentAddress { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Tehsil { get; set; }
        public string UCNumber { get; set; }
        public string MouzaOrTown { get; set; }
        public string RealtionshipWithApplicant { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string Profession { get; set; }
        public string EmployerName { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

    }
}
