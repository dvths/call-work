namespace CallWork.Contracts.CallWork;

public record CreateCallWorkResponse(
    Guid Id,
    string CallWork,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Subjects,
    List<string> Technologies
);