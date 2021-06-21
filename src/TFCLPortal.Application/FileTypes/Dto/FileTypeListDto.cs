using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FileTypes.Dto
{
    [AutoMapFrom(typeof(FileType))]
    public class FileTypeListDto : EntityDto
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
