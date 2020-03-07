using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Commands
{
    public class CreateMeetingCommand : ICreateMeetingCommand
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        private const string MeetingTableName = "socialroomtemperature-meeting";

        public CreateMeetingCommand(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<DynamoDbMeeting> Execute(Meeting meetingRequest)
        {
            var dynamoDbMeeting = new DynamoDbMeeting
            {
                MeetingId = meetingRequest.MeetingId.ToString(),
                MeetingName = meetingRequest.MeetingName,
                SpeakerName = meetingRequest.SpeakerName
            };
            
            var operationConfig = new DynamoDBOperationConfig
            {
                OverrideTableName = MeetingTableName
            };

            await _dynamoDbContext.SaveAsync(dynamoDbMeeting, operationConfig);

            return dynamoDbMeeting;
        }
    }
}