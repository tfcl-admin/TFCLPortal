using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.PostDisbursementForms
{
    [Table("PostDisbursementForm")]
    public class PostDisbursementForm : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string FileMonthlyIncome { get; set; }
        public string FileNetBusinessIncome { get; set; }
        public string FileIncomeAfterHHexp { get; set; }
        public string FileCollateral { get; set; }
        public string GuarantorBusinessCondition { get; set; }
        public string Comments { get; set; }
        public string LoanAmountUtilization { get; set; }
        public string CurrentMonthlyIncome { get; set; }
        public string CurrentNetBusinessIncome { get; set; }
        public string CurrentIncomeAfterHHexp { get; set; }
        public string CurrentCollateral { get; set; }
    }
}
