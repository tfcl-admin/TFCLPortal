using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TFCLPortal.Applications;

namespace TFCLPortal.DescripentScreens
{
    [Table("DescripentScreen")]
    public class DescripentScreen : FullAuditedEntity<int>
    {
        public int? ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Applicationz applicationz { get; set; }

        public int Fk_ScreenId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public int Fk_CreaterUserId { get; set; }
        public string ScreenCode { get; set; }

    }
}
