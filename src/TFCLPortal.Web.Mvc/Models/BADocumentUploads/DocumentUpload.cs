using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.BADocumentUploads
{
    public class DocumentUpload
    {
        public int ApplicationId { get; set; }
        public IFormFile DataCheck_photo { get; set; }
        public IFormFile ECIB_photo { get; set; }
        public IFormFile Tasdeeq_photo { get; set; }
        public IFormFile Verisys_photo { get; set; }
    }
}
