using System;

namespace AwsDotnetCsharp.Shared.Models
{
    public class Meeting
    {
        public Guid MeetingId { get; set; }
        public string MeetingName { get; set; }
        public string SpeakerName { get; set; }
    }
}