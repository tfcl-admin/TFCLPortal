using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TFCLPortal.Applications;

namespace TFCLPortal.Web.Models.BADocumentUploads
{
    public class BADocumentUpload
    {
        public int Fk_UserId { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }
        public int SDE_UserId { get; set; }
        public int BA_UserId { get; set; }
        public string ECIB_photo { get; set; }
        public string DataCheck_photo { get; set; }
        public string Tasdeeq_photo { get; set; }
        public string Verisys_photo { get; set; }
        public string DocumentKey_photo { get; set; }
    }
}
