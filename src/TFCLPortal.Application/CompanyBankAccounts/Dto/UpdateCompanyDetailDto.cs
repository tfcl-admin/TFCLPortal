using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.Companies.Dto;

namespace TFCLPortal.CompanyBankAccounts.Dto
{
   public class UpdateCompanyBankAccountDto : CreateCompanyBankAccountDto
    {
        public int Id { get; set; }
    }
}
