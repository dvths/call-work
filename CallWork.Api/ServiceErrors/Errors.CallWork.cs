using ErrorOr;

namespace CallWork.Api.ServiceErrors;

public static class Errors
{
    public static class CallWork
    {
        public static Error InvalidTitle => Error.Validation(
            code: "CallWork.InvalidTitle",
            description: $"Call title must be at least {Models.CallWorkModel.MinTitleLength}" +
                         $" characters long and at most {Models.CallWorkModel.MaxTitleLength} characters long");

        public static Error InvalidDescription => Error.Validation(
            code: "CallWork.InvalidDescription",
            description: $"Call description must be at least {Models.CallWorkModel.MinTitleLength}" +
                         $" characters long and at most {Models.CallWorkModel.MaxTitleLength} characters long");

        public static Error NotFound => Error.NotFound(
            code: "CallWork.NotFound",
            description: "Call not found.");
    }
}