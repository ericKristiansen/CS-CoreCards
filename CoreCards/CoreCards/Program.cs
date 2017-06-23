using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace CoreCards
{
    public class Program
    {
        /// <summary>
        /// Provide a point of entry for the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
