using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Applications;

namespace TFCLPortal.WorkFlows
{
    [Table("BccState")]
    public class BccState : FullAuditedEntity<Int32>
    {
        public int Fk_UserId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Applicationz Applications { get; set; }
        public int Fk_BccId { get; set; }
       


    }
}
