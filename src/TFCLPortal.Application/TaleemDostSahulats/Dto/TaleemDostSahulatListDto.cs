using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemDostSahulats.Dto
{
    [AutoMapFrom(typeof(TaleemDostSahulat))]
    public class TaleemDostSahulatListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
