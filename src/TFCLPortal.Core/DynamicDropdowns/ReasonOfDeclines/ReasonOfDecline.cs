using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.ReasonOfDeclines
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("ReasonOfDecline")]
    public class ReasonOfDecline : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}

