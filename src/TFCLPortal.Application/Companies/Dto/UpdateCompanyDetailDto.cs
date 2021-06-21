using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.Company.Dto
{
   public class UpdateCompanyDetailDto : CreateCompanyDetailDto
    {
        public int Id { get; set; }
    }
}
