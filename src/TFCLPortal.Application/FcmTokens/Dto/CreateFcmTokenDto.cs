    
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.FcmTokens.Dto
{
    [AutoMapTo(typeof(FcmToken))]
    public class CreateFcmTokenDto
    {
        public int FK_UserId { get; set; }
        public string Token { get; set; }
    }
}
