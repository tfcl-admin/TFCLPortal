using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemFeeSahulats.Dto
{
    [AutoMapFrom(typeof(TaleemFeeSahulat))]
    public class TaleemFeeSahulatListDto : Entity<int>
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
