using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TFCLPortal.Authorization;

namespace TFCLPortal
{
    [DependsOn(
        typeof(TFCLPortalCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TFCLPortalApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TFCLPortalAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TFCLPortalApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
