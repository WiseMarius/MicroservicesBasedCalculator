using Generated;
using Grpc.Core;
using System.Threading.Tasks;

namespace Server
{
    internal class DivisionOperationService : Generated.DivisionOperationService.DivisionOperationServiceBase
    {
        public override Task<OperationResponse> Calculate(DivisionRequest request, ServerCallContext context)
        {
            var result = request.FirstOperand / request.SecondOperand;

            System.Console.WriteLine("Division request -> {0} / {1} = {2}", request.FirstOperand, request.SecondOperand, request.FirstOperand / request.SecondOperand);

            return Task.FromResult(new OperationResponse() { Result = result });
        }
    }
}
