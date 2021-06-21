using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.TaleemSchoolAsasahs
{
    [Table("TaleemSchoolAsasah")]
    public class TaleemSchoolAsasah : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }

    }
}
