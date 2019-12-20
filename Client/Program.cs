using Grpc.Core;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Host = "localhost";
            const int Port = 16842;

            var channel = new Channel($"{Host}:{Port}", ChannelCredentials.Insecure);
            var client = new Generated.SumOperationService.SumOperationServiceClient(channel);

            var response = client.Calculate(new Generated.SumRequest
            {
                FirstOperand = 4,
                SecondOperand = 7,
            });

            Console.WriteLine("Client received response: {0}", response.Result);

            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
