using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.UploadFiles
{
    public class UploadFile
    {
        public int ApplicationId { get; set; }
        public int FileTypeId { get; set; }
        public int ddrName { get; set; }
        public IFormFile UploadedFile { get; set; }
        public string Description{ get; set; }
        public string UploadedBy{ get; set; }
    }
}
