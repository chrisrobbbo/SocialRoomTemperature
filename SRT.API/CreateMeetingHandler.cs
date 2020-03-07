using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Commands;
using AwsDotnetCsharp.Shared.Converters;
using Newtonsoft.Json;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsDotnetCsharp
{
    // ReSharper disable once UnusedType.Global
    public class CreateMeetingHandler
    {
        private readonly IMeetingRequestConverter _meetingRequestConverter;
        private readonly ICreateMeetingCommand _createMeetingCommand;

        public CreateMeetingHandler()
        {
            var amazonDynamoDbClient = new AmazonDynamoDBClient();
            _meetingRequestConverter = new MeetingRequestConverter();
            _createMeetingCommand = new CreateMeetingCommand(new DynamoDBContext(amazonDynamoDbClient));
        }

        public async Task<APIGatewayProxyResponse> EntryMethod(APIGatewayProxyRequest request)
        {
            try
            {
                var meetingRequest = _meetingRequestConverter.ConvertRequest(request);

                var dynamoDbResponse = await _createMeetingCommand.Execute(meetingRequest);
                
                var proxyResponse = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = JsonConvert.SerializeObject(dynamoDbResponse)
                };

                return proxyResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
