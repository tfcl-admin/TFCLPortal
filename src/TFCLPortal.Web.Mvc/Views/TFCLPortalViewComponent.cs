using Abp.AspNetCore.Mvc.ViewComponents;

namespace TFCLPortal.Web.Views
{
    public abstract class TFCLPortalViewComponent : AbpViewComponent
    {
        protected TFCLPortalViewComponent()
        {
            LocalizationSourceName = TFCLPortalConsts.LocalizationSourceName;
        }
    }
}
