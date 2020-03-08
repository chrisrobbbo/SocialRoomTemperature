using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Converters
{
    public interface IConverter<out TRes> where TRes : IRequest
    {
        TRes ConvertRequest(APIGatewayProxyRequest request);
    }
}