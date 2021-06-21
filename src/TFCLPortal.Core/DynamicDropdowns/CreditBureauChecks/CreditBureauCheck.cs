using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.CreditBureauChecks
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("CreditBureauCheck")]
    public class CreditBureauCheck : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
