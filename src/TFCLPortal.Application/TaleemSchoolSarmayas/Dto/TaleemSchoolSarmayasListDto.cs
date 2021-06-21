using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemSchoolSarmayas.Dto
{
    [AutoMapFrom(typeof(TaleemSchoolSarmaya))]
    public class TaleemSchoolSarmayasListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
