using CallWork.Api.Models;

namespace CallWork.Api.Services.CallWork;

public interface ICallWorkService {
    void CreateNewCallWork(CallWorkModel callwork);
    CallWorkModel GetCallById(Guid id);
    void UpsertCallWork(CallWorkModel callwork);
    void DeleteCall(Guid id);
}