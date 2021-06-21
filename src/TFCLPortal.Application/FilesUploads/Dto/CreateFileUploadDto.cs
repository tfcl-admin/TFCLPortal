using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FilesUploads.Dto
{
    [AutoMapTo(typeof(FilesUpload))]
    public class CreateFileUploadDto
    {
        public int ApplicationId { get; set; }
        public string FileUrl { get; set; }
        public int Fk_idForName { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public string ScreenCode { get; set; }
        public string BaseUrl { get; set; }

        public int? FileTypeId { get; set; }
        public string UploadedBy { get; set; }
    }
}
