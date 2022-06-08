using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.BusinessRadiuses
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("BusinessRadius")]
    public class BusinessRadius : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
