using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.LoanPurposeClassifications
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("LoanPurposeClassification")]
    public class LoanPurposeClassification : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}

