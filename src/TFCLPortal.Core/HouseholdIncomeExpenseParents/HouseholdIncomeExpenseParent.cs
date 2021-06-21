using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.HouseholdIncomeExpenseParents
{
    [Table("HouseholdIncomeExpenseParent")]
    public class HouseholdIncomeExpenseParent : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
        public string totalHouseHoldIncomeExpense { get; set; }

    }
}
