using CallWork.Api.Models;
using CallWork.Api.ServiceErrors;

using ErrorOr;

namespace CallWork.Api.Services.CallWork;

public class CallWorkService : ICallWorkService
{
    private static readonly Dictionary<Guid, CallWorkModel> _callwork = new();
    public ErrorOr<Created>CreateNewCallWork(CallWorkModel callwork)
    {
        _callwork.Add(callwork.Id, callwork);

        return Result.Created;
    }

    public ErrorOr<CallWorkModel> GetCallById(Guid id)
    {
        return _callwork.TryGetValue(id, out var callWork)
            ? (ErrorOr<CallWorkModel>)callWork
            : (ErrorOr<CallWorkModel>)Errors.CallWork.NotFound;
    }

    public ErrorOr<UpsertedCallWork>UpsertCallWork(CallWorkModel callWork)
    {
        var isNewlyCreated = !_callwork.ContainsKey(callWork.Id);

        _callwork[callWork.Id] = callWork;

        return new UpsertedCallWork(isNewlyCreated);
    }

    public ErrorOr<Deleted>DeleteCall(Guid id)
    {
        _callwork.Remove(id);

        return Result.Deleted;
    }
}
