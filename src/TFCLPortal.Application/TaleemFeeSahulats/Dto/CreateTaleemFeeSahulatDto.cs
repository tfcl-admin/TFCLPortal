using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemFeeSahulats.Dto
{
    [AutoMapTo(typeof(TaleemFeeSahulat))]
    public class CreateTaleemFeeSahulatDto
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
