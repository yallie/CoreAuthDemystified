using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DemystifyTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(factory =>
                {
                    factory.AddConsole();
                    factory.AddFilter("Console", level => level >= LogLevel.Information);
                })
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5000);
                })
                ////.UseIISIntegration()
                .Build();

            host.Run();
        }
    }
}
