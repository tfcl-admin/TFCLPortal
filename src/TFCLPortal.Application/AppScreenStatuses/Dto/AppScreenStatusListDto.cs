using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.AppScreenStatuses.Dto
{
    [AutoMapFrom(typeof(AppScreenStatus))]
    public class AppScreenStatusListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public string ScreenStatus { get; set; }
    }
}
