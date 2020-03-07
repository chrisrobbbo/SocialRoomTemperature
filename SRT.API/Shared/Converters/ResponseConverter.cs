using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

namespace AwsDotnetCsharp.Shared.Converters
{
    public class ResponseConverter
    {
        public APIGatewayProxyResponse Convert(APIGatewayProxyRequest request)
        {
            var proxyResponse = new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = JsonConvert.SerializeObject(request.Body)
            };

            return proxyResponse;
        }
    }
}