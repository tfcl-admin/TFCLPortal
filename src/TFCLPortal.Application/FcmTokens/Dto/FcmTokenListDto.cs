using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FcmTokens.Dto
{
    [AutoMapFrom(typeof(FcmToken))]
    public class FcmTokenListDto : EntityDto
    {
        public int FK_UserId { get; set; }
        public string Token { get; set; }
    }
}
