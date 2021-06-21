using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Host.Models
{
    public class FileUpload
    {
        public int ApplicationId { get; set; }
        public IFormFile applicant_photo { get; set; }
        public IFormFile applicant_cnic_front { get; set; }
        public IFormFile applicant_cnic_back { get; set; }
        public IFormFile applicant_utility_bil_one { get; set; }
        public IFormFile applicant_utility_bil_two { get; set; }
        public IFormFile applicant_school_reg_certification { get; set; }
        public IFormFile applicant_school_front_view { get; set; }
        public IFormFile applicant_rent_agreement { get; set; }
        public IFormFile applicant_other_document_one { get; set; }
        public IFormFile applicant_other_document_two { get; set; }
        public IFormFile guarantor_photo { get; set; }
        public IFormFile guarantor_cnic_front { get; set; }
        public IFormFile guarantor_cnic_back { get; set; }
        public IFormFile guarantor_employment_card { get; set; }
        public IFormFile guarantor_additional_document_one { get; set; }
        public IFormFile guarantor_additional_document_two { get; set; }
        public IFormFile co_applicant_photo { get; set; }
        public IFormFile co_applicant_cnic_front { get; set; }
        public IFormFile co_applicant_cnic_back { get; set; }
        public IFormFile co_applicant_additional_document_one { get; set; }
        public IFormFile co_applicant_additional_document_two { get; set; }
    }


    public class BADocument
    {
        public int ApplicationId { get; set; }
    }

    public class BccUserSDE
    {

        public int SDEUserId { get; set; }
    }

    public class BCCModel
    {

        public int ApplicationId { get; set; }
        public int SDEuserId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
    public class User
    {
        public int CurrentUserId { get; set; }
    }
}
