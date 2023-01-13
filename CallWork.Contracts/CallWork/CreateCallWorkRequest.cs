namespace CallWork.Contracts.CallWork;

public record CreateCallWorkRequest(
    string CallWork,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Subjects,
    List<string> Technologies
);