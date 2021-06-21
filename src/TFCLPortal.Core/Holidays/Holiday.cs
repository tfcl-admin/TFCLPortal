using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Holidays
{
    [Table("Holiday")]
    public class Holiday : FullAuditedEntity<int>
    {
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Days { get; set; }
        public string Description { get; set; }
    }
}
