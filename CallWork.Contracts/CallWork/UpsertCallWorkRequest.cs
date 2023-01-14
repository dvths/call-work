namespace CallWork.Contracts.CallWork;

public record UpsertCallWorkRequest(
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Subjects,
    List<string> Technologies
);