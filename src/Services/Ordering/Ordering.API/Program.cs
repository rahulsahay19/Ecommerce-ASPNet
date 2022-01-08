using Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ordering.API.Extensions;
using Ordering.Infrastructure.Persistence;
using Serilog;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Explicit way
            //var host = CreateHostBuilder(args).Build();
            //host.MigrateDatabase<OrderContext>((context, services) =>
            //{
            //    var logger = services.GetService<ILogger<OrderContextSeed>>();
            //    //Seeding Db
            //    OrderContextSeed.SeedAsync(context, logger).Wait();
            //});
            //host.Run();
           
            //Fluent way
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<OrderContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<OrderContextSeed>>();
                    OrderContextSeed.SeedAsync(context, logger)
                        .Wait();
                })
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(SeriLogger.configure)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
