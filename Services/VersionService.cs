using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcServiceNetCore
{
    public class VersionService : Version.VersionBase
    {
        private int _receivedRequestsCount = 0;
        private readonly ILogger<VersionService> _logger;
        public VersionService(ILogger<VersionService> logger)
        {
            _logger = logger;
        }

        public override Task<VersionResponse> GetVersion(VersionRequest request, ServerCallContext context) {
            _receivedRequestsCount++;

            _logger.LogInformation("Processing request...");
            _logger.LogInformation($"Client Name: {request.Client}");

            if (_receivedRequestsCount > 100)
            {
                _logger.LogInformation("Received more than 100 requests...");
                _receivedRequestsCount = 0;
            }

            return Task.FromResult(new VersionResponse { Version = "1.0.0", Person = new Person { Age = 23, Name = "Ruan" } });
        }
    }
}
