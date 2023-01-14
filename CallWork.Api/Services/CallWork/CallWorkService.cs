using CallWork.Api.Models;

namespace CallWork.Api.Services.CallWork;

public class CallWorkService : ICallWorkService
{
    private static readonly Dictionary<Guid, CallWorkModel> _callwork = new();
    public void CreateNewCallWork(CallWorkModel callwork)
    {
        _callwork.Add(callwork.Id, callwork);
    }

    public CallWorkModel GetCallById(Guid id)
    {
        return _callwork[id];
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
