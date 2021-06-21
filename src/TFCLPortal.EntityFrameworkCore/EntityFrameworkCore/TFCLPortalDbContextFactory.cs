using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TFCLPortal.Configuration;
using TFCLPortal.Web;

namespace TFCLPortal.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TFCLPortalDbContextFactory : IDesignTimeDbContextFactory<TFCLPortalDbContext>
    {
        public TFCLPortalDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TFCLPortalDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TFCLPortalDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TFCLPortalConsts.ConnectionStringName));

            return new TFCLPortalDbContext(builder.Options);
        }
    }
}
