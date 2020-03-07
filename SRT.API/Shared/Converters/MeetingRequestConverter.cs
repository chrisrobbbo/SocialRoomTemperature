using System;
using Amazon.Lambda.APIGatewayEvents;
using AwsDotnetCsharp.Shared.Models;
using Newtonsoft.Json;

namespace AwsDotnetCsharp.Shared.Converters
{
    public class MeetingRequestConverter : IMeetingRequestConverter
    {
        public Meeting ConvertRequest(APIGatewayProxyRequest request)
        {
            var meeting = JsonConvert.DeserializeObject<Meeting>(request.Body);
            meeting.MeetingId = new Guid();

            return meeting;
        }
    }
}