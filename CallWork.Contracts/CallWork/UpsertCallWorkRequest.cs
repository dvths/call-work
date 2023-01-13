namespace CallWork.Contracts.CallWork;

public record UpsertCallWorkRequest(
    string CallWork,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Subjects,
    List<string> Technologies
);