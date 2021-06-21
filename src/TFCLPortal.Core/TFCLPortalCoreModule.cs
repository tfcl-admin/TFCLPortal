using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using TFCLPortal.Authorization.Roles;
using TFCLPortal.Authorization.Users;
using TFCLPortal.Configuration;
using TFCLPortal.Localization;
using TFCLPortal.MultiTenancy;
using TFCLPortal.Timing;

namespace TFCLPortal
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class TFCLPortalCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            TFCLPortalLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            //Configuration.MultiTenancy.IsEnabled = TFCLPortalConsts.MultiTenancyEnabled;
            Configuration.MultiTenancy.IsEnabled = false;
            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TFCLPortalCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
