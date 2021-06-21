using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.BankRatings
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("BankRating")]
    public class BankRating : AuditedEntity<Int32>
    {
        public string Name { get; set; }
        public string AllowedLTV { get; set; }
    }

}
