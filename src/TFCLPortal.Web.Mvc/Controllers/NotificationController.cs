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


    }
}
