using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.SpouseStatuses
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("SpouseStatus")]
    public class SpouseStatus : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}

