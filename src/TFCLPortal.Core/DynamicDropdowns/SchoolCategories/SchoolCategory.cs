using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.SchoolCategories
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("SchoolCategory")]
    public class SchoolCategory : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
