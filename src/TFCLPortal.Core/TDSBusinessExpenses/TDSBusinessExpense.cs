using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TDSBusinessExpenses
{
    [Table("TDSBusinessExpense")]
    public class TDSBusinessExpense : FullAuditedEntity<Int32>
    {
        public int ApplicationId { get; set; }
       
        //NEW
        public string NetMonthlyBusinessExpense{ get; set; }
    }
}
