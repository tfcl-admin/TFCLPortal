using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemJariSahulats.Dto
{
    [AutoMapTo(typeof(TaleemJariSahulat))]
    public class CreateTaleemJariSahulatDto
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
