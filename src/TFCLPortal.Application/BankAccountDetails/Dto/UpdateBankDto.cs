using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BankAccountDetails.Dto
{
    [AutoMapTo(typeof(BankAccountDetail))]
    public class UpdateBankDto : Entity<int>
    {

        public int ApplicationId { get; set; }
        public int? BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? AccountMaintained { get; set; }
        public DateTime? AnalysisMonth { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
    }
}