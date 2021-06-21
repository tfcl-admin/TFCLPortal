using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.FileTypes
{
    [Table("FileType")]
    public class FileType : FullAuditedEntity<int>
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
