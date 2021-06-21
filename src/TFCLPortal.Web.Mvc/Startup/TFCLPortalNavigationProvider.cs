using Abp.Application.Navigation;
using Abp.Localization;
using TFCLPortal.Authorization;

namespace TFCLPortal.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class TFCLPortalNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users/Index",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_BM
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles/Index",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_BM
                    )
                );
                
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TFCLPortalConsts.LocalizationSourceName);
        }
    }
}
