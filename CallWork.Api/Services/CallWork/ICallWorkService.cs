using CallWork.Api.Models;

using ErrorOr;

namespace CallWork.Api.Services.CallWork;

public interface ICallWorkService {
    void CreateNewCallWork(CallWorkModel callwork);
    ErrorOr<CallWorkModel> GetCallById(Guid id);
    void UpsertCallWork(CallWorkModel callwork);
    void DeleteCall(Guid id);
}