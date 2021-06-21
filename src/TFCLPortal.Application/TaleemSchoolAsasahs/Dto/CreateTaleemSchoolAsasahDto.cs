using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.TaleemSchoolAsasahs.Dto
{
    [AutoMapTo(typeof(TaleemSchoolAsasah))]
    public class CreateTaleemSchoolAsasahDto
    {
        public int ApplicationId { get; set; }
        public int ApplicationNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
