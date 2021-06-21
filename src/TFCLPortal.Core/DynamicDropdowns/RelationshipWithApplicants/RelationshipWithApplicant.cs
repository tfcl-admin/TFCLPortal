using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.RelationshipWithApplicants
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("RelationshipWithApplicant")]
    public class RelationshipWithApplicant : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}

