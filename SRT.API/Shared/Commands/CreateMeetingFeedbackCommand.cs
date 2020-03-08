using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Commands
{
    public class CreateMeetingFeedbackCommand : ICommand<CreateMeetingFeedbackRequest, DynamoDbFeedback>
    {
        private readonly IDynamoDBContext _dynamoDbContext;
        
        private const string MeetingTableName = "socialroomtemperature-meeting-feedback";

        public CreateMeetingFeedbackCommand(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }
        
        public async Task<DynamoDbFeedback> Execute(CreateMeetingFeedbackRequest request)
        {
            var dynamoDbMeeting = new DynamoDbFeedback
            {
                MeetingId = request.MeetingId.ToString(),
                OverallRating = request.OverallRating.ToString(),
                AdditionalComments = request.AdditionalComments
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