using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.BankAccountDetails.Dto
{
    [AutoMapFrom(typeof(BankAccountDetail))]
    public  class BankAccountListDto: Entity<int>
    {
        public int ApplicationId { get; set; }
        public int? BankName { get; set; }
        public string BankFullName { get; set; }
        public string BranchName { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? AccountMaintained { get; set; }
        public DateTime? AnalysisMonth { get; set; }
        public List<BankAccountChildListDto> BankAccountChilds { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
    }
}
