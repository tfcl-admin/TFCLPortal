using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TFCLPortal.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var webHost = new WebHostBuilder()
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var env = hostingContext.HostingEnvironment;
                 config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                           optional: true, reloadOnChange: true);
                 config.AddEnvironmentVariables();
             })
             .ConfigureLogging((hostingContext, logging) =>
             {
                  // Requires `using Microsoft.Extensions.Logging;`
                  logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 logging.AddConsole();
                 logging.AddDebug();
                 logging.AddEventSourceLogger();
             })
             .UseStartup<Startup>()
             .Build();

            return webHost;
            //return WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>()
            //    .Build();
        }
    }
}
