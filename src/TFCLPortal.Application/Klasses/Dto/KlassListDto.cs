using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Klasses.Dto
{
    [AutoMapFrom(typeof(Klass))]
    public class KlassListDto : EntityDto
    {
 
        public string Name { get; set; }
        public int TotalStudents { get; set; }
        public string Teacher { get; set; }
    }
}
