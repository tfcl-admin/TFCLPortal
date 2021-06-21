using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.FilesUploads
{
    [Table("FilesUpload")]
    public class FilesUpload : FullAuditedEntity<int>
    {
        public int ApplicationId { get; set; }
        public string FileUrl { get; set; }
        public string ScreenStatus { get; set; }
        public int Fk_idForName { get; set; }
        public string Comments { get; set; }
        public string ScreenCode { get; set; }
        public string BaseUrl { get; set; }
        public int? FileTypeId { get; set; }
        public string UploadedBy { get; set; }

    }
}
