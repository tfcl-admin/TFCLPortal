using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.OtherSourceOfIncomes
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("OtherSourceOfIncome")]
    public class OtherSourceOfIncome : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
