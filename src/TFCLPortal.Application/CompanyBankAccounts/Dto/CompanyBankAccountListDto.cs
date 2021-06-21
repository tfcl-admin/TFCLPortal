using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.CompanyBankAccounts.Dto
{
    [AutoMapFrom(typeof(CompanyBankAccount))]
    public class CompanyBankAccountListDto : EntityDto
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
    }
}
