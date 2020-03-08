using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Commands
{
    public class ListMeetingsItemsCommand : ICommand<ListTableItemsRequest, ListMeetingsResponse>
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public ListMeetingsItemsCommand(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<ListMeetingsResponse> Execute(ListTableItemsRequest request)
        {
            var operationConfig = new DynamoDBOperationConfig
            {
                OverrideTableName = request.TableName
            };

            var dynamoResponse = await _dynamoDbContext.ScanAsync<DynamoDbMeeting>(new List<ScanCondition>(), operationConfig).GetRemainingAsync();
            
            /*var dynamoResponse = await _dynamoDbContext.
                QueryAsync<DynamoDbMeeting>(operationConfig).GetRemainingAsync();*/

            return MapDynamoResponse(dynamoResponse);
        }

        private static ListMeetingsResponse MapDynamoResponse(IEnumerable<DynamoDbMeeting> meetings)
        {
            var meetingsList = meetings.Select(meeting => new Meeting
            {
                MeetingId = Guid.Parse(meeting.MeetingId),
                MeetingName = meeting.MeetingName,
                SpeakerName = meeting.SpeakerName
            });
            
            return new ListMeetingsResponse { Meetings = meetingsList };
        }
    }
}