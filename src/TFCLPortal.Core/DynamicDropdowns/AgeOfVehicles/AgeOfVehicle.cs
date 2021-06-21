using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFCLPortal.DynamicDropdowns.AgeOfVehicles
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("AgeOfVehicle")]
    public class AgeOfVehicle : AuditedEntity<Int32>
    {
        public string Name { get; set; }
        public string AllowedLTV { get; set; }

    }

}
