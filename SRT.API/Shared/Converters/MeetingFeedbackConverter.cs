using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Models;
using Newtonsoft.Json;

namespace AwsDotnetCsharp.Shared.Converters
{
    public class MeetingFeedbackConverter : IConverter<CreateMeetingFeedbackRequest>
    {
        public CreateMeetingFeedbackRequest ConvertRequest(APIGatewayProxyRequest request)
        {
            var meetingFeedback = JsonConvert.DeserializeObject<CreateMeetingFeedbackRequest>(request.Body);
            
            return meetingFeedback;
        }
    }
}