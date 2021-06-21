using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TFCLPortal.Authorization
{
    public class TFCLPortalAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_SDE, L("SDE"));
            context.CreatePermission(PermissionNames.Pages_VO, L("VO"));
            context.CreatePermission(PermissionNames.Pages_BM, L("BM"));
            context.CreatePermission(PermissionNames.Pages_BCC, L("BCC"));
            context.CreatePermission(PermissionNames.Pages_BA, L("BA"));
            context.CreatePermission(PermissionNames.Pages_MCRC, L("MCRC"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TFCLPortalConsts.LocalizationSourceName);
        }
    }
}
