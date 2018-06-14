using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LMSAPI.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

        }

        /// <summary>
        /// BuildWebHost
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {

            // NOTE: IIS must have 'Load User Profile' = TRUE in order for hostingContext.HostingEnvironment to equal ASPNETCORE_ENVIRONMENT environment variable
            return new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                        if (args != null)
                        {
                            config.AddCommandLine(args);
                        }
                    })
                    .UseStartup<Startup>()
                    .UseIISIntegration()
                    .Build();


        }

    }
}
