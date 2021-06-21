using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.RespondantDesignations
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("RespondantDesignation")]
    public class RespondantDesignation : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }

}
