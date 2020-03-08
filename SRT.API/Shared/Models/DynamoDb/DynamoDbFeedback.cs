using System.Diagnostics.CodeAnalysis;

namespace AwsDotnetCsharp.Shared.Models
{
    [ExcludeFromCodeCoverage]
    public class DynamoDbFeedback : IResponse
    {
        public string MeetingId { get; set; }
        public string OverallRating { get; set; }
        public string AdditionalComments { get; set; }
    }
}