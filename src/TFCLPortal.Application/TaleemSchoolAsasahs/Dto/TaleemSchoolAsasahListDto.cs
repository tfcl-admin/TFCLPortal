using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemSchoolAsasahs.Dto
{
    [AutoMapFrom(typeof(TaleemSchoolAsasah))]
    public class TaleemSchoolAsasahListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
