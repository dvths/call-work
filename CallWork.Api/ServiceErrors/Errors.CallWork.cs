using ErrorOr;

namespace CallWork.Api.ServiceErrors;

public static class Errors
{
    public static class CallWork
    {
        public static Error NotFound => Error.NotFound(
            code: "CallWork.NotFound",
            description: "Call not found.");
    }
}