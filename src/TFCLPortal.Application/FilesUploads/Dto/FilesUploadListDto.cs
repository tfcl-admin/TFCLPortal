using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FilesUploads.Dto
{
    [AutoMapFrom(typeof(FilesUpload))]
    public class FilesUploadListDto: FullAuditedEntityDto
    {
        public int ApplicationId { get; set; }
        public string FileUrl { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public int Fk_idForName { get; set; }
        public string RespectiveName { get; set; }
        public string ScreenCode { get; set; }
        public string BaseUrl { get; set; }

        public int? FileTypeId { get; set; }
        public string UploadedBy { get; set; }
    }
}
