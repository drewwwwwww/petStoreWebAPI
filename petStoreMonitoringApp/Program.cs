using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using petStoreMonitoringApp.Services;

namespace petStoreMonitoringApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            BuildDatabase(host); //create the database
            await SeedDataAsync(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void BuildDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;


                var _context = services.GetService<petStoreMonitoringAppContext>();
                var _env = services.GetService<IWebHostEnvironment>();
                _context.Database.EnsureCreated();
            }
        }

        //Seeds roles into the database
        public static async Task SeedDataAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var initializer = services.GetRequiredService<Initializer>();
                await initializer.SeedRolesAsync();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError($"An error occured while seeding the database: {ex.Message}");
            }
        }
    }
}