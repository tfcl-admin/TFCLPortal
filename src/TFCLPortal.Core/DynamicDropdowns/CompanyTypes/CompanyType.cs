using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.CompanyTypes
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("CompanyType")]
    public class CompanyType : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
