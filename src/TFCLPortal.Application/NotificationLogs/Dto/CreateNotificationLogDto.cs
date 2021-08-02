using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.NotificationLogs.Dto
{
    [AutoMapTo(typeof(NotificationLog))]
    public class CreateNotificationLogDto
    {
        public int Reciever_UserId { get; set; }
        public string Reciever_Token { get; set; }
        public string title { get; set; }
        public string Body { get; set; }
        public bool isRead { get; set; }
    }
}
