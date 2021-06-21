using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.ClientBusinessClassifications
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("ClientBusinessClassification")]
    public class ClientBusinessClassification : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
