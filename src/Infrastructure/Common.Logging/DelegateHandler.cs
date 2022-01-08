using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Common.Logging
{
   public class DelegateHandler : DelegatingHandler
    {
       private readonly ILogger<DelegateHandler> logger;

       public DelegateHandler(ILogger<DelegateHandler> logger)
       {
           this.logger = logger;
       }

       protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
       {
           try
           {
               logger.LogInformation($"Sending request to {request.RequestUri}");

               var response = await base.SendAsync(request, cancellationToken);

               if (response.IsSuccessStatusCode)
               {
                   logger.LogInformation($"Received a success response from {response.RequestMessage.RequestUri}");
               }
               else
               {
                   logger.LogWarning($"Received a failuer status code {(int)response.StatusCode} from {response.RequestMessage.RequestUri}");
               }

               return response;
           }
           catch (HttpRequestException ex)
               when (ex.InnerException is SocketException se && se.SocketErrorCode == SocketError.ConnectionRefused)
           {
               var hostWithPort = request.RequestUri.IsDefaultPort
                   ? request.RequestUri.DnsSafeHost
                   : $"{request.RequestUri.DnsSafeHost}:{request.RequestUri.Port}";

               logger.LogCritical(ex, $"Unable to connect to {hostWithPort}. Please check the " +
                                      "configuration to ensure the correct URL for the service " +
                                      "has been configured.");
           }

           return new HttpResponseMessage(HttpStatusCode.BadGateway)
           {
               RequestMessage = request
           };
       }
   }
}