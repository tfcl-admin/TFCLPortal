using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.SpouseFamilyOtherIncomes
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("SpouseFamilyOtherIncome")]
    public class SpouseFamilyOtherIncome : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
