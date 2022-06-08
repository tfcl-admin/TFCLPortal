using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.FinancialRecords
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("FinancialRecord")]
    public class FinancialRecord : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
