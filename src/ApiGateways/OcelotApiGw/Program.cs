using Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((env, config) =>
                {
                    config.AddJsonFile($"ocelot.{env.HostingEnvironment.EnvironmentName}.json", true, true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog(SeriLogger.configure);

        // This is already handled in elastic search
        //.ConfigureLogging((ctx, builder) =>
        //{
        //    builder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
        //    builder.AddConsole();
        //    builder.AddDebug();
        //});
    }
}
