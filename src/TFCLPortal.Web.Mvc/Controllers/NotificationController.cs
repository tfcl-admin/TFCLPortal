using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFCLPortal.Controllers;
//using System.Web.Script.Serialization;

namespace TFCLPortal.Web.Controllers
{
    public class NotificationController : TFCLPortalControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        //public JsonResult PushNotification(string Message,string TagMsg)
        //{
        //    //try
        //    //{
        //    //    var applicationID = "AAAAImxr9yQ:APA91bH-odJVoQuBfVdcpF0DgXwzqZFBB_L9NcH4QGpuag5lTHZw2dTAbgzuF_yMDcMcBXGUavUgLURoI8e2fhU-VYJ4PlxEj_77COvzHwGTfGr6ra1mNbl8kcyXCNJJBlUkrUAF-tz2";

        //    //    var senderId = "147847903012";

        //    //    string deviceId = "euxqdp------ioIdL87abVL";

        //    //    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

        //    //    tRequest.Method = "post";

        //    //    tRequest.ContentType = "application/json";

        //    //    var data = new

        //    //    {

        //    //        to = deviceId,

        //    //        notification = new

        //    //        {

        //    //            body = Message,

        //    //            title = TagMsg,

        //    //            icon = "myicon"

        //    //        }
        //    //    };
                 
        //    //    var serializer = new JavaScriptSerializer();

        //    //    var json = serializer.Serialize(data);

        //    //    Byte[] byteArray = Encoding.UTF8.GetBytes(json);

        //    //    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

        //    //    tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

        //    //    tRequest.ContentLength = byteArray.Length;


        //    //    using (Stream dataStream = tRequest.GetRequestStream())
        //    //    {

        //    //        dataStream.Write(byteArray, 0, byteArray.Length);


        //    //        using (WebResponse tResponse = tRequest.GetResponse())
        //    //        {

        //    //            using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //    //            {

        //    //                using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //    //                {

        //    //                    String sResponseFromServer = tReader.ReadToEnd();

        //    //                    string str = sResponseFromServer;

        //    //                    return Json(str);
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    //catch (Exception ex)
        //    //{

        //    //    string str = ex.Message;
        //    //    return Json(str);
        //    //}

            

        //}

    }
}
