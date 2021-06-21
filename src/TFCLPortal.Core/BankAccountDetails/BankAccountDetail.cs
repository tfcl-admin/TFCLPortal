using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.BankAccountDetails
{
    [Table("BankAccountDetail")]
    public class BankAccountDetail:FullAuditedEntity<int>
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
