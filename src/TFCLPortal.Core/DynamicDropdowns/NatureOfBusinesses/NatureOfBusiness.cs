using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.NatureOfBusinesses
{
    [Table("NatureOfBusiness")]
    public class NatureOfBusiness : AuditedEntity<Int32>
    {
        public string Name { get; set; }

    }
}
