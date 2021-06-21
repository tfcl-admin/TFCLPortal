using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TFCLPortal.Controllers
{
    public abstract class TFCLPortalControllerBase: AbpController
    {
        protected TFCLPortalControllerBase()
        {
            LocalizationSourceName = TFCLPortalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
