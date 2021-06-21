using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.CompanyBankAccounts
{
    [Table("CompanyBankAccount")]
    public class CompanyBankAccount : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
    }
}
