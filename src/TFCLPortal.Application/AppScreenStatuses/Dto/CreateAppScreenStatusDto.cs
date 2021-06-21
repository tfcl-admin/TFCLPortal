using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.AppScreenStatuses.Dto
{
    [AutoMapTo(typeof(AppScreenStatus))]
    public class CreateAppScreenStatusDto
    {
        public int ApplicationId { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public string ScreenStatus { get; set; }
    }
}
