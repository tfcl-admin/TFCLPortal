using Abp.Domain.Repositories;
using Abp.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.NotificationLogs.Dto;
using TFCLPortal.FcmTokens;

namespace TFCLPortal.NotificationLogs
{

    public class NotificationLogAppService : TFCLPortalAppServiceBase, INotificationLogAppService
    {
        private readonly IRepository<NotificationLog> _NotificationLogRepository;
        private readonly IFcmTokenAppService _fcmTokenAppService;
        private string NotificationLog = "Notification Log";

        public NotificationLogAppService(IRepository<NotificationLog> NotificationLogRepository, IFcmTokenAppService fcmTokenAppService)
        {
            _NotificationLogRepository = NotificationLogRepository;
            _fcmTokenAppService = fcmTokenAppService;
        }



        public async Task<string> SendNotification(int userId, string title, string body)
        {
            try
            {

                var getToken = _fcmTokenAppService.getFcmTokenByUserId(userId);
                string to = "";
                if (getToken != null)
                {
                    to = getToken.Result;
                }
                else
                {
                    to = "";
                }

                if (to != "")
                {
                    // Get the server key from FCM console
                    var serverKey = string.Format("key={0}", "AAAAx-i87jc:APA91bEQRsLmzxqs80V4YZlYNb504Mp4skMroaI3WVqfAI9Kx8FJvP0U8WWXYV0HoCzu-eObLjQ5GPZBxNGBiMHd_LAhwz6w7btL4S05A0cJ-_P6bcKS1s3vYZyLqJvSpb0vLUciUlY4");

                    // Get the sender id from FCM console
                    var senderId = string.Format("id={0}", "858603187767");

                    string image = "https://taleemfinance.com/logo.png";

                    var data = new
                    {
                        to, // Recipient device token
                        notification = new { title, body, image }
                    };


                    // Using Newtonsoft.Json
                    var jsonBody = JsonConvert.SerializeObject(data);

                    using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
                    {
                        httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                        httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                        httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                        using (var httpClient = new HttpClient())
                        {
                            var result = await httpClient.SendAsync(httpRequest);

                            if (result.IsSuccessStatusCode)
                            {
                                CreateNotificationLogDto notification = new CreateNotificationLogDto();
                                notification.Reciever_UserId = userId;
                                notification.Reciever_Token = to;
                                notification.title = title;
                                notification.Body = body;
                                await CreateNotificationLog(notification);

                                return "Success";
                            }
                            else
                            {
                                // Use result.StatusCode to handle failure
                                // Your custom error handler here
                                throw new UserFriendlyException($"Error sending notification. Status Code: {result.StatusCode}");
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException($"Exception thrown in Notify Service: {ex}");
            }

            return "Error";
        }



        public async Task CreateNotificationLog(CreateNotificationLogDto input)
        {
            try
            {

                var NotificationLogVar = ObjectMapper.Map<NotificationLog>(input);
                await _NotificationLogRepository.InsertAsync(NotificationLogVar);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", NotificationLog));
            }
        }

        public List<NotificationLogListDto> GetNotificationLogList()
        {
            try
            {
                var NotificationLogVar = _NotificationLogRepository.GetAllList();

                return ObjectMapper.Map<List<NotificationLogListDto>>(NotificationLogVar);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", NotificationLog));
            }
        }

        public List<NotificationLogListDto> GetNotificationLogListByUserId(int UserId)
        {
            try
            {
                var NotificationLogVar = _NotificationLogRepository.GetAllList(x => x.Reciever_UserId == UserId);
                List<NotificationLogListDto> NotifList = new List<NotificationLogListDto>();
                if (NotificationLogVar != null)
                {
                    int maxValue = NotificationLogVar.Count;
                    //int maxValue = 0;
                    //if (NotificationLogVar.Count < 20)
                    //{
                    //    maxValue = NotificationLogVar.Count;
                    //}
                    //else
                    //{
                    //    maxValue = 20;
                    //}

                    for (int i = 0; i < maxValue; i++)
                    {
                        var tempnotification = ObjectMapper.Map<NotificationLogListDto>(NotificationLogVar[i]);
                        NotifList.Add(tempnotification);
                    }

                }
                return NotifList;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", NotificationLog));
            }
        }

        public bool MarkRead(int UserId)
        {
            try
            {
                var NotificationLogVar = _NotificationLogRepository.GetAllList(x=>x.Reciever_UserId==UserId&&x.isRead==false);

                foreach(var item in NotificationLogVar)
                {
                    item.isRead = true;
                    _NotificationLogRepository.Update(item);
                    CurrentUnitOfWork.SaveChanges();
                }
              
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
