using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Controllers;

namespace TFCLPortal.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TFCLPortalControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
