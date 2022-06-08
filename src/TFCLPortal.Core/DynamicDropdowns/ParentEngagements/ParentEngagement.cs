using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.ParentEngagements
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("ParentEngagement")]
    public class ParentEngagement : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
