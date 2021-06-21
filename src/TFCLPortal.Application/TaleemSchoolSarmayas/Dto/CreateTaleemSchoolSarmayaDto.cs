using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemSchoolSarmayas.Dto
{
    [AutoMapTo(typeof(TaleemSchoolSarmaya))]
    public class CreateTaleemSchoolSarmayaDto 
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
