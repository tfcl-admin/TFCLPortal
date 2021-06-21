using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.ApplicantSources
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("ApplicantSource")]
    public class ApplicantSource : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
