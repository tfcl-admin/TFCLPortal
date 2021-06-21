using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TFCLPortal.Configuration;
using Abp.Configuration.Startup;

namespace TFCLPortal.Web.Host.Startup
{
    [DependsOn(
       typeof(TFCLPortalWebCoreModule))]
    public class TFCLPortalWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TFCLPortalWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TFCLPortalWebHostModule).GetAssembly());
        }

        //public override void PreInitialize()
        //{
        //    Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;
        //}
    }
}
