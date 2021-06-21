using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemDostSahulats.Dto
{
    [AutoMapTo(typeof(TaleemDostSahulat))]
    public class CreateTaleemDostSahulatDto
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
