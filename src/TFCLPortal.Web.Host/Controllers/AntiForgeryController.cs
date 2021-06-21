using Microsoft.AspNetCore.Antiforgery;
using TFCLPortal.Controllers;

namespace TFCLPortal.Web.Host.Controllers
{
    public class AntiForgeryController : TFCLPortalControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
