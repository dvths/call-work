namespace CallWork.Api.Models;

public class CallWorkModel
{
    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Subjects { get; }
    public List<string> Technologies { get; }

    public CallWorkModel(Guid id, string title, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, List<string> subjects, List<string> technologies)
    {
        Id = id;
        Title = title;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Subjects = subjects;
        Technologies = technologies;
    }
}