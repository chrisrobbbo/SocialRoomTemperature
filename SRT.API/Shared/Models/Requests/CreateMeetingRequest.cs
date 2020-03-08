using System;
using System.Diagnostics.CodeAnalysis;

namespace AwsDotnetCsharp.Shared.Models
{
    [ExcludeFromCodeCoverage]
    public class CreateMeetingRequest : IRequest
    {
        public Guid MeetingId { get; set; }
        public string MeetingName { get; set; }
        public string SpeakerName { get; set; }
    }
}