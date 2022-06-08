using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.BiggestMotivations
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("BiggestMotivation")]
    public class BiggestMotivation : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
