using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BankAccountChildDetails;

namespace TFCLPortal.BankAccountDetails.Dto
{
    [AutoMapTo(typeof(BankAccountDetail))]
    public class BankAccountDto
    {
        public int ApplicationId { get; set; }
        public int? BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountTitle { get; set; }
        public string  AccountNumber { get; set; }
        public DateTime? AccountMaintained { get; set; }
        public DateTime? AnalysisMonth { get; set; }
        public List<BankAccountChildDto> BankAccountChilds { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
    }
}
