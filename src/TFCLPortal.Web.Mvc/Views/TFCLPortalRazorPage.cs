using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace TFCLPortal.Web.Views
{
    public abstract class TFCLPortalRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TFCLPortalRazorPage()
        {
            LocalizationSourceName = TFCLPortalConsts.LocalizationSourceName;
        }
    }
}
