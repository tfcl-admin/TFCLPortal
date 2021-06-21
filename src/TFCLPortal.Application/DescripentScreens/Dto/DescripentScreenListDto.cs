using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.DescripentScreens.Dto
{
    [AutoMapFrom(typeof(DescripentScreen))]
    public class DescripentScreenListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public int Fk_ScreenId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }
        public int Fk_CreaterUserId { get; set; }
        public string ScreenCode { get; set; }
    }
}
