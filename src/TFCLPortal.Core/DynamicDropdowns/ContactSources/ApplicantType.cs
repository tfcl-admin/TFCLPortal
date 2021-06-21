using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.ContactSources
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("ContactSource")]
    public class ContactSource : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
