using FirstProjectEmptyApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.VisualStudio.Setup.Configuration;

namespace FirstProjectEmptyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            if(args.Length==1 && args[0].ToLower() == "/seed") RunSeeding(host);
            else host.Run();
        }

        private static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(SetupConfiguration).UseStartup<Startup>().Build();
        

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope()) 
            {
                var seeder= scope.ServiceProvider.GetService<ArtPlaygroundSeeder>();
                seeder.Seed();
            }
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureAppConfiguration(AddConfiguration)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        //private static void AddConfiguration(HostBuilderContext ctx, IConfigurationBuilder bldr)
        //{

        //    bldr.Sources.Clear();
        //    bldr.SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("config.json")
        //        .AddEnvironmentVariables();
        //}

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder bldr)
        {

            bldr.Sources.Clear();
            bldr.AddJsonFile("config.json",false,true)
                .AddEnvironmentVariables();
        }
    }
}
