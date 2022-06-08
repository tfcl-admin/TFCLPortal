using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.PeopleSteals
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("PeopleSteal")]
    public class PeopleSteal : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
