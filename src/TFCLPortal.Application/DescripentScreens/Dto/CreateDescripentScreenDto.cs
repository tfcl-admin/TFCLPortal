using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DescripentScreens.Dto
{
    [AutoMapTo(typeof(DescripentScreen))]
    public class CreateDescripentScreenDto
    {
        public int ApplicationId { get; set; }
        public int Fk_ScreenId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public int Fk_CreaterUserId { get; set; }
        public string ScreenCode { get; set; }
    }
}
