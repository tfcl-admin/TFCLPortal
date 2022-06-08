using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.AyasPresents
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("AyasPresent")]
    public class AyasPresent : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
