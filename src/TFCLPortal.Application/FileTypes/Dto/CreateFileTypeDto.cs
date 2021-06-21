using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FileTypes.Dto
{
    [AutoMapTo(typeof(FileType))]
    public class CreateFileTypeDto
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
