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

            Console.WriteLine("Chose your operation:\n 1. Sum\n 2. Subtraction\n 3. Multiplication\n 4. Division");

            do
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            var client = new Generated.SumOperationService.SumOperationServiceClient(channel);

                            var response = client.Calculate(new Generated.SumRequest
                            {
                                FirstOperand = 16,
                                SecondOperand = 16,
                            });

                            Console.WriteLine("\nClient received response: {0}", response.Result);

                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            var client = new Generated.SubtractionOperationService.SubtractionOperationServiceClient(channel);

                            var response = client.Calculate(new Generated.SubtractionRequest
                            {
                                FirstOperand = 16,
                                SecondOperand = 16,
                            });

                            Console.WriteLine("\nClient received response: {0}", response.Result);

                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            var client = new Generated.MultiplicationOperationService.MultiplicationOperationServiceClient(channel);

                            var response = client.Calculate(new Generated.MultiplicationRequest
                            {
                                FirstOperand = 16,
                                SecondOperand = 16,
                            });

                            Console.WriteLine("\nClient received response: {0}", response.Result);

                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            var client = new Generated.DivisionOperationService.DivisionOperationServiceClient(channel);

                            var response = client.Calculate(new Generated.DivisionRequest
                            {
                                FirstOperand = 16,
                                SecondOperand = 16,
                            });

                            Console.WriteLine("\nClient received response: {0}", response.Result);

                            break;
                        }
                }
            } while (true);


            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
