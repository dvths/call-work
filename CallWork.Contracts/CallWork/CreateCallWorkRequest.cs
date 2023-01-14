namespace CallWork.Contracts.CallWork;

public record CreateCallWorkRequest(
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Subjects,
    List<string> Technologies
);