using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemTeacherSahulats.Dto
{
    [AutoMapTo(typeof(TaleemTeacherSahulat))]
    public class CreateTaleemTeacherSahulatDto
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
