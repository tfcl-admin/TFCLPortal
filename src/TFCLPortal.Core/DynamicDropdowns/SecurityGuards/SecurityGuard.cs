using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.SecurityGuards
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("SecurityGuard")]
    public class SecurityGuard : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
