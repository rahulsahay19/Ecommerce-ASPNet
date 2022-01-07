using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Common.Logging
{
   public static class SeriLogger
   {
       public static Action<HostBuilderContext, LoggerConfiguration> configure =>
           (context, configuration) =>
           {
               //This will read elastic config from diff microservices
               var elasticUri = context.Configuration.GetValue<string>("ElasticConfiguration:Uri");
               configuration
                   .Enrich.FromLogContext()
                   .Enrich.WithMachineName()
                   .WriteTo.Debug()
                   .WriteTo.Console()
                   .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                   {
                       IndexFormat = $"AppLogs-{context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                       AutoRegisterTemplate = true,
                       NumberOfShards = 2,
                       NumberOfReplicas = 1
                   })
                   //This will create separate index kibana
                   .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                   .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                   //Means read from appsettings Elastic configuration
                   .ReadFrom.Configuration(context.Configuration);

           };
   }
}
