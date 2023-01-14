using CallWork.Api.Models;

using ErrorOr;

namespace CallWork.Api.Services.CallWork;

public interface ICallWorkService {
    ErrorOr<Created>CreateNewCallWork(CallWorkModel callWork);
    ErrorOr<CallWorkModel>GetCallById(Guid id);
    ErrorOr<UpsertedCallWork>UpsertCallWork(CallWorkModel callWork);
    ErrorOr<Deleted>DeleteCall(Guid id);
}