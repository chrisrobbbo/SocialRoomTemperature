using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AwsDotnetCsharp.Shared.Models
{
    [ExcludeFromCodeCoverage]
    public class ListMeetingsResponse : IResponse
    {
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}