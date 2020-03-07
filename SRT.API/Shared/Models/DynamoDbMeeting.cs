using System.Diagnostics.CodeAnalysis;

namespace AwsDotnetCsharp.Shared.Models
{
    [ExcludeFromCodeCoverage]
    public class DynamoDbMeeting
    {
        public string MeetingId { get; set; }
        public string MeetingName { get; set; }
        public string SpeakerName { get; set; }
    }
}