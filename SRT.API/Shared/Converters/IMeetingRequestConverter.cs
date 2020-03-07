using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Converters
{
    public interface IMeetingRequestConverter
    {
        Meeting ConvertRequest(APIGatewayProxyRequest request);
    }
}