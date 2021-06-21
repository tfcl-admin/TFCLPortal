using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemTeacherSahulats.Dto
{
    [AutoMapFrom(typeof(TaleemTeacherSahulat))]
    public class TaleemTeacherSahulatListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
