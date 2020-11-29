using Grpc.Core;
using GrpcGreeterClient;
using System;
using System.Threading.Tasks;

namespace GrpcServiceNetCore.Services
{
    public class ReadkeyService : Readkey.ReadkeyBase
    {
        public override Task<ReadkeyResponse> GetKeyResponse(ReadkeyRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Key read: {request.Key}");
            return Task.FromResult(new ReadkeyResponse { Received = true });
        }
    }
}
