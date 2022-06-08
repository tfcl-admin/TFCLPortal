using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.LearningAids
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("LearningAid")]
    public class LearningAid : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
