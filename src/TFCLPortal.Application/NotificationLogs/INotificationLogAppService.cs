using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.NotificationLogs.Dto;

namespace TFCLPortal.NotificationLogs
{

    public interface INotificationLogAppService : IApplicationService
    {
        Task CreateNotificationLog(CreateNotificationLogDto input);
        List<NotificationLogListDto> GetNotificationLogList();
        Task<string> SendNotification(int userId, string title, string body);
        List<NotificationLogListDto> GetNotificationLogListByUserId(int UserId);

        bool MarkRead(int UserId);
    }
}
