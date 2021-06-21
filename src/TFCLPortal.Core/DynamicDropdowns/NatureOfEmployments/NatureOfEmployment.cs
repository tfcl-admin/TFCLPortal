using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.NatureOfEmployments
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("NatureOfEmployment")]
    public class NatureOfEmployment : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
