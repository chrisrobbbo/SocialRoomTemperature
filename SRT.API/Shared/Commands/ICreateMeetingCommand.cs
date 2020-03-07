using System.Threading.Tasks;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Commands
{
    public interface ICreateMeetingCommand
    {
        Task<DynamoDbMeeting> Execute(Meeting meetingRequest);
    }
}