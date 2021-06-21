using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.ApplicantTypes
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("ApplicantType")]
    public class ApplicantType : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
