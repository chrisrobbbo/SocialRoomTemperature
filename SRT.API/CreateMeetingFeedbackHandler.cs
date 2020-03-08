using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Commands;
using AwsDotnetCsharp.Shared.Converters;
using AwsDotnetCsharp.Shared.Models;
using Newtonsoft.Json;

namespace AwsDotnetCsharp
{
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMember.Global
    public class CreateMeetingFeedbackHandler
    {
        private readonly IConverter<CreateMeetingFeedbackRequest> _meetingRequestConverter;
        private readonly ICommand<CreateMeetingFeedbackRequest, DynamoDbFeedback> _createMeetingCommand;

        public CreateMeetingFeedbackHandler()
        {
            var amazonDynamoDbClient = new AmazonDynamoDBClient();
            _meetingRequestConverter = new MeetingFeedbackConverter();
            _createMeetingCommand = new CreateMeetingFeedbackCommand(new DynamoDBContext(amazonDynamoDbClient));
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
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