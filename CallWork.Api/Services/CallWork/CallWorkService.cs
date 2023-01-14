using CallWork.Api.Models;
using CallWork.Api.ServiceErrors;

using ErrorOr;

namespace CallWork.Api.Services.CallWork;

public class CallWorkService : ICallWorkService
{
    private static readonly Dictionary<Guid, CallWorkModel> _callwork = new();
    public void CreateNewCallWork(CallWorkModel callwork)
    {
        _callwork.Add(callwork.Id, callwork);
    }

    public ErrorOr<CallWorkModel> GetCallById(Guid id)
    {
        return _callwork.TryGetValue(id, out var callWork)
            ? (ErrorOr<CallWorkModel>)callWork
            : (ErrorOr<CallWorkModel>)Errors.CallWork.NotFound;
    }

    public void UpsertCallWork(CallWorkModel callWork)
    {
        _callwork[callWork.Id] = callWork;
    }

    public void DeleteCall(Guid id)
    {
        _callwork.Remove(id);
    }
}
