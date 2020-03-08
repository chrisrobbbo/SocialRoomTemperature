using System;
using System.Diagnostics.CodeAnalysis;

namespace AwsDotnetCsharp.Shared.Models
{
    [ExcludeFromCodeCoverage]
    public class CreateMeetingFeedbackRequest : IRequest
    {
        public Guid MeetingId { get; set; }
        public Rating OverallRating { get; set; }
        public string AdditionalComments { get; set; }
    }
}