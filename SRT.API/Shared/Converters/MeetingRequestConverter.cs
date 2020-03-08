using System;
using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Models;
using Newtonsoft.Json;

namespace AwsDotnetCsharp.Shared.Converters
{
    public class MeetingRequestConverter : IConverter<CreateMeetingRequest>
    {
        public CreateMeetingRequest ConvertRequest(APIGatewayProxyRequest request)
        {
            var meeting = JsonConvert.DeserializeObject<CreateMeetingRequest>(request.Body);
            meeting.MeetingId = Guid.NewGuid();
            

            return meeting;
        }
    }
}