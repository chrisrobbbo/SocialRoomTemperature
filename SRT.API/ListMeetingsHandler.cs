using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AwsDotnetCsharp.Shared.Commands;
using AwsDotnetCsharp.Shared.Models;
using Newtonsoft.Json;

namespace AwsDotnetCsharp
{
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMember.Global
    public class ListMeetingsHandler
    {
        private readonly ICommand<ListTableItemsRequest, ListMeetingsResponse> _listMeetingsCommand;
        
        private const string MeetingTableName = "socialroomtemperature-meeting";

        public ListMeetingsHandler()
        {
            var amazonDynamoDbClient = new AmazonDynamoDBClient();
            _listMeetingsCommand = new ListMeetingsItemsCommand(new DynamoDBContext(amazonDynamoDbClient));
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public async Task<APIGatewayProxyResponse> EntryMethod()
        {
            try
            {
                var dynamoDbResponse = await _listMeetingsCommand.Execute(new ListTableItemsRequest { TableName = MeetingTableName});
                
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