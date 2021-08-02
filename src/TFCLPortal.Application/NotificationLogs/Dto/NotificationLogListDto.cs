using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.NotificationLogs.Dto
{
    [AutoMapFrom(typeof(NotificationLog))]
    public class NotificationLogListDto : FullAuditedEntityDto
    {
        public int Reciever_UserId { get; set; }
        public string Reciever_Token { get; set; }
        public string title { get; set; }
        public bool isRead { get; set; }
        public string Body { get; set; }
    }
}
