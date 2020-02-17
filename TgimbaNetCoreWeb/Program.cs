using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TgimbaNetCoreWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // NOTE: This is not necessary if using environmental variables...leaving in for clarity
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                    // HACK: I cannot do environmental variables on my shared production environment, so if not 
                    //       development, force production app settings to load.
                    if (env.EnvironmentName != "Development")
                    {
                        config.AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
                    } 
                    else
                    {
                        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    }
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>()
                .Build();
    }
}
