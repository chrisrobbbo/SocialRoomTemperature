using System.Threading.Tasks;
using AwsDotnetCsharp.Shared.Models;

namespace AwsDotnetCsharp.Shared.Commands
{
    public interface ICommand<in TReq, TRes> where TReq : IRequest where TRes : IResponse
    {
        Task<TRes> Execute(TReq request);
    }
}