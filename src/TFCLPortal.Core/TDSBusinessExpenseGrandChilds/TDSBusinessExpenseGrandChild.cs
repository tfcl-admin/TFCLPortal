using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TDSBusinessExpenses
{
    [Table("TDSBusinessExpenseGrandChild")]
    public class TDSBusinessExpenseGrandChild : FullAuditedEntity<Int32>
    {
        public int Fk_TDSBusinessExpenseChildid  { get; set; }
       
        public string EmployerName { get; set; }
        public string Designation { get; set; }
        public string Gender  { get; set; }
        public string Salary { get; set; }


    }
}
